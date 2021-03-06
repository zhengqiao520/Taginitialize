﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Entity;
using System.Data.SQLite;
using System.Data;
using MySql.Data.MySqlClient;
using Renci.SshNet;

namespace Infrastructure
{
    public class TagInfoDAL
    {

        public static readonly string SSHString= System.Configuration.ConfigurationManager.AppSettings["ssh"].ToString();
        #region sqlite 操作
        /// <summary>
        /// 根据条件获取标签信息
        /// </summary>
        /// <param name="rangeType"></param>
        /// <returns></returns>
        public static List<TagInfo> GetTagInfoListByRange(string rangeType=null,int tagType=0) {
            string range = rangeType == null ? DateTime.Now.ToString("yyyyMM") : rangeType;
            string sql = $"select * from TagInfo where tagType={tagType} order by createdate desc";
            return Utility.SQLiteInstance.ExecuteList<TagInfo>(CommandType.Text, sql, null);
        }
        /// <summary>
        /// 插入或修改标签isbn
        /// </summary>
        /// <param name="tagId">标签id</param>
        /// <param name="epc">epc</param>
        /// <param name="isbn"></param>
        /// <param name="cpuId"></param>
        /// <param name="tagType">标签类型0：高频，1超高频</param>
        /// <returns></returns>
        public static int InsertOrUpdateTagInfo(string tagId,string epc,string isbn,string cpuId,int tagType=0) {
            var param = new object[] { tagId, epc, isbn, cpuId, tagType };
            var res = Utility.SQLiteInstance.ExecuteScalarSp("usp_CheckInsertTag", param) ?? 0;
            return (int)res;
        }

        public static TagInfo SelectTagInfoByID(string tagID) {
            string sql = $"select * from TagInfo where tagID=@tagID";
            SQLiteParameter[] param = new SQLiteParameter[] {
                 new SQLiteParameter("@tagID",tagID)
            };
            var res=Utility.SQLiteInstance.ExecuteList<TagInfo>(CommandType.Text, sql, param);
            if (null != res && res.Count > 0) {
                return res[0];
            }
            return null;
        }
        public static int InsertTagInfo(TagInfo tagInfo)
        {
            using (SQLiteConnection con = new SQLiteConnection(Utility.SqliteConnectionString))
            {
                con.Open();
                using (SQLiteTransaction trans = con.BeginTransaction())
                {
                    try
                    {
                        string sql = "INSERT INTO TagInfo(TagID,EPC,ISBN,CpuID,TagType,CreateDate,Status) values(@TagID,@EPC,@ISBN,@CpuID,@TagType,@CreateDate,@Status)";
                        SQLiteParameter[] param = new SQLiteParameter[]
                        {
                            new SQLiteParameter("@TagID",tagInfo.TagID),
                            new SQLiteParameter("@EPC",tagInfo.EPC),
                            new SQLiteParameter("@ISBN",tagInfo.ISBN),
                            new SQLiteParameter("@CpuID",tagInfo.CpuID),
                            new SQLiteParameter("@TagType",tagInfo.TagType),
                            new SQLiteParameter("@CreateDate",tagInfo.CreateDate),
                            new SQLiteParameter("@Status",tagInfo.Status)
                        };
                        var res = Utility.SQLiteInstance.ExecuteNonQuery(trans, CommandType.Text, sql, param);
                        trans.Commit();
                        return 1;
                    }
                    catch (Exception ee)
                    {
                        trans.Rollback();
                        return 0;
                    }
                }
            }
        }

        public static bool UpdateTagInfo(string isbn,string tagID) {
            string sql = "update TagInfo set ISBN=@ISBN where TagID=@TagID";
            SQLiteParameter[] param = new SQLiteParameter[] {
                 new SQLiteParameter("@ISBN",isbn),
                 new SQLiteParameter("@TagID",tagID)
            };
            var res = Utility.SQLiteInstance.ExecuteNonQuery(CommandType.Text, sql, param);
            if (res > 0) {
                return true;
            }
            return false;
        }
        public static  bool DeleteTag(string tagID) {
            string sql = $"delete from TagInfo where TagID=@TagID";
            int res=Utility.SQLiteInstance.ExecuteNonQuery(CommandType.Text, sql, new System.Data.Common.DbParameter[] {
                new SQLiteParameter("@TagID",tagID)
            });
            return res > 0;
        }
        #endregion

        #region 同步mysql操作

        /// <summary>
        /// 获取服务器时间
        /// </summary>
        /// <returns></returns>
        public static DateTime GetMysqlSeverDateTime() {
           var datetime=Utility.MySqlInstance.ExecuteScalar(CommandType.Text, "SELECT NOW()", null);
            if (datetime != null) {
                return Convert.ToDateTime(datetime);
            }
            return DateTime.Now;
        }
        /// <summary>
        /// 获取图书实体信息
        /// </summary>
        /// <param name="rfid"></param>
        /// <returns></returns>
        public static BookEntity GetBookEntityByRFIDCode(string rfid) {
            string sql = "select * from book_entity where rfid_code=@rfid";
            var res = Utility.MySqlInstance.ExecuteList<BookEntity>(CommandType.Text, sql, new System.Data.Common.DbParameter[] {
                 new MySqlParameter("@rfid",rfid)
            });
            if (null != res && res.Count > 0)
            {
                return res[0];
            }
            return null;
        }
        /// <summary>
        /// 保存图书信息
        /// </summary>
        /// <param name="bookEntity"></param>
        /// <returns></returns>
        public static bool InsertBookEntity(BookEntity bookEntity)
        {
            bool result = false;
            string sql = "insert into book_entity(isbn_no,rfid_code,status,create_time)values(@isbn_no,@rfid_code,@status,@create_time)";
            using (MySqlConnection con = new MySqlConnection(Utility.MysqlDES3DecryptConnctionString))
            {
                con.Open();
                using (MySqlTransaction trans = con.BeginTransaction())
                {
                    var res = Utility.MySqlInstance.ExecuteNonQuery(trans,CommandType.Text, sql, new System.Data.Common.DbParameter[] {
                        new MySqlParameter("@isbn_no",bookEntity.isbnNo),
                        new MySqlParameter("@rfid_code",bookEntity.rfidCode),
                        new MySqlParameter("@status",bookEntity.status),
                        new MySqlParameter("@create_time",bookEntity.createTime)
                    });
                    result = res > 0;
                }
            }
            return result;
        }

        public static List<BookInfo> SelectBookInfoListBy(string isbn_no,string book_name="",bool isVagueQuery=false) {
            string where = isVagueQuery ? $"  like @isbn_no" : "=@isbn_no";
            string sql = $"select * from book_info where isbn_no{where}";
            List<MySqlParameter> param = new List<MySqlParameter>() {
                 new MySqlParameter("@isbn_no", isVagueQuery?"%" + isbn_no + "%":isbn_no)
            };
            if (!string.IsNullOrEmpty(book_name))
            {
                sql += $" and book_name=@book_name";
                param.Add(new MySqlParameter("@book_name", book_name));
            }
            var listBookInfo = Utility.MySqlInstance.ExecuteList<BookInfo>(CommandType.Text, sql,param.ToArray());
           
            if (null != listBookInfo && listBookInfo.Count > 0)
            {
                return listBookInfo;
            }
            return null;
        }
        public static List<BookInfo> SelectBookInfoList(string isbn="") {
            try
            { 
                string where = !string.IsNullOrEmpty(isbn) ? $" isbn_no='{isbn}'" : " 1=1";
                return Utility.MySqlInstance.ExecuteList<BookInfo>(CommandType.Text, $"select * from book_info where {where}", null);
            }
            catch {
                return null;
            }
        }
        

        public static bool InsertBookInfo(BookInfo bookinfo,out string msg, bool enableUpdate = false)
        {
             msg = string.Empty;
            List<BookInfo> listBookInfo=SelectBookInfoList(bookinfo.isbn_no.Trim());
            if (null != listBookInfo && listBookInfo.Count > 0) {
                if (enableUpdate) {
                    try
                    {
                        //string update_sql = $"update book_info set brief='{bookinfo.brief}' where isbn_no='{bookinfo.isbn_no}'";
                        string update_sql = $"delete from  book_info where   isbn_no='{bookinfo.isbn_no.Trim()}'";
                        Utility.MySqlInstance.ExecuteNonQuery(CommandType.Text, update_sql, null);
                    }
                    catch(Exception ee) {

                    }
                }
                //msg = "exists";
                //return false;
            }
            using (MySqlConnection con = new MySqlConnection(Utility.MysqlDES3DecryptConnctionString))
            {
                con.Open();
                using (MySqlTransaction trans = con.BeginTransaction())
                {
                    string sql = "insert into book_info(isbn_no, book_name, author, press, publication_date, category, price, readable, imgurl, brief, `describe`, create_time, modify_time)values(@isbn_no, @book_name, @author, @press, @publication_date, @category, @price, @readable, @imgurl, @brief, @describe, @create_time, @modify_time)";
                    MySqlParameter[] param = new MySqlParameter[] {
                        new MySqlParameter("@isbn_no",bookinfo.isbn_no),
                        new MySqlParameter("@book_name",bookinfo.book_name),
                        new MySqlParameter("@author",bookinfo.author),
                        new MySqlParameter("@press",bookinfo.press),
                        new MySqlParameter("@publication_date",bookinfo.publication_date),
                        new MySqlParameter("@category",bookinfo.category),
                        new MySqlParameter("@price",bookinfo.price),
                        new MySqlParameter("@readable",bookinfo.readable),
                        new MySqlParameter("@imgurl",bookinfo.imgurl),
                        new MySqlParameter("@brief",bookinfo.brief),
                        new MySqlParameter("@describe",bookinfo.describe),
                        new MySqlParameter("@create_time",bookinfo.create_time),
                        new MySqlParameter("@modify_time",bookinfo.modify_time)
                    };
                    int result=Utility.MySqlInstance.ExecuteNonQuery(trans, CommandType.Text, sql, param);
                    trans.Commit();
                    return result > 0;
                }
            }
        }

        /// <summary>
        /// 保存标签-isbn建档信息
        /// </summary>
        /// <param name="book_init_mapping"></param>
        /// <returns></returns>
        public static int InsertBookInitMapping(Book_init_mapping book_init_mapping)
        {
            using (MySqlConnection con = new MySqlConnection(Utility.MysqlDES3DecryptConnctionString))
            {
                con.Open();
                using (MySqlTransaction trans = con.BeginTransaction())
                {
                    try
                    {
                        string sql = "insert into book_init_mapping(tag_id,isbn,status,account,tag_type,create_time,isbn_type) values(@tag_id,@isbn,@status,@account,@tag_type,@create_time)";
                        MySqlParameter[] param = new MySqlParameter[]
                        {
                            new MySqlParameter("@tag_id",book_init_mapping.tag_id),
                            new MySqlParameter("@isbn",book_init_mapping.isbn),
                            new MySqlParameter("@status",book_init_mapping.status),
                            new MySqlParameter("@account",book_init_mapping.account),
                            new MySqlParameter("@tag_type",book_init_mapping.tag_type),
                            new MySqlParameter("@create_time",book_init_mapping.create_time),
                            new MySqlParameter("@create_time",book_init_mapping.isbn_type),
                        };
                        var res = Utility.MySqlInstance.ExecuteNonQuery(trans, CommandType.Text, sql, param);
                        trans.Commit();
                        return 1;
                    }
                    catch (Exception ee)
                    {
                        trans.Rollback();
                        return 0;
                    }
                }
            }
        }
        /// <summary>
        /// 根据标签查询标签建档信息
        /// </summary>
        /// <param name="tag_id"></param>
        /// <returns></returns>
        public static Book_init_mapping SelectBookInitMapping(string tag_id)
        {
            string sql = $"select * from book_init_mapping where tag_id=@tag_id";
            MySqlParameter[] param = new MySqlParameter[] {
                 new MySqlParameter("@tag_id",tag_id)
            };
            var res = Utility.MySqlInstance.ExecuteList<Book_init_mapping>(CommandType.Text, sql, param);
            if (null != res && res.Count > 0)
            {
                return res[0];
            }
            return null;
        }
        /// <summary>
        /// 获取标签图书相关信息列表
        /// </summary>
        /// <param name="tag_id"></param>
        /// <param name="isbn"></param>
        /// <param name="user_account"></param>
        /// <returns></returns>
        public static List<Book_init_mapping> SelectBookInitMappingListBy(string tag_id, string isbn="", string user_account="") {
            string sql = $"select * from book_init_mapping where tag_id=@tag_id";
            List<MySqlParameter> param = new List<MySqlParameter>() {
                 new MySqlParameter("@tag_id",tag_id)
            };
            if (!string.IsNullOrEmpty(isbn)) {
                sql += $" and isbn='{isbn}'";
                param.Add(new MySqlParameter("@isbn", isbn));
            }
            if (!string.IsNullOrEmpty(user_account)) {
                sql += $" and user_account='{user_account}'";
                param.Add(new MySqlParameter("@user_account", user_account));
            }
          return  Utility.MySqlInstance.ExecuteListText<Book_init_mapping>(sql,param.ToArray());
        }
        /// <summary>
        /// 查询当日标签建档信息
        /// </summary>
        /// <param name="rangeType"></param>
        /// <param name="tagType"></param>
        /// <returns></returns>
        public static List<Book_init_mapping> GetBookInitMapping(string rangeType = null, int tagType = 0)
        {
            string range = rangeType == null ? DateTime.Now.ToString("yyyyMM") : rangeType;
            string sql = $"select * from book_init_mapping where tag_type={tagType} and  to_days(create_time)=to_days(now()) order by create_time desc";
            return Utility.MySqlInstance.ExecuteList<Book_init_mapping>(CommandType.Text, sql, null);
        }

        public static List<Book_init_mappingExt> GetBookInitMappingExt(string rangeType = null, int tagType = 0) {
            string range = rangeType == null ? DateTime.Now.ToString("yyyyMM") : rangeType;
            string sql = $"select a.ID, a.tag_id, a.isbn, a.status, a.account, a.tag_type, a.create_time, a.gather_time, a.filing_time, a.isbn_type, a.isbn_sequence,b.book_name from book_init_mapping a left join book_info b on a.isbn = b.isbn_no    where a.tag_type={tagType} and  to_days(a.create_time)=to_days(now()) order by a.create_time desc";
            return Utility.MySqlInstance.ExecuteList<Book_init_mappingExt>(CommandType.Text, sql, null);
        }
        /// <summary>
        /// 更新标签建档信息
        /// </summary>
        /// <param name="isbn"></param>
        /// <param name="tagID"></param>
        /// <returns></returns>
        public static bool UpdateBookInitMapping(string isbn, string tagID)
        {
            string sql = "update book_init_mapping set ISBN=@ISBN where tag_id=@tag_id";
            MySqlParameter[] param = new MySqlParameter[] {
                 new MySqlParameter("@ISBN",isbn),
                 new MySqlParameter("@tag_id",tagID)
            };
            var res = Utility.MySqlInstance.ExecuteNonQuery(CommandType.Text, sql, param);
            if (res > 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="user_account"></param>
        /// <returns></returns>
        public static Book_init_user GetBookInitUser(string user_account) {
            string sql = "select * from book_init_user where user_account=@user_name";
            var res = Utility.MySqlInstance.ExecuteList<Book_init_user>(CommandType.Text, sql, new MySqlParameter[] {
                new MySqlParameter("@user_name",user_account)
            });
            if (null != res && res.Count > 0)
            {
                return res[0];
            }
            return null;
        }

        /// <summary>
        /// 删除标签建档信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeletetBookInitMapping(string id) {
            string sql = "delete from book_init_mapping where id=@id";
            var res = Utility.MySqlInstance.ExecuteNonQuery(CommandType.Text, sql, new System.Data.Common.DbParameter[] {
                new MySqlParameter("@id",id)
            });
            return res > 0;
        }

        /// <summary>
        /// 保存BookRfidIsbnMapping
        /// </summary>
        /// <param name="bookRfidIsbnMapping"></param>
        /// <returns></returns>
        public static bool InsertBookRfidIsbnMapping(BookRfidIsbnMapping bookRfidIsbnMapping) {
            string sql = "insert into book_rfid_isbn_mapping(isbn,rfid_tag_id,isbn_sequence,isbn_type,status) values(@isbn,@rfid_tag_id,@isbn_sequence,@isbn_type,@status)";
            var res = Utility.MySqlInstance.ExecuteNonQuery(CommandType.Text, sql, new System.Data.Common.DbParameter[] {
                new MySqlParameter("@isbn",bookRfidIsbnMapping.isbn),
                new MySqlParameter("@rfid_tag_id",bookRfidIsbnMapping.rfid_tag_id),
                new MySqlParameter("@isbn_sequence",bookRfidIsbnMapping.isbn_sequence),
                new MySqlParameter("@isbn_type",bookRfidIsbnMapping.isbn_type),
                new MySqlParameter("@status",bookRfidIsbnMapping.status)
            });
            return res > 0;
        }
        /// <summary>
        /// 处理BookRfidIsbnMapping表逻辑信息
        /// </summary>
        /// <param name="bookRfidIsbnMapping"></param>
        /// <returns></returns>
        public static bool ProcessBookRfidIsbnMappingLogical(BookRfidIsbnMapping bookRfidIsbnMapping) {

            //查询isbn记录是否存在，存在则记录为多本，不存在则记录为单本
            var sql = "update book_rfid_isbn_mapping set isbn_sequence=@isbn_sequence,isbn_type=@isbn_type where rfid_tag_id=@rfid_tag_id";
            List<BookRfidIsbnMapping> listBookRfidIsbnMapping = GetBookRfidIsbnMappingByIsbn(bookRfidIsbnMapping.isbn);
            if (listBookRfidIsbnMapping == null || listBookRfidIsbnMapping.Count == 1)
            {
                bookRfidIsbnMapping.isbn_sequence = 1;
                bookRfidIsbnMapping.isbn_type = 1;
            }
            else {
                bookRfidIsbnMapping.isbn_sequence = listBookRfidIsbnMapping.Count;
                bookRfidIsbnMapping.isbn_type = 2;
                string update_sql = $"update book_rfid_isbn_mapping set isbn='{bookRfidIsbnMapping.isbn}'";
                Utility.MySqlInstance.ExecuteNonQueryText(update_sql, null);
            }
            //更新BookRfidIsbnMapping中isbn对应图书信息
            var res = Utility.MySqlInstance.ExecuteNonQuery(CommandType.Text, sql, new System.Data.Common.DbParameter[] {
                new MySqlParameter("@isbn_sequence",bookRfidIsbnMapping.isbn_sequence),
                new MySqlParameter("@isbn_type", bookRfidIsbnMapping.isbn_type),
                new MySqlParameter("@rfid_tag_id", bookRfidIsbnMapping.rfid_tag_id)
            });            
            return res>0;
        }

        /// <summary>
        /// 查询rfid标签信息
        /// </summary>
        /// <param name="isbn"></param>
        /// <returns></returns>
        public static List<BookRfidIsbnMapping> GetBookRfidIsbnMappingByIsbn(string isbn="") {
            string sql = "select * from book_rfid_isbn_mapping where isbn=@isbn";
            var res = Utility.MySqlInstance.ExecuteList<BookRfidIsbnMapping>(CommandType.Text, sql, new System.Data.Common.DbParameter[] {
                new MySqlParameter("@isbn",isbn)
            });
            return res;
        }
        /// <summary>
        /// 异步保存BookRfidIsbnMapping
        /// </summary>
        /// <param name="bookRfidIsbnMapping"></param>
        /// <returns></returns>
        public async static Task<bool> InsertBookRfidIsbnMappingAsync(BookRfidIsbnMapping bookRfidIsbnMapping) {
            return await Task.Run(()=>InsertBookRfidIsbnMapping(bookRfidIsbnMapping)); 
        }
        #endregion
    }
}


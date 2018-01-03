//!
//! Description
//! 	PR9200 DEMO
//!-------------------------------------------------------------------
//! History
//!-------------------------------------------------------------------
//! 1.0	2007/09/01	Jinsung Yi		Initial Release

using Infrastructure;
using Infrastructure.Entity;
using Newtonsoft.Json;
using NLog;
using NLog.Config;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace Phychips.PR9200
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                SSHInfo.Instance = Utility.SSHInfo;
                LogManager.Configuration = new XmlLoggingConfiguration(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\NLog.config");
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormLogin());
            }
            catch(Exception ee) {

            }
        }
    }
}
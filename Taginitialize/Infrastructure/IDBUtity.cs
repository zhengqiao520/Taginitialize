using DevLib.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IDBUtity
    {
        Utility Instance(DbProvider dbDbProvider);
    }
}

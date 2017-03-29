using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinStarter.Repository.Interfaces
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}

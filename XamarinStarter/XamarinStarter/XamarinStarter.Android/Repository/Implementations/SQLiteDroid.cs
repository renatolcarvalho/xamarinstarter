using SQLite;
using System.IO;
using Xamarin.Forms;
using XamarinStarter.Droid.Repository.Implementations;
using XamarinStarter.Repository.Interfaces;

[assembly: Dependency(typeof(SQLiteDroid))]
namespace XamarinStarter.Droid.Repository.Implementations
{
    public class SQLiteDroid : ISQLite
    {
        public SQLiteDroid()
        {

        }

        public SQLiteConnection GetConnection()
        {
            SQLitePCL.Batteries.Init();
            var sqliteFileName = "XamarinStarter.db3";
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFileName);
            var conn = new SQLite.SQLiteConnection(path);
            return conn;
        }
    }
}
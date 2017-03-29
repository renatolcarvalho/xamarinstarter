using SQLite;
using System.IO;
using Xamarin.Forms;
using XamarinStarter.iOS.Repository.Implementations;
using XamarinStarter.Repository.Interfaces;
using System;

[assembly: Dependency(typeof(SQLiteIOS))]
namespace XamarinStarter.iOS.Repository.Implementations
{
    public class SQLiteIOS : ISQLite
    {
        public SQLiteIOS()
        {

        }

        public SQLiteConnection GetConnection()
        {
            var sqliteFileName = "XamarinStarter.db3";
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, sqliteFileName);
            var conn = new SQLite.SQLiteConnection(path);
            return conn;
        }
    }
}

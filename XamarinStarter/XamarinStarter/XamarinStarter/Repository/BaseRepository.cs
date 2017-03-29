using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinStarter.Repository
{
    public class BaseRepository
    {
        SQLiteConnection dataBase;
        public BaseRepository()
        {
            dataBase = DependencyService.Get<Interfaces.ISQLite>().GetConnection();
            dataBase.CreateTable<Model.Entities.Aluno>();
        }

        public void SaveValue<T>(T value) where T : Interfaces.IKeyObject, new()
        {
            var item = GetByKey<T>(value.Key);
            if (item != null)
                dataBase.Update(value);
            else
                dataBase.Insert(value);
        }

        public void DeleteValue<T>(string value) where T : Interfaces.IKeyObject, new()
        {
            var item = GetByKey<T>(value);
            if (item != null)
                dataBase.Delete<T>(value);
            else
                throw new Exception("Não foi encontrado esse registro no banco de dados para deletar");
        }

        public List<T> GetAll<T>() where T : Interfaces.IKeyObject, new()
        {
            return dataBase.Table<T>().AsEnumerable().ToList();
        }

        public T GetByKey<T>(string value) where T : Interfaces.IKeyObject, new()
        {
            return (from entry in dataBase.Table<T>().AsEnumerable()
                    where entry.Key == value
                    select entry).FirstOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinStarter.Model.Observable;

namespace XamarinStarter.Model.Entities
{
    public class Aluno : ObservableBase, Repository.Interfaces.IKeyObject
    {
        [SQLite.PrimaryKey]
        public string Key { get; set; }

        private string nome;

        public string Nome
        {
            get { return nome; }
            set { nome = value; OnPropertyChanged(); }
        }

        private string curso;

        public string Curso
        {
            get { return curso; }
            set { curso = value; OnPropertyChanged(); }
        }

        private int? nota;

        public int? Nota
        {
            get { return nota; }
            set { nota = value; OnPropertyChanged(); }
        }
    }
}

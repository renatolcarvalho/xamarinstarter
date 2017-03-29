using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinStarter.Model.Entities;

namespace XamarinStarter.Model.Observable
{
    public class AlunoObservable : ObservableBase
    {
        private ObservableCollection<Aluno> alunos;

        public ObservableCollection<Aluno> Alunos
        {
            get { return alunos; }
            set { alunos = value; OnPropertyChanged(); }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinStarter.Model.Entities;
using XamarinStarter.Model.Observable;
using XamarinStarter.Model.Service;

namespace XamarinStarter.ViewModel
{
    public class AlunoObservableViewModel : ObservableBase
    {
        public ObservableCollection<Aluno> Alunos { get; set; }
        private bool _isBusy;

        public bool IsBusy
        {
            get { return _isBusy; }
            set { _isBusy = value; OnPropertyChanged(); }
        }

        public Command AlunoObservableCommand{ get; set; }

        public AlunoObservableViewModel()
        {
            Alunos = new ObservableCollection<Aluno>();
            IsBusy = false;
            AlunoObservableCommand = new Command((obj) => CarregarObservable());
        }

        async private void CarregarObservable()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                Alunos.Clear();
                var observable = AlunoService.CarregarAlunos();
                if (observable != null)
                {
                    foreach (var aluno in observable.Alunos)
                    {
                        Alunos.Add(aluno);
                    }
                }
                IsBusy = false;
            }
        }
    }
}

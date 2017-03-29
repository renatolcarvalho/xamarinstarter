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
    public class NovoAlunoViewModel : ObservableBase, Repository.Interfaces.IKeyObject
    {
        public string Key { get; set; }

        private string nome;

        public string Nome
        {
            get { return nome; }
            set { nome = value; OnPropertyChanged(); NovoAlunoCommand.ChangeCanExecute(); }
        }

        private string curso;

        public string Curso
        {
            get { return curso; }
            set { curso = value; OnPropertyChanged(); NovoAlunoCommand.ChangeCanExecute(); }
        }

        private int? nota;

        public int? Nota
        {
            get { return nota; }
            set { nota = value; OnPropertyChanged(); }
        }

        public Command NovoAlunoCommand { get; set; }
        public Command DeletarAlunoCommand { get; set; }

        public NovoAlunoViewModel()
        {
            NovoAlunoCommand = new Command(ExecuteNovoAlunoCommand, CanExecuteNovoAlunoCommand);
            DeletarAlunoCommand = new Command(ExecuteDeletarAlunoCommand, CanExecuteDeletarAlunoCommand);
        }

        private void ExecuteDeletarAlunoCommand(object obj)
        {
            AlunoService.ExcluirAluno(Key);
            Application.Current.MainPage.Navigation.PopAsync();
        }

        private bool CanExecuteDeletarAlunoCommand(object arg)
        {
            return !string.IsNullOrEmpty(Key);
        }

        private void ExecuteNovoAlunoCommand()
        {
            AlunoService.SalvarAluno(new Aluno
            {
                Key = Guid.NewGuid().ToString(),
                Nome = Nome,
                Curso = Curso,
                Nota = Nota
            });

            Application.Current.MainPage.Navigation.PopAsync();
        }

        private bool CanExecuteNovoAlunoCommand()
        {
            if (string.IsNullOrEmpty(Nome) || string.IsNullOrEmpty(Curso))
                return false;
            return true;
        }
    }
}

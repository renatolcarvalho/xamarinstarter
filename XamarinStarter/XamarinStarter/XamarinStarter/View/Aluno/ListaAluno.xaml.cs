using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinStarter.View.Aluno
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaAluno : ContentPage
    {
        public ListaAluno()
        {
            InitializeComponent();
            btnNovoAluno.Clicked += btnNovoAluno_Clicked;
            lvAlunos.ItemSelected += LvAlunos_ItemSelected;
        }

        private async void LvAlunos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var aluno = e.SelectedItem as Model.Entities.Aluno;
            if (aluno != null)
            {
                await Navigation.PushAsync(new NovoAluno(new ViewModel.NovoAlunoViewModel
                {
                    Key = aluno.Key,
                    Nome = aluno.Nome,
                    Curso = aluno.Curso,
                    Nota = aluno.Nota
                }));
            }

            lvAlunos.SelectedItem = null;
        }

        private async void btnNovoAluno_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NovoAluno());
        }
    }
}

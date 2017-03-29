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
    public partial class NovoAluno : ContentPage
    {
        public NovoAluno()
        {
            InitializeComponent();
        }

        public NovoAluno(ViewModel.NovoAlunoViewModel aluno)
        {
            InitializeComponent();
            BindingContext = aluno;
        }
    }
}

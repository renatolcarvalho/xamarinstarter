using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinStarter.Model.Entities;
using XamarinStarter.Model.Observable;

namespace XamarinStarter.Model.Service
{
    public class AlunoService
    {
        public static AlunoObservable CarregarAlunos()
        {
            var dataBase = new Repository.BaseRepository();
            var alunos = new ObservableCollection<Aluno>(dataBase.GetAll<Aluno>());
            var alunosObservable = new Observable.AlunoObservable();
            if (alunos.Any())
            {
                alunosObservable.Alunos = alunos;
                return alunosObservable;
            }

            return null;
        }

        public static AlunoObservable CarregarAlunoObservable()
        {
            var alunos = new ObservableCollection<Aluno>();

            string[] nomes = { "José Luis", "Miguel Ángel", "José Francisco", "Jesús Antonio", "Sofía", "Camila", "Valentina", "Isabella", "Ximena" };
            string[] cursos = { "Administração", "Sistemas de Informação", "Medicina", "Odonto" };
            Random rdn = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < 20; i++)
            {
                var aluno = new Aluno
                {
                    Key = Guid.NewGuid().ToString(),
                    Nome = nomes[rdn.Next(0, 8)],
                    Curso = cursos[rdn.Next(0, 3)],
                    Nota = rdn.Next(0, 10)
                };
                alunos.Add(aluno);
            }

            return new AlunoObservable
            {
                Alunos = alunos
            };
        }

        internal static void ExcluirAluno(string key)
        {
            var dataBase = new Repository.BaseRepository();
            dataBase.DeleteValue<Aluno>(key);
        }

        public static void SalvarAluno(Model.Entities.Aluno aluno)
        {
            var dataBase = new Repository.BaseRepository();
            dataBase.SaveValue(aluno);
        }
    }
}

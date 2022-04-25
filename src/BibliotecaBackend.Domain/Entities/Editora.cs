using System.Collections.Generic;

namespace BibliotecaBackend.Domain.Entities
{
    public class Editora : Entity
    {
        public string Nome { get; set; }
        public IReadOnlyCollection<Livro> Livros { get; protected set; }

        public Editora()
        {

        }
    }
}

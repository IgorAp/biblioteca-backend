using System.Collections.Generic;

namespace BibliotecaBackend.Domain.Entities
{
    public class Autor: Entity
    {
        public string Nome { get; set; }
        public IReadOnlyCollection<LivroAutor> LivrosAutor { get; protected set; }

        public Autor()
        {

        }
    }
}

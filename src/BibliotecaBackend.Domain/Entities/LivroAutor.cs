using System;

namespace BibliotecaBackend.Domain.Entities
{
    public class LivroAutor : Entity
    {
        public Livro Livro { get; protected set; }
        public Guid LivroId { get; protected set; }

        public Autor Autor { get; protected set; }
        public Guid AutorId { get; protected set; }

        protected LivroAutor()
        {

        }

        public LivroAutor(Livro livro, Autor autor)
        {
            Livro = livro;
            Autor = autor;
        }
    }
}

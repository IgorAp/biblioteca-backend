using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBackend.Domain.Entities
{
    public class Livro : Entity, IAggregateRoot
    {
        public string Titulo { get; protected set; }
        public string Foto { get; protected set; }
        private List<LivroAutor> _autoresLivro;
        public IReadOnlyCollection<LivroAutor> AutoresLivro { get { return _autoresLivro.ToArray(); } }
        public Guid EditoraId { get; protected set; }
        public Editora Editora { get; protected set; }

        protected Livro() 
        {
            _autoresLivro = new List<LivroAutor>();
        }

        public Livro(string titulo, string foto, IEnumerable<Autor> autores, Editora editora)
        {
            _autoresLivro = new List<LivroAutor>();
            DefinirTitulo(titulo);
            DefinirFoto(foto);
            DefinirAutores(autores);
            DefinirEditora(editora);
        }

        public void DefinirTitulo(string titulo)
        {
            Titulo = titulo;
        }

        public void DefinirFoto(string foto)
        {
            Foto = foto;
        }

        public void DefinirAutores(IEnumerable<Autor> autores)
        {
            foreach (var item in _autoresLivro)
            {
                _autoresLivro.Remove(item);
            }

            foreach (var autor in autores)
            {
                _autoresLivro.Add(new LivroAutor(this, autor));
            }
        }

        public void DefinirEditora(Editora editora)
        {
            Editora = editora;
        }
    }
}

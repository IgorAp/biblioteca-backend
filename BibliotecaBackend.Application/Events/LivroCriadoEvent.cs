using BibliotecaBackend.Domain.Entities;

namespace BibliotecaBackend.Application.Events
{
    public class LivroCriadoEvent : Event
    {
        public Livro Livro { get; set; }
    }
}

using BibliotecaBackend.Domain.Entities;

namespace BibliotecaBackend.Application.Events
{
    public class LivroAlteradoEvent : Event
    {
        public Livro Livro { get; set; }
    }
}

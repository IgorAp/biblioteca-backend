using BibliotecaBackend.Domain.Repositories;
using BibliotecaBackend.Infra.Data.ReadModel.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace BibliotecaBackend.Application.Events
{
    public class LivroEventHandler
        : INotificationHandler<LivroCriadoEvent>
        , INotificationHandler<LivroAlteradoEvent>
        , INotificationHandler<LivroRemovidoEvent>
    {
        private readonly IBaseRepository<LivroDTO> _livroRepository;

        public LivroEventHandler(IBaseRepository<LivroDTO> livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public async Task Handle(LivroCriadoEvent notification, CancellationToken cancellationToken)
        {
            var livro = notification.Livro;

            var livroDTO = new LivroDTO
            {
                Key = livro.Id,
                Livro = livro.Titulo,
                Editora = livro.Editora.Nome,
                Autores = livro.AutoresLivro.Select(x => x.Autor.Nome).ToArray()
            };

            await _livroRepository.AddAsync(livroDTO);
        }

        public async Task Handle(LivroAlteradoEvent notification, CancellationToken cancellationToken)
        {
            var livroNotificacao = notification.Livro;
            var livro = await _livroRepository.GetByIdAsync(livroNotificacao.Id);

            livro.Key = livroNotificacao.Id;
            livro.Livro = livroNotificacao.Titulo;
            livro.Editora = livroNotificacao.Editora.Nome;
            livro.Autores = livroNotificacao.AutoresLivro.Select(x => x.Autor.Nome).ToArray();

            await _livroRepository.Update(livro);
        }

        public async Task Handle(LivroRemovidoEvent notification, CancellationToken cancellationToken)
        {
            var livro = await _livroRepository.GetByIdAsync(notification.AggregateId);
            await _livroRepository.Remove(livro);
        }
    }
}

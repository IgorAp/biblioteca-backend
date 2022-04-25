using BibliotecaBackend.Domain.Entities;
using BibliotecaBackend.Domain.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using BibliotecaBackend.Application.Events;

namespace BibliotecaBackend.Application.Commands
{
    public class LivroCommandHandler 
        : IRequestHandler<CriarLivroCommand, bool>
        , IRequestHandler<AtualizarLivroCommand, bool>
        , IRequestHandler<RemoverLivroCommand, bool>
    {
        private readonly IBaseRepository<Livro> LivroRepository;
        private readonly IBaseRepository<Editora> EditoraRepository;
        private readonly IBaseRepository<Autor> AutorRepository;
        private readonly IMediator mediator;

        public LivroCommandHandler(IBaseRepository<Livro> livroRepository,
                            IBaseRepository<Editora> editoraRepository,
                            IBaseRepository<Autor> autorRepository,
                            IMediator mediator)
        {
            LivroRepository = livroRepository;
            EditoraRepository = editoraRepository;
            AutorRepository = autorRepository;
            this.mediator = mediator;
        }

        public async Task<bool> Handle(CriarLivroCommand request, CancellationToken cancellationToken)
        {
            var editora = await EditoraRepository.GetByIdAsync(request.EditoraId);
            var autores = await AutorRepository.GetAsync();

            var autoresFiltrados = (
                    from autor in autores
                    join autorCommand in request.AutoresId on autor.Id equals autorCommand
                    select autor
                );

            var livro = new Livro(request.Titulo,request.Foto, autoresFiltrados,  editora);

            await LivroRepository.AddAsync(livro);

            await mediator.Publish(new LivroCriadoEvent
            {
                AggregateId = livro.Id,
                Livro = livro
            });

            return true;
        }

        public async Task<bool> Handle(AtualizarLivroCommand request, CancellationToken cancellationToken)
        {
            var editora = await EditoraRepository.GetByIdAsync(request.EditoraId);
            var autores = await AutorRepository.GetAsync();

            var autoresFiltrados = (
                    from autor in autores
                    join autorCommand in request.AutoresId on autor.Id equals autorCommand
                    select autor
                );

            var livro = await LivroRepository.GetByIdAsync(request.AggregateId);

            livro.DefinirTitulo(request.Titulo);
            livro.DefinirFoto(request.Foto);
            //livro.DefinirAutores(autoresFiltrados);
            livro.DefinirEditora(editora);

            await LivroRepository.Update(livro);

            await mediator.Publish(new LivroAlteradoEvent
            {
                AggregateId = livro.Id,
                Livro = livro
            });

            return true;
        }

        public async Task<bool> Handle(RemoverLivroCommand request, CancellationToken cancellationToken)
        {
            var livro = await LivroRepository.GetByIdAsync(request.AggregateId);
            await LivroRepository.Remove(livro);

            await mediator.Publish(new LivroRemovidoEvent
            {
                AggregateId = livro.Id
            });

            return true;
        }
    }
}

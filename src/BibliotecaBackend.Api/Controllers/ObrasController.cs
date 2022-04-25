using BibliotecaBackend.Application.Commands;
using BibliotecaBackend.Domain.Entities;
using BibliotecaBackend.Domain.Repositories;
using BibliotecaBackend.Infra.Data.ReadModel.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace BibliotecaBackend.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IBaseRepository<LivroDTO> _readRepository;


        public BooksController(IMediator mediator, IBaseRepository<LivroDTO> readRepository)
        {
            _mediator = mediator;
            _readRepository = readRepository;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var livros = await _readRepository.GetAsync();
            var result = livros.ToList().Skip(10000);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CriarLivroCommand livro )
        {
            await _mediator.Send(livro);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] AtualizarLivroCommand livro)
        {
            livro.AggregateId = id;
            await _mediator.Send(livro);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new RemoverLivroCommand { AggregateId = id });

            return NoContent();
        }
    }

}

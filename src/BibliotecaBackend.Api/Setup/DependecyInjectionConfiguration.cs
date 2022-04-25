using BibliotecaBackend.Application.Commands;
using BibliotecaBackend.Application.Events;
using BibliotecaBackend.Domain.Entities;
using BibliotecaBackend.Domain.Repositories;
using BibliotecaBackend.Infra.Data.ReadModel.DTOs;
using BibliotecaBackend.Infra.Data.ReadModel.Repositories;
using BibliotecaBackend.Infra.Data.WriteModel.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaBackend.Api.Setup
{
    public static class DependecyInjectionConfiguration
    {
        public static void ConfigureDependencies(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<Livro>, WriteBaseRepository<Livro>>();
            services.AddScoped<IBaseRepository<Editora>, WriteBaseRepository<Editora>>();
            services.AddScoped<IBaseRepository<Autor>, WriteBaseRepository<Autor>>();
            services.AddScoped<IBaseRepository<LivroDTO>,ReadBaseRepository<LivroDTO>>();

            services.AddScoped<IRequestHandler<CriarLivroCommand, bool>, LivroCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarLivroCommand, bool>, LivroCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverLivroCommand, bool>, LivroCommandHandler>();
            services.AddScoped<INotificationHandler<LivroCriadoEvent>, LivroEventHandler>();
            services.AddScoped<INotificationHandler<LivroAlteradoEvent>, LivroEventHandler>();
            services.AddScoped<INotificationHandler<LivroRemovidoEvent>, LivroEventHandler>();
        }
    }
}

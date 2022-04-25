using System;
using System.Collections.Generic;

namespace BibliotecaBackend.Application.Commands
{
    public class AtualizarLivroCommand : Command<bool>
    {
        public string Titulo { get; set; }
        public Guid EditoraId { get; set; }
        public string Foto { get; set; }
        public IEnumerable<Guid> AutoresId { get; set; }
    }
}

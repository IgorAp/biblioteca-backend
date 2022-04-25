using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BibliotecaBackend.Application.Commands
{
    public class CriarLivroCommand : Command<bool>
    {
        public string Titulo { get; set; }
        public Guid EditoraId { get; set; }
        public string Foto { get; set; }
        public IEnumerable<Guid> AutoresId { get; set; }
    }

    public class RemoverLivroCommand : Command<bool>
    {

    }
}

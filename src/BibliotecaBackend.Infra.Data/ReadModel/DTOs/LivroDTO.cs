using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBackend.Infra.Data.ReadModel.DTOs
{
    public class LivroDTO : BaseDTO
    {
        public string Livro { get; set; }
        public string[] Autores { get; set; }
        public string Editora { get; set; }
    }
}

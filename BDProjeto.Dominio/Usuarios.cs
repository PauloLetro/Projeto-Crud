using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDProjeto.Dominio
{
    public class Usuarios
    {
        // Paramentros que correspondem ao banco de dados, será o meio termo entre o banco de dados e a aplicação
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public DateTime Data { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comidas.Shared.Entidades
{
    public class VotoComida
    {
        public int Id { get; set; }
        public int Voto { get; set; }
        public DateTime FechaVoto { get; set; }
        public int ComidasRapidasId { get; set; }
        public ComidasRapidas ComidasRapidas { get; set; }
    }
}

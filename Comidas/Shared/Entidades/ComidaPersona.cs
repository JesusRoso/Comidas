using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comidas.Shared.Entidades
{
    public class ComidaPersona
    {
        public int ComidaRapidaId { get; set; }
        public int PersonaId { get; set; }
        public ComidasRapidas ComidasRapidas { get; set; }
        public Persona Persona { get; set; }
    }
}

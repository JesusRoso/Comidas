using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comidas.Shared.Entidades
{
    public class ComidasRapidas
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="El campo {0} es requerido")]
        public string titulo { get; set; }
        [Required(ErrorMessage = "El campo {1} es requerido")]
        public int precio { get; set; }
        //public List<ComidaPersona> ComidaPersonas { get; set; }
    }
}

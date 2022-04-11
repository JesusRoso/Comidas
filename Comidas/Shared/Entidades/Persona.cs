using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Comidas.Shared.Entidades
{
    public class Persona
    {

        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public DateTime? FechaNacimiento { get; set; }

        //public List<ComidaPersona> ComidasPersona { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Persona p2)
            {
                return Id == p2.Id;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

using System;
using System.Collections.Generic;

namespace ProjectCursoXamarin.Entities.Models
{
    public partial class Restaurantes
    {
        public Restaurantes()
        {
            RestaurantesAmburguesas = new HashSet<RestaurantesAmburguesas>();
        }

        public int IdRestaurante { get; set; }
        public string NombreRestaurante { get; set; }
        public string Ubicacion { get; set; }
        public int Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<RestaurantesAmburguesas> RestaurantesAmburguesas { get; set; }
    }
}

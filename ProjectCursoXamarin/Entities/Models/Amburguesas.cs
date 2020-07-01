using System;
using System.Collections.Generic;

namespace ProjectCursoXamarin.Entities.Models
{
    public partial class Amburguesas
    {
        public Amburguesas()
        {
            RestaurantesAmburguesas = new HashSet<RestaurantesAmburguesas>();
        }

        public int IdAmburguesa { get; set; }
        public string NombreAmburguesa { get; set; }
        public bool Favorita { get; set; }
        public string Imagen { get; set; }
        public int Precio { get; set; }
        public float? Rating { get; set; }
        public bool? Estado { get; set; }
        public int? IdCategoria { get; set; }

        public virtual Categorias IdCategoriaNavigation { get; set; }
        public virtual ICollection<RestaurantesAmburguesas> RestaurantesAmburguesas { get; set; }
    }
}

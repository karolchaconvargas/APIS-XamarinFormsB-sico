using System;
using System.Collections.Generic;

namespace ProjectCursoXamarin.Entities.Models
{
    public partial class RestaurantesAmburguesas
    {
        public int IdRestaurante { get; set; }
        public int IdAmburguesa { get; set; }

        public virtual Amburguesas IdAmburguesaNavigation { get; set; }
        public virtual Restaurantes IdRestauranteNavigation { get; set; }
    }
}

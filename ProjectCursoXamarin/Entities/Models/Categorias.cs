using System;
using System.Collections.Generic;

namespace ProjectCursoXamarin.Entities.Models
{
    public partial class Categorias
    {
        public Categorias()
        {
            Amburguesas = new HashSet<Amburguesas>();
        }

        public int IdCategoria { get; set; }
        public string Categoria { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<Amburguesas> Amburguesas { get; set; }
    }
}

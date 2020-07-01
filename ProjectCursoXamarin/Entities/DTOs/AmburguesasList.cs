using ProjectCursoXamarin.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCursoXamarin.Entities.DTOs
{
    public class AmburguesasList
    {
        public int IdAmburguesa { get; set; }
        public List<Categorias> categoriasAgregadas{ get; set; }
    }
}

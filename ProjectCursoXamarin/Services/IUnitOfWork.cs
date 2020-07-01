using ProjectCursoXamarin.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCursoXamarin.Services
{
    //Contrados donde definimos que todos lo que desean implementar esa interfaz deberan impenntar todos los metodos que definieron
  
    //Definimos 4 propiedades(Amburguesas, Categorias, Restaurantes,RestaurantesAmburguesas)
    public interface IUnitOfWork
    {
        //Todas las entidades a las que tendremos acceso,
        //es como un db content,le estamos diciendo que estamos herednando de las entidades
        //Amburguesas, categorias,, restaurantes,RestauantesAmburguesas

        //Utilidad, si por alguna raz[on necesitamos otros metodos y todas las clases que estan implementadas
        //en lainterfaz,cumplan con los requisitos y asi se obliga que de esta forma deban darle cuerpo e implementar estaforma de trabajo
        IRepository<Amburguesas> Amburguesas { get; }
        IRepository<Categorias> Categorias { get; }
        IRepository<Restaurantes> Restaurantes { get; }
        IRepository<RestaurantesAmburguesas> RestaurantesAmburguesas { get; }
        void Saved();
    }
}

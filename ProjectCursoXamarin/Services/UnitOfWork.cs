using ProjectCursoXamarin.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCursoXamarin.Services
{
    //Clase que va a implementarse
    //En esta clase damos cuerpo a los metodos creados en lainterfaz IUnitOfWork
    public class UnitOfWork : IUnitOfWork
    {

        //Implementamos o inyectamos dependencias
        private DemoContext _context;
        private BaseRepository<Amburguesas> _amburguesas;
        private BaseRepository<Categorias> _categorias;
        private BaseRepository<Restaurantes> _restaurantes;
        private BaseRepository<RestaurantesAmburguesas> _restaurantesAmburguesas;

        //Creamos constructor,recibe un context
        //creamos propiedades

      //Como es generico, debemos crear cadapropeidad y asignarle el valo, paraque sepa a que nos estamos refiriendo

        //UnitOfWork nos facilita a la hora decrearlos controladores, al hacer variastransacciones en un mismo bloque de codigo
        //se haga apartir del save una unicatransaccion a la base de datos en lugar devarios, cuando sea posible,a menos de que sea necesario.
        public UnitOfWork(DemoContext dbcontext)
        {
            _context = dbcontext;
        }

        //Inicializamos las propiedades
        public IRepository<Amburguesas> Amburguesas{
            get
            {
                //Al decirle = Lo que hace es inciarlizar el respositorio
                return _amburguesas ??
                                   (_amburguesas = new BaseRepository<Amburguesas>(_context));
            }
        }

        public IRepository<Categorias> Categorias
        {
            get
            {
                return _categorias ??
                                   (_categorias = new BaseRepository<Categorias>(_context));
            }
        }

        public IRepository<Restaurantes> Restaurantes
        {
            get
            {
                return _restaurantes ??
                                   (_restaurantes = new BaseRepository<Restaurantes>(_context));
            }
        }

        public IRepository<RestaurantesAmburguesas> RestaurantesAmburguesas
        {
            get
            {
                return _restaurantesAmburguesas ??
                                   (_restaurantesAmburguesas = new BaseRepository<RestaurantesAmburguesas>(_context));
            }
        }

        public void Saved()
        {
            _context.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectCursoXamarin.Services
{
    //Esto se puede realizar en el baseRepository, pero la forma correcta de hacerlo es haciendo una interfaz,
    //Se hace de esta forma para poderutilizarlo como un estandar en otrso proyectos que tengan varios repositorios
    public interface IRepository<TEntity> where TEntity : class
    {
        //Insert
        void Insert(TEntity entityToInsert);

        //Update
        void Update(TEntity entityToUpdate);

        //Va a devolver cualquier entidad(Acepta un expression TDelegado)
        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            //Recibe un filtro,orderby y un includePorperties, esto es para obtener lo de nuestra entidad
                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                string includeProperties = "");

        //GetByID
        TEntity GetById(Object id);

        //Delete(Recibo entidad)
        void Delete(TEntity entityToDelete);

        //Delelet(Recibo id)
        void Delete(Object Id);
    }
}

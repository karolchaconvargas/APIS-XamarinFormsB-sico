using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ProjectCursoXamarin.Entities.Models;


namespace ProjectCursoXamarin.Services
{
    //Le decimos que heredamos de Irepository, que es deltipo TENTITY
    //Aqui para generar las clases solo le damos implementar interfaz(AQUI ES DONDE SE LE DA EL CUERPO A ESOS  MÉTODOS)
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        //Creamos las dependencias
        internal DemoContext context;
        internal DbSet<TEntity> dbSet;

        public BaseRepository(DemoContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();

        }

        public void Delete(TEntity entityToDelete)
        {
            //Single esta entidad no esta traqueada por el contexto, sino 
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                //La tacha y luego la borra
                dbSet.Attach(entityToDelete);
            }
            //Si esta tachada solo pasa a borrarla
            dbSet.Remove(entityToDelete);
        }

        public void Delete(object id)
        {
            //eliminar la entidad del id que recibido
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;
            //Hacer validación, se le dice que el puedeenciar un filtro
            //Si es difernete de null, filtre con los datos que nos enviaron
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {//Toma cada una de las propiedades y las separa por comas
                foreach (var includeProperty in includeProperties.Split
              (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    //Incluya esas propiedades que esta separando
                    query = query.Include(includeProperty);
                }
            }
                if (orderBy != null)
                {
                    return orderBy(query).ToList();
                }
                else
                {
                //Sin ningún orden específico
                    return query.ToList();
                }
            }

        public TEntity GetById(object id)
        {
            //Debe devolver la entidad
            return dbSet.Find(id);
        }

        public void Insert(TEntity entityToInsert)
        {
            dbSet.Add(entityToInsert);
        }

        public void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State =EntityState.Modified;
        }
    }
}

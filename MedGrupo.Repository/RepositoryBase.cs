using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MedGrupo.Data;
using MedGrupo.Domain;
using MedGrupo.Repository.Interfaces;

namespace MedGrupo.Repository
{
    public class RepositoryBase<T>
        : IDisposable, IRepositoryBase<T> where T : class
    {
        private DataContext _context;
        private IQueryable<T> _query;
  
        public RepositoryBase(DataContext context)
        {
            _context = context;
            _query = _context.Set<T>().AsQueryable();
        }

        public T BuscaPorId(int id)
        {
            return _context.Set<T>().Find(id);            
        }
  
        public IQueryable<T> BuscaPorQuery(bool traking)
        {
            if(traking)
                return _context.Set<T>();
            else
                return _context.Set<T>().AsNoTracking();
        }
  
        public void Incluir(T item)
        {
            _context.Set<T>().Add(item);
            _context.SaveChanges();
        }
  
        public void Editar(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remover(T item)
        {
            _context.Set<T>().Remove(item);
            _context.SaveChanges();
        }
  
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MedGrupo.Repository.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        T BuscaPorId(int id);
        IQueryable<T> BuscaPorQuery(bool traking);
        void Incluir(T item);
        void Editar(T item);
        void Remover(T item);        
    }
}
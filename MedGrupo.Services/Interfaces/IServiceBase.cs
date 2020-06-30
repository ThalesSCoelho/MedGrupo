using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MedGrupo.Services.Interfaces
{
    public interface IServiceBase<T> where T : class
    {
        IQueryable<T> Query(bool traking);
        T Salvar(T item);        
        void Remover(int id);        
    }
}
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MedGrupo.Data;
using MedGrupo.Domain;
using MedGrupo.Services.Interfaces;
using MedGrupo.Repository.Interfaces;
using MedGrupo.Repository;
using System.Reflection;

namespace MedGrupo.Services
{
    public class ServiceBase<T>
        : IServiceBase<T> where T : class
    {
        private IRepositoryBase<T> _repository;
        private DataContext _dataContext;
  
        public ServiceBase(DataContext dataContext)
        {
            _dataContext = dataContext;
            _repository = new RepositoryBase<T>(_dataContext);
        }
  
        public IQueryable<T> Query(bool traking)
        {
            try
            {
                return _repository.BuscaPorQuery(traking);
            }
            catch(Exception ex)
            {
                throw new Exception("Não foi possível realizar a consulta! Mensagem: " + ex.Message);
            }
        }
  
        public T Salvar(T item)
        {
            try
            {
                Type t = item.GetType();
                PropertyInfo prop = t.GetProperty("Id");

                if(prop == null)            
                    _repository.Incluir(item);
                else 
                {
                    _repository.Editar(item);
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Não foi possível realizar a persistência dos dados! Mensagem: " + ex.Message);
            }
            return item;
        }

        public void Remover(int id)
        {
            try
            {
                var entity = _repository.BuscaPorId(id);
				if(entity == null)
				{
					throw new Exception("Entidade não encontrada!");
				}

                _repository.Remover(entity);
            }
            catch(Exception ex)
            {
                throw new Exception("Não foi possível realizar a exclusão! Mensagem: " + ex.Message);
            }
        }
    }
}
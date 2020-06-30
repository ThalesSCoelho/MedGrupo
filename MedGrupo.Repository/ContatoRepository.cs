using System;
using System.Collections.Generic;
using System.Linq;
using MedGrupo.Data;
using MedGrupo.Domain;
using MedGrupo.Repository.Interfaces;

namespace MedGrupo.Repository
{
	public class ContatoRepository : RepositoryBase<Contato>, IContatoRepository
	{
        public ContatoRepository(DataContext context) : base(context)
		{
			
		}		
	}
}
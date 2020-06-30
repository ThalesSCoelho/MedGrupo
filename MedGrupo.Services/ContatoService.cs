using MedGrupo.Domain;
using MedGrupo.Repository;
using MedGrupo.Repository.Interfaces;
using MedGrupo.Services.Interfaces;
using MedGrupo.Data;

namespace MedGrupo.Services
{
    public class ContatoService : ServiceBase<Contato>, IContatoService
    {
        public ContatoService(DataContext context) : base(context)
        {
            
        }
    }
}
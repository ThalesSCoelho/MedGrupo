using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedGrupo.Domain
{
	public class EntityBase
	{

        [Key]
        public virtual int Id { get; set;}
	}
}
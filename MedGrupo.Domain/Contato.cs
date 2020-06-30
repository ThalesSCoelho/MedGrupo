using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedGrupo.Domain
{
	[Table("Contato")]
	public class Contato : EntityBase
	{
		[Required(ErrorMessage = "Informe o Nome!")]
		[StringLength(255, MinimumLength=3, ErrorMessage="O Nome deve ter no mínimo 3 e no máximo 255 caracteres!")]
		public string Nome { get; set; }

		[Range(typeof(DateTime), "1800-01-01", "9999-12/31",
        ErrorMessage = "Data de Nascimento Inválida!")]
		public DateTime DtNascimento { get; set; }
                
        [Required(ErrorMessage = "Informe o campo Sexo!")]
        [StringLength(1, MinimumLength = 1, ErrorMessage = "O Sexo deve conter apenas 1 caracter.")]
        [RegularExpression("M|F", ErrorMessage = "O Sexo deve conter apenas 'M' ou 'F'.")]
		public string Sexo { get; set; }

		[NotMapped]
		public int Idade 
		{ 
			get => DtNascimento != DateTime.MinValue ? Convert.ToInt32((DateTime.Now - DtNascimento).Days / 365.25m)  : 0; 

		}
	}
}
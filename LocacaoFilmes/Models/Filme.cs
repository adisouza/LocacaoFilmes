using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocacaoFilmes.Models {

	[Table("Filme")]
	public class Filme {
		[Key]
		public int Id { get; set; }

		[StringLength(100)]
		public string Titulo { get; set; }
		public int ClassificacaoIndicativa { get; set; }
		public byte Lancamento { get; set; }
	}
}

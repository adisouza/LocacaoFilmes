using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace LocacaoFilmes.Models {
	[Table("Locacao")]
	public class Locacao {
		[Key]
		public int Id { get; set; }

		//[ForeignKey("FK_Cliente_idx")]
		[Column("Id_Cliente")]
		public virtual Cliente IdCliente { get; set; }

		//[ForeignKey("FK_Filme_idx")]
		[Column("Id_Filme")]
		public virtual Filme IdFilme { get; set; }

		public DateTime DataLocacao { get; set; }
		public DateTime DataDevolucao { get; set; }
	}
}

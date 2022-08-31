using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocacaoFilmes.Models {
	[Table("Cliente")]
	public class Cliente {
		[Key]
		public int Id { get; set; }

		[StringLength(200)]
		public string Nome { get; set; }
		
		[StringLength(11)]
		public string CPF { get; set; }
		public DateTime DataNascimento { get; set; }
	}
}

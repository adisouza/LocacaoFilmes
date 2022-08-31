using LocacaoFilmes.Models;
using LocacaoFilmes.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocacaoFilmes.Controllers {
	public class FilmeController: ControllerBase {
		private IGenericService<Filme> _services;
		public FilmeController(IGenericService<Filme> filmeServices) {
			_services = filmeServices;
		}

		[HttpGet("FilmeGetAll")]
		public async Task<ActionResult<IAsyncEnumerable<Filme>>> GetAll() {
			try {
				var obj = await _services.GetAll();
				return Ok(obj);

			} catch(Exception) {
				throw;
			}
		}
		[HttpGet("{id}", Name = "FilmeGetId")]
		public async Task<ActionResult<Filme>> GetId(int id) {
			try {
				var obj = await _services.Get(id);
				if(obj is null) {
					return NotFound();
				}

				return Ok(obj);

			} catch(Exception) {
				throw;
			}
		}
		[HttpPost("FilmeInsert")]
		public async Task<ActionResult> Insert([FromBody] List<Filme> obj) {
			try {
				  foreach( var o in obj) {
					var item = await _services.Get(o.Id);
					if(item is not null) {
						if(item.Titulo.Equals(o.Titulo) &&
							item.ClassificacaoIndicativa.Equals(o.ClassificacaoIndicativa) &&
							item.Lancamento.Equals(o.Lancamento)) {
							continue;
						}
							await _services.Delete(item);
					}
						await _services.Insert(o);
					
				}
				return Ok("FilmeGetId");


			} catch(Exception ex) {
				 return BadRequest(ex.Message);
			}
		}
		[HttpPut("{id}", Name = "FilmeUpdate")]
		public async Task<ActionResult> Update(int id, [FromBody] Filme obj) {
			try {
				if(obj.Id.Equals(id)) {
					await _services.Update(obj);
					return NoContent();
				}

				return NotFound();

			} catch(Exception) {
				throw;
			}
		}
		[HttpDelete("{id}", Name = "FilmeDelete")]
		public async Task<ActionResult> Delete(int id) {
			try {
				var obj = await _services.Get(id);
				if(obj is not null) {
					await _services.Delete(obj);
					return NoContent();
				}

				return NotFound();

			} catch(Exception) {
				throw;
			}
		}
	}
}

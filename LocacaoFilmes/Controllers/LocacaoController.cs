using LocacaoFilmes.Models;
using LocacaoFilmes.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocacaoFilmes.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class LocacaoController: ControllerBase {
		private IGenericService<Locacao> _services;
		public LocacaoController(IGenericService<Locacao> locacaoServices) {
			_services = locacaoServices;
		}

		[HttpGet("LocacaoGetAll")]
		public async Task<ActionResult<IAsyncEnumerable<Locacao>>> GetAll() {
			try {
				var obj = await _services.GetAll();
				return Ok(obj);

			} catch(Exception) {
				throw;
			}
		}
		[HttpGet("{id}", Name = "LocacaoGetId")]
		public async Task<ActionResult<Locacao>> GetId(int id) {
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
		[HttpPost("LocacaoInsert")]
		public async Task<ActionResult> Insert([FromBody] Locacao obj) {
			try {
				await _services.Insert(obj);
				return CreatedAtRoute("LocacaoGetId", new { id = obj.Id }, obj);

			} catch(Exception) {
				throw;
			}
		}
		[HttpPut("{id}", Name = "LocacaoUpdate")]
		public async Task<ActionResult> Update(int id, [FromBody] Locacao obj) {
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
		[HttpDelete("{id}", Name = "LocacaoDelete")]
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

using LocacaoFilmes.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocacaoFilmes.Models;

namespace LocacaoFilmes.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class ClienteController: ControllerBase {
		private IGenericService<Cliente> _services;
		public ClienteController(IGenericService<Cliente> clienteServices) {
			_services = clienteServices;
		}

		[HttpGet("GetAll")]
		public async Task<ActionResult<IAsyncEnumerable<Cliente>>> GetAll() {
			try {
				var obj = await _services.GetAll();
				return Ok(obj);

			} catch(Exception) {
				throw;
			}
		}
		[HttpGet("{id}", Name = "GetId")]
		public async Task<ActionResult<Cliente>> GetId(int id) {
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
		[HttpPost("Insert")]
		public async Task<ActionResult> Insert([FromBody] Cliente obj) {
			try {
				await _services.Insert(obj);
				return CreatedAtRoute("GetId", new { id = obj.Id }, obj);

			} catch(Exception) {
				throw;
			}
		}
		[HttpPut("{id}", Name = "Update")]
		public async Task<ActionResult> Update(int id, [FromBody] Cliente obj) {
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
		[HttpDelete("{id}", Name = "Delete")]
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

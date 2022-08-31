using LocacaoFilmes.Data;
using LocacaoFilmes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocacaoFilmes.Services {
	public class ClienteServices: IGenericService<Cliente> {
		private readonly AppDbContext _appDbContext;

		public ClienteServices(AppDbContext context) {
			_appDbContext = context;
		}

		public async Task<IEnumerable<Cliente>> GetAll() {
			try {
				return await _appDbContext.Clientes.ToListAsync();

			} catch(Exception) {
				throw;
			}
		}

		public async Task<Cliente> Get(int Id) {
			try {
				return await _appDbContext.Clientes.FindAsync(Id);

			} catch(Exception) {
				throw;
			}
		}

		public async Task Insert(Cliente obj) {
			try {
				_appDbContext.Clientes.Add(obj);
				await _appDbContext.SaveChangesAsync();

			} catch(Exception) {
				throw;
			}
		}

		public async Task Update(Cliente obj) {
			try {
				_appDbContext.Entry(obj).State = EntityState.Modified;
				await _appDbContext.SaveChangesAsync();
			} catch(Exception) {
				throw;
			}
		}

		public async Task Delete(Cliente obj) {
			try {
				_appDbContext.Clientes.Remove(obj);
				await _appDbContext.SaveChangesAsync();

			} catch(Exception) {
				throw;
			}
		}

	}
}

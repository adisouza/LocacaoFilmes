using LocacaoFilmes.Data;
using LocacaoFilmes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocacaoFilmes.Services {
	public class LocacaoServices: IGenericService<Locacao> {
		private readonly AppDbContext _appDbContext;

		public LocacaoServices(AppDbContext context) {
			_appDbContext = context;
		}

		public async Task<IEnumerable<Locacao>> GetAll() {
			try {
				return await _appDbContext.Locacoes.ToListAsync();

			} catch(Exception) {
				throw;
			}
		}

		public async Task<Locacao> Get(int Id) {
			try {
				return await _appDbContext.Locacoes.FindAsync(Id);

			} catch(Exception) {
				throw;
			}
		}

		public async Task Insert(Locacao obj) {
			try {
				_appDbContext.Locacoes.Add(obj);
				await _appDbContext.SaveChangesAsync();

			} catch(Exception) {
				throw;
			}
		}

		public async Task Update(Locacao obj) {
			try {
				_appDbContext.Entry(obj).State = EntityState.Modified;
				await _appDbContext.SaveChangesAsync();
			} catch(Exception) {
				throw;
			}
		}

		public async Task Delete(Locacao obj) {
			try {
				_appDbContext.Locacoes.Remove(obj);
				await _appDbContext.SaveChangesAsync();

			} catch(Exception) {
				throw;
			}
		}

	}
}

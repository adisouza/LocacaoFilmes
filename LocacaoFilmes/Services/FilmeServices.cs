using LocacaoFilmes.Data;
using LocacaoFilmes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocacaoFilmes.Services {
	public class FilmeServices: IGenericService<Filme> {
		private readonly AppDbContext _appDbContext;

		public FilmeServices(AppDbContext context) {
			_appDbContext = context;
		}

		public async Task<IEnumerable<Filme>> GetAll() {
			try {
				return await _appDbContext.Filmes.ToListAsync();

			} catch(Exception) {
				throw;
			}
		}

		public async Task<Filme> Get(int Id) {
			try {
				return await _appDbContext.Filmes.FindAsync(Id);

			} catch(Exception) {
				throw;
			}
		}

		public async Task Insert(Filme obj) {
			try {
				_appDbContext.Filmes.Add(obj);
				await _appDbContext.SaveChangesAsync();

			} catch(Exception) {
				throw;
			}
		}

		public async Task Update(Filme obj) {
			try {
				_appDbContext.Entry(obj).State = EntityState.Modified;
				_appDbContext.Filmes.Update(obj);
				await _appDbContext.SaveChangesAsync();
			} catch(Exception) {
				throw;
			}
		}

		public async Task Delete(Filme obj) {
			try {
				_appDbContext.Filmes.Remove(obj);
				await _appDbContext.SaveChangesAsync();

			} catch(Exception) {
				throw;
			}
		}

	}
}

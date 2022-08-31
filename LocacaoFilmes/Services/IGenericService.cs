using LocacaoFilmes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocacaoFilmes.Services {
	public interface IGenericService<T>  {
		Task<IEnumerable<T>> GetAll();
		Task<T> Get(int Id);
		Task Insert(T obj);
		Task Update(T obj);
		Task Delete(T obj);
	}
}

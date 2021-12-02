using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ordering.Domain.Common;

namespace Ordering.Application.Contracts.Persistence
{
	public interface IAsyncRepository<T> where T : EntityBase
	{
		// get alt metode async
		Task<IReadOnlyList<T>> GetAllAsync();
		// get metode, der tager parameters  
		Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);
		// samme måde som - forventer orderby 
		Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
										Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
										string includeString = null,
										bool disableTracking = true);
		// kan bruge includes 
		Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
									   Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
									   List<Expression<Func<T, object>>> includes = null,
									   bool disableTracking = true);
		// get ud fra id
		Task<T> GetByIdAsync(int id);
		// sidste 3 er for crud - opdater, opret og slet (standard)
		Task<T> AddAsync(T entity);
		Task UpdateAsync(T entity);
		Task DeleteAsync(T entity);
	}
}

using EffortEntry.Repository.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace EffortEntry.Repository.Repositories.Base
{
	public class Repository<T> : IRepository<T>
			where T : class
	{
		internal readonly DbContext _dbContext;

		public Repository(DbContext context)
		{
			_dbContext = context;
		}

		public T Create(T entity)
		{
			try
			{
				if (entity is IBaseEntity)
					(entity as IBaseEntity).CreatedDate = DateTime.Now;

				var result = _dbContext.Set<T>().Add(entity).Entity; //Changed in EF core
				return result;
			}
			catch
			{
				throw;
			}
		}

		public T FindByKey(int id)
		{
			try
			{
				var result = _dbContext.Set<T>().Find(id); // this checks the cache before database
				return result;
			}
			catch
			{
				throw;
			}
		}

		public void Delete(T entity)
		{
			try
			{
				_dbContext.Set<T>().Remove(entity);
				_dbContext.Entry(entity).State = EntityState.Deleted;
			}
			catch
			{
				throw;
			}
		}

		public IEnumerable<T> All()
		{
			try
			{
				return _dbContext.Set<T>().AsNoTracking().ToList();
			}
			catch
			{
				throw;
			}
		}

		public void Update(T entity)
		{
			try
			{
				if (entity is IBaseEntity)
					(entity as IBaseEntity).ModifiedDate = DateTime.Now;

				_dbContext.Set<T>().Attach(entity);
				_dbContext.Entry(entity).State = EntityState.Modified;
			}
			catch
			{
				throw;
			}
		}

		public void Attach(T entity)
		{
			try
			{
				_dbContext.Set<T>().Attach(entity);
			}
			catch
			{
				throw;
			}
		}

		public virtual IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate, string[] includes = null)
		{
			if (includes == null || !includes.Any())
				return _dbContext.Set<T>().Where(predicate);

			var query = _dbContext.Set<T>().Include(includes.First());
			query = includes.Skip(1).Aggregate(query, (current, include) => current.Include(include));
			return query.Where(predicate);
		}

		public virtual IEnumerable<T> FindByNoTracking(Expression<Func<T, bool>> predicate, string[] includes = null)
		{
			if (includes == null || !includes.Any())
				return _dbContext.Set<T>().Where(predicate);

			var query = _dbContext.Set<T>().AsNoTracking().Include(includes.First());
			query = includes.Skip(1).Aggregate(query, (current, include) => current.Include(include));
			return query.Where(predicate);
		}

		public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
		{
			try
			{
				return _dbContext.Set<T>().AsNoTracking().Where(predicate).ToList();
			}
			catch
			{
				throw;
			}
		}

		public void Save()
		{
			try
			{
				_dbContext.SaveChanges();
			}
			catch (Exception ex)
			{
				var properties = ex.GetType().GetProperties();

				foreach (PropertyInfo p in properties)
				{
					if (p.Name == "Entries")
					{
						var entities = (IEnumerable<EntityEntry>)p.GetValue(ex, null);

						foreach (var entity in entities)
						{
							switch (entity.State)
							{
								case EntityState.Added:
									entity.State = EntityState.Detached;
									break;
								case EntityState.Modified:
									entity.CurrentValues.SetValues(entity.OriginalValues);
									entity.State = EntityState.Unchanged;
									break;
								case EntityState.Deleted:
									entity.State = EntityState.Unchanged;
									break;
							}
						}
					}
				}

				throw;
			}
		}
	}
}

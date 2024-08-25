using EffortEntry.Repository.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffortEntry.Repository.Repositories.Base
{
	public class UnitOfWork : IUnitOfWork
	{
		private DbContext _dbContext;

		public UnitOfWork(DbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public void CommitTransaction()
		{
			_dbContext.Database.CurrentTransaction.Commit();
		}

		public void RollbackTransaction()
		{
			if (_dbContext.Database.CurrentTransaction != null)
				_dbContext.Database.CurrentTransaction.Rollback();
		}

		public void StartTransaction()
		{
			_dbContext.Database.BeginTransaction();
		}

		public void SaveChanges()
		{
			_dbContext.SaveChanges();
		}

		public void Dispose()
		{
			if (_dbContext.Database.CurrentTransaction != null)
				_dbContext.Database.CurrentTransaction.Dispose();
		}
	}
}

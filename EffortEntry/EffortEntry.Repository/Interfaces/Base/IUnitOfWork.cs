using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffortEntry.Repository.Interfaces.Base
{
	public interface IUnitOfWork : IDisposable
	{
		void StartTransaction();
		void CommitTransaction();
		void RollbackTransaction();
		void SaveChanges();
	}
}

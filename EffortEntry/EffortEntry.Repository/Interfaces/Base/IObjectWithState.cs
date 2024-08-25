using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffortEntry.Repository.Interfaces.Base
{
	public interface IObjectWithState
	{
		ObjectState ObjectState { get; set; }
	}

	public enum ObjectState
	{
		Unchanged,
		Added,
		Modified,
		Deleted
	}
}

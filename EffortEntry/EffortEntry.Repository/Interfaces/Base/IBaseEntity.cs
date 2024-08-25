using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffortEntry.Repository.Interfaces.Base
{
	public interface IBaseEntity
	{
		DateTime CreatedDate { get; set; }
		DateTime? ModifiedDate { get; set; }
		int? CreatedBy { get; set; }
		int? ModifiedBy { get; set; }
	}
}

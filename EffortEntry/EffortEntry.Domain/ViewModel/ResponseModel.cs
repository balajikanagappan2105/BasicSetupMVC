using EffortEntry.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffortEntry.Domain.ViewModel
{
	public class ResponseModel
	{
		public string ResponseStatus { get; set; }
		public User User { get; set; }
	}
}

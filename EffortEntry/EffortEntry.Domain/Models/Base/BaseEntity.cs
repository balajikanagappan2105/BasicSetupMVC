﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffortEntry.Domain.Models.Base
{
	public class BaseEntity
	{
		public int? CreatedBy { get; set; }
		public DateTime CreatedDate { get; set; }
		public int? ModifiedBy { get; set; }
		public DateTime? ModifiedDate { get; set; }
	}
}

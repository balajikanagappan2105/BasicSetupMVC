﻿using EffortEntry.Domain.Enums;
using EffortEntry.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffortEntry.Domain.Models
{
	public class User : BaseEntity
	{
		public int Id { get; set; }
		public Guid ActivationId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
		public bool IsActive { get; set; }
		public bool IsRegistered { get; set; }
		public int? ClientId { get; set; }
		public int? EmployeeId { get; set; }
		public string MobileNumber { get; set; }
		public bool IsDeleted { get; set; }
		public Guid AuthClientId { get; set; }
		public int AuthorizedClientId { get; set; }
		public DateTime? LastLoginDate { get; set; }
		public DateTime? HipaaAcceptedOn { get; set; }
		public bool EnableTwoFactorAuthentication { get; set; }
		public string TwoFactorOTP { get; set; }
		public DateTime? TwoFactorOTPDate { get; set; }
		public int? TwoFactorOTPFailedCount { get; set; }
		public bool IsCreatedByAuditor { get; set; }
		public bool IsSSOUser { get; set; }
		public bool IsModifiedByAuditor { get; set; }
		public ObjectState ObjectState { get; set; }		
	}
}

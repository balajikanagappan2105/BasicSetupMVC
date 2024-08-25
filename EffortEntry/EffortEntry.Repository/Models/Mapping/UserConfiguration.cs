using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffortEntry.Repository.Models.Mapping
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.ToTable("Users", "Auth");

			builder.Property(t => t.FirstName)
				.HasMaxLength(100)
				.IsRequired();

			builder.Property(t => t.LastName)
				.HasMaxLength(100)
				.IsRequired();

			builder.Property(t => t.UserName)
				.HasMaxLength(100)
				.IsRequired();

			builder.Property(t => t.Password)
				.HasMaxLength(100)
				.IsRequired();

			builder.Property(t => t.Email)
				.HasMaxLength(100)
				.IsRequired();

			builder.Property(t => t.EmployeeId)
				.IsRequired(false);

			builder.Property(t => t.MobileNumber)
				.HasMaxLength(50)
				.IsRequired(false);

			builder.Property(t => t.IsActive)
				.IsRequired();

			builder.Property(t => t.IsRegistered)
				.IsRequired();

			builder.Property(t => t.AuthorizedClientId)
				.IsRequired();

			builder.Property(t => t.EnableTwoFactorAuthentication)
				.IsRequired();

			builder.Property(t => t.TwoFactorOTP)
				.HasMaxLength(10)
			   .IsRequired(false);

			builder.Property(t => t.TwoFactorOTPDate)
			   .IsRequired(false);

			builder.Property(t => t.TwoFactorOTPFailedCount)
			   .IsRequired(false);

			builder.Property(t => t.IsCreatedByAuditor)
				   .IsRequired();

			builder.Property(t => t.IsSSOUser)
				   .IsRequired();
		}
	}
}

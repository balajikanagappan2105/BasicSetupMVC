using EffortEntry.Repository.Models.Mapping;
using Microsoft.EntityFrameworkCore;

namespace EffortEntry.Repository.DBContexts
{
	public partial class DBContext : DbContext
	{
		public DBContext(DbContextOptions<DBContext> options)
			: base(options)
		{

		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer("Data Source=SANDCASTLE01;Initial Catalog=AuthTest;Persist Security Info=True;User ID=VerificationServicesAPIUser;Password=Q@#ESZAW7;MultipleActiveResultSets=True;TrustServerCertificate=True;");
			}
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new UserConfiguration());
		}
	}
}

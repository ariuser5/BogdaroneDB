using System.Data.Entity;

namespace DbAccess
{
	public class BogdaroneDbContext: DbContext
	{
		public DbSet<User> Users { get; set; }
	}

}

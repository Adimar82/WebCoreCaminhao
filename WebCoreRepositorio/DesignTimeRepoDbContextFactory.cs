using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WebCoreRepositorio
{
	public class DesignTimeRepoDbContextFactory : IDesignTimeDbContextFactory<PersistDbContext>
	{
		public PersistDbContext CreateDbContext(string[] args)
		{
			var builder = new DbContextOptionsBuilder<PersistDbContext>();
			var connectionString = "Server=localhost;Port=3306;User ID=caminhaouser;Password=a123456b;Database=caminhaobd";
			builder.UseMySql(connectionString);
			return new PersistDbContext(builder.Options);
		}
	}
}

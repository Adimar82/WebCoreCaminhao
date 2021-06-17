using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebCoreRepositorio.DBModel;

namespace WebCoreRepositorio
{
	public class PersistDbContext : DbContext
	{
		public PersistDbContext(DbContextOptions<PersistDbContext> options) : base(options)
		{
		}

		public DbSet<Caminhao> Caminhao { get; set; }
	}
}

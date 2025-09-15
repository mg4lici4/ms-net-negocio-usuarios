using Microsoft.EntityFrameworkCore;

namespace ms_net_store_usuarios.DBContext;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}

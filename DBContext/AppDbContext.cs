using Microsoft.EntityFrameworkCore;

namespace UsuariosApi.DBContext;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}

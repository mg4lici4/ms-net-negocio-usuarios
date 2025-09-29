using Microsoft.EntityFrameworkCore;
using UsuariosApi.Models.Entities;

namespace UsuariosApi.DBContext;

public class AppDbContext: DbContext
{
    public  DbSet<UsuarioEntity> Usuarios { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasSequence<long>("Seq_Usuario_Id")
                .StartsAt(1)
                .IncrementsBy(1);

        modelBuilder.Entity<UsuarioEntity>(entity =>
        {
            entity.ToTable("Usuario");
            entity.HasKey(e => e.IdUsuario);
            entity.Property(e => e.IdUsuario)
                  .HasDefaultValueSql("NEXT VALUE FOR Seq_Usuario_Id");
            entity.Property(e => e.Nombre)
                  .IsRequired()
                  .HasMaxLength(100);
            entity.Property(e => e.Contrasenia)
                  .IsRequired()
                  .HasMaxLength(256);
            entity.Property(e => e.IdAplicacion)
                  .IsRequired();
            entity.Property(e => e.FechaRegistro)
                  .HasDefaultValueSql("GETDATE()");
            entity.Property(e => e.FechaModificacion);
        });

    }
}

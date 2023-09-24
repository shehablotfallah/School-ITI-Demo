namespace Demo02.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseSqlServer("Server=.;Database=iti;Trusted_connection=True;");
        //base.OnConfiguring(optionsBuilder);
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Department> Departments { get; set; }
}

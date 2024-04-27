using FileUpload.Models;

namespace FileUpload.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
           : base(options)
        {

        }

        public DbSet<Project > Projects { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<Models.File> Files { get; set; }
    }
}

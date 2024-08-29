using Microsoft.EntityFrameworkCore;

namespace BaoTran.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }

        #region DbSet
        public DbSet<FileType> FileTypes { get; set; }
        public DbSet<MediaFile> MediaFiles { get; set; }
        public DbSet<PlaySchedual> PlayScheduals { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //MediaFile
            modelBuilder.Entity<MediaFile>()
                .HasOne(f => f.FileType)
                .WithMany(i => i.MediaFiles)
                .HasForeignKey(i => i.IdFileType)
                .OnDelete(DeleteBehavior.Cascade);

            //PlaySchedual
            modelBuilder.Entity<PlaySchedual>()
                .HasOne(g => g.MediaFile)
                .WithMany(i => i.PlayScheduals)
                .HasForeignKey(g => g.IdMediaFile)
                .OnDelete(DeleteBehavior.Cascade);

        }


    }
}

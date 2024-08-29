using BaoTran.Data;
using BaoTran.ReRepository;
using Microsoft.EntityFrameworkCore.Storage;

namespace BaoTran.Repository
{
    public interface IRepositoryWrapper
    {
        IRepositoryBase<FileType> FileTypes { get; }
        IRepositoryBase<MediaFile> MediaFiles { get; }
        IRepositoryBase<PlaySchedual> PlayScheduals { get; }


        Task SaveChangeAsync();
        Task<IDbContextTransaction> BeginTransactionAsync();
    }

    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly MyDbContext db;

        public RepositoryWrapper(MyDbContext db)
        {
            this.db = db;
        }


        private IRepositoryBase<FileType> FileTypesRepositoryBase;
        public IRepositoryBase<FileType> FileTypes => FileTypesRepositoryBase ??= new RepositoryBase<FileType>(db);


        private IRepositoryBase<MediaFile> MediaFilesRepositoryBase;
        public IRepositoryBase<MediaFile> MediaFiles => MediaFilesRepositoryBase ??= new RepositoryBase<MediaFile>(db);


        private IRepositoryBase<PlaySchedual> PlaySchedualsRepositoryBase;
        public IRepositoryBase<PlaySchedual> PlayScheduals => PlaySchedualsRepositoryBase ??= new RepositoryBase<PlaySchedual>(db);


        public async Task SaveChangeAsync()
        {
            await db.SaveChangesAsync();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await db.Database.BeginTransactionAsync();
        }
    }
}

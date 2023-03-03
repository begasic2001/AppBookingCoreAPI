using LearnAPI.Models;

namespace TourBooking.Helpers
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TourDatabaseContext _context;

        public UnitOfWork(TourDatabaseContext context)
        {
            _context = context;
        }
        public Task<int> SaveChangesAsync(CancellationToken cancellation = default)
        {
            return _context.SaveChangesAsync(cancellation);
        }
    }
}

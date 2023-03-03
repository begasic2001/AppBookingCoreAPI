namespace TourBooking.Helpers
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellation= default);
    }
}

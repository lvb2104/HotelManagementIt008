namespace HotelManagementIt008.Repositories.Interfaces
{
    // Define methods specific to Params entity
    public interface IParamsRepository : IRepository<Params>
    {
        Task<Params?> GetByKeyAsync(string key);
        Task<IEnumerable<Params>> GetAllOrderedByCreatedAtAsync();
        Task<IEnumerable<Params>> GetHistoryOrderedByCreatedAtAsync();
    }
}

namespace HotelManagementIt008.Services.Interfaces
{
    public interface IParamService
    {
        Task<Result<Params>> GetParamByKeyAsync(string key);
        Task<Result<IEnumerable<Params>>> GetAllParamsAsync();
        Task<Result<IEnumerable<Params>>> GetParamsHistoryAsync();
        Task<Result<IEnumerable<Params>>> UpdateParamAsync(string key, UpdateParamDto dto);
    }
}

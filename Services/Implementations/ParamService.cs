namespace HotelManagementIt008.Services.Implementations
{
    public class ParamService : IParamService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ParamService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Params>> GetParamByKeyAsync(string key)
        {
            try
            {
                var param = await _unitOfWork.ParamsRepository.GetByKeyAsync(key);

                if (param == null)
                {
                    return Result<Params>.Failure($"Param with name {key} not found");
                }

                return Result<Params>.Success(param);
            }
            catch (Exception ex)
            {
                return Result<Params>.Failure($"Error retrieving param: {ex.Message}");
            }
        }

        public async Task<Result<IEnumerable<Params>>> GetAllParamsAsync()
        {
            try
            {
                var paramsList = await _unitOfWork.ParamsRepository.GetAllOrderedByCreatedAtAsync();

                return Result<IEnumerable<Params>>.Success(paramsList);
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<Params>>.Failure($"Error retrieving params: {ex.Message}");
            }
        }

        public async Task<Result<IEnumerable<Params>>> GetParamsHistoryAsync()
        {
            try
            {
                var paramsList = await _unitOfWork.ParamsRepository.GetHistoryOrderedByCreatedAtAsync();

                return Result<IEnumerable<Params>>.Success(paramsList);
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<Params>>.Failure($"Error retrieving params history: {ex.Message}");
            }
        }

        public async Task<Result<IEnumerable<Params>>> UpdateParamAsync(string key, UpdateParamDto dto)
        {
            try
            {
                var existingParam = await _unitOfWork.ParamsRepository.GetByKeyAsync(key);

                if (existingParam == null)
                {
                    return Result<IEnumerable<Params>>.Failure($"Param with name {key} not found");
                }

                // Create new param with same key and description, but new value
                var newParam = new Params
                {
                    Key = existingParam.Key,
                    Value = dto.Value,
                    Description = existingParam.Description,
                    // CreatedAt will be set by DbContext
                };

                // Soft delete existing
                await _unitOfWork.ParamsRepository.RemoveAsync(existingParam);

                // Add new
                await _unitOfWork.ParamsRepository.AddAsync(newParam);

                // Save changes (atomic transaction)
                await _unitOfWork.SaveAsync();

                // Return the updated list of params
                return await GetAllParamsAsync();
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<Params>>.Failure($"Error updating param: {ex.Message}");
            }
        }
    }
}

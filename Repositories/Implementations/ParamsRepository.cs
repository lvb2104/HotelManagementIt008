namespace HotelManagementIt008.Repositories.Implementations
{
    public class ParamsRepository : Repository<Params>, IParamsRepository
    {
        public ParamsRepository(HotelManagementDbContext context) : base(context)
        {

        }
    }
}

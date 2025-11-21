namespace HotelManagementIt008.Repositories
{
    public class ParamsRepository : Repository<Params>, IParamsRepository
    {
        public ParamsRepository(HotelManagementDbContext context) : base(context)
        {

        }
    }
}

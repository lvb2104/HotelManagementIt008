namespace HotelManagementIt008.Repositories
{
    public class ParamsRepository : GenericRepository<Params>, IParamsRepository
    {
        public ParamsRepository(HotelManagementDbContext context) : base(context)
        {

        }
    }
}

namespace HotelManagementIt008.Repositories
{
    internal class ParamsRepository : GenericRepository<Params>, IParamsRepository
    {
        public ParamsRepository(HotelManagementDbContext context) : base(context)
        {

        }
    }
}

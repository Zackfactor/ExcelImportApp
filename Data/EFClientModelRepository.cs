using ExcelImportApp.Model;

namespace ExcelImportApp.Data
{
    public class EFClientModelRepository : RepositoryBase<ClientModel>, IClientModelRepository
    {
        public EFClientModelRepository(ExcelImportAppContext context) : base(context)
        {
        }
    }
}

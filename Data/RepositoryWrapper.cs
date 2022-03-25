namespace ExcelImportApp.Data
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ExcelImportAppContext _appContext;
        private IClientModelRepository _clientModel;

        public RepositoryWrapper(ExcelImportAppContext appContext)
        {
            _appContext = appContext;
        }

        public IClientModelRepository clientModel
        {
            get
            {
                if (_clientModel== null)
                {
                    _clientModel = new EFClientModelRepository(_appContext);
                }

                return _clientModel;
            }
        }
    }
}

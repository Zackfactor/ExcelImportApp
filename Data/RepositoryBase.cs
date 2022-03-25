namespace ExcelImportApp.Data
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ExcelImportAppContext _context;
        public RepositoryBase(ExcelImportAppContext context)
        {
            _context = context;
        }
        public IEnumerable<T> FindAll()
        {
            return _context.Set<T>();
        }
    }
}

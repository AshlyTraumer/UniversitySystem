using ClassLibrary;

namespace UniversitySystem.ExportDatabaseManager
{
    public class ExportDatabaseManager<T> where T: BaseEntity
    {
        private RepositoryContext _context;
        public ExportDatabaseManager(RepositoryContext context)
        {
            _context = context;
        }
    }
}
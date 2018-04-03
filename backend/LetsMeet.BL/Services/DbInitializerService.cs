using LetsMeet.BL.Interfaces;
using LetsMeet.DA.Interfaces;

namespace LetsMeet.BL.Services
{
    public class DbInitializerService : IDbInitializerService
    {
        private readonly IDbInitializer _dbInitializer;

        public DbInitializerService(IDbInitializer dbInitializer)
        {
            _dbInitializer = dbInitializer;
        }

        public void Seed()
        {
            _dbInitializer.Seed();
        }
    }
}

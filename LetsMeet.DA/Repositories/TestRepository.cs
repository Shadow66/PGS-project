using LetsMeet.DA.Interfaces;

namespace LetsMeet.DA.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly ApplicationDbContext _context;

        public TestRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public int TestGet()
        {
            return 4;
        }
    }
}

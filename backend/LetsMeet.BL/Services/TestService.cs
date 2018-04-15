using LetsMeet.BL.Interfaces;
using LetsMeet.DA.Interfaces;

namespace LetsMeet.BL.Services
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;

        public TestService(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        public int TestGet()
        {
            return _testRepository.TestGet();
        }
    }
}

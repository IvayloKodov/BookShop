using AutoMapper;
using BookShop.Api.Infrastructure.Mapping;

namespace BookShop.Tests
{
    public class TestsInit
    {
        private static bool _testsInitialized = false;

        public static void Initialize()
        {
            if (!_testsInitialized)
            {
                Mapper.Initialize(config => config.AddProfile<AutoMapperProfile>());
                _testsInitialized = true;
            }
        }
    }
}

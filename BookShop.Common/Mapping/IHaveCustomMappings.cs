namespace BookShop.Common.Mapping
{
    using AutoMapper;

    public interface IHaveCustomMappings
    {
        void ConfigureMapping(Profile mapper);
    }
}
using AutoMapper;
using eTable.Application.Configs;

namespace CommonTestUtilities.Builders.Configs
{
    public class MapperBuilder
    {
        public static IMapper Build()
        {
            return new MapperConfiguration(options =>
            {
                options.AddProfile(new MappingConfig());
            }).CreateMapper();
        }
    }
}

using AutoMapper;
using System.Diagnostics.CodeAnalysis;

namespace Bank.Application.Mapping
{
    [ExcludeFromCodeCoverage]
    public class AutoMapperInitializer
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfiles(typeof(AutoMapperInitializer));
            });
        }

        public static void Reset()
        {
            Mapper.Reset();
        }
    }
}

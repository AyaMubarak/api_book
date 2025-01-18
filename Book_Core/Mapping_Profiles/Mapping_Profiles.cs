using Book_Core.DTO_s;
using Book_Core.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Core.Mapping_Profiles
{
    public class Mapping_Profiles
    {
        private static readonly TypeAdapterConfig _config = new TypeAdapterConfig();
        static Mapping_Profiles()
        {
            _config.NewConfig<Iteams, IteamDTO>()
                .Map(dest => dest.IteamsUnit, src => src.IteamsUnites.Select(unit => unit.Units.Name.ToList()))
                .Map(dest => dest.Stores, src => src.InvIteamStores.Select(store => store.Stores.Name.ToList()));
        }
        public static TypeAdapterConfig Config => _config;

    }

}

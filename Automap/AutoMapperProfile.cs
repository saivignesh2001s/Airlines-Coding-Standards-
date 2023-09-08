using Airlines.Model;
using AutoMapper;

namespace Airlines.Automap
{
    public class AutoMapperProfile:Profile
    {
      public AutoMapperProfile() 
        { 
         CreateMap<Airline,AirlinesMapper>().ReverseMap();
        }
    }
}

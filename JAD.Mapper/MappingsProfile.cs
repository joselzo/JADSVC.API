using AutoMapper;
using JAD.Data.DataDB;
using JAD.Models;

namespace JAD.Mapper
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Feature, FeatureDTO>().ReverseMap();
            CreateMap<Service, ServiceDTO>().ReverseMap();
            CreateMap<ServiceLevel, ServiceLevelDTO>().ReverseMap();
            CreateMap<ServiceOrder, ServiceOrderDTO>().ReverseMap();
            CreateMap<StateChange, StateChangeDTO>().ReverseMap();
            CreateMap<UserFeature, UserFeatureDTO>().ReverseMap();
        }
    }
}
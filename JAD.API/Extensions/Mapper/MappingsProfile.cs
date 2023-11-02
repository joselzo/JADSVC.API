using AutoMapper;
using JADSVC.Data.DataDB;
using JADSVC.Data.DataDB.StoreProcedure;
using JADSVC.Models;
using JADSVC.Models.StoreProcedures.ServiceFeatureModel;
using JADSVC.Models.StoreProcedures.spGetServiceOrderByIdUser;
using JADSVC.Models.StoreProcedures.UserSP;

namespace JAD.API.Extensions.Mapper
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            //TABLES
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Feature, FeatureDTO>().ReverseMap();
            CreateMap<Service, ServiceDTO>().ReverseMap();
            CreateMap<ServiceLevel, ServiceLevelDTO>().ReverseMap();
            CreateMap<ServiceOrder, ServiceOrderDTO>().ReverseMap();
            CreateMap<StateChange, StateChangeDTO>().ReverseMap();
            CreateMap<UserFeature, UserFeatureDTO>().ReverseMap();

            //STORED PROCEDURES
            CreateMap<SPGetUser, SPGetUserDTO>().ReverseMap();
            CreateMap<spgetLevelsandFeatures, spgetLevelsandFeaturesDTO>().ReverseMap();
            CreateMap<SPGetFeatureByIdUser, SPGetFeatureByIdUserDTO>().ReverseMap();
            CreateMap<spGetServiceOrderByIdUser, spGetServiceOrderByIdUserDTO>().ReverseMap();
        }
    }
}
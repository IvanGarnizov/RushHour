namespace RushHour.App.App_Start
{
    using AutoMapper;

    using Entities;

    using Models.ViewModels;

    public class MapperConfig
    {
        public static void RegisterMappngs()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Appointment, AppointmentViewModel>();
                cfg.CreateMap<User, UserViewModel>()
                    .ForMember("Name", opt => opt.MapFrom(u => u.UserName))
                    .ForMember("Phone", opt => opt.MapFrom(u => u.PhoneNumber));
            });
        }
    }
}
using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() {
            CreateMap<Activity, Activity>(); // Maps Type Activity you fetched to Type Activity in DB, so it doesn't become redundant.
        }
    }
}
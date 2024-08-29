using AutoMapper;
using BaoTran.Data;
using BaoTran.Models;


namespace BaoTran.Mappers
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<MediaFileRequest, MediaFile>().ReverseMap();

            CreateMap<MediaFile, MediaFileResponse>().ReverseMap();


            CreateMap<PlaySchedualRequest, PlaySchedual>().ReverseMap();

            CreateMap<PlaySchedual, PlaySchedualResponse>().ReverseMap();

        }
    }
}

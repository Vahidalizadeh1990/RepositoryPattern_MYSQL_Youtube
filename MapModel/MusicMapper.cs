using AutoMapper;
using RepositoryPattern_MySQL_Youtube.Models;
using RepositoryPattern_MYSQL_Youtube.DTO;

namespace RepositoryPattern_MYSQL_Youtube.MapModel
{
    public class MusicMapper : Profile
    {
        public MusicMapper()
        {
            // ===> Source ==> target
            CreateMap<Music,MusicDTO>();
            CreateMap<MusicDTO,Music>();
        }
    }
}
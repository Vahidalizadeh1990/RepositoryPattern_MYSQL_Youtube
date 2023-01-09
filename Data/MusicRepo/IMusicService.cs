using RepositoryPattern_MySQL_Youtube.Models;

namespace RepositoryPattern_MYSQL_Youtube.Data.MusicRepo
{
    public interface IMusicService
    {
        Task<Music> AddMusic(Music music);
        Task<Music> EditMusic(Music music);
        bool DeleteMusic(string id);
        IEnumerable<Music> ListMusic();
        Music DetailsMusic(string id);
    }
}
using RepositoryPattern_MySQL_Youtube.Models;

namespace RepositoryPattern_MYSQL_Youtube.Data.MusicRepo
{
    public class MusicService : IMusicService
    {
        private readonly AppDbContext _dbContext;

        // Constructor
        public MusicService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Add a Music
        public async Task<Music> AddMusic(Music music)
        {
            if(music is not null)
            {
                music.Id = Guid.NewGuid().ToString();
                await _dbContext.Music.AddAsync(music);
                await _dbContext.SaveChangesAsync();
            }
            return music;
        }

        // Details a music
        public Music DetailsMusic(string id)
        {
            return _dbContext.Music.FirstOrDefault(m=>m.Id == id);
        }
        // Delete a music
        public bool DeleteMusic(string id)
        {
            var music = DetailsMusic(id);
            if(music is not null)
            {
                _dbContext.Music.Remove(music);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
        
        // Edit a music based on the Id
        public async Task<Music> EditMusic(Music music)
        {
            var musicDetails = DetailsMusic(music.Id);
            if(musicDetails is not null)
            {
                // We can use any mapping function or libraries like Automapper or Mapster
                // Automapper will be used inside the controller
                musicDetails.Title = music.Title;
                musicDetails.ReleaseDate = music.ReleaseDate;
                musicDetails.Artist = music.Artist;
                musicDetails.Rate = music.Rate;
                await _dbContext.SaveChangesAsync();
            }
            return musicDetails;
        }

        // List of all music
        public IEnumerable<Music> ListMusic()
        {
            return _dbContext.Music.OrderByDescending(m=>m.ReleaseDate).ToList();
        }
    }
}
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern_MySQL_Youtube.Models;
using RepositoryPattern_MYSQL_Youtube.Data.MusicRepo;
using RepositoryPattern_MYSQL_Youtube.DTO;

namespace RepositoryPattern_MYSQL_Youtube.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MusicController : ControllerBase
    {
        private readonly IMusicService _musicService;
        private readonly IMapper _mapper;

        public MusicController(IMusicService musicService, IMapper mapper)
        {
            _musicService = musicService;
            _mapper = mapper;
        }

        // This action will return all music as a list object 
        [HttpGet]
        public IActionResult Gets()
        {
            var model = _musicService.ListMusic();
            if (model.Any())
            {
                // Mapping model is a mandatory section to pass the result to the client
                // Never ever pass the base model to the client.
                // That is the main reason that we have to using Automapper or any kind of mapping inside an application
                // IEnumerable has been used due to the return object that is a list of all music
                return StatusCode(StatusCodes.Status200OK, _mapper.Map<IEnumerable<MusicDTO>>(model));
            }
            return StatusCode(StatusCodes.Status204NoContent);
        }

        // This action will return a music based on the id that comes through the API request url
        [HttpGet("Details")]
        public IActionResult Get(string id)
        {
            var model = _musicService.DetailsMusic(id);
            if (model is not null)
            {
                return StatusCode(StatusCodes.Status200OK, _mapper.Map<MusicDTO>(model));
            }
            return StatusCode(StatusCodes.Status404NotFound);
        }

        // This action will return a new music 
        [HttpPost]
        public async Task<IActionResult> Post(MusicDTO musicDTO)
        {
            // Map the model to able the post request to pass a model based on the Music model
            var mapModel = _mapper.Map<Music>(musicDTO);
            var newmusic = await _musicService.AddMusic(mapModel);
            if (newmusic is not null)
            {
                // To pass the new music that has been added, mapping model is a require section of all part of an API
                // When you want pass the result value to the client
                return StatusCode(StatusCodes.Status201Created, _mapper.Map<MusicDTO>(newmusic));
            }
            return StatusCode(StatusCodes.Status400BadRequest);
        }

        // This action will retrun an updated music
        [HttpPut]
        public async Task<IActionResult> Put(MusicDTO musicDTO)
        {
            // Map the model to able the post request to pass a model based on the Music model
            var mapModel = _mapper.Map<Music>(musicDTO);
            var newmusic = await _musicService.EditMusic(mapModel);
            if (newmusic is not null)
            {
                // To pass the new music that has been added, mapping model is a require section of all part of an API
                // When you want pass the result value to the client
                return StatusCode(StatusCodes.Status200OK, _mapper.Map<MusicDTO>(newmusic));
            }
            return StatusCode(StatusCodes.Status400BadRequest);
        }

        // This action will remove a music
        [HttpDelete]
        public IActionResult Delete(string id)
        {
            var music = _musicService.DeleteMusic(id);
            if (music is true)
            {
                return StatusCode(StatusCodes.Status200OK);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
    }
}
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entities;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/bands/{bandID}/albums")]
    public class AlbumsController : ControllerBase
    {
        private readonly IBandAlbumRepository _bandAlbumRepository;
        private readonly IMapper _mapper;

        public AlbumsController(IBandAlbumRepository bandAlbumRepository, IMapper mapper)
        {
            _bandAlbumRepository = bandAlbumRepository ?? throw new ArgumentNullException(nameof(bandAlbumRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public ActionResult<IEnumerable<AlbumDTO>> GetAlbumsForABand(int bandID)
        {
            if(!_bandAlbumRepository.BandExists(bandID))
            {
                return NotFound();
            }

            var albumsFromRepo = _bandAlbumRepository.GetAlbumsForABand(bandID);

            return Ok(_mapper.Map<IEnumerable<AlbumDTO>>(albumsFromRepo));
        }

        [HttpGet("{albumID}", Name = "GetAlbumForABand")]
        public ActionResult<AlbumDTO> GetAlbumForABand(int bandID, int albumID)
        {
            if (!_bandAlbumRepository.BandExists(bandID))
            {
                return NotFound();
            }
            
            var albumFromRepo = _bandAlbumRepository.GetAlbumForABand(bandID, albumID);

            if(albumFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AlbumDTO>(albumFromRepo));
        }

        [HttpPost]
        public ActionResult<AlbumDTO> CreateAlbumForBand(int bandID,
            [FromBody] AlbumCreationDTO albumCreationDTO)
        {
            if(!_bandAlbumRepository.BandExists(bandID))
            {
                return NotFound();
            }

            var albumEntityMapped = _mapper.Map<Album>(albumCreationDTO);
            _bandAlbumRepository.AddAlbum(bandID, albumEntityMapped);
            _bandAlbumRepository.SaveChanges();

            var albumDTOMapped = _mapper.Map<AlbumDTO>(albumEntityMapped);
            return CreatedAtRoute("GetAlbumForABand", new { bandID = bandID, albumID = albumDTOMapped.AlbumID },
                albumDTOMapped);
        }
    }
}

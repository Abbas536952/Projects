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
    [Route("api/albumscollection/{bandID}")]
    public class AlbumCollectionController : ControllerBase
    {
        private readonly IBandAlbumRepository _bandAlbumRepository;
        private readonly IMapper _mapper;

        public AlbumCollectionController(IBandAlbumRepository bandAlbumRepository,
            IMapper mapper)
        {
            _bandAlbumRepository = bandAlbumRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult CreateAlbumCollection(int bandID, 
            [FromBody]IEnumerable<AlbumCreationDTO> albums)
        {
            if(!_bandAlbumRepository.BandExists(bandID))
            {
                return NotFound();
            }

            var albumEntities = _mapper.Map<IEnumerable<Album>>(albums);
            foreach(var album in albumEntities)
            {
                _bandAlbumRepository.AddAlbum(bandID, album);
            }
            _bandAlbumRepository.SaveChanges();

            return Ok();
        }
    }
}

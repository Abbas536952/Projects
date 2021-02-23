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
    [Route("api/bandscollection")]
    public class BandCollectionController : ControllerBase
    {
        private readonly IBandAlbumRepository _bandAlbumRepository;
        private readonly IMapper _mapper;

        public BandCollectionController(IBandAlbumRepository bandAlbumRepository, IMapper mapper)
        {
            _bandAlbumRepository = bandAlbumRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateBandsCollection([FromBody]
            IEnumerable<BandCreationDTO>bandsCollection)
        {
            var bandsCollectionMapped = _mapper.Map<IEnumerable<Band>>(bandsCollection);
            foreach(var band in bandsCollectionMapped)
            {
                _bandAlbumRepository.AddBand(band);
            }
            _bandAlbumRepository.SaveChanges();
            return Ok();
        }
    }
}

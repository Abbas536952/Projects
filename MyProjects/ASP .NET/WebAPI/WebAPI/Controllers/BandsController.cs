using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entities;
using WebAPI.Helpers;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/bands")]
    public class BandsController : ControllerBase //Normally we inherit from Controllers class but here we don't need extra functionalities in WebAPIs.
    {

        private readonly IBandAlbumRepository _bandAlbumRepository;
        private readonly IMapper _mapper;

        public BandsController(IBandAlbumRepository bandAlbumRepository, IMapper mapper)
        {
            _bandAlbumRepository = bandAlbumRepository ?? throw new ArgumentNullException(nameof(bandAlbumRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        //[HttpGet("api/bands")]

        [HttpGet("{bandID}", Name = "GetBand")] //Not mentioning route here as attribute because all calls will direct to api/bands.
        //public IActionResult GetBand(int bandID) //IActionResult's implementation is a better choice.
        public ActionResult<BandDTO> GetBand(int bandID) //ActionResult is better to use because it specifies the output type.
        {
            var bandFromRepo = _bandAlbumRepository.GetBand(bandID);

            //Adding this because Ok() will return 200 OK or No Content even if the band isn't found.
            if (bandFromRepo == null)
            {
                return NotFound();
            }

            //return new JsonResult(bandFromRepo); Not using this because JsonResult would not be suitable for XML and other formats..
            return Ok(_mapper.Map<BandDTO>(bandFromRepo));
        }

        //Just an example to show how HttpOptions works for different calls.
        [HttpOptions("{bandID}")]
        public IActionResult AddingOptions(int bandID)
        {
            Response.Headers.Add("OPTIONS", "GET,POST,HEAD");
            return Ok();
        }

        //[HttpGet]
        ////public IActionResult GetAllBands()
        //public ActionResult<IEnumerable<BandDTO>> GetAllBands()
        //{
        //    //This exception is for the purpose of checking exception handling.
        //    //throw new Exception("Testing 123...");

        //    var bandsFromRepo = _bandAlbumRepository.GetAllBands();

        //    //var bandDTOs = new List<BandDTO>(); //Will give output of Bands only with required output fields.
        //    //var currentDate = DateTime.Now;
        //    //foreach(var i in bandsFromRepo)
        //    //{
        //    //    bandDTOs.Add(new BandDTO()
        //    //    {
        //    //        ID = i.ID,
        //    //        Name = i.Name,
        //    //        FoundedYearsAgo = "Year " + i.Founded.ToString("yyyy") + 
        //    //                          " (" + (currentDate.Year - i.Founded.Year).ToString() + " Years Ago)",
        //    //        Genre = i.Genre
        //    //    });
        //    //}

        //    return Ok(_mapper.Map<IEnumerable<BandDTO>>(bandsFromRepo));
        //}

        [HttpGet]
        [HttpHead] //Displays information that might be useful for the user.
        //[FromQuery] is necessary to be mentioned when passing arguments that will come from a query
        //String and other basic types are automatically understood by application but complex types
        //Like objects aren't and FromQuery should be mentioned necessarily otherwise program will assume that the
        //argument will be passed from the body.

        public ActionResult<IEnumerable<BandDTO>> GetAllBands(
            //[FromQuery]string Genre, [FromQuery]string Search
            [FromQuery] BandsResourceParameters bandsResourceParameters)
        {
            var bandsFromRepo = _bandAlbumRepository.GetAllBands(bandsResourceParameters);
            return Ok(_mapper.Map<IEnumerable<BandDTO>>(bandsFromRepo));
        }

        [HttpPost]
        public ActionResult<BandDTO> CreateBand([FromBody] BandCreationDTO bandCreationDTO)
        {
            //No need to null check as bad req. will be thrown by API automatically if null.
            var bandEntityMapped = _mapper.Map<Band>(bandCreationDTO);
            _bandAlbumRepository.AddBand(bandEntityMapped);

            //Adding this functionality on my own because the instructor doesn't mention how to add
            //albums as well into the database. Not including this code will only save the band and not albums in dbset.
            foreach (var album in bandEntityMapped.Albums)
            {
                _bandAlbumRepository.AddAlbum(bandEntityMapped.ID, album);
            }

            _bandAlbumRepository.SaveChanges();
            //Now we need to show the saved band details so mapping the entity with DTO.
            var mappedWithDTO = _mapper.Map<BandDTO>(bandEntityMapped);
            return CreatedAtRoute("GetBand", new { bandID = mappedWithDTO.ID }, mappedWithDTO);
        }

        //Adding this is a good option because when user seelcts Option feature, it will return
        //405 Method Not Allowed in addition to showing the allowed verbs on the call.
        //Adding this will remove 405 Error and return 200 OK alongwith enabling OPTIONS feature.
        [HttpOptions]
        public IActionResult AddingOptions()
        {
            Response.Headers.Add("OPTIONS", "GET,POST,HEAD");
            return Ok();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services.Interfaces
{
    public interface IBandService
    {
        Task<BandDTO> GetBand(int bandID);
        Task<List<BandDTO>> GetAllBands();
        Task CreateBand(BandCreationDTO request);
        Task UpdateBand(BandCreationDTO updateRequest);
        Task DeleteBand(int bandID);
    }
}

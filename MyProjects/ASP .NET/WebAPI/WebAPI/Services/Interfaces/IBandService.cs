using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services.Interfaces
{
    public interface IBandService
    {
        Task<BandDTO> GetBandAsync(int bandID);
        Task<List<BandDTO>> GetAllBandsAsync();
        Task CreateBandAsync(BandCreationDTO request);
        Task UpdateBandAsync(int bandID, BandUpdateDTO updateRequest);
        Task DeleteBandAsync(int bandID);
    }
}

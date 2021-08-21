using Detailing_Diary.Models.Bussiness;
using Detailing_Diary.ViewModels.Input;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Detailing_Diary.Services
{
    public interface IGarageService
    {
        Task<ActionResult<Garage>> AddGarageAsync(GarageInputModel garage);
        void DeleteGarage(Guid id);
        IEnumerable<Garage> GetGarages();
        ActionResult<Garage> GetGarage(Guid id);
        ActionResult<Garage> EditGarage(GarageInputModel garage);
    }
}

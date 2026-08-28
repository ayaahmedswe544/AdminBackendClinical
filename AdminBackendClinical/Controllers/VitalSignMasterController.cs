using Microsoft.AspNetCore.Mvc;
using ServiceLayer.VitalSignMaster;

namespace AdminBackendClinical.Controllers
{
    public class VitalSignMasterController : Controller
    {
        private readonly IVitalSignMasterService _vitalSignMasterService;
        public VitalSignMasterController(IVitalSignMasterService service)
        {
            _vitalSignMasterService = service;
        }
        public async Task<IActionResult> Index()
        {
            var response=await _vitalSignMasterService.GetVitalSignMastersAsync();

            if (response.Success == true)
            {
            var data = response.Data;   
                return View(data);
            }
            Console.WriteLine(response.Message);
            return RedirectToAction(nameof(Index));
        }
    }
}

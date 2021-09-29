using System.Threading.Tasks;
using Domain.InformationService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers
{
    [ApiController]
    [Route(nameof(InformationController))]
    public class InformationController : Controller
    {
        private readonly InformationService _informationService;
        
        public InformationController()
        {
            _informationService = new InformationService();
        }

        [HttpGet]
        public async Task<string> Get(string name)
        {
            return await _informationService.GetInformation(name);
        }

        [HttpPost]
        public async Task Insert(string name, string color)
        {
            await _informationService.Insert(name, color);
        }
    }
}
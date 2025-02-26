using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarAPIController : ControllerBase
    {
        public List<string> Cars = new List<string>()
        {
            "Suzuki",
            "Honda",
            "Toyota",
            "BMW"
        };

        [HttpGet]
        public List<string> GetCars()
        {
            return Cars;
        }

        [HttpGet("{id}")]
        public string GetCarsById(int id)
        {
            return Cars.ElementAt(id);
        }
    }
}

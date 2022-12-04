using AspNetCoreWithReact.Model.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWithReact.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LibraController : ControllerBase
    {
        private readonly ILibraService _libraService;

        public LibraController(ILibraService libraService)
        {
            _libraService = libraService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            
            var x = _libraService.GetAll();
            return Ok(x);
        }

        [HttpGet]
        public IActionResult SearchByName(string name)
        {
            var x = _libraService.GetByName(name);
            return Ok(x);
        }

        [HttpPut]

        public IActionResult Update(Libra libra)
        {
           
            return Ok(_libraService.Update(libra));
        }

        [HttpPost]

        public IActionResult Create(Libra libra)
        {
            return Ok(_libraService.Save(libra));
        }

        [HttpDelete]

        public IActionResult Delete(int id)
        {
            _libraService.Delete(id);
            return Ok("SUCCES");
        }

        [HttpPost]

        public IActionResult SaveAll(List<Libra> libras)
        {
            return Ok(_libraService.SaveAll(libras));
        }
    }
}

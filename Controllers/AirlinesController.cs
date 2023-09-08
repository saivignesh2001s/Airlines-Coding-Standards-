using Airlines.Model;
using Airlines.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Airlines.Controllers
{
    public class AirlinesController : Controller
    {
        private readonly IRepository<Airline> _airlineMethods;
        private readonly IMapper _mapper;
        public AirlinesController(IRepository<Airline> airlineMethods,IMapper mapper)
        {
            _airlineMethods = airlineMethods;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
           var airlinesList= _airlineMethods.GetAll();
           return View(airlinesList);
        }
        public IActionResult Create()
        {
            AirlinesMapper airlinesMapper = new AirlinesMapper();
            return View(airlinesMapper);
        }
        [HttpPost]
        public IActionResult Create(AirlinesMapper airlinesMapper)
        {
           
            Airline airline=_mapper.Map<Airline>(airlinesMapper);
            airline.Id = Guid.NewGuid().ToString();
            bool added=_airlineMethods.Add(airline);
            if (added)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Edit(string id)
        {
            var airline = _airlineMethods.Get(id);
            return View(airline);

        }
        [HttpPost]
        public IActionResult Edit(Airline airline)
        {
            
            bool updated=_airlineMethods.Update(airline);
            if (updated)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(airline);
            }
        }
        public IActionResult Details(string id)
        {
            var airline = _airlineMethods.Get(id);
            return View(airline);

        }
        public IActionResult Delete(string id)
        {
            var airline = _airlineMethods.Get(id);
            return View(airline);
        }
        [HttpPost]
        public IActionResult Delete(Airline airline)
        {
            bool deleted=_airlineMethods.Remove(airline);
            if (deleted)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(airline);
            }
        }
       
    }
}

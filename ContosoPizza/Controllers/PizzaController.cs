using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class PizzaController : ControllerBase
    {
        public PizzaController()
        {

        }

        [HttpGet]
        public ActionResult<List<Pizza>> GetAll()
        {
            var pizza = PizzaService.GetAll();
            if (pizza != null)
            {
                return Ok(pizza);
            }
            return NotFound("NENHUMA PIZZA ENCONTRADA");
        }
        [HttpGet("{Id}")]

        public ActionResult<Pizza> Get(int Id)
        {
            var pizza = PizzaService.Get(Id);
            if (pizza != null)
            {
                return Ok(pizza);
            }
            return NotFound("NENHUMA PIZZA ENCONTRADA");
        }
        [HttpPost]

        public ActionResult<Pizza> CreatePizza(Pizza pizza)
        {
            PizzaService.Add(pizza);
            return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
        }
        [HttpPut("{Id}")]
        public ActionResult<Pizza>UpdatePizza(int Id,Pizza pizza)
        {
            if (Id != pizza.Id)
                return NotFound();

            var pizzaExisting = PizzaService.Get(pizza.Id);
            if (pizzaExisting is null)
                return NotFound();

            PizzaService.Update(pizza);
            return Ok(pizza);

        }
        [HttpDelete("{Id}")]
        public IActionResult DeletePizza(int Id)
        {
            var pizzaExisting = Get(Id);
            if (pizzaExisting is null)
                return NotFound(); 

            PizzaService.Delete(Id);
            return NoContent();
        }      

    }
}

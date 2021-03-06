using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
  public PizzaController()
  {

  }

  // GET all action
  [HttpGet]
  public ActionResult<List<Pizza>> Getall() =>
    PizzaService.GetAll();

  // GET by Id action
  [HttpGet("{id}")] // Attention, pas d'espace entre les caractères
  public ActionResult<Pizza> Get(int id)
  {
    var pizza = PizzaService.Get(id);

    if (pizza == null)
      return NotFound();

    return pizza;
  }

  // POST action
  [HttpPost]
  public IActionResult Create(Pizza pizza)
  {
    PizzaService.Add(pizza);
    return CreatedAtAction(nameof(Create), new { id = pizza.Id }, pizza);
  }

  // PUT action
  [HttpPut("{id}")] // Attention, pas d'espace entre les caractères
  public IActionResult Update(int id, Pizza pizza)
  {
    if (id != pizza.Id)
      return BadRequest();

    var existingPizza = PizzaService.Get(id);
    if (existingPizza is null)
      return NotFound();

    PizzaService.Update(pizza);

    return NoContent();

  }

  // DELETE action
  [HttpDelete("{id}")] // Attention, pas d'espace entre les caractères
  public IActionResult Delete(int id)
  {
    var pizza = PizzaService.Get(id);
    if (pizza is null)
      return NotFound();

    PizzaService.Delete(id);

    return NoContent();
  }

}
using FlashCardsAPI.Models;
using FlashCardsAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FlashCardsAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class FlashCardsController : ControllerBase
  {
    private readonly FlashCardService _flashCardService;

    public FlashCardsController(FlashCardService flashCardService)
    {
      _flashCardService = flashCardService;
    }

    [HttpGet]
    public ActionResult<List<FlashCard>> Get() =>
      _flashCardService.Get();

    [HttpGet("{id:length(24)}", Name = "GetFlashCard")]
    public ActionResult<FlashCard> Get(string id)
    {
      var flashCard = _flashCardService.Get(id);

      if (flashCard == null)
      {
        return NotFound();
      }
      return flashCard;
    }

    [HttpPost]
    public ActionResult<FlashCard> Create(FlashCard flashCard)
    {
      _flashCardService.Create(flashCard);
      return CreatedAtRoute("GetFlashCard", new { id = flashCard.Id.ToString()}, flashCard);
    }

    [HttpPut("{id:length(24)}")]
    public IActionResult Update(string id, FlashCard flashCardIn)
    {
      var flashCard = _flashCardService.Get(id);

      if (flashCard == null)
      {
        return NotFound();
      }
      _flashCardService.Update(id, flashCardIn);
      return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public IActionResult Delete(string id)
    {
      var flashCard = _flashCardService.Get(id);
      if (flashCard == null)
      {
        return NotFound();
      }
      _flashCardService.Remove(flashCard.Id);
      return NoContent();
    }
  }
}
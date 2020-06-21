using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Question.Models;

namespace QuizCarApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class QuestionItemsController : ControllerBase
  {
    /** Old Approach: EF < 3.0

    private readonly QuestionContext _context;

    public QuestionItemsController(QuestionContext context)
    {
      _context = context;
    }
    */

    // GET: api/QuestionItems
    [HttpGet]
    public async Task<ActionResult<IEnumerable<QuestionItemDTO>>> GetQuestionItems(
      [FromServices] QuestionContext context)
    {
      return await context.QuestionItems
        // .Include(item => item.Options)
        .AsNoTracking()  // To don't create Proxies of object
        .Select(x => ItemToDTO(x))
        .ToListAsync();
    }

    // GET: api/QuestionItems/5
    [HttpGet("{id}")]
    public async Task<ActionResult<QuestionItemDTO>> GetQuestionItem(
      [FromServices] QuestionContext context,
      long id)
    {
      var questionItem = await context.QuestionItems
        .AsNoTracking()
        .FirstOrDefaultAsync(item => item.Id == id);

      if (questionItem == null)
      {
        return NotFound();
      }

      return ItemToDTO(questionItem);
    }

    // PUT: api/QuestionItems/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutQuestionItem(
      [FromServices] QuestionContext context,
      long id,
      [FromBody] QuestionItemDTO questionItemDTO)
    {
      if (id != questionItemDTO.Id)
      {
        return BadRequest();
      }
      var questionItem = await context.QuestionItems.FindAsync(id);
      if (questionItem == null)
      {
        return NotFound();
      }

      questionItem.Question = questionItemDTO.Question;
      questionItem.Options = questionItemDTO.Options;
      questionItem.CorrectQuestion = questionItemDTO.CorrectQuestion;
      questionItem.KnowMore = questionItemDTO.KnowMore;

      if (ModelState.IsValid)
      {
        context.QuestionItems.Add(questionItem);
        await context.SaveChangesAsync();
      }
      else
      {
        return BadRequest(ModelState);
      }

      try
      {
        await context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!QuestionItemExists(context, id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    // POST: api/QuestionItems
    [HttpPost]
    public async Task<ActionResult<QuestionItemDTO>> PostQuestionItem(
      [FromServices] QuestionContext context,
      [FromBody] QuestionItemDTO questionItemDTO)
    {

      var questionItem = new QuestionItem
      {
        Id = questionItemDTO.Id,
        Question = questionItemDTO.Question,
        Options = questionItemDTO.Options,
        CorrectQuestion = questionItemDTO.CorrectQuestion,
        KnowMore = questionItemDTO.KnowMore,
      };

      if (ModelState.IsValid)
      {
        context.QuestionItems.Add(questionItem);
      }
      else
      {
        return BadRequest(ModelState);
      }

      try
      {
        await context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        throw;
      }

      return CreatedAtAction(
        nameof(GetQuestionItem),
        new { id = questionItem.Id },
        ItemToDTO(questionItem)
        );
    }

    // DELETE: api/QuestionItems/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<QuestionItem>> DeleteQuestionItem(
      [FromServices] QuestionContext context,
      long id)
    {
      var questionItem = await context.QuestionItems.FindAsync(id);
      if (questionItem == null)
      {
        return NotFound();
      }

      context.QuestionItems.Remove(questionItem);
      await context.SaveChangesAsync();

      return questionItem;
    }

    private bool QuestionItemExists(
      [FromServices] QuestionContext context,
      long id)
    {
      return context.QuestionItems.Any(e => e.Id == id);
    }

    private static QuestionItemDTO ItemToDTO(QuestionItem questionItem) =>
    new QuestionItemDTO
    {
      Id = questionItem.Id,
      Question = questionItem.Question,
      Options = questionItem.Options,
      CorrectQuestion = questionItem.CorrectQuestion,
      KnowMore = questionItem.KnowMore,
    };
  }
}

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
    private readonly QuestionContext _context;

    public QuestionItemsController(QuestionContext context)
    {
      _context = context;
    }

    // GET: api/QuestionItems
    [HttpGet]
    public async Task<ActionResult<IEnumerable<QuestionItemDTO>>> GetQuestionItems()
    {
      // return await _context.QuestionItems.ToListAsync();
      return await _context.QuestionItems.Select(x => ItemToDTO(x)).ToListAsync();
    }

    // GET: api/QuestionItems/5
    [HttpGet("{id}")]
    public async Task<ActionResult<QuestionItemDTO>> GetQuestionItem(long id)
    {
      var questionItem = await _context.QuestionItems.FindAsync(id);

      if (questionItem == null)
      {
        return NotFound();
      }

      return ItemToDTO(questionItem);
    }

    // PUT: api/QuestionItems/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPut("{id}")]
    public async Task<IActionResult> PutQuestionItem(long id, QuestionItemDTO questionItemDTO)
    {
      if (id != questionItemDTO.Id)
      {
        return BadRequest();
      }
      var questionItem = await _context.QuestionItems.FindAsync(id);
      if (questionItem == null)
      {
        return NotFound();
      }
      // _context.Entry(questionItem).State = EntityState.Modified;

      questionItem.Question = questionItemDTO.Question;
      questionItem.Options = questionItemDTO.Options;
      questionItem.CorrectQuestion = questionItemDTO.CorrectQuestion;
      questionItem.KnowMore = questionItemDTO.KnowMore;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!QuestionItemExists(id))
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
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPost]
    public async Task<ActionResult<QuestionItemDTO>> PostQuestionItem(QuestionItemDTO questionItemDTO)
    {
      var questionItem = new QuestionItem
      {
        Id = questionItemDTO.Id,
        Question = questionItemDTO.Question,
        Options = questionItemDTO.Options,
        CorrectQuestion = questionItemDTO.CorrectQuestion,
        KnowMore = questionItemDTO.KnowMore,
      };


      _context.QuestionItems.Add(questionItem);
      await _context.SaveChangesAsync();

      // return CreatedAtAction("GetQuestionItem", new { id = questionItemDTO.Id }, questionItemDTO);
      return CreatedAtAction(
        nameof(GetQuestionItem),
        new { id = questionItem.Id },
        ItemToDTO(questionItem)
        );
    }

    // DELETE: api/QuestionItems/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<QuestionItem>> DeleteQuestionItem(long id)
    {
      var questionItem = await _context.QuestionItems.FindAsync(id);
      if (questionItem == null)
      {
        return NotFound();
      }

      _context.QuestionItems.Remove(questionItem);
      await _context.SaveChangesAsync();

      return questionItem;
    }

    private bool QuestionItemExists(long id)
    {
      return _context.QuestionItems.Any(e => e.Id == id);
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

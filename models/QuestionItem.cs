using System.ComponentModel.DataAnnotations.Schema;

public class QuestionItem
{
  public long Id { get; set; }
  public string Question { get; set; }
  [NotMapped]
  public string[] Options { get; set; }
  public string CorrectQuestion { get; set; }
  public string KnowMore { get; set; }
}


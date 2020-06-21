using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class QuestionItem
{
  [Key]
  public long Id { get; set; }

  [Required(ErrorMessage = "This field is required")]
  [MinLength(3, ErrorMessage = "This field must contain between 3 and 100 caracters")]
  [MaxLength(100, ErrorMessage = "This field must contain between 3 and 100 caracters")]
  public string Question { get; set; }

  [NotMapped]
  [Required(ErrorMessage = "This field is required")]
  public string[] Options { get; set; }

  [Required(ErrorMessage = "This field is required")]
  [MinLength(3, ErrorMessage = "This field must contain between 3 and 100 caracters")]
  [MaxLength(100, ErrorMessage = "This field must contain between 3 and 100 caracters")]
  public string CorrectQuestion { get; set; }

  [MaxLength(1024, ErrorMessage = "This field must contain between 3 and 100 caracters")]
  public string KnowMore { get; set; }
}
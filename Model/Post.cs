using System.ComponentModel.DataAnnotations;

namespace project.Model
{
  public class Post
  {
        [Key]
        public int Id { get; set; }

    [Required(ErrorMessage = "Title is required")]
    [StringLength(250, MinimumLength = 3, ErrorMessage = "The Blog post title must be between 3 to 250 characters")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Description is required")]
    [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Content is required")]
    [MinLength(10, ErrorMessage = "Content must be at least 10 characters long")]
    public string Content { get; set; }

    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    public DateTime? DateUpdated { get; set; }



    [Required(ErrorMessage = "Slug is required")]
    [RegularExpression(@"^[a-z0-9]+(?:-[a-z0-9]+)*$",
        ErrorMessage = "Slug can only contain lowercase letters, numbers, and hyphens")]
    [StringLength(200, ErrorMessage = "Slug cannot be longer than 200 characters")]
    public string Slug { get; set; }

    // [Url(ErrorMessage = "Please provide a valid URL")]
    public string ImageUrl { get; set; }

    [Required]
    public bool IsPolished { get; set; } = false;
  }

}

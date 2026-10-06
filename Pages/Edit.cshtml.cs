using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using project.Data;
using project.Model;

namespace project.Pages;

public class EditModel : PageModel
{
  private readonly AppDbContext _context;
  public EditModel(AppDbContext context)
  {
    _context = context;
  }
  
  [BindProperty]
  public Post Post { get; set; }

  public IActionResult OnGet(int id)
  {
    Post = _context.Posts.Find(id);

    if (Post == null)
      return RedirectToPage("/NotFound");

    return Page();
  }

  public IActionResult OnPost()
  {
    if (!ModelState.IsValid)
      return Page();

        var existingPost = _context.Posts.Find(Post.Id);
        if (existingPost == null)
            return RedirectToPage("/NotFound");

        existingPost.Title = Post.Title;
        existingPost.Description = Post.Description;
        existingPost.Content = Post.Content;
        existingPost.Slug = Post.Slug;
        existingPost.ImageUrl = Post.ImageUrl;

        existingPost.DateUpdated = DateTime.UtcNow;

        _context.Attach(existingPost).State = EntityState.Modified;
        _context.SaveChanges();

    return RedirectToPage("/Index");
  }
}

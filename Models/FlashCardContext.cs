using Microsoft.EntityFrameworkCore;

namespace FlashCardsAPI.Models
{
  public class FlashCardContext : DbContext
  {
    public FlashCardContext(DbContextOptions<FlashCardContext> options) 
      : base(options)
      {
      }
      public DbSet<FlashCard> FlashCardItems { get; set; }
  }
}
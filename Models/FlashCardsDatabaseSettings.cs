namespace FlashCardsAPI.Models
{
    public class FlashCardsDatabaseSettings : IFlashCardsDatabaseSettings 
    {
      public string FlashCardsCollectionName { get; set; }
      public string ConnectionString { get; set; }
      public string DatabaseName { get; set; }
    }

    public interface IFlashCardsDatabaseSettings
    {
      string FlashCardsCollectionName { get; set; }
      string ConnectionString { get; set; }
      string DatabaseName { get; set; }
    }
}
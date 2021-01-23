using FlashCardsAPI.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace FlashCardsAPI.Services
{
    public class FlashCardService
    {
        private readonly IMongoCollection<FlashCard> _flashCards;

        public FlashCardService(IFlashCardsDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _flashCards = database.GetCollection<FlashCard>(settings.FlashCardsCollectionName);
        }

        public List<FlashCard> Get() =>
            _flashCards.Find(flashCard => true).ToList();

        public FlashCard Get(string id) =>
            _flashCards.Find<FlashCard>(flashCard => flashCard.Id == id).FirstOrDefault();

        public FlashCard Create(FlashCard flashCard)
        {
            _flashCards.InsertOne(flashCard);
            return flashCard;
        }

        public void Update(string id, FlashCard flashCardIn) =>
            _flashCards.ReplaceOne(flashCard => flashCard.Id == id, flashCardIn);

        public void Remove(FlashCard flashCardIn) =>
            _flashCards.DeleteOne(flashCard => flashCard.Id == flashCardIn.Id);

        public void Remove(string id) => 
            _flashCards.DeleteOne(flashCard => flashCard.Id == id);
    }
}
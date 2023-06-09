using BookStoreWebapiWithMongoDB.Data.Model;
using BookStoreWebapiWithMongoDB.Data.ServiceInterfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookStoreWebapiWithMongoDB.Data.Service
{
    public class BooksService : IBookService
    {
        
        private IMongoCollection<BooksModel> _books;
        //private IConfiguration _Configuration;
        public BooksService(IOptions<BookStoreDatabaseSettings> bookStoreDatabaseSettings,IConfiguration configuration)
        {
           // _Configuration = configuration;
           // var dbConn = _Configuration.GetSection("MongoDbConnectionStrings").GetSection("MongoDbConnectionString").Value;
           // var dbName = _Configuration.GetSection("MongoDbConnectionStrings").GetSection("DatabaseName").Value;
            var mongoClient = new MongoClient(bookStoreDatabaseSettings.Value.MongoDbConnectionString);
            var db = mongoClient.GetDatabase(bookStoreDatabaseSettings.Value.DatabaseName); //Db name declared
            _books = db.GetCollection<BooksModel>("Books"); //collection declared

        }
        public bool AddBooks(BooksModel book)
        {
            _books.InsertOne(book);
            return true;
        }

        public bool DeleteBooks(string id)
        {
            var result = _books.DeleteOne(x => x.Id == id);
            if (result != null)
            {
                return true;
            }

            return false;
        }

        public BooksModel GetBook(string id)
        {
            var model = _books.Find(x => x.Id == id).FirstOrDefault();
            return model;
        }

        public List<BooksModel> GetBooks()
        {
            var model = _books.Find(x => true).ToList(); 
            return model;
        }

        public int GetNumberOfBooks()
        {
            var model = _books.Find(x => true).ToList();
            return model.Count();
        }

        public bool UpdateBooks(BooksModel book)
        {
            var result = _books.ReplaceOne(x => x.Id == book.Id,book);
            if (result != null)
            {
                return true;
            }

            return false;
        }



    }
}

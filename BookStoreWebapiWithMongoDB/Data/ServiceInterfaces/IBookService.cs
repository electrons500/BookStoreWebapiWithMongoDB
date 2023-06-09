using BookStoreWebapiWithMongoDB.Data.Model;

namespace BookStoreWebapiWithMongoDB.Data.ServiceInterfaces
{
    public interface IBookService
    {
        List<BooksModel> GetBooks();
        BooksModel GetBook(string id);
        bool AddBooks(BooksModel book);
        bool UpdateBooks(BooksModel book);
        bool DeleteBooks(string  id);
        int GetNumberOfBooks();
    }
}

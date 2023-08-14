// See https://aka.ms/new-console-template for more information
using ConceptArchitect.BookManagement;

class Program
{
    static  void Main()
    {

        


        var manager = new BookManager();
        Console.WriteLine("Program Starts...");

        var t1= PrintAllBooksAsync(manager); //can this funciton be async

        Console.WriteLine("Printing all books");

        Console.WriteLine("Finding book Manas");
        var t2= FindBookByTitle(manager,"Manas");

        Console.WriteLine("Finding book The Great Expectations");
        var t3=FindBookByTitle(manager, "The Great Expectations");





        Console.WriteLine("Please wait for the tasks to be over");
        Task.WaitAll(t1, t2, t3);
    }

    static async Task FindBookByTitle(BookManager manager, string title)
    {
        try
        {
            var book = await manager.GetBookById(title);

            Console.WriteLine($"Book: {book}");
        }
        catch
        {
            Console.WriteLine($"No book with title:{title}");
        }           
    }

    

    static async Task PrintAllBooksAsync(BookManager manager)
    {
        var books = await manager.GetAllBooks();
        foreach (var book in books)
            Console.WriteLine(book);

    }


    static Task FindBookByTitleV1(BookManager manager, string title)
    {
        return manager
                    .GetBookById(title)
                    .ContinueWith(t =>
                    {
                        Console.WriteLine($"Book: {t.Result}");
                    });



    }

    static Task PrintAllBooksAsyncV1(BookManager manager)
    {
        return manager
                    .GetAllBooks()
                    .ContinueWith(t =>
                    {
                        var books = t.Result;
                        foreach(var book in books)
                            Console.WriteLine(book);
                    });
               
    }

    static void PrintAllBooksSync(BookManager manager)
    {
        var t= manager.GetAllBooks();
        t.Wait();

        var books = t.Result;

        foreach (var book in books)
            Console.WriteLine(book);
    }
}

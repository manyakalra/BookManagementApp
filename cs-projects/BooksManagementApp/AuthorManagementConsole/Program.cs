using ConceptArchitect.BookManagement;

class Program
{
    static void Main()
    {
        var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\MyWorks\Corporate\202307-ecolab-cs\booksdb.mdf;Integrated Security=True;Connect Timeout=30";
        var manager = new AuthorManager() 
        { 
            ConnectionString = connectionString 
        } ;


        foreach (Author author in manager.GetAllAuthors())
            Console.WriteLine(author);


    
    }
}

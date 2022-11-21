/*
 * QUESTION - 4
 Create a small database, which will be used to store data about books. For a certain book, we want to keep the following information:

Title
Author
The program must be able to store 10  books, and the user will be allowed to:

Add data for one book
Display all the entered books (just title and author, in the same line)
Search for the book(s) with a certain title
 
 */

using System.Collections;

public class Program
{
    public static void Main(string[] args)
    {

        ArrayList library = new ArrayList();
        library.Add(new Book("A Passage to India", "E.M. Forster"));
        library.Add(new Book("Professor Shonku", "Satyajit Ray"));
        library.Add(new Book("The Room on the Roof", "Ruskin Bond"));
        library.Add(new Book("Train to Pakistan", "Khuswant Singh"));

        Console.Write("Enter the book name : ");
        String query = Console.ReadLine();
        foreach (Book i in library)
        {
            if (i.getName() == query)
            {
                Console.WriteLine(i.getName() + " is available");
                Console.WriteLine("This book is written by : " + i.getAuthor());
                break;
            }
        }
    }
}
class Book
{
    String name;
    String author;
    public Book(String name, String author)
    {
        this.name = name;
        this.author = author;
    }
    public String getName()
    {
        return name;
    }
    public string getAuthor()
    {
        return author;
    }
}
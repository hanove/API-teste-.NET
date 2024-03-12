public class Book
{

    public int ID { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int YearOfPublication { get; set; }
    public string Genre { get; set; }


    public Book(int id, string title, string author, int yearOfPublication, string genre)
    {
        ID = id;
        Title = title;
        Author = author;
        YearOfPublication = yearOfPublication;
        Genre = genre;
    }
}
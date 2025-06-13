namespace Library_5_4
{
    internal class Book
    {
        public Book(string title, string description, 
            string author, string publishingYear)
        {
            Title = title;
            Description = description;
            Author = author;
            PublishingYear = publishingYear;
        }

        public string Title { get; private set;}
        public string Description { get; private set;}
        public string Author { get; private set;}
        public string PublishingYear { get; private set; }

        public string GetInfoForDisplaying()
        {
            return $"{Author}, {Title} - {PublishingYear}";
        }
    }
}
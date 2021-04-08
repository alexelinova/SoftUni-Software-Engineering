using System;

namespace Articles
{
    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public Article()
        {

        }

        public void Edit(string newContent)
        {
            Content = newContent;
        }

        public void ChangeAuthor(string newAuthor)
        {
            Author = newAuthor;
        }

        public void Rename(string newTitle)
        {
            Title = newTitle;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");

            Article article = new Article
            {
                Title = input[0],
                Content = input[1],
                Author = input[2]
            };

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split(": ");

                string action = line[0];

                string newContent = line[1];

                if (action == "Edit")
                {
                    article.Edit(newContent);
                }
                else if (action == "ChangeAuthor")
                {
                    article.ChangeAuthor(newContent);
                }
                else
                {
                    article.Rename(newContent);
                }
            }

            Console.WriteLine(article);
        }
    }
}

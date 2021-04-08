using System;
using System.Collections.Generic;
using System.Linq;

namespace Article03
{
    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {


            int n = int.Parse(Console.ReadLine());

            List<Article> articles = new List<Article>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ");

                Article article = new Article
                {
                    Title = input[0],
                    Content = input[1],
                    Author = input[2]
                };

                articles.Add(article);
            }

            string sort = Console.ReadLine();

            if (sort == "title")
            {
                foreach (var article in articles.OrderBy(n => n.Title))
                {
                    Console.WriteLine(article);
                }
            }
            else if (sort == "content")
            {
                foreach (var article in articles.OrderBy(n => n.Content))
                {
                    Console.WriteLine(article);
                }
            }
            else
            {
                foreach (var article in articles.OrderBy(n => n.Author))
                {
                    Console.WriteLine(article);
                }
            }
        }
    }
}

namespace ODataWebAPI
{
    public static class DataSource
    {
        private static IList<Book> _books { get; set; }

        private static IList<Companies> _companies { get; set; }

        public static IList<Book> GetBooks()
        {
            if (_books != null)
            {
                return _books;
            }

            _books = new List<Book>();

            // book #1
            Book book = new Book
            {
                Id = 1,
                ISBN = "978-0-321-87758-1",
                Title = "Essential C#5.0",
                Author = "Mark Michaelis",
                Price = 59.99m,
                Location = new Address { City = "Redmond", Street = "156TH AVE NE" },
                Press = new Press
                {
                    Id = 1,
                    Name = "Addison-Wesley",
                    Category = Category.Book,
                    Email = "a@gmail.com"
                }
            };
            _books.Add(book);

            // book #2
            book = new Book
            {
                Id = 2,
                ISBN = "063-6-920-02371-5",
                Title = "Enterprise Games",
                Author = "Michael Hugos",
                Price = 49.99m,
                Location = new Address { City = "Bellevue", Street = "Main ST" },
                Press = new Press
                {
                    Id = 2,
                    Name = "O'Reilly",
                    Category = Category.EBook,
                    Email = "o@gmail.com"
                }
            };
            _books.Add(book);

            return _books;
        }

        public static IList<Companies> GetCompanies()
        {
            if (_companies != null)
            {
                return _companies;
            }

            _companies = new List<Companies>();


            Companies compani = new Companies
            {
                Id = 1,
                Name = "Alfaomega",
                Rating = 5,
                Address = new Address { City = "medellin", Street = "AV_Oriental" }


            };
            _companies.Add(compani);

            Companies compani2 = new Companies
            {
                Id = 2,
                Name = "Babel",
                Rating = 3,
                Address = new Address { City = "medellin", Street = "El poblado" }
            }; 
            _companies.Add(compani2);

            return _companies;
        }

    }
}

namespace Library.Models;

public static class DataInitializer
{
    public static bool _hasInit = false;

    public static void Init(LibraryContext db)
    {
        if (_hasInit)
            return;

        db.Categories.Add(new Category
        { 
            Name = "Modernist",
            Searchable = SearchFormatter.Format("Modernist"),
            Description = "Originated in the late 19th and early 20th century, charactered by a self-conscious break with traditional ways of writing in both poetry and prose fiction writing." 
        });
        
        db.Formats.AddRange(new Format[]
        {
            new Format { 
                Name = "Paper Book",
                Searchable = SearchFormatter.Format("Paper Book")
            },
            new Format { 
                Name = "Audio Book",
                Searchable = SearchFormatter.Format("Audio Book")
            },
            new Format { 
                Name = "Braille",
                Searchable = SearchFormatter.Format("Braille")
            },
            new Format { 
                Name = "Large Print",
                Searchable = SearchFormatter.Format("Large Print")
            }
        });
        
        db.Languages.AddRange(new Language[]
        {
            new Language { 
                Name = "English",
                Searchable = SearchFormatter.Format("English")
            },
            new Language { 
                Name = "Chinese",
                Searchable = SearchFormatter.Format("Chinese")
            },
            new Language { 
                Name = "French",
                Searchable = SearchFormatter.Format("French")
            },
            new Language { 
                Name = "Afrikaans",
                Searchable = SearchFormatter.Format("Afrikaans")
            }
        });
        
        db.MaturityRatings.AddRange(new MaturityRating[]
        {
            new MaturityRating {
                Rating = "G",
                Description = "Suitable for all readers. May contain some mild cartoon-like violence."
            },
            new MaturityRating {
                Rating = "PG",
                Description = "Suitable for most readers. Contains singular or few instances of violence, inappropriate language, and mature topics."
            },
            new MaturityRating {
                Rating = "PG-13",
                Description = "Suitable for mature readers. May contain numerous or long instances of graphic violence, inappropriate language, strong sex innuendos and discussion of sex."
            },
            new MaturityRating {
                Rating = "M",
                Description = "Only suitable for mature readers. Contains long or numerous instances of graphic sex, innuendos and discussion, and can be considered the story's main focus."
            },
            new MaturityRating {
                Rating = "R",
                Description = "Only suitable for mature readers. Contains long or numerous instances of graphic violence, torture and war sequences."
            }
        });
        
        db.Statuses.AddRange(new Status[]
        {
            new Status { Name = "Overdue" },
            new Status { Name = "Last Renewal" },
            new Status { Name = "Renewed" },
            new Status { Name = "Checked Out" }
        });
        
        db.Notifications.AddRange(new Notification[]
        {
            new Notification {
                Type = "Alert",
                Description = "Available Copy",
                Message = "An item on your waitlist is available: "
            },
            new Notification {
                Type = "Alert",
                Description = "Ready to Checkout",
                Message = "One of your holds is ready for checkout: "
            },
            new Notification {
                Type = "Warning",
                Description = "Item(s) Overdue",
                Message = "You have item(s) overdue: "
            },
            new Notification {
                Type = "Warning",
                Description = "Last Renewal",
                Message = "You have item(s) you cannot renew anymore: "
            },
            new Notification {
                Type = "Alert",
                Description = "Item(s) Renewed",
                Message = "You have renewed item(s): "
            },
            new Notification {
                Type = "Alert",
                Description = "New Release",
                Message = "One of your favorite authors has released a new book: "
            }
        });

        db.Publishers.AddRange(new Publisher[]
        {
            new Publisher {
                Name = "Self-Published",
                Searchable = SearchFormatter.Format("Self-Published")
            },
            new Publisher { 
                Name = "THIS.Library",
                Searchable = SearchFormatter.Format("THIS.Library")
            },
            new Publisher { 
                Name = "Yale University Press",
                Searchable = SearchFormatter.Format("Yale University Press")
            },
            new Publisher { 
                Name = "Viking",
                Searchable = SearchFormatter.Format("Viking")
            },
            new Publisher { 
                Name = "Allen Lane", 
                Searchable = SearchFormatter.Format("Allen Lane")
            }
        });

        Person[] persons = new Person[]
        {
            new Person
            {
                FirstName = "Valentin Louis Georges Eugène Marcel",
                LastName = "Proust",
                Searchable = SearchFormatter.Format("Valentin Louis Georges Eugène Marcel", "Proust"),
                DateOfBirth = new DateTime(1871, 7, 10),
                CountryOfOrigin = "France"
            },
            new Person
            {
                FirstName = "Jane",
                LastName = "Doe",
                Searchable = SearchFormatter.Format("Jane", "Doe"),
                DateOfBirth = new DateTime(2000, 1, 1),
                CountryOfOrigin = "United States of America"
            },
            new Person
            {
                FirstName = "John",
                LastName = "Smith",
                Searchable = SearchFormatter.Format("John", "Smith"),
                DateOfBirth = new DateTime(1960, 12, 31),
                CountryOfOrigin = "United Kingdom"
            }
        };
        db.Persons.AddRange(persons);
        
        int personId = db.Persons
            .Single(person => person.Searchable.Contains("marcelproust"))
            .PersonId;
        db.Authors.Add(new Author
        {
            PenName = "Marcel Proust",
            Bio = "Valentin...Proust was a French novelest, literary critic, and essayist who wrote the monumantal novel: In Search of Lost Time. The title was previously translated to: Remembrance of Things Past. The novel was originally in French and published in seven volumes between 1913 and 1927. He is considered by critics and writers to be one of the most influential authors of the 20th century.",
            Deceased = true,
            PersonId = personId
        });

        db.BookSeries.Add(new BookSerial
        {
            Searchable = SearchFormatter.Format("In Search of Lost Time", "Marcel Proust"),
            IsFinished = true
        });
            
        int serialId = db.BookSeries
            .FirstOrDefault(serial => serial.Searchable == "insearchoflosttimemarcelproust")
            .BookSerialId;
        int[] languageIds = new int[]
        {
            db.Languages
                .SingleOrDefault(lang => lang.Searchable == "french")
                .LanguageId,
            db.Languages
                .SingleOrDefault(lang => lang.Searchable == "english")
                .LanguageId
        };

        db.SerialTitles.AddRange(new SerialTitle[]
        {
            new SerialTitle
            {
                Title = "À La Recherche du Temps Perdu",
                Searchable = SearchFormatter.Format("À La Recherche du Temps Perdu"),
                BookSerialId = serialId,
                LanguageId = languageIds[0]
            },
            new SerialTitle
            {
                Title = "La Recherche",
                Searchable = SearchFormatter.Format("La Recherche"),
                BookSerialId = serialId,
                LanguageId = languageIds[0]
            },
            new SerialTitle
            {
                Title = "In Search of Lost Time",
                Searchable = SearchFormatter.Format("In Search of Lost Time"),
                BookSerialId = serialId,
                LanguageId = languageIds[1]
            },
            new SerialTitle
            {
                Title = "Remembrance of Things Past",
                Searchable = SearchFormatter.Format("Remembrance of Things Past"),
                BookSerialId = serialId,
                LanguageId = languageIds[1]
            }
        });

        string[] titles = new string[]
        {
            "Swann's Way",
            "In the Shadow of Young Girls in Flower",
            "The Guermantes Way",
            "Sodom and Gomorrah",
            "The Prisoner",
            "The Fugitive",
            "Finding Time Again"
        };
        string penname = db.Authors
            .SingleOrDefault(author => author.PenName == "Marcel Proust")
            .PenName;
        int ratingId = db.MaturityRatings
            .SingleOrDefault(rating => rating.Rating == "PG")
            .MaturityRatingId;

        Book[] books = new Book[titles.Length];
        for (int i = 0; i < books.Length; i++)
            books[i] = new Book
            {
                Searchable = SearchFormatter.Format(titles[i], penname),
                MaturityRatingId = ratingId,
                BookSerialId = serialId,
                NumInSeries = i + 1
            };
        db.Books.AddRange(books);
        
        int langId = db.Languages
            .SingleOrDefault(lang => lang.Searchable == "english")
            .LanguageId;

        List<BookTitle> booktitles = new List<BookTitle>();
        for (int i = 0; i < titles.Length; i++)
        {
            string searchable = SearchFormatter.Format(titles[i], penname);
            int bookId = db.Books
                .SingleOrDefault(book => book.Searchable == searchable)
                .BookId;
            booktitles.Add(new BookTitle
            {
                Title = titles[i],
                Searchable = SearchFormatter.Format(titles[i]),
                BookId = bookId,
                LanguageId = langId
            });
        }
        db.BookTitles.AddRange(booktitles.ToArray());

        Contributor[] contributors = new Contributor[]
        {
            new Contributor
            {
                Name = "C.K. Scott Moncrieff",
                Searchable = SearchFormatter.Format("C.K. Scott Moncrieff")
            },
            new Contributor
            {
                Name = "William C. Carter",
                Searchable = SearchFormatter.Format("William C. Carter")
            },
            new Contributor
            {
                Name = "Christopher Prendergast",
                Searchable = SearchFormatter.Format("Christopher Prendergast")
            },
            new Contributor
            {
                Name = "Lydia Davis",
                Searchable = SearchFormatter.Format("Lydia Davis")
            },
            new Contributor
            {
                Name = "James Grieve",
                Searchable = SearchFormatter.Format("James Grieve")
            },
            new Contributor
            {
                Name = "Mark Trehame",
                Searchable = SearchFormatter.Format("Mark Trehame")
            },
            new Contributor
            {
                Name = "John Sturrock",
                Searchable = SearchFormatter.Format("John Sturrock")
            },
            new Contributor
            {
                Name = "Carol Clark",
                Searchable = SearchFormatter.Format("Carol Clark")
            },
            new Contributor
            {
                Name = "Peter Collier",
                Searchable = SearchFormatter.Format("Peter Collier")
            },
            new Contributor
            {
                Name = "Ian Patterson",
                Searchable = SearchFormatter.Format("Ian Patterson")
            }
        };
        db.Contributors.AddRange(contributors);

        int formatId = db.Formats
            .SingleOrDefault(format => format.Searchable == "paperbook")
            .FormatId;
        db.BookVersions.AddRange(new BookVersion[]
        {
            new BookVersion
            {
                ISBN = "978-0300185430",
                Published = new DateTime(2013, 11, 14),
                BookId = db.Books
                    .FirstOrDefault(book => book.Searchable == "swannswaymarcelproust")
                    .BookId,
                PublisherId = db.Publishers
                    .FirstOrDefault(publisher => publisher.Searchable == "yaleuniversitypress")
                    .PublisherId,
                FormatId = formatId,
                LanguageId = langId
            },
            new BookVersion
            {
                ISBN = "978-0300185423",
                Published = new DateTime(2015, 10, 13),
                BookId = db.Books
                    .FirstOrDefault(book => book.Searchable == "intheshadowofyounggirlsinflowermarcelproust")
                    .BookId,
                PublisherId = db.Publishers
                    .FirstOrDefault(publisher => publisher.Searchable == "yaleuniversitypress")
                    .PublisherId,
                FormatId = formatId,
                LanguageId = langId
            },
            new BookVersion
            {
                ISBN = "978-0300186192",
                Published = new DateTime(2018, 11, 20),
                BookId = db.Books
                    .FirstOrDefault(book => book.Searchable == "theguermanteswaymarcelproust")
                    .BookId,
                PublisherId = db.Publishers
                    .FirstOrDefault(publisher => publisher.Searchable == "yaleuniversitypress")
                    .PublisherId,
                FormatId = formatId,
                LanguageId = langId
            },
            new BookVersion
            {
                ISBN = "978-0300186208",
                Published = new DateTime(2021, 6, 22),
                BookId = db.Books
                    .FirstOrDefault(book => book.Searchable == "sodomandgomorrahmarcelproust")
                    .BookId,
                PublisherId = db.Publishers
                    .FirstOrDefault(publisher => publisher.Searchable == "yaleuniversitypress")
                    .PublisherId,
                FormatId = formatId,
                LanguageId = langId
            },
            new BookVersion
            {
                ISBN = "0-14-243796-4",
                Published = new DateTime(2004, 11, 30),
                BookId = db.Books
                    .FirstOrDefault(book => book.Searchable == "swannswaymarcelproust")
                    .BookId,
                PublisherId = db.Publishers
                    .FirstOrDefault(publisher => publisher.Searchable == "viking")
                    .PublisherId,
                FormatId = formatId,
                LanguageId = langId
            },
            new BookVersion
            {
                ISBN = "0-14-303907-5",
                Published = new DateTime(2005, 1, 25),
                BookId = db.Books
                    .FirstOrDefault(book => book.Searchable == "intheshadowofyounggirlsinflowermarcelproust")
                    .BookId,
                PublisherId = db.Publishers
                    .FirstOrDefault(publisher => publisher.Searchable == "viking")
                    .PublisherId,
                FormatId = formatId,
                LanguageId = langId
            },
            new BookVersion
            {
                ISBN = "0-14-303922-9",
                Published = new DateTime(2005, 5, 31),
                BookId = db.Books
                    .FirstOrDefault(book => book.Searchable == "theguermanteswaymarcelproust")
                    .BookId,
                PublisherId = db.Publishers
                    .FirstOrDefault(publisher => publisher.Searchable == "allenlane")
                    .PublisherId,
                FormatId = formatId,
                LanguageId = langId
            },
            new BookVersion
            {
                ISBN = "0-14-303931-8",
                Published = new DateTime(2003, 10, 28),
                BookId = db.Books
                    .FirstOrDefault(book => book.Searchable == "sodomandgomorrahmarcelproust")
                    .BookId,
                PublisherId = db.Publishers
                    .FirstOrDefault(publisher => publisher.Searchable == "allenlane")
                    .PublisherId,
                FormatId = formatId,
                LanguageId = langId
            }
        });

        

        db.SaveChanges();
        _hasInit = true;
    }
}
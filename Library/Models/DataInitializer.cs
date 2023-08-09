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
            Description = "Originated in the late 19th and early 20th century, charactered by a self-conscious break with traditional ways of writing in both poetry and prose fiction writing." 
        });
        
        db.Formats.AddRange(new Format[]
        {
            new Format { Name = "Paper Book"},
            new Format { Name = "Audio Book"},
            new Format { Name = "Braille"},
            new Format { Name = "Large Print" }
        });
        
        db.Languages.AddRange(new Language[]
        {
            new Language { Name = "English" },
            new Language { Name = "Chinese" },
            new Language { Name = "French" },
            new Language { Name = "Afrikaans" }
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
            new Publisher { Name = "Self-Published" },
            new Publisher { Name = "THIS.Library" },
            new Publisher { Name = "Yale University Press" },
            new Publisher { Name = "Viking" },
            new Publisher { Name = "Allen Lane" }
        });

        db.Persons.Add(new Person
        {
            FirstName = "Valentin Louis Georges Eugène Marcel",
            LastName = "Proust",
            DateOfBirth = new DateTime(1871, 7, 10),
            CountryOfOrigin = "France"
        });
        
        int personId = db.Persons
            .Single(person => person.FirstName == "Valentin Louis Georges Eugène Marcel" 
            && person.LastName == "Proust").PersonId;
        db.Authors.Add(new Author
        {
            PenName = "Marcel Proust",
            Bio = "Valentin...Proust was a French novelest, literary critic, and essayist who wrote the monumantal novel: In Search of Lost Time. The title was previously translated to: Remembrance of Things Past. The novel was originally in French and published in seven volumes between 1913 and 1927. He is considered by critics and writers to be one of the most influential authors of the 20th century.",
            Deceased = true,
            PersonId = personId
        });

        db.BookSeries.Add(new BookSerial
        {
            SerialName = "insearchoflosttime-marcelproust",
            IsFinished = true
        });
            
        int serialId = db.BookSeries
            .FirstOrDefault(serial => serial.SerialName == "insearchoflosttime-marcelproust")
            .BookSerialId;
        int[] languageIds = new int[]
        {
            db.Languages
                .SingleOrDefault(lang => lang.Name == "French")
                .LanguageId,
            db.Languages
                .SingleOrDefault(lang => lang.Name == "English")
                .LanguageId
        };
        db.SerialTitles.AddRange(new SerialTitle[]
        {
            new SerialTitle
            {
                Title = "À La Recherche du Temps Perdu",
                BookSerialId = serialId,
                LanguageId = languageIds[0]
            },
            new SerialTitle
            {
                Title = "La Recherche",
                BookSerialId = serialId,
                LanguageId = languageIds[0]
            },
            new SerialTitle
            {
                Title = "In Search of Lost Time",
                BookSerialId = serialId,
                LanguageId = languageIds[1]
            },
            new SerialTitle
            {
                Title = "Remembrance of Things Past",
                BookSerialId = serialId,
                LanguageId = languageIds[1]
            }
        });

        string[] bookTitles = new string[]
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

        Book[] books = new Book[bookTitles.Length];
        for (int i = 0; i < books.Length; i++)
        {
            string bookname = Book.SetBookName(bookTitles[i], penname);
            books[i] = new Book
            {
                BookName = bookname,
                MaturityRatingId = ratingId,
                BookSerialId = serialId,
                NumInSeries = i + 1
            };
        }
        db.Books.AddRange(books);
        
        int langId = db.Languages
            .SingleOrDefault(lang => lang.Name == "English")
            .LanguageId;
        List<BookTitle> btitles = new List<BookTitle>();
        for (int i = 0; i < bookTitles.Length; i++)
        {
            string condensedTitle = bookTitles[i];
            condensedTitle = String.Join("", condensedTitle.Split(new char[] { '\'', ':', '-' }));
            condensedTitle = String.Join("", condensedTitle.ToLower().Split(" "));
            int bookId = db.Books
                .SingleOrDefault(book => book.BookName == condensedTitle + condensedPenName)
                .BookId;
            btitles.Add(new BookTitle
            {
                Title = bookTitles[i],
                BookId = bookId,
                LanguageId = langId
            });
        }
        db.BookTitles.AddRange(btitles.ToArray());

        db.Contributors.AddRange(new Contributor[]
        {
            new Contributor { Name = "C.K. Scott Moncrieff" },
            new Contributor { Name = "William C. Carter" },
            new Contributor { Name = "Christopher Prendergast" },
            new Contributor { Name = "Lydia Davis" },
            new Contributor { Name = "James Grieve" },
            new Contributor { Name = "Mark Trehame" },
            new Contributor { Name = "John Sturrock" },
            new Contributor { Name = "Carol Clark" },
            new Contributor { Name = "Peter Collier" },
            new Contributor { Name = "Ian Patterson" }
        });

        int formatId = db.Formats
            .SingleOrDefault(format => format.Name == "Paper Book")
            .FormatId;
        db.BookVersions.AddRange(new BookVersion[]
        {
            new BookVersion
            {
                ISBN = "978-0300185430",
                Published = new DateTime(2013, 11, 14),
                BookId = db.Books
                    .FirstOrDefault(book => book.BookName == "swannsway-marcelproust")
                    .BookId,
                PublisherId = db.Publishers
                    .FirstOrDefault(publisher => publisher.Name == "Yale University Press")
                    .PublisherId,
                FormatId = formatId,
                LanguageId = langId
            },
            new BookVersion
            {
                ISBN = "978-0300185423",
                Published = new DateTime(2015, 10, 13),
                BookId = db.Books
                    .FirstOrDefault(book => book.BookName == "intheshadowofyounggirlsinflower-marcelproust")
                    .BookId,
                PublisherId = db.Publishers
                    .FirstOrDefault(publisher => publisher.Name == "Yale University Press")
                    .PublisherId,
                FormatId = formatId,
                LanguageId = langId
            },
            new BookVersion
            {
                ISBN = "978-0300186192",
                Published = new DateTime(2018, 11, 20),
                BookId = db.Books
                    .FirstOrDefault(book => book.BookName == "theguermantesway-marcelproust")
                    .BookId,
                PublisherId = db.Publishers
                    .FirstOrDefault(publisher => publisher.Name == "Yale University Press")
                    .PublisherId,
                FormatId = formatId,
                LanguageId = langId
            },
            new BookVersion
            {
                ISBN = "978-0300186208",
                Published = new DateTime(2021, 6, 22),
                BookId = db.Books
                    .FirstOrDefault(book => book.BookName == "sodomandgomorrah-marcelproust")
                    .BookId,
                PublisherId = db.Publishers
                    .FirstOrDefault(publisher => publisher.Name == "Yale University Press")
                    .PublisherId,
                FormatId = formatId,
                LanguageId = langId
            },
            new BookVersion
            {
                ISBN = "0-14-243796-4",
                Published = new DateTime(2004, 11, 30),
                BookId = db.Books
                    .FirstOrDefault(book => book.BookName == "swannsway-marcelproust")
                    .BookId,
                PublisherId = db.Publishers
                    .FirstOrDefault(publisher => publisher.Name == "Viking")
                    .PublisherId,
                FormatId = formatId,
                LanguageId = langId
            },
            new BookVersion
            {
                ISBN = "0-14-303907-5",
                Published = new DateTime(2005, 1, 25),
                BookId = db.Books
                    .FirstOrDefault(book => book.BookName == "intheshadowofyounggirlsinflower-marcelproust")
                    .BookId,
                PublisherId = db.Publishers
                    .FirstOrDefault(publisher => publisher.Name == "Viking")
                    .PublisherId,
                FormatId = formatId,
                LanguageId = langId
            },
            new BookVersion
            {
                ISBN = "0-14-303922-9",
                Published = new DateTime(2005, 5, 31),
                BookId = db.Books.FirstOrDefault(book => book.BookName == "theguermantesway-marcelproust").BookId,
                PublisherId = db.Publishers
                    .FirstOrDefault(publisher => publisher.Name == "Allen Lane")
                    .PublisherId,
                FormatId = formatId,
                LanguageId = langId
            },
            new BookVersion
            {
                ISBN = "0-14-303931-8",
                Published = new DateTime(2003, 10, 28),
                BookId = db.Books.FirstOrDefault(book => book.BookName == "sodomandgomorrah-marcelproust").BookId,
                PublisherId = db.Publishers
                    .FirstOrDefault(publisher => publisher.Name == "Allen Lane")
                    .PublisherId,
                FormatId = formatId,
                LanguageId = langId
            }
        });

        Person patronPerson = new Person
        {
            FirstName = "Jane",
            LastName = "Doe",
            DateOfBirth = new DateTime(2000, 1, 1),
            CountryOfOrigin = "United States of America"
        };
        db.Persons.Add(patronPerson);
        int patronPersonId = db.Persons
            .SingleOrDefault
        ApplicationUser patronUser = new ApplicationUser
        {

        }

        Person librarianPerson = new Person
        {
            FirstName = "John",
            LastName = "Smith",
            DateOfBirth = new DateTime(1960, 12, 31),
            CountryOfOrigin = "United Kingdom"
        };

        db.SaveChanges();
        _hasInit = true;
    }
}
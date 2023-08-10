using Microsoft.AspNetCore.Identity;

namespace Library.Models;

public static class DataInitializer
{
    public async static void Init(WebApplication host)
    {
        using (var scope = host.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<LibraryContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            if (!db.Categories.Any())
            {
                db.Categories.Add(new Category
                {
                    Name = "Modernist",
                    Searchable = SearchFormatter.Format("Modernist"),
                    Description = "Originated in the late 19th and early 20th century, charactered by a self-conscious break with traditional ways of writing in both poetry and prose fiction writing."
                });
                db.SaveChanges();
            }

            if (!db.Categories.Any())
            {
                db.Countries.AddRange(new Country[]
                {
                new Country
                {
                    Name = "United States of America",
                    Searchable = SearchFormatter.Format("United States of America")
                },
                new Country
                {
                    Name = "France",
                    Searchable = SearchFormatter.Format("France")
                }
                });
                db.SaveChanges();
            }

            if (!db.Formats.Any())
            {
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
                db.SaveChanges();
            }

            if (!db.Languages.Any())
            {
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
                db.SaveChanges();
            }

            if (!db.MaturityRatings.Any())
            {
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
                db.SaveChanges();
            }

            if (!db.Statuses.Any())
            {
                db.Statuses.AddRange(new Status[]
                {
                new Status { Name = "Overdue" },
                new Status { Name = "Last Renewal" },
                new Status { Name = "Renewed" },
                new Status { Name = "Checked Out" },
                new Status { Name = "Returned" }
                });
                db.SaveChanges();
            }

            if (!db.Notifications.Any())
            {
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
                db.SaveChanges();
            }

            if (!db.Publishers.Any())
            {
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
                db.SaveChanges();
            }

            if (!db.Persons.Any())
            {
                int countryId = db.Countries
                    .SingleOrDefault(country => country.Searchable.Contains("unitedstates"))
                    .CountryId;
                db.Persons.AddRange(new Person[]
                {
            new Person
            {
                FirstName = "Valentin Louis Georges Eugène Marcel",
                LastName = "Proust",
                Searchable = SearchFormatter.Format("Valentin Louis Georges Eugène Marcel", "Proust", SearchFormatter.FormatDate(new DateTime(1871, 7, 10))),
                DateOfBirth = new DateTime(1871, 7, 10),
                CountryId = db.Countries
                    .SingleOrDefault(country => country.Searchable == "france")
                    .CountryId
            },
            new Person // patron-author
            {
                FirstName = "Jane",
                LastName = "Doe",
                Searchable = SearchFormatter.Format("Jane", "Doe", SearchFormatter.FormatDate(new DateTime(2000, 1, 1))),
                DateOfBirth = new DateTime(2000, 1, 1),
                CountryId = countryId
            },
            new Person // librarian
            {
                FirstName = "John",
                LastName = "Smith",
                Searchable = SearchFormatter.Format("John", "Smith", SearchFormatter.FormatDate(new DateTime(1960, 12, 31))),
                DateOfBirth = new DateTime(1960, 12, 31),
                CountryId = countryId
            },
            new Person // guardian patron
            {
                FirstName = "Joe",
                LastName = "Johnson",
                Searchable = SearchFormatter.Format("Joe", "Johnson", SearchFormatter.FormatDate(new DateTime(1980, 7, 7))),
                DateOfBirth = new DateTime(1980, 7, 7),
                CountryId = countryId
            },
            new Person // child patron
            {
                FirstName = "Alexi",
                LastName = "Johnson",
                Searchable = SearchFormatter.Format("Alexi", "Johnson", SearchFormatter.FormatDate(new DateTime(2010, 10, 10))),
                DateOfBirth = new DateTime(2010, 10, 10),
                CountryId = countryId
            }
                });
                db.SaveChanges();
            }


            ApplicationUser[] members = new ApplicationUser[]
            {
            new ApplicationUser // patron-author
            {
                CardNumber = "100A0000001",
                UserName = "JaneMaster",
                Email = "jmaster@wordpiss.com",
                PhoneNumber = "010-224-0102",
                PersonId = db.Persons
                    .SingleOrDefault(person => person.Searchable.Contains("janedoe"))
                    .PersonId
            },
            new ApplicationUser // librarian
            {
                CardNumber = "A0000001",
                UserName = "Smith01",
                Email = "jjsmith@thislibrary.com",
                PhoneNumber = "110-110-1111",
                PersonId = db.Persons
                    .SingleOrDefault(person => person.Searchable.Contains("johnsmith"))
                    .PersonId
            },
            new ApplicationUser // child patron
            {
                CardNumber = "200A0000001",
                UserName = "Blue-27:0-40",
                PersonId = db.Persons
                    .SingleOrDefault(person => person.Searchable.Contains("alexijohnson"))
                    .PersonId
            },
            new ApplicationUser // guardian patron
            {
                CardNumber = "100A0000002",
                UserName = "1984Joe",
                Email = "19198484@megabox.com",
                PhoneNumber = "100-200-3004",
                PersonId = db.Persons
                    .SingleOrDefault(person => person.Searchable.Contains("joejohnson"))
                    .PersonId
            }
            };

            if (userManager.Users == null)
            {
                foreach (ApplicationUser user in members)
                    await userManager.CreateAsync(user, "a1");
                ApplicationUser patronauthor = await userManager.FindByNameAsync(members[0].UserName);
                await userManager.AddToRoleAsync(patronauthor, "author");
                ApplicationUser librarian = await userManager.FindByNameAsync(members[1].UserName);
                await userManager.AddToRoleAsync(librarian, "librarian");
                db.SaveChanges();
            }

            if (!db.Patrons.Any())
            {
                db.Patrons.AddRange(new Patron[]
                {
                new Patron // patron-author
                {
                    Searchable = db.Persons
                        .SingleOrDefault(person => person.Searchable.Contains("janedoe"))
                        .Searchable,
                    User = await userManager.FindByNameAsync(members[0].UserName)
                },
                new Patron // child patron
                {
                    Searchable = db.Persons
                        .SingleOrDefault(person => person.Searchable.Contains("alexijohnson"))
                        .Searchable,
                    User = await userManager.FindByNameAsync(members[2].UserName)
                },
                new Patron // guardian patron
                {
                    Searchable = db.Persons
                        .SingleOrDefault(person => person.Searchable.Contains("joejohnson"))
                        .Searchable,
                    User = await userManager.FindByNameAsync(members[3].UserName)
                }
                });
                db.SaveChanges();
            }

            if (!db.ChildGuardians.Any())
            {
                db.ChildGuardians.Add(new ChildGuardian
                {
                    Relation = "father",
                    ChildPatronId = db.Patrons
                        .SingleOrDefault(patron => patron.Searchable.Contains("alexi"))
                        .PatronId,
                    GuardianPatronId = db.Patrons
                        .SingleOrDefault(patron => patron.Searchable.Contains("joe"))
                        .PatronId,
                    HasPermissionToCheckoutAlone = true,
                    HasPermissionForComputer = true,
                    HasPermissionToPrint = false,
                    HasPermissionToPublish = false,
                    MaturityRatingId = db.MaturityRatings
                        .SingleOrDefault(rating => rating.Rating == "G")
                        .MaturityRatingId
                });
                db.SaveChanges();
            }

            if (!db.Authors.Any())
            {
                Author deceasedAuthor = new Author
                {
                    PenName = "Marcel Proust",
                    Searchable = SearchFormatter.Format(
                    db.Persons
                        .SingleOrDefault(person => person.Searchable.Contains("marcelproust"))
                        .Searchable,
                    "Marcel Proust"
                ),
                    Bio = "Marcel Proust was a French novelist, literary critic, and essayist who wrote the monumantal novel: In Search of Lost Time. The title was previously translated to: Remembrance of Things Past. The novel was originally in French and published in seven volumes between 1913 and 1927. He is considered by critics and writers to be one of the most influential authors of the 20th century.",
                    Deceased = true,
                    PersonId = db.Persons
                        .Single(person => person.Searchable.Contains("marcelproust"))
                        .PersonId
                };

                Author livingAuthor = new Author
                {
                    PenName = "J.D. Middler",
                    Searchable = SearchFormatter.Format(
                        db.Persons
                            .SingleOrDefault(person => person.Searchable.Contains("janedoe"))
                            .Searchable,
                        "J.D.Middler"
                    ),
                    Deceased = false,
                    PersonId = db.Persons
                        .SingleOrDefault(person => person.Searchable.Contains("janedoe"))
                        .PersonId
                };

                db.Authors.AddRange(new Author[]
                {
            deceasedAuthor,
            livingAuthor
                });
                db.SaveChanges();
            }

            if (!db.BookSeries.Any())
            {
                db.BookSeries.Add(new BookSerial
                {
                    Searchable = SearchFormatter.Format("In Search of Lost Time", "Marcel Proust"),
                    IsFinished = true
                });
                db.SaveChanges();
            }


            if (!db.SerialTitles.Any())
            {
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
                db.SaveChanges();
            }

            if (!db.Books.Any())
            {
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
                int serialId = db.BookSeries
                    .FirstOrDefault(serial => serial.Searchable == "insearchoflosttimemarcelproust")
                    .BookSerialId;

                Book[] books = new Book[titles.Length];
                int countryId = db.Countries
                    .SingleOrDefault(country => country.Searchable.Contains("france"))
                    .CountryId;
                for (int i = 0; i < books.Length; i++)
                    books[i] = new Book
                    {
                        Searchable = SearchFormatter.Format(titles[i], penname),
                        CountryId = countryId,
                        MaturityRatingId = ratingId,
                        BookSerialId = serialId,
                        NumInSeries = i + 1
                    };
                db.Books.AddRange(books);
                db.SaveChanges();
            }

            if (!db.BookTitles.Any())
            {
                int langId = db.Languages
                    .SingleOrDefault(lang => lang.Searchable == "english")
                    .LanguageId;
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
                db.SaveChanges();
            }

            if (!db.Contributors.Any())
            {
                db.Contributors.AddRange(new Contributor[]
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
                });
                db.SaveChanges();
            }

            if (!db.BookVersions.Any())
            {
                int langId = db.Languages
                    .SingleOrDefault(lang => lang.Searchable == "english")
                    .LanguageId;
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
            }

            if (!db.BookCopies.Any())
            {
                BookVersion[] bookversions = db.BookVersions.ToArray();
                List<BookCopy> bookcopies = new List<BookCopy>();
                foreach (BookVersion version in bookversions)
                {
                    for (int i = 0; i < 3; i++)
                        bookcopies.Add(new BookCopy
                        {
                            BookVersionId = version.BookVersionId,
                            BookId = version.BookId
                        });
                }
                db.BookCopies.AddRange(bookcopies.ToArray());
                db.SaveChanges();
            }

            if (!db.BookAuthors.Any())
            {
                Book[] books = db.Books.ToArray();
                int authorId = db.Authors
                    .SingleOrDefault(author => author.Searchable.Contains("marcelproust"))
                    .AuthorId;
                List<BookAuthor> bookauthors = new List<BookAuthor>();
                foreach (Book book in books)
                {
                    bookauthors.Add(new BookAuthor
                    {
                        BookId = book.BookId,
                        AuthorId = authorId
                    });
                }
                db.BookAuthors.AddRange(bookauthors.ToArray());
                db.SaveChanges();
            }

            if (!db.BookCategories.Any())
            {
                Book[] books = db.Books.ToArray();
                int categoryId = db.Categories
                    .SingleOrDefault(category => category.Searchable.Contains("modernist"))
                    .CategoryId;
                List<BookCategory> bookcategories = new List<BookCategory>();
                foreach (Book book in books)
                {
                    bookcategories.Add(new BookCategory
                    {
                        BookId = book.BookId,
                        CategoryId = categoryId
                    });
                }
                db.BookCategories.AddRange(bookcategories.ToArray());
                db.SaveChanges();
            }

            if (!db.Recommendations.Any())
            {
                db.Recommendations.Add(new Recommendation
                {
                    ShowAsAnonymous = false,
                    ConfirmedCheckout = true,
                    Rating = 4,
                    Review = "It was a long and hard read for me and my dad, but we did it!",
                    RecommendationForBook = true,
                    BookId = db.Books
                    .SingleOrDefault(book => book.Searchable.Contains("sodomandgomorrah"))
                    .BookId,
                    BookSerialId = db.BookSeries
                    .SingleOrDefault(serial => serial.Searchable.Contains("insearchoflosttime"))
                    .BookSerialId,
                    PatronId = db.Patrons
                    .SingleOrDefault(patron => patron.Searchable.Contains("alexi"))
                    .PatronId
                });
                db.SaveChanges();
            }

            if (!db.Checkouts.Any())
            {
                db.Checkouts.Add(new Checkout
                {
                    CheckedOut = new DateTime(2023, 6, 14),
                    DueDate = new DateTime(2023, 8, 9),
                    NumRenewals = 4,
                    BookCopyId = db.BookCopies
                    .Include(copy => copy.Book)
                    .FirstOrDefault(copy => copy.Book.Searchable.Contains("sodomandgomorrah"))
                    .BookCopyId,
                    PatronId = db.Patrons
                    .SingleOrDefault(patron => patron.Searchable.Contains("alexi"))
                    .PatronId,
                    StatusId = db.Statuses
                    .SingleOrDefault(status => status.Name == "Returned")
                    .StatusId
                });
                db.SaveChanges();
            }

            if (!db.OnHolds.Any())
            {
                db.OnHolds.Add(new OnHold
                {
                    DatePlaced = new DateTime(2023, 8, 6),
                    BookCopyId = db.BookCopies
                    .Include(copy => copy.Book)
                    .LastOrDefault(copy => copy.Book.Searchable.Contains("sodomandgomorrah"))
                    .BookCopyId,
                    PatronId = db.Patrons
                    .SingleOrDefault(patron => patron.Searchable.Contains("janedoe"))
                    .PatronId
                });
                db.SaveChanges();
            }

            if (db.WaitLists.Any())
            {
                int formatId = db.Formats
                    .SingleOrDefault(format => format.Searchable == "paperbook")
                    .FormatId;
                db.WaitLists.Add(new WaitList
                {
                    BookId = db.Books
                    .FirstOrDefault(book => book.Searchable.Contains("sodomandgomorrah"))
                    .BookId,
                    FormatId = formatId,
                    PatronId = db.Patrons
                    .SingleOrDefault(patron => patron.Searchable.Contains("janedoe"))
                    .PatronId
                });
                db.SaveChanges();
            }

            if (!db.UserNotifications.Any())
            {
                db.UserNotifications.Add(new UserNotification
                {
                    SentAt = DateTime.Now,
                    SeenByUser = false,
                    NotificationId = db.Notifications
                    .SingleOrDefault(notice => notice.Description.Contains("Checkout"))
                    .NotificationId,
                    User = await userManager.FindByNameAsync(members[0].UserName)
                });
                db.SaveChanges();
            }
        }
    }
}
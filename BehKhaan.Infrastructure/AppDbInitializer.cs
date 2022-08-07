using BehKhaan.Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehKhaan.Infrastructure
{
    public class AppDbInitializer
    {

        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                // Users
                if (!context.Users.Any())
                {
                    context.Users.AddRange(new List<User>()
                    {
                        new User()
                        {
                            Id = "A3C00A5E-D50F-4C24-8CFF-867EC6905F4C",
                            UserName = "user1",
                            FullName = "Ali"
                        },
                        new User()
                        {
                            Id = "5249E121-9D85-4D17-9D35-D4B23E502DB8",
                            UserName = "user2",
                            FullName = "Reza"
                        },
                        new User()
                        {
                            Id = "B0D56ECB-0754-4DD2-8644-707FC731C7E2",
                            UserName = "user3",
                            FullName = "Mohammad"
                        }
                    }
                    );
                    context.SaveChanges();
                }

                // Books
                if (!context.Books.Any())
                {
                    context.Books.AddRange(new List<Book>()
                    {
                        new Book()
                        {
                            Id = "A2A1E57F-C49C-4446-B352-CDC8F9CDE03C",
                            ISBN = "book1",
                            Name = "Shahname",
                            Description = "Ketab e ferdosi",
                            ImageURL = "https://persikad.com/wp-content/uploads/2020/10/SFE.jpg",
                            Price = 125000,
                            Rate = 5
                        },
                        new Book()
                        {
                            Id = "862356F0-A058-4907-ACD8-53DDE8B190EC",
                            ISBN = "book2",
                            Name = "Boostan",
                            Description = "Ketab e saadi",
                            ImageURL = "https://persikad.com/wp-content/uploads/2020/08/BOS1.jpg",
                            Price = 112500,
                            Rate = 4
                        },
                        new Book()
                        {
                            Id = "3FA00E74-FBA3-40E4-B20B-B0804281A08A",
                            ISBN = "book3",
                            Name = "Baharestan",
                            Description = "Ketab e jaami",
                            ImageURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQvKtgOWy8yobNDsb3Jjd8h3lNmReqzARyrdQ&usqp=CAU",
                            Price = 99000,
                            Rate = 3
                        }
                    }
                    );
                    context.SaveChanges();
                }

                // Shelfs
                if (!context.Shelfs.Any())
                {
                    context.Shelfs.AddRange(new List<Shelf>()
                    {
                        new Shelf()
                        {
                            Id = "F256CCC9-1630-41AB-8C65-DC43D923C641",
                            Name = "firstShelf",
                            UserId = "A3C00A5E-D50F-4C24-8CFF-867EC6905F4C"
                        },
                        new Shelf()
                        {
                            Id = "6D6A0699-C9B1-4F74-9ED8-0536D0F6D37B",
                            Name = "secondShelf",
                            UserId = "A3C00A5E-D50F-4C24-8CFF-867EC6905F4C"
                        },
                        new Shelf()
                        {
                            Id = "B4828CD6-F490-402B-A4B0-47B7E78C26F2",
                            Name = "Shelf1",
                            UserId = "5249E121-9D85-4D17-9D35-D4B23E502DB8"
                        },
                        new Shelf()
                        {
                            Id = "4FDE1165-1E74-4515-9A7C-9C6227E84633",
                            Name = "Shelf2",
                            UserId = "5249E121-9D85-4D17-9D35-D4B23E502DB8"
                        }
                    }
                    );
                    context.SaveChanges();
                }

                // Books & Shelfs
                if (!context.Books_Shelfs.Any())
                {
                    context.Books_Shelfs.AddRange(new List<Book_Shelf>()
                    {
                        new Book_Shelf()
                        {
                            BookId = "A2A1E57F-C49C-4446-B352-CDC8F9CDE03C",
                            ShelfId = "F256CCC9-1630-41AB-8C65-DC43D923C641",
                            StudyState = 2,
                            PuttingTime = DateTime.Parse("04/26/2022 11:34:05")
                        },
                        new Book_Shelf()
                        {
                            BookId = "862356F0-A058-4907-ACD8-53DDE8B190EC",
                            ShelfId = "6D6A0699-C9B1-4F74-9ED8-0536D0F6D37B",
                            StudyState = 3,
                            PuttingTime = DateTime.Parse("07/05/2022 14:36:46")
                        },
                        new Book_Shelf()
                        {
                            BookId = "A2A1E57F-C49C-4446-B352-CDC8F9CDE03C",
                            ShelfId = "4FDE1165-1E74-4515-9A7C-9C6227E84633",
                            StudyState = 1,
                            PuttingTime = DateTime.Parse("06/04/2022 23:12:29")
                        },
                        new Book_Shelf()
                        {
                            BookId = "862356F0-A058-4907-ACD8-53DDE8B190EC",
                            ShelfId = "4FDE1165-1E74-4515-9A7C-9C6227E84633",
                            StudyState = 2,
                            PuttingTime = DateTime.Parse("12/27/2021 22:28:42")
                        }
                    }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}

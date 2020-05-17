using Chat.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Data
{
    public static class SeedData
    {
        public static void Initialize(ChatContext context)
        {
            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new Models.User
                    {
                        FirstName = "Douglas",
                        LastName = "Dias",
                        Email = "douglas.dias@chat.com",
                        Password = Security.HashPassword("123qwe"),
                        BirthDate = new DateTime(1994, 2, 21)
                    },
                    new Models.User
                    {
                        FirstName = "Bruna",
                        LastName = "Ferreira",
                        Email = "bruna.ferreira@chat.com",
                        Password = Security.HashPassword("123qwe"),
                        BirthDate = new DateTime(1993, 12, 31)
                    }
                );

                context.SaveChanges();
            }
        }
    }
}

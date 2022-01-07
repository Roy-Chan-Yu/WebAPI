namespace EmptyWebApi.Migrations
{
    using EmptyWebApi.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EmptyWebApi.Models.EmptyWebApiContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EmptyWebApi.Models.EmptyWebApiContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Authors.AddOrUpdate(x => x.Id,
                new Author() { Id = 1, Name = "Royu" },
                new Author() { Id = 2, Name = "Alice" },
                new Author() { Id = 3, Name = "Bella" }
            );

            context.Books.AddOrUpdate(x => x.Id,
               new Book()
               {
                   Id = 1,
                   Title = "Pride and Prejudice",
                   Year = 1813,
                   AuthorId = 1,
                   Price = 9.99M,
                   Genre = "Comedy of manners"
               },
               new Book()
               {
                   Id = 2,
                   Title = "Northanger Abbey",
                   Year = 1817,
                   AuthorId = 1,
                   Price = 12.95M,
                   Genre = "Gothic parody"
               },
               new Book()
               {
                   Id = 3,
                   Title = "David Copperfield",
                   Year = 1850,
                   AuthorId = 2,
                   Price = 15,
                   Genre = "Bildungsroman"
               },
               new Book()
               {
                   Id = 4,
                   Title = "Don Quixote",
                   Year = 1617,
                   AuthorId = 3,
                   Price = 8.95M,
                   Genre = "Picaresque"
               });

        }
    }
}

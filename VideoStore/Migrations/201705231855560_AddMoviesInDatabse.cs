namespace VideoStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMoviesInDatabse : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, ReleaseDate, DateAdded, NumberInStock, GenreId) VALUES ('Hangover', '2012-02-02', '2013-02-02', 5, 1 )");
            Sql("INSERT INTO Movies (Name, ReleaseDate, DateAdded, NumberInStock, GenreId) VALUES ('Die Hard', '1997-10-11', '2000-02-02', 3, 2 )");
            Sql("INSERT INTO Movies (Name, ReleaseDate, DateAdded, NumberInStock, GenreId) VALUES ('Titanic', '1993-12-06', '1997-02-02', 1, 3 )");
            Sql("INSERT INTO Movies (Name, ReleaseDate, DateAdded, NumberInStock, GenreId) VALUES ('Inception', '2016-02-02', '2017-02-02', 8, 4 )");
        }
        
        public override void Down()
        {
        }
    }
}

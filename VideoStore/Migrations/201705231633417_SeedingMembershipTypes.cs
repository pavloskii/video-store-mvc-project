namespace VideoStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedingMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (Name, SignUpFee, DurationInMonths, DiscountRate) VALUES ('Pay as you Go', 0, 0, 0)");
            Sql("INSERT INTO MembershipTypes (Name, SignUpFee, DurationInMonths, DiscountRate) VALUES ('Monthly', 30, 1, 0)");
            Sql("INSERT INTO MembershipTypes (Name, SignUpFee, DurationInMonths, DiscountRate) VALUES ('Quartaly', 90, 3, 15)");
            Sql("INSERT INTO MembershipTypes (Name, SignUpFee, DurationInMonths, DiscountRate) VALUES ('Annual', 300, 12, 20)");
        }
        
        public override void Down()
        {
        }
    }
}

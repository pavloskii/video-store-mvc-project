namespace VideoStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipTypeTable : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name='Pay As You Go' WHERE MembershipTypeId=1");
        }
        
        public override void Down()
        {
        }
    }
}

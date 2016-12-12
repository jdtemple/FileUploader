namespace FileUploader.Data.Migrations
{
  using System.Data.Entity.Migrations;

  public partial class Upload_Column_Update : DbMigration
  {
    public override void Up()
    {
      AddColumn("dbo.Uploads", "Subfolder", c => c.String());
      DropColumn("dbo.Uploads", "Note");
    }

    public override void Down()
    {
      AddColumn("dbo.Uploads", "Note", c => c.String());
      DropColumn("dbo.Uploads", "Subfolder");
    }
  }
}

namespace FileUploader.Data.Migrations
{
  using System.Data.Entity.Migrations;

  public partial class UploadLocation : DbMigration
  {
    public override void Up()
    {
      CreateTable(
          "dbo.UploadLocations",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            Path = c.String(nullable: false),
            StartId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id);

    }

    public override void Down()
    {
      DropTable("dbo.UploadLocations");
    }
  }
}

namespace FileUploader.Data.Migrations
{
  using System.Data.Entity.Migrations;

  public partial class Upload : DbMigration
  {
    public override void Up()
    {
      CreateTable(
          "dbo.Uploads",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            Extension = c.String(),
            Note = c.String(),
            Title = c.String(),
            UploadType = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id);

    }

    public override void Down()
    {
      DropTable("dbo.Uploads");
    }
  }
}

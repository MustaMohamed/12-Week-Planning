using FluentMigrator;

namespace WeeksPlanning.Migration.Migrations
{
    [Migration(1)]
    public class _001_User: FluentMigrator.Migration
    {
        public override void Up()
        {
            Create.Table(Tables.User)
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Name").AsString(StringLength.Hundred)
                .WithColumn("Email").AsString(StringLength.Hundred)
                .WithColumn("Password").AsString(StringLength.Hundred)
                .WithColumn("IsActive").AsBoolean().WithDefaultValue(true).NotNullable()
                .WithColumn("LastLoginDate").AsDateTime().Nullable()
                .WithColumn("DateCreatedUtc").AsDateTime().NotNullable()
                .WithColumn("LastModifiedUtc").AsDateTime().Nullable();
        }

        public override void Down()
        {
            Delete.Table(Tables.User);
        }
        
    }
}
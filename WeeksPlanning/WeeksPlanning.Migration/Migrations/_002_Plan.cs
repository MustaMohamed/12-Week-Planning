using FluentMigrator;

namespace WeeksPlanning.Migration.Migrations
{
    [Migration(2)]
    public class _002_Plan : FluentMigrator.Migration
    {
        public override void Up()
        {
            Create.Table(Tables.Plan)
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Name").AsString(StringLength.Hundred)
                .WithColumn("StartingDateUtc").AsDateTime().NotNullable()
                .WithColumn("DurationInWeeks").AsInt16().WithDefaultValue(12).NotNullable()
                .WithColumn("IsActive").AsBoolean().WithDefaultValue(true).NotNullable()
                .WithColumn("DateCreatedUtc").AsDateTime().NotNullable()
                .WithColumn("CreatedByUserId").AsInt64().Nullable().ForeignKey(Tables.User, "Id").Indexed()
                .WithColumn("LastModifiedUtc").AsDateTime().Nullable()
                .WithColumn("LastModifiedByUserId").AsInt64().Nullable().ForeignKey(Tables.User, "Id").Indexed();
        }

        public override void Down()
        {
            Delete.Table(Tables.Plan);
        }
    }
}
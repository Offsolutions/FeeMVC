namespace MvcFeeManage.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcFeeManage.Areas.Auth.Models.dbcontext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;

        }

        protected override void Seed(MvcFeeManage.Areas.Auth.Models.dbcontext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
        public class SeedDbInitializer : DropCreateDatabaseAlways<MyDbContext>
        {
            protected override void Seed(MyDbContext context)
            {
                //context.Database.ExecuteSqlCommand(
                //                                   @"SELECT * INTO targetTable
                //                            FROM[sourceserver].[sourcedatabase].[dbo].[sourceTable]"
                //                                   );
                context.Database.ExecuteSqlCommand(
                                                  @"SELECT * INTO studentdatas
                                            FROM kohliData.studentdata"
                                                  );
                base.Seed(context);
            }
        }

        public class MyDbContext : DbContext
        {
            public MyDbContext() : base("dbcontext")
            {
                Database.SetInitializer<MyDbContext>(new SeedDbInitializer());
            }
            //public DbSet<User> Users { get; set; }
        }
    }
}

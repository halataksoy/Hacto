namespace HACTO.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HACTO.Models.DataContext.HactoDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;//otomatik migration özelliğini açtık büyük çaplı projelerde false olması mantıklı
        }

        protected override void Seed(HACTO.Models.DataContext.HactoDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}

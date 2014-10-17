namespace BT.Migrations
{
    using BT.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BT.Models.dbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BT.Models.dbContext context)
        {
            context.TStatus.AddOrUpdate(a => a.Id,
                new TStatus {Id = 1, TStatusName = "Черновик" },
                new TStatus {Id = 2, TStatusName = "Утверждено" }
                );
        }
    }
}

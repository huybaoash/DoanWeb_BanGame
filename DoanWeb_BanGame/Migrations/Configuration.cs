namespace DoanWeb_BanGame.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DoanWeb_BanGame.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DoanWeb_BanGame.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }

    public class CreateOrMigrateDatabaseInitializer<TContext, TConfiguration>
    : CreateDatabaseIfNotExists<TContext>, IDatabaseInitializer<TContext>
    where TContext : DbContext
    where TConfiguration : DbMigrationsConfiguration<TContext>, new()
    {

        void IDatabaseInitializer<TContext>.InitializeDatabase(TContext context)
        {
            if (context.Database.Exists())
            {
                if (!context.Database.CompatibleWithModel(throwIfNoMetadata: false))
                {
                    var migrationInitializer = new MigrateDatabaseToLatestVersion<TContext, TConfiguration>(true);
                    migrationInitializer.InitializeDatabase(context);
                }
            }

            base.InitializeDatabase(context);
        }
    }
}

using System;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using Castle.Core.Internal;
using Castle.Windsor;
using Core.Domain;
using Core.Domain.Base;
using Core.Features.Queries.Base;
using Microsoft.AspNet.Identity.EntityFramework;
using Classes = Castle.MicroKernel.Registration.Classes;

namespace Core
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetAssembly(typeof(ApplicationDbContext)));
            using (var container = new WindsorContainer())
            {
                var method = typeof (DbModelBuilder).GetMethod("Entity");

                container.Register(
                    Classes.FromAssemblyContaining<ApplicationUser>()
                        .BasedOn<Entity>()
                        .If(x => !x.IsAbstract)
                        .WithServices(typeof (Entity)));
                container.ResolveAll<Entity>()
                    .ForEach(x => method.MakeGenericMethod(x.GetType()).Invoke(modelBuilder, new object[] {}));
            }
        }

        public override int SaveChanges()
        {
            var now = DateTime.Now;
            foreach (
                var created in
                    ChangeTracker.Entries().Where(x => x.Entity is EntityWithCreated && x.State == EntityState.Added))
            {
                ((EntityWithCreated) created.Entity).Created = now;
                ((EntityWithCreated) created.Entity).Modified = now;
            }
            foreach (
                var modified in
                    ChangeTracker.Entries().Where(x => x.Entity is Entity && (x.State == EntityState.Modified || x.State == EntityState.Added)))
                ((Entity) modified.Entity).Modified = now;

            return base.SaveChanges();
        }
    }
}
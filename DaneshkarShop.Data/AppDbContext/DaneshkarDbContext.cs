using DaneshkarShop.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaneshkarShop.Data.AppDbContext
{
    public class DaneshkarDbContext : DbContext
    {
        #region Ctor
        public DaneshkarDbContext(DbContextOptions options) : base(options)
        {
        }
        #endregion

        #region DbSet
        public DbSet<User> Users { get; set; }
        #endregion

        #region Model Creating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Cascade;

            base.OnModelCreating(modelBuilder);
        }
        #endregion



    }


}

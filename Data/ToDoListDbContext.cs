using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyTodoListApi.Models;
using System;

namespace MyTodoListApi.Data
{
    public class ToDoListDbContext:IdentityDbContext<CurrentUser>
    {
        #region public Properties

        public DbSet<ToDoItemModel> TodoItems { get; set; }

        #endregion 
        public ToDoListDbContext(DbContextOptions<ToDoListDbContext> options):base(options)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ToDoItemModel>().ToTable("ToDoItemModel");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using MyTodoListApi.Models;
using System;

namespace MyTodoListApi.Data
{
    public class ToDoListDbContext:DbContext
    {
        #region public Properties

        public DbSet<ToDoItemModel> TodoList { get; set; }

        #endregion MyRegion
        public ToDoListDbContext(DbContextOptions<ToDoListDbContext> options):base(options)
        {

        }
        
        public void SeedData()
        {
            TodoList.AddRange(new ToDoItemModel() {  IsComplete =false , Task="Wash plates" },
                new ToDoItemModel() {  IsComplete = true, Task = "read books" },
                new ToDoItemModel() { IsComplete = false, Task = "write Code" });
                SaveChanges();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

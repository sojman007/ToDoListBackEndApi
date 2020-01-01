using Microsoft.AspNetCore.Mvc;
using MyTodoListApi.Data;
using MyTodoListApi.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;

namespace MyTodoListApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController:ControllerBase
    {
        protected ToDoListDbContext context;
        public ToDoController(ToDoListDbContext _context)
        {
            context = _context;

            context.Database.EnsureCreated();
            if (!context.TodoList.Any())
            {
                context.SeedData();

            }
            
        }

        //create simple get and post methods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoItemModel>>> Get() =>  await context.TodoList.ToListAsync();

       [HttpGet("{Id}")]
       
       public ActionResult <ToDoItemModel> GetId(string Id)
        {

            var Item = context.TodoList.Find(Id) ;
            if (Item == null) return NotFound();
            
            return Item;
        }



        [HttpPost]
        public ActionResult<ToDoItemModel> Create (ToDoItemModel Item)
        {

            if (context.TodoList.Find(Item.Id) != null) return BadRequest("You Cannot Create An Already Existing Object"); 
            context.TodoList.Add(Item);
            context.SaveChanges();
            return CreatedAtAction(nameof(GetId), new { id = Item.Id }, Item); 
        }

        [HttpPut("{Id}")]
        public ActionResult<ToDoItemModel> EditItem (string Id, ToDoItemModel model)
        {


            if (Id != model.Id) return NotFound();
            
            context.Entry(model).State = EntityState.Modified;
            context.SaveChanges();

            return NoContent();
        }
       
        [HttpDelete("{Id}")]
        public ActionResult<ToDoItemModel> RemoveItem(string Id)
        {

            var Item = context.TodoList.Find(Id);
            context.TodoList.Remove(Item);
            context.SaveChanges();
            return NoContent();
        }
       
    }
}

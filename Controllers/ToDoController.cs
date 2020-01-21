using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTodoListApi.Data;
using MyTodoListApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTodoListApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController:ControllerBase
    {
        protected ToDoListDbContext context;
        public ToDoController(ToDoListDbContext _context)
        {
            context = _context;
           
            
        }

        //create simple get and post methods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoItemModel>>> Get() =>  await context.TodoItems.ToListAsync();

       [HttpGet("{Id}")]
       
       public ActionResult<ToDoItemModel> GetId(int Id)
        {

            var Item =   context.TodoItems.Find(Id) ;
            if (Item == null) return NotFound();

            return Ok(Item);
            
           // return Item;
        }



        [HttpPost]
        public ActionResult<ToDoItemModel> Create (ToDoItemModel Item)
        {

            if (context.TodoItems.Find(Item.Id) != null) return BadRequest("You Cannot Create An Already Existing Object"); 
            context.TodoItems.Add(Item);
            context.SaveChanges();
            return Created(Item.Id.ToString() , Item); 
        }

        [HttpPut("{Id}")]
        public ActionResult<ToDoItemModel> EditItem (int Id, ToDoItemModel model)
        {


            if (Id != model.Id) return NotFound();
            
            context.Entry(model).State = EntityState.Modified;
            context.SaveChanges();

            return NoContent();
        }
       
        [HttpDelete("{Id}")]
        public async Task<ActionResult<ToDoItemModel>> RemoveItem(int Id)
        {

            var Item =  await    context.TodoItems.FindAsync(Id);
            if (Item == null) return NotFound("Impossible to Delete a Non Existent Item");
            context.TodoItems.Remove(Item);
             await context.SaveChangesAsync();
            return   NoContent();
        }
       
    }
}

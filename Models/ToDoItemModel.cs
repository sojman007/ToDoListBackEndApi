using System;
using System.ComponentModel.DataAnnotations;

namespace MyTodoListApi.Models
{
    public class ToDoItemModel
    {
        [Key]
        public int Id { get; set; } 
        [Required]
        [MaxLength(2048)]
        public string Task { get; set; }
        public bool IsComplete { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        
        public DateTime CompletedDateTime { get; set; }
       
    
    }
}

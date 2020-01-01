using System;
using System.ComponentModel.DataAnnotations;

namespace MyTodoListApi.Models
{
    public class ToDoItemModel
    {
        [Key]
        [Required]
        public string Id { get; set; } = new Guid().ToString();
        [Required]
        [MaxLength(2048)]
        public string Task { get; set; }
        public bool IsComplete { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

      //  public ToDoItemModel() => CreatedDateTime = DateTime.Now;

    }
}

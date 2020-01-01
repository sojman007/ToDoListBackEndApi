using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyTodoListApi.Models
{
    public class CurrentUser
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(32)]
        [MinLength(8)]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        [MaxLength(16)]
        [MinLength(8)]
        
        public string Password { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public IEnumerable<ToDoItemModel> ToDoITems { get; set; }

    }
}

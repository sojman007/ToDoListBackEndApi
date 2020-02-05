using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyTodoListApi.Models
{
    public class LogInModel
    {
       [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        
    }
}

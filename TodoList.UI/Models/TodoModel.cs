using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoList.UI.Models
{
    public class TodoModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }

 
}
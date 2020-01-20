using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Todo")]
    public class Todo : Entity<int>
    {
        public string Description { get; set; }
    }
}

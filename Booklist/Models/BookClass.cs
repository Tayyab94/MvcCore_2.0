using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Booklist.Models
{
    public class BookClass
    {
        public int id { get; set; }

       [Required(ErrorMessage ="Please Enter your Book Name")]
     
        public string Name { get; set; }
    }
}

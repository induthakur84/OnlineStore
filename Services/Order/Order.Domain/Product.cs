using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Order.Domain
{
    public class Product
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //Many to many relationships

        //one product can belong to multiple categories

        //one category can belong to multiple products
        public ICollection<Category> Categories { get; set; } = new List<Category>();

    }
}

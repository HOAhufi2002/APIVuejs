using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo_Nextjs.Models
{
    public class SanPhamDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public bool OnSale { get; set; }
    }
}

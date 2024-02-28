using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace stroi_modern
{
    public class Product
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public long Article { get; set; }
        public int Price { get; set; }

        public string Img_name { get; set; }

        public int Type_id { get; set; }

        public int Count { get; set; }

    }
}

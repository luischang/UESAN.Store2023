using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Store.CORE.Entities;

namespace UESAN.Store.CORE.DTOs
{
    public class OrderDetailDTO
    {
        public int Id { get; set; }

        public int? OrdersId { get; set; }

        public int? ProductId { get; set; }

        public int? Quantity { get; set; }

        public decimal? Price { get; set; }

        public DateTime? CreatedAt { get; set; }

        public virtual Orders? Orders { get; set; }

        public virtual Product? Product { get; set; }
    }

    public class OrderDetailInsertDTO
    {
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }

    }
}

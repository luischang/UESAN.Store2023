using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Store.CORE.DTOs
{
    public class PaymentDTO
    {
        public int Id { get; set; }

        public int? OrdersId { get; set; }

        public decimal? TotalAmount { get; set; }

        public string? PaymentMethod { get; set; }
        public string? Status { get; set; }
    }
    public class PaymentMethodDescriptionDTO
    {
        public int Id { get; set; }

        public string? PaymentMethod { get; set; }

        public string? Status { get; set; }

        public decimal? TotalAmount { get; set; }
        public int? OrdersId { get; set; }

       
    }
    public class PaymentInsertDTO
    {
       

        public string? PaymentMethod { get; set; }

        public string? Status { get; set; }

        public decimal? TotalAmount { get; set; }
        public int? OrdersId { get; set; }


    }
    public class PaymentUpdateDTO
    {


        public string? PaymentMethod { get; set; }

        public string? Status { get; set; }

        public decimal? TotalAmount { get; set; }

        public int? OrdersId { get; set; }


    }
}

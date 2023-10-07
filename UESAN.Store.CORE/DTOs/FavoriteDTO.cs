using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Store.CORE.Entities;

namespace UESAN.Store.CORE.DTOs 
{
    public class FavoriteDTO
    {
		public int Id { get; set; }

		public int? UserId { get; set; }

		public int? ProductId { get; set; }

		public DateTime? CreatedAt { get; set; }
	}
	public class FavoriteUserDTO
	{
		public int? UserId { get; set; }
		public virtual User? User { get; set; }

	}
	public class FavoriteProductDTO
	{
		public int? ProductId { get; set; }

		public virtual Product? Product { get; set; }

	}
	public class FavoriteConsultDTO
	{
		public int Id { get; set; }
		public DateTime? CreatedAt { get; set; }
	}

}

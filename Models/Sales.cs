using System;

namespace PropertySearch.Models
{
	public class Sales
	{
		public int Id { get; set; }
		public int PropertyId { get; set; }
		public DateTime SaleDate { get;set;}
		
		public double SalePrice { get; set; }
		
	}
}

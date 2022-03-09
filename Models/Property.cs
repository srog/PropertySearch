using System;
using System.ComponentModel;

namespace PropertySearch.Models
{
	public class Property
	{
		public int Id { get; set; }
		[DisplayName ( "Address Line 1" )]
		public string AddressLine1 { get; set; }
		[DisplayName( "Address Line 2" )]
		public string AddressLine2 { get; set; }
		[DisplayName( "Address Line 3" )]
		public string AddressLine3 { get; set; }
		[DisplayName( "Postcode" )]
		public string Postcode { get; set; }		
		public double LastSoldPrice { get; set; }
		[DisplayName( "Last Sold Price" )]
		public string LastSoldPriceDisplay
		{
			get
			{
				if( LastSoldPrice == 0 )
				{
					return "";
				}
				else
				{
					return String.Format( "£{0}", LastSoldPrice );
				}
			}
		}
		public DateTime LastSoldDate { get; set; }
		[DisplayName( "Last Sold Date" )]
		
		public string LastSoldDateDisplay
		{
			get
			{
				if( LastSoldDate == DateTime.MinValue )
				{
					return "None";
				}
				else
				{
					return LastSoldDate.ToLongDateString();
				}
			}
		}
		
		
	}
}

using System;
using System.Collections.Generic;
using PropertySearch.Models;

namespace PropertySearch.DataAccess
{
	public interface IDataAccess
	{
		public List<Property> GetAllProperties();
		public List<Property> GetAllPropertiesByPostcode(string postcode);
		public Property GetPropertyById( int id );
		public Sales GetLatestSaleForProperty( int propertyId );
		public List<Sales> GetSalesForProperty( int propertyId );

	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using PropertySearch.Models;

namespace PropertySearch.DataAccess
{
	public class TestDataAccess : IDataAccess
	{
		public List<Property> GetAllProperties()
		{
			return _properties;
		}

		public List<Property> GetAllPropertiesByPostcode(string postcode)
		{
			return _properties.Where(p => p.Postcode == postcode).ToList();
		}

		public Sales GetLatestSaleForProperty( int propertyId )
		{
			return _sales
				.Where( s => s.PropertyId == propertyId )
				.OrderByDescending(s => s.SaleDate)
				.FirstOrDefault();
		}

		public Property GetPropertyById( int id )
		{
			return _properties
				.Where( p => p.Id == id )
				.FirstOrDefault();
		}

		public List<Sales> GetSalesForProperty( int propertyId )
		{
			return _sales
				.Where( s => s.PropertyId == propertyId )
				.OrderByDescending( s => s.SaleDate )
				.ToList();
		}

		private static readonly List<Sales> _sales = new List<Sales>()
		{
			new Sales { Id = 1, PropertyId = 1, SaleDate = DateTime.Now.AddDays(-200), SalePrice = 145000 },
			new Sales { Id = 2, PropertyId = 1, SaleDate = DateTime.Now.AddDays(-2000), SalePrice = 122000 },
			new Sales { Id = 3, PropertyId = 2, SaleDate = DateTime.Now.AddDays(-455), SalePrice = 180000 },
			new Sales { Id = 4, PropertyId = 8, SaleDate = DateTime.Now.AddDays(-1200), SalePrice = 350000 },
			new Sales { Id = 5, PropertyId = 10, SaleDate = DateTime.Now.AddDays(-500), SalePrice = 243000 },
			new Sales { Id = 6, PropertyId = 13, SaleDate = DateTime.Now.AddDays(-900), SalePrice = 120000 }
		};

		private static readonly List<Property> _properties = new List<Property>()
		{
			new Property { Id = 1, AddressLine1 = "1 High Street", AddressLine2 = "Cheadle", Postcode = "sk14nn" },
			new Property { Id = 2, AddressLine1 = "2 High Street", AddressLine2 = "Cheadle", Postcode = "sk14nn" },
			new Property { Id = 3, AddressLine1 = "3 High Street", AddressLine2 = "Cheadle", Postcode = "sk14nn" },
			new Property { Id = 4, AddressLine1 = "4 High Street", AddressLine2 = "Cheadle", Postcode = "sk14nn" },
			new Property { Id = 5, AddressLine1 = "5 High Street", AddressLine2 = "Cheadle", Postcode = "sk14nn" },
			new Property { Id = 6, AddressLine1 = "6 High Street", AddressLine2 = "Cheadle", Postcode = "sk14nn" },
			new Property { Id = 7, AddressLine1 = "7 Low Street", AddressLine2 = "Cheadle", Postcode = "sk14eq" },
			new Property { Id = 8, AddressLine1 = "18 Low Street", AddressLine2 = "Cheadle", Postcode = "sk14eq" },
			new Property { Id = 9, AddressLine1 = "20 Low Street", AddressLine2 = "Cheadle", Postcode = "sk14eq" },
			new Property { Id = 10, AddressLine1 = "25 Low Street", AddressLine2 = "Cheadle", Postcode = "sk14eq" },
			new Property { Id = 11, AddressLine1 = "35 Low Street", AddressLine2 = "Cheadle", Postcode = "sk14eq" },
			new Property { Id = 12, AddressLine1 = "45 Low Street", AddressLine2 = "Cheadle", Postcode = "sk14eq" },
			new Property { Id = 13, AddressLine1 = "50 Low Street", AddressLine2 = "Cheadle", Postcode = "sk14eq" }

		};
	}
}

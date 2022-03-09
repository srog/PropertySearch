using System;
using PropertySearch.DataAccess;
using PropertySearch.Models;

namespace PropertySearch.Services
{
	public class PropertySearchService : ISearchService
	{
		private readonly IDataAccess _dataAccess;
	
		public PropertySearchService(IDataAccess dataAccess)
		{
			_dataAccess = dataAccess;
		}

		public PropertySearchResults Search(string postcodeSearch)
		{
			var propertyList = _dataAccess.GetAllPropertiesByPostcode(postcodeSearch);

			foreach( var property in propertyList )
			{
				var latestSale = _dataAccess.GetLatestSaleForProperty( property.Id );
				if( latestSale == null )
				{
					property.LastSoldDate = DateTime.MinValue;
					property.LastSoldPrice = 0;
				}
				else
				{
					property.LastSoldDate = latestSale.SaleDate;
					property.LastSoldPrice = latestSale.SalePrice;
				}
			}


			return new PropertySearchResults { SearchResults = propertyList };	
		}
	}
}

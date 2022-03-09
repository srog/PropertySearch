using PropertySearch.Models;

namespace PropertySearch.Services
{
	public interface ISearchService
	{
		public PropertySearchResults Search( string postcodeSearch );
	}
}

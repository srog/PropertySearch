using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PropertySearch.Models;
using PropertySearch.Services;

namespace PropertySearch.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ISearchService _searchService;

		public HomeController( ILogger<HomeController> logger, ISearchService searchService )
		{
			_logger = logger;
			_searchService = searchService;
		}

		public IActionResult Index()
		{
			ViewBag.postcode = "";
			return View();
		}

		public IActionResult Search( string searchPostcode )
		{
			var propertyList = _searchService.Search( searchPostcode );
			ViewBag.postcode = searchPostcode; 

			return View( "Index", propertyList );
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache( Duration = 0, Location = ResponseCacheLocation.None, NoStore = true )]
		public IActionResult Error()
		{
			return View( new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier } );
		}
	}
}

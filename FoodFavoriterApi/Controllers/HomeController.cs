using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

using System.Web.Http;

using FoodFavoriter.Api.Service;

namespace FoodFavoriterApi.Controllers
{
	public class HomeController : ApiController
	{
		FavoriterService favoriterService;

		public HomeController()
		{
		}

		public HomeController(FavoriterService favoriterService)
		{
			this.favoriterService = favoriterService;
		}

		[System.Web.Http.AcceptVerbs("GET", "POST")]
		[System.Web.Http.HttpGet]
		public string Index()
		{
			favoriterService.FavouriteFoodItem("ref-001", 1234567);
			return "hi";
		}
	}
}

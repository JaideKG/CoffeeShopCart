using CoffeeShopCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoffeeShopCart.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}
		public ActionResult Menu()
		{
			CoffeeShopEntities db = new CoffeeShopEntities();
			List<Item> items = db.Items.ToList();
			ViewBag.Items = items;

			ViewBag.Statuses = db.Items.ToList();

			return View();
		}
		//filter by Name
		public ActionResult MenuByName(string name)
		{
			CoffeeShopEntities db = new CoffeeShopEntities();
			//LINQ Query
			List<Item> items = (from i in db.Items
								where i.Name == name
								select i).ToList();
			ViewBag.Name = items;

			ViewBag.Name = db.Items.ToList();

			return View("Menu");
		}

		public ActionResult MenuByDescription(string description)
		{
			CoffeeShopEntities db = new CoffeeShopEntities();
			//LINQ Query
			List<Item> items = (from i in db.Items
								where i.Description.Contains(description)
								select i).ToList();
			ViewBag.Items = items;

			ViewBag.Names = db.Items.ToList();

			return View("Menu");
		}

		public ActionResult MenuSorted(string column)
		{
			CoffeeShopEntities db = new CoffeeShopEntities();
			//LINQ Query
			if (column == "ID")
			{
				ViewBag.Items = (from i in db.Items
								 orderby i.ID
								 select i).ToList();
			}
			else if (column == "Name")
			{
				ViewBag.Items = (from i in db.Items
								 orderby i.Name
								 select i).ToList();
			}
			else if (column == "Description")
			{
				ViewBag.Items = (from i in db.Items
								 orderby i.Description
								 select i).ToList();
			}
			else if (column == "Quantity")
			{
				ViewBag.Items = (from i in db.Items
								 orderby i.Quantity
								 select i).ToList();
			}
			else if (column == "Price")
			{
				ViewBag.Items = (from i in db.Items
								 orderby i.Price
								 select i).ToList();
			}

			ViewBag.Statuses = db.Items.ToList();

			return View("Menu");
		}

		public ActionResult Add(int id)
		{
			CoffeeShopEntities db = new CoffeeShopEntities();

			//check if the Cart object already exists
			if (Session["Cart"] == null)
			{
				List<Item> cart = new List<Item>();
				cart.Add((from i in db.Items
						  where i.ID == id
						  select i).Single());

				Session.Add("Cart", cart);
			}
			else
			{
				//if it does exist, get the list
				List<Item> cart = (List<Item>)(Session["Cart"]);
				//add this book to it
				cart.Add((from i in db.Items
						  where i.ID == id
						  select i).Single());
				//(add it back to the session)
				Session["Cart"] = cart;
			}
			return View();
		}
	}
}
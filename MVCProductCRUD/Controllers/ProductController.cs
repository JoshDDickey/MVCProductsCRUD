using DataLayer;
using DataLayer.Models;
using MVCProductCRUD.Mapping;
using MVCProductCRUD.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;

namespace MVCProductCRUD.Controllers
{
    public class ProductController : Controller
    {
        //Dependencies
        private static string connectionString = ConfigurationManager.ConnectionStrings["serverConnectString"].ConnectionString;
        private ProductsDAO dataAccess;

        //Basic Constructor
        public ProductController()
        {
            //Calls the Constructor for ProductDAO so that this layer has data access to the DataLayer
            dataAccess = new ProductsDAO(connectionString);
        }

        //Index/Read Products
        [HttpGet]
        public ActionResult Index()
        {
            //Declaring local variables
            List<ProductPO> mappedProducts = new List<ProductPO>();

            try
            {
                //Reading products into a list of data objects, and mapping them to a list of presentation objects
                List<ProductDO> productList = dataAccess.ReadAllProducts();
                mappedProducts = ProductMapper.MapDOToPO(productList);
            }
            catch (Exception ex)
            {
                //Setting an error message if there was a problem reading data
                TempData["Message"] = "Cannot display Products at this time!";
            }

            //Calling the view and sending the list of presentation objects
            return View(mappedProducts);
        }
    }
}
using IdentityLab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityLab.DAO
{
    public class DAOclass
    {

        //This function adds the information to a user object and adds it to the DB
       

        //This function puts product items into a list
        public static List<Product> GenerateProductList()
        {
            ProductsEntities db = new ProductsEntities();
            List<Product> products = db.Products.ToList();
            return products;
        }

        //This adds a product to the session cart
        public static List<Product> AddItemToCartList(int id)
        {
            ProductsEntities db = new ProductsEntities();
            //check if cart alreay exists
            if (HttpContext.Current.Session["Cart"] == null)
            {
                //make a new list
                List<Product> cart = new List<Product>();
                //add this product to it
                cart.Add((from p in db.Products
                          where p.ID == id
                          select p).Single());
                //add the list to the session
                HttpContext.Current.Session.Add("Cart", cart);
                return cart;
            }
            else
            {
                //if the cart isn't empty
                List<Product> cart = (List<Product>)(HttpContext.Current.Session["Cart"]);
                //add book to cart
                cart.Add((from p in db.Products
                          where p.ID == id
                          select p).Single());
                return cart;
            }
        }

        //This function searches the description of product listings
        public static List<Product> SearchProductList(string term)
        {
            ProductsEntities db = new ProductsEntities();
            List<Product> results = (from r in db.Products
                                     where r.Description.Contains(term)
                                     select r).ToList();
            return results;

        }

        //This function deletes from the shopping cart
        public static List<Product> DeleteItemFromCartList(int id)
        {
            ProductsEntities db = new ProductsEntities();
            //check if cart alreay exists
            if (HttpContext.Current.Session["Cart"] == null)
            {
                //make a new list
                List<Product> cart = new List<Product>();
                //add this product to it
                cart.Remove((from p in db.Products
                             where p.ID == id
                             select p).Single());
                //add the list to the session
                HttpContext.Current.Session.Add("Cart", cart);
                return cart;
            }
            else
            {
                //if the cart isn't empty
                List<Product> cart = (List<Product>)(HttpContext.Current.Session["Cart"]);
                //add book to cart
                cart.Remove((from p in db.Products
                             where p.ID == id
                             select p).Single());
                return cart;
            }
        }

        public static double GenerateCheckOutTotals()
        {
            //Figure out way to calculate total price if the cart
            return 0;
        }
    }
}
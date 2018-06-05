using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication34.Models;

namespace WebApplication34.Repositories
{
    public class SortProducts
    {
        public IEnumerable<ProductsModel> SortByName()
        {
            using (AspProjectEntities asp = new AspProjectEntities())
            {
                var products = (from p in asp.Products
                                orderby p.Title ascending
                                where p.State == (int)state.upload
                                select new ProductsModel
                                {
                                    title = p.Title,
                                    price = (long)p.Price,
                                    shortDescription = p.ShortDescription,
                                    longDescription = p.LongDescription,
                                    image1 = p.Picture1,
                                    image2 = p.Picture2,
                                    image3 = p.Picture3,
                                    date = p.Date,
                                    status = (state)p.State,
                                    ID = p.ProductID
                                }).ToList();
                return products;
            }
        }
        public IEnumerable<ProductsModel> SortByDate()
        {
            using (AspProjectEntities asp = new AspProjectEntities())
            {
                var products = (from p in asp.Products
                                orderby p.Date ascending
                                where p.State == (int)state.upload
                                select new ProductsModel
                                {
                                    title = p.Title,
                                    price = (long)p.Price,
                                    shortDescription = p.ShortDescription,
                                    longDescription = p.LongDescription,
                                    image1 = p.Picture1,
                                    image2 = p.Picture2,
                                    image3 = p.Picture3,
                                    date = p.Date,
                                    status = (state)p.State,
                                    ID = p.ProductID
                                }).ToList();
                return products;
            }
        }
    }
}
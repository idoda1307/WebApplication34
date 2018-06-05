using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication34.Models;
namespace WebApplication34.Repositories
{
    public class UpdateProductState
    {
        public void ChangeProductStateAddedToCart()
        {
            var date = DateTime.Now.AddMinutes(-20);
            using (AspProjectEntities asp = new AspProjectEntities())
            {
                var prod = asp.Products.Where(p => p.State == (int)state.cart && date > p.DateAddedToCart).ToList();
                foreach(var p in prod)
                {
                    p.UserID = null;
                    p.State = (int)state.upload;
                    asp.Entry(p).State = EntityState.Modified;
                    asp.SaveChanges();
                }
            }
        }
        public void ChangeStateToCartGuest(long id)
        {
            using (AspProjectEntities asp = new AspProjectEntities())
            {
                Product p = asp.Products.Where(prod=>prod.State == (int)state.upload
                && prod.ProductID == id).FirstOrDefault();
                if (p != null)
                {
                    p.DateAddedToCart=DateTime.Now;
                    p.State = (int)state.cart;
                    asp.Entry(p).State = EntityState.Modified;
                    asp.SaveChanges();
                }
            }
        }
        public void ChangeProductStateToCart(long ID, long uID)
        {
            using (AspProjectEntities asp = new AspProjectEntities())
            {
                Product p = asp.Products.Where(prod => prod.ProductID == ID && prod.State==(int)state.upload).FirstOrDefault();
                if (p != null)
                {
                    p.DateAddedToCart = DateTime.Now;
                    p.UserID = uID;
                    p.State = (int)state.cart;
                    asp.Entry(p).State = EntityState.Modified;
                    asp.SaveChanges();
                }
            }
        }
        public void ChangeProductStateToBoughtUser(long uID)
        {
            using (AspProjectEntities asp = new AspProjectEntities())
            {
                var p = asp.Products.Where(prod => prod.State == (int)state.cart
                && prod.UserID==uID).ToList();
                foreach(var item in p)
                {
                    if(item!=null)
                    {
                        item.State = (int)state.bought;
                        item.OwnerID = item.UserID;
                        item.UserID = null;
                        asp.Entry(item).State = EntityState.Modified;
                        asp.SaveChanges();
                    }
                }
            }
        }
        public void ChangeProductStateToBoughtGuest(long id)
        {
            using (AspProjectEntities asp = new AspProjectEntities())
            {
                var p = asp.Products.Where(prod => prod.State == (int)state.cart && prod.ProductID==id).FirstOrDefault();
                    if (p != null)
                    {
                        p.OwnerID = null;
                        p.State = (int)state.bought;
                        asp.Entry(p).State = EntityState.Modified;
                        asp.SaveChanges();
                    }
            }
        }
        public void ChangeProductStateToAvailable()
        {
            using (AspProjectEntities asp = new AspProjectEntities())
            {
                Product p = asp.Products.Where(prod => prod.State == (int)state.cart).SingleOrDefault();
                if (p != null)
                {
                    p.State = (int)state.upload;
                    p.UserID = null;
                    asp.Entry(p).State = EntityState.Modified;
                    asp.SaveChanges();
                }
            }
        }
        public void ChangeProductStateToUploaded(long id)
        {
            using (AspProjectEntities asp = new AspProjectEntities())
            {
                Product p = asp.Products.Where(pr => pr.ProductID == id && pr.State == (int)state.cart).SingleOrDefault();
                if (p != null)
                {
                    p.State = (int)state.upload;
                    p.UserID = null;
                    asp.Entry(p).State = EntityState.Modified;
                    asp.SaveChanges();
                }
            }
        }
    }
}
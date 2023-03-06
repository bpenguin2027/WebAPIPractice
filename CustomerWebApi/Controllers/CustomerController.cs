using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CustomerWebApi.Models;

namespace CustomerWebApi.Controllers
{
    public class CustomerController : ApiController
    {
        // GET: api/Customer
        public List<tCustomer> Get()
        {
            using (dbCustomerEntities db = new dbCustomerEntities())
            {
                return db.tCustomer.OrderBy(m => m.Id).ToList();
            }
        }

        // GET: api/Customer/5
        public tCustomer Get(int id)
        {
            using (dbCustomerEntities db = new dbCustomerEntities())
            {
                return db.tCustomer.Where(m => m.Id == id).FirstOrDefault();
            }
        }

        // POST: api/Customer
        public int Post(string name, string phone, string email, string address)
        {
            using (dbCustomerEntities db = new dbCustomerEntities())
            {
                int num = 0;
                try
                {
                    tCustomer customer = new tCustomer();
                    customer.Name = name;
                    customer.Phone = phone;
                    customer.Email = email;
                    customer.Address = address;
                    db.tCustomer.Add(customer);
                    num = db.SaveChanges();
                }
                catch (Exception ex)
                {
                    num = 0;
                }
                return num;
            }
        }

        // PUT: api/Customer/5
        public int Put(int id, string name, string phone, string email, string address)
        {
            using (dbCustomerEntities db = new dbCustomerEntities())
            {
                int num = 0;
                try
                {
                    var customer = db.tCustomer.Where(m => m.Id == id).FirstOrDefault();
                    if (customer != null)
                    {
                        customer.Name = name;
                        customer.Phone = phone;
                        customer.Email = email;
                        customer.Address = address;
                        num = db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    num = 0;
                }
                return num;
            }
        }

        // DELETE: api/Customer/5
        public int Delete(int id)
        {
            using (dbCustomerEntities db = new dbCustomerEntities())
            {
                int num = 0;
                try
                {
                    var customer = db.tCustomer.Where(m => m.Id == id).FirstOrDefault();
                    if (customer != null)
                    {
                        db.tCustomer.Remove(customer);
                        num = db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    num = 0;
                }
                return num;
            }
        }
    }
}

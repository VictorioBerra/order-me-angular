﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OrderMe_Angular.OMA.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderMe_Angular.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {

        private OrderConext _context;

        public ProductController(OrderConext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            var products = _context.Products.ToList();
            return products;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _context.Products.Where(p => p.ProductId == id).Single();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Product product)
        {
            if (String.IsNullOrEmpty(product.Name)) {
                throw new InvalidOperationException("name is required");
            }

            _context.Products.Add(new Product() { Name = product.Name, Price = product.Price });
            _context.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put([FromBody]Product product)
        {
            Product productToUpdate = _context.Products.Where(p => p.ProductId == product.ProductId).Single();

            productToUpdate.Name = product.Name;
            productToUpdate.Price = product.Price;

            _context.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Product product = _context.Products.Where(p => p.ProductId == id).Single();
            _context.Remove(product).Context.SaveChanges();            
        }
    }
}

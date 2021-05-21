using DAL;
using DomainModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Controllers;
using Xunit;

namespace WebApp.Xunit
{
    public class ProductControllerXunitTest
    {
        //A:Arrangement
        Product p1;
        Product p2;
        Product p3;

        ProductModel p11;
        ProductModel p21;
        ProductModel p31;

        List<Product> productList;
        List<ProductModel> productModelList;

        Category c1;
        Category c2;
        List<Category> categoryList;

        ProductController ctrl;
        Mock<IUnitOfWork> uow;
        public ProductControllerXunitTest()
        {

            p1 = new Product { ProductId = 1, Name = "MVC Book", CategoryId = 1, Description = "MVC Book", UnitPrice = 199M };
            p2 = new Product { ProductId = 2, Name = "ASPNET Book", CategoryId = 1, Description = "ASPNET Book", UnitPrice = 299M };
            p3 = new Product { ProductId = 3, Name = "Core Book", CategoryId = 1, Description = "Core Book", UnitPrice = 399M };

            p11 = new ProductModel { ProductId = 1, Name = "MVC Book", CategoryId = 1, Description = "MVC Book", UnitPrice = 199M };
            p21 = new ProductModel { ProductId = 2, Name = "ASPNET Book", CategoryId = 1, Description = "ASPNET Book", UnitPrice = 299M };
            p31 = new ProductModel { ProductId = 3, Name = "Core Book", CategoryId = 1, Description = "Core Book", UnitPrice = 399M };

            c1 = new Category { CategoryId = 1, Name = "Books" };
            c2 = new Category { CategoryId = 2, Name = "Courses" };

            categoryList = new List<Category>();
            categoryList.Add(c1);
            categoryList.Add(c2);

            productList = new List<Product>();
            productList.Add(p1);
            productList.Add(p2);

            productModelList = new List<ProductModel>();
            productModelList.Add(p11);
            productModelList.Add(p21);

            uow = new Mock<IUnitOfWork>();
            ctrl = new ProductController(uow.Object); //mocking

        }
        [Fact]
        public void TestIndex()
        {
            //setup
            uow.Setup(u => u.ProductRepo.GetProducts()).Returns(productModelList);

            //A:Action
            var result = ctrl.Index() as ViewResult;
            var model = result.Model as List<ProductModel>;

            //A:Assert

            Assert.Equal(result.Model, model);

        }
        [Fact]    
        public void TestCreatePost()
        {

            //setup
            uow.Setup(u => u.ProductRepo.Add(p3)).Callback((Product model) =>
            {
                productList.Add(model);
            });

            //A:Action
            ctrl.Create(p3);

            var data = productList.Where(x => x.ProductId == p3.ProductId).FirstOrDefault();

            Assert.Equal(data, p3);

        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using assignment.Controllers;
using Moq;
using assignment.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace assignment.Tests.Controllers
{
    [TestClass]
    public class ShoppersControllerTest
    {

        // global variables needed for multiple tests in this class
        ShoppersController controller;
        Mock<IShoppersMock> mock;
        List<Shopper> shoppers;

        [TestInitialize]
        public void TestInitalize()
        {
            mock = new Mock<IShoppersMock>();

             shoppers= new List<Shopper>
            {
                new Shopper { Stock = 100, Products = "ten", Food = "one"
                },
                new Shopper { Stock = 200,Products = "Twenty", Food = "two" }


            };


            mock.Setup(m => m.Shoppers).Returns(shoppers.AsQueryable());
            controller = new ShoppersController(mock.Object);
        }
        [TestMethod]
        public void IndexLoadsView()
        {
            // arrange - now moved to TestInitialize for code re-use
            // ShoppersController controller = new ShoppersController();

            // act
            var result = controller.Index();

            // assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IndexReturnsShoppers()
        {
            // act
            var result = (List<Shopper>)((ViewResult)controller.Index()).Model;

            // assert
            CollectionAssert.AreEqual(shoppers, result);
        }

        [TestMethod]
        public void DetailsNoId()
        {
            // act
            ViewResult result = (ViewResult)controller.Details(null);

            // assert
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void DetailsInvalidId()
        {
            // act
            ViewResult result = (ViewResult)controller.Details(10);

            // assert
            Assert.AreEqual("Error", result.ViewName);
        }
        [TestMethod]
        public void DetailsValidIdLoadsView()
        {
            // act
            ViewResult result = (ViewResult)controller.Details(100);

            // assert
            Assert.AreEqual("Details", result.ViewName);
        }
        [TestMethod]
        public void DetailsValidIdLoadsShopper()
        {
            // act
            Shopper result = (Shopper)((ViewResult)controller.Details(100)).Model;

            // assert
            Assert.AreEqual(shoppers[0], result);
        }
        //POST:Shoppers/Create
        [TestMethod]
        public void ShopperSavedAndRedirected()
        {
            //act
            var result = (RedirectToRouteResult)controller.Create(shoppers[0]);

            //assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }
        [TestMethod]
        public void ShopperPriceNotNull()
        {

            //act
            controller.ModelState.AddModelError("some error name", "fake error description");
            var result = (ViewResult)this.controller.Create(this.shoppers[0]);

            //assert
            Assert.IsNotNull(result.ViewBag.Stock);
        }
        [TestMethod]
        public void EditNoId()
        {
            // arrange
            int? id = null;

            // act 
            ViewResult result = (ViewResult)controller.Edit(id);
            // assert 
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void EditInvalidId()
        {
            // act 
            ViewResult result = (ViewResult)controller.Edit(10);

            // assert 
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void EditValidIdLoadsView()
        {
            // act 
            ViewResult result = (ViewResult)controller.Edit(100);

            // assert 
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]
        public void EditValidIdLoadsShopper()
        {
            // act 
           Shopper result = (Shopper)((ViewResult)controller.Edit(100)).Model;

            // assert 
            Assert.AreEqual(shoppers[0], result);
        }

        [TestMethod]
        public void EditReturnsStockViewBag()
        {
            // act 
            ViewResult result = controller.Edit(100) as ViewResult;

            // assert 
            Assert.IsNotNull(result.ViewBag.Stock);
        }


        [TestMethod]
        public void ModelValidIndexLoaded()
        {
            // act
            RedirectToRouteResult result = (RedirectToRouteResult)controller.Edit(shoppers[0]);

            // assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void ModelInvalidViewbagsRightStock()
        {
            // arrange
            controller.ModelState.AddModelError("some error name", "Error description");

            // Act
            ViewResult result = (ViewResult)controller.Edit(shoppers[0]);

            // Assert
            Assert.IsNotNull(result.ViewBag.Stock);
        }

        [TestMethod]
        public void ModelInValidLoadsView()
        {
            // arrange
            controller.ModelState.AddModelError("some error name", "Error description");

            // act 
            ViewResult result = (ViewResult)controller.Edit(shoppers[0]);

            // assert
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]
        public void ModelInvalidHasShopperLoaded()
        {
            // arrange
            controller.ModelState.AddModelError("some error name", "Error description");

            // act 
            Shopper result = (Shopper)((ViewResult)controller.Details(100)).Model;

            // assert
            Assert.AreEqual(shoppers[0], result);
        }
        [TestMethod]
        public void DeleteNoId()
        {
            // act
            ViewResult result = (ViewResult)controller.Delete(null);

            // assert
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void DeleteInvalidId()
        {
            // act
            ViewResult result = (ViewResult)controller.Delete(1009);

            // assert
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void DeleteValidIdReturnShopper()
        {
            // act
            Shopper result = (Shopper)((ViewResult)controller.Delete(100)).Model;

            // assert
            Assert.AreEqual(shoppers[0], result);
        }
        [TestMethod]
        public void DeleteValidIdReturnView()
        {
            // act
            ViewResult result = (ViewResult)controller.Delete(100);

            // assert
            Assert.AreEqual("Delete", result.ViewName);
        }

        [TestMethod]
        public void DeleteConfirmedNoId()
        {
            // act
            ViewResult result = (ViewResult)controller.DeleteConfirmed(0);

            // assert
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void DeleteConfirmedInvalidId()
        {
            // act
            ViewResult result = (ViewResult)controller.DeleteConfirmed(5000);

            // assert
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void DeleteWorks()
        {
            // act
            RedirectToRouteResult result = (RedirectToRouteResult)controller.DeleteConfirmed(100);

            // assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }
    }
}

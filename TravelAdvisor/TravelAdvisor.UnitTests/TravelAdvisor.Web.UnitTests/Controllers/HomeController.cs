﻿using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelAdvisor.Web.Controllers;

namespace TravelAdvisor.Web.UnitTests.Controllers
{
	[TestClass]
	public class HomeControllerTest
	{
		[TestMethod]
		public void Index()
		{
			// Arrange
			HomeController controller = new HomeController();

			// Act
			ViewResult result = controller.Index() as ViewResult;

			// Assert
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void Contact()
		{
			// Arrange
			HomeController controller = new HomeController();

			// Act
			ViewResult result = controller.Contact() as ViewResult;

			// Assert
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void Test()
		{
			// Arrange & Act & Assert
			Assert.IsTrue(true);
		}

		[TestMethod]
		public void Test2()
		{
			// Arrange & Act & Assert
			Assert.IsFalse(false);
		}
	}
}
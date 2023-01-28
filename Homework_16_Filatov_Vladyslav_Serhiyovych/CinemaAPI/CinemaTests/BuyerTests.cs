using CinemaAPI.Controllers;
using CinemaAPI.Data;
using CinemaAPI.Models.ModelsForRequests;
using Microsoft.EntityFrameworkCore;
using Task.Models;

namespace CinemaTests
{
    public class BuyerTests
    {
        CinemaAPIDbContext context;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<CinemaAPIDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            context = new CinemaAPIDbContext(options);
            context.Database.EnsureCreated();
        }

        [Test]
        public void AddBuyer_Test()
        {
            //Act
            SetUp();
            BuyerController buyerController = new(context);
            string buyerFirstName = "Alex";
            string buyerLastName = "Brown";
            //checking the @ symbol in a AddBuyerRequest
            string buyerEmail = "some@gmail.com";

            //Arrange       
            var buyer = buyerController.AddBuyer(new AddBuyerRequest
            {
                FirstName = buyerFirstName,
                LastName = buyerLastName,
                Email= buyerEmail   
            });

            //Assert
            Assert.That(context.Buyers.SingleOrDefault(buyer =>
                buyer.FirstName == buyerFirstName &&
                buyer.LastName == buyerLastName && 
                buyer.Email == buyerEmail), Is.Not.Null);
        }
    }
}
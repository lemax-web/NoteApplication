using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NoteApi.Controllers;
using NoteApp.ClassLib.Model;
using RecipeWebApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests.NoteApp.Tests
{
    [TestClass]
    public class UnitTestNoteApi
    {
        [Fact]
        [TestMethod]
        public async Task GetNote_Returns_The_Correct_Number_of_Categories()
        {
            int count = 6;
            var faceRecipes = A.CollectionOfDummy<Note>(count).AsEnumerable();
            var context = A.Fake<SqlServerDbContext>();
            foreach (Note category in faceRecipes)
            {
                A.CallTo(() => context.Note.Add(category));
            }
            var controller = new NoteApi.Controllers.NoteController(context);

            var actionResult = await controller.getUsers();

            var result = actionResult.Result as OkObjectResult;
            var returnCategories = result.Value as IEnumerable<Note>;
            Assert.Equals(count, returnCategories.Count());
        }
        [Fact]
        [TestMethod]
        public async Task noteCountIsCorrect()
        {
            int count = 6;
            var faceRecipes = A.CollectionOfDummy<Note>(count).AsEnumerable();

            Assert.AreEqual(faceRecipes.Count(), 6);
        }
        [Fact]
        [TestMethod]
        public async Task testNoteModel()
        {
            Note user = new Note(0,"Go to work","do task",1);
            Assert.AreEqual(user.Title, "Go to work");
        }
        [Fact]
        [TestMethod]
        public async Task nullControlNoteList()
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<SqlServerDbContext>(options =>
                    options.UseSqlServer("Data Source=(local); Initial Catalog=Note; trusted_connection=yes; TrustServerCertificate=True"))
                .BuildServiceProvider();

            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<SqlServerDbContext>();


                var controller = new NoteController(dbContext); // Instantiate your controller

                // Act
                var result = controller.getUsers();


                // Assert
                Assert.IsNotNull(result);

            }
        }

    }
}

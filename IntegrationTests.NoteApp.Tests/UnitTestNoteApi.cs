using FakeItEasy;
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
            var faceRecipes = A.CollectionOfDummy<NoteApi.Model.Note>(count).AsEnumerable();
            var context = A.Fake<NoteApi.Data.SqlServerDbContext>();
            foreach (NoteApi.Model.Note category in faceRecipes)
            {
                A.CallTo(() => context.Note.Add(category));
            }
            var controller = new NoteApi.Controllers.NoteController(context);

            var actionResult = await controller.getUser();

            var result = actionResult.Result as OkObjectResult;
            var returnCategories = result.Value as IEnumerable<NoteApi.Model.Note>;
            Assert.Equals(count, returnCategories.Count());
        }
    }
}

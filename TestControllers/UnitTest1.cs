using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using Newtonsoft.Json;
using ProjectV2.API.Controllers;
using ProjectV2.Bll.Interfaces;
using ProjectV2.Common.Dtos.Users;
using System.Net;
using System.Text;

namespace TestControllers
{
    [TestClass]
    public class UnitTest1
    {
        private readonly Mock<IUserService> _mockUserService = new Mock<IUserService>();
        
        // returns BadRequest if user already exists
        [TestMethod]
        public async Task ShouldReturn_BadRequest_CreateUser_UserController_Async()
        {
            _mockUserService.Setup(x => x.CreateUserAsync(It.IsAny<UserUpdateDto>())).ReturnsAsync(() => null);
            var userController = new UserController(_mockUserService.Object);

            var result = (BadRequestResult)await userController.CreateUserAsync(null);

            Assert.AreEqual(400, result.StatusCode);
        }

        // returns Ok if user not exist
        [TestMethod]
        public async Task ShouldReturn_Ok_CreateUserAsync_UserController()
        {
            _mockUserService.Setup(x => x.CreateUserAsync(It.IsAny<UserUpdateDto>())).ReturnsAsync(() => new UserDto());
            var userController = new UserController(_mockUserService.Object);

            var result = (ObjectResult)await userController.CreateUserAsync(null);

            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public async Task ShouldReturn_BadRequest_GetUserAsync_UserController()
        {
            _mockUserService.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(() => null);
            var userController = new UserController(_mockUserService.Object);

            var result = (BadRequestResult)await userController.GetUserAsync(-1);

            Assert.AreEqual(400, result.StatusCode);
        }

        [TestMethod]
        public async Task ShouldReturn_Ok_GetUserAsync_UserController()
        {
            _mockUserService.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(() => new UserDto());
            var userController = new UserController(_mockUserService.Object);

            var result = (ObjectResult)await userController.GetUserAsync(-1);

            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public async Task ShouldReturn_BadRequest_UpdateUserAsync_UserController()
        {
            _mockUserService.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(() => null);
            var userController = new UserController(_mockUserService.Object);

            var result = (BadRequestResult)await userController.GetUserAsync(-1);

            Assert.AreEqual(400, result.StatusCode);
        }

        [TestMethod]
        public async Task ShouldReturn_Ok_UpdateUserAsync_UserController()
        {
            _mockUserService.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(() => new UserDto());
            var userController = new UserController(_mockUserService.Object);

            var result = (ObjectResult)await userController.GetUserAsync(-1);

            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public async Task ShouldReturn_BadRequest_DeleteUserAsync_UserController()
        {
            _mockUserService.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(() => null);
            var userController = new UserController(_mockUserService.Object);

            var result = (BadRequestResult)await userController.GetUserAsync(-1);

            Assert.AreEqual(400, result.StatusCode);
        }

        [TestMethod]
        public async Task ShouldReturn_Ok_DeleteUserAsync_UserController()
        {
            _mockUserService.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(() => new UserDto());
            var userController = new UserController(_mockUserService.Object);

            var result = (ObjectResult)await userController.GetUserAsync(-1);

            Assert.AreEqual(200, result.StatusCode);
        }
    }

    [TestClass]
    public class IntegrationTestController
    {
        private readonly HttpClient _client;

        public IntegrationTestController()
        {
            var server = new WebApplicationFactory<Program>();

            _client = server.CreateClient();
        }

        [TestMethod]
        public async Task ShouldReturn_BadRequest_GetUserAsync()
        {
            int id = 3;
            var request = $"/api/users/{id}";
            var response = await _client.GetAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var obj = JsonConvert.DeserializeObject<UserDto>(jsonResponse);
                Assert.IsTrue(obj.Id == id);
            }
            else
            {
                Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            }

        }

        [TestMethod]
        public async Task UpdateUserTestAsync()
        {
            int id = 4;
            var userUpdateDto = new UserUpdateDto()
            {
                Username = "string2",
                Password = "string",
                Email = "sdfg@gmail.com"
            };

            var jsonRequest = JsonConvert.SerializeObject(userUpdateDto);

            HttpContent content = new StringContent(jsonRequest, Encoding.Default, "application/json");

            var response = await _client.PutAsync($"/api/users/{id}", content);

            if (response.IsSuccessStatusCode)
            {
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
            else
            {
                Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            }
        }

        [TestMethod]
        public async Task DeleteUserTestAsync()
        {
            int id = 4;
            var request = $"/api/users/{id}";
            var response = await _client.DeleteAsync(request);

            if (response.IsSuccessStatusCode)
            {
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
            else
            {
                Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            }

        }
    }
}
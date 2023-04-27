using Moq;
using MyHome.Data;

namespace MyHome.Test.Controller
{
    public class TestPropertyController
    {
        public class TestGet
        {
            [Fact]
            public async Task Get_OnSuccess_ReturnStatusCode200()
            {
                var mockService = new Mock<IPropertyData>();
                mockService
                    .Setup(s => s.GetAll())
                    .ReturnsAsync(PropertyFixture.GetTestProperties());

                var controller = new PropertyController(mockService.Object);

                var result = await controller.Get();

                Assert.IsType<OkObjectResult>(result);
                var objectResult = (OkObjectResult)result;
                Assert.Equal(StatusCodes.Status200OK, objectResult.StatusCode);
            }

            [Fact]
            public async Task Get_OnSuccess_InvokePropertyData()
            {
                var mockService = new Mock<IPropertyData>();
                mockService
                    .Setup(s => s.GetAll())
                    .ReturnsAsync(new List<Property>());

                var controller = new PropertyController(mockService.Object);

                var result = await controller.Get();

                mockService.Verify(s => s.GetAll(), Times.Once());
            }

            [Fact]
            public async Task Get_OnSuccess_ReturnsListOfProperties()
            {
                var mockService = new Mock<IPropertyData>();
                mockService
                    .Setup(s => s.GetAll())
                    .ReturnsAsync(PropertyFixture.GetTestProperties());

                var controller = new PropertyController(mockService.Object);

                var result = await controller.Get();

                Assert.IsType<OkObjectResult>(result);
                var objectResult = (OkObjectResult)result;
                Assert.IsType<List<Property>>(objectResult.Value);
            }

            [Fact]
            public async Task Get_OnNoPropertiesFound_ReturnsStatusCode404()
            {
                var mockService = new Mock<IPropertyData>();
                mockService
                    .Setup(s => s.GetAll())
                    .ReturnsAsync(new List<Property>());

                var controller = new PropertyController(mockService.Object);

                var result = await controller.Get();

                Assert.IsType<NotFoundResult>(result);
                var objectResult = (NotFoundResult)result;
                Assert.Equal(StatusCodes.Status404NotFound, objectResult.StatusCode);
            }
        }

        public class TestGetById
        {
            [Fact]
            public async void Get_OnSuccess_ReturnsStatusCode200()
            {
                var mockService = new Mock<IPropertyData>();
                mockService
                    .Setup(s => s.GetById(It.IsAny<int>()))
                    .ReturnsAsync(PropertyFixture.GetTestProperty());

                var controller = new PropertyController(mockService.Object);

                var result = await controller.Get(propertyId: 1);

                Assert.IsType<OkObjectResult>(result);
                var objectResult = (OkObjectResult)result;
                Assert.Equal(StatusCodes.Status200OK, objectResult.StatusCode);
            }


            [Fact]
            public async void Get_OnSuccess_InvokesPropertyData()
            {
                var mockService = new Mock<IPropertyData>();
                mockService
                    .Setup(s => s.GetById(It.IsAny<int>()))
                    .ReturnsAsync(PropertyFixture.GetTestProperty());

                var controller = new PropertyController(mockService.Object);

                var result = await controller.Get(propertyId: 1);

                mockService.Verify(s => s.GetById(It.IsAny<int>()), Times.Once());
            }

            [Fact]
            public async void Get_OnSuccess_ReturnsProperty()
            {
                var mockService = new Mock<IPropertyData>();
                mockService
                    .Setup(s => s.GetById(It.IsAny<int>()))
                    .ReturnsAsync(PropertyFixture.GetTestProperty());

                var controller = new PropertyController(mockService.Object);

                var result = await controller.Get(propertyId: 1);

                Assert.IsType<OkObjectResult>(result);
                var objectResult = (OkObjectResult)result;
                Assert.IsType<Property>(objectResult.Value);
            }

            [Fact]
            public async void Get_OnNoPropertyFound_ReturnsStatusCode404()
            {
                Property property = null;
                var mockService = new Mock<IPropertyData>();
                mockService
                    .Setup(s => s.GetById(It.IsAny<int>()))
                    .ReturnsAsync(property);

                var controller = new PropertyController(mockService.Object);

                var result = await controller.Get(1);

                Assert.IsType<NotFoundResult>(result);
                var objectResult = (NotFoundResult)result;
                Assert.Equal(StatusCodes.Status404NotFound, objectResult.StatusCode);
            }
        }

        public class TestPost
        {
            [Fact]
            public async void Post_OnSuccess_ReturnsStatusCode201()
            {
                Property property = PropertyFixture.GetTestProperty();
                var mockService = new Mock<IPropertyData>();
                mockService
                    .Setup(s => s.Add(It.IsAny<Property>()))
                    .ReturnsAsync(PropertyFixture.GetTestProperty());

                var controller = new PropertyController(mockService.Object);

                var result = await controller.Post(property);
            }
        }
    }
}
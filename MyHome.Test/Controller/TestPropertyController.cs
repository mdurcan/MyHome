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

                var result = (OkObjectResult)await controller.Get();

                Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            }

            [Fact]
            public async Task Get_OnSuccess_InvokePropertyService()
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
            public async Task Get_OnNoPropertiesFound_Resturns404()
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

        public class TestPost
        {
            [Fact]
            public void test1()
            {
            }
        }
    }
}
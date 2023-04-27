

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
                    .Returns(PropertyFixture.GetTestProperties());

                var controller = new PropertyController(mockService.Object);

                var result =  controller.Get();

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
                    .Returns(new List<Property>());

                var controller = new PropertyController(mockService.Object);

                var result =  controller.Get();

                mockService.Verify(s => s.GetAll(), Times.Once());
            }

            [Fact]
            public async Task Get_OnSuccess_ReturnsListOfProperties()
            {
                var mockService = new Mock<IPropertyData>();
                mockService
                    .Setup(s => s.GetAll())
                    .Returns(PropertyFixture.GetTestProperties());

                var controller = new PropertyController(mockService.Object);

                var result =  controller.Get();

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
                    .Returns(new List<Property>());

                var controller = new PropertyController(mockService.Object);

                var result =  controller.Get();

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
                    .Returns(PropertyFixture.GetTestProperty());

                var controller = new PropertyController(mockService.Object);

                var result =  controller.Get(propertyId: 1);

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
                    .Returns(PropertyFixture.GetTestProperty());

                var controller = new PropertyController(mockService.Object);

                var result =  controller.Get(propertyId: 1);

                mockService.Verify(s => s.GetById(It.IsAny<int>()), Times.Once());
            }

            [Fact]
            public async void Get_OnSuccess_ReturnsProperty()
            {
                var mockService = new Mock<IPropertyData>();
                mockService
                    .Setup(s => s.GetById(It.IsAny<int>()))
                    .Returns(PropertyFixture.GetTestProperty());

                var controller = new PropertyController(mockService.Object);

                var result =  controller.Get(propertyId: 1);

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
                    .Returns(property);

                var controller = new PropertyController(mockService.Object);

                var result =  controller.Get(1);

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
                    .Returns(property);

                var controller = new PropertyController(mockService.Object);

                var result =  controller.Post(property);

                Assert.IsType<CreatedResult>(result);
                var objectResult = (CreatedResult)result;
                Assert.Equal(StatusCodes.Status201Created, objectResult.StatusCode);
            }

            [Fact]
            public async void Post_OnSuccess_InvokePropertyData()
            {
                Property property = PropertyFixture.GetTestProperty();
                var mockService = new Mock<IPropertyData>();
                mockService
                    .Setup(s => s.Add(It.IsAny<Property>()))
                    .Returns(property);

                var controller = new PropertyController(mockService.Object);

                var result =  controller.Post(property);

                mockService.Verify(s => s.Add(It.IsAny<Property>()), Times.Once());
            }

            [Fact]
            public async void Post_OnSuccess_ReturnsProperty()
            {
                Property property = PropertyFixture.GetTestProperty();
                var mockService = new Mock<IPropertyData>();
                mockService
                    .Setup(s => s.Add(It.IsAny<Property>()))
                    .Returns(property);

                var controller = new PropertyController(mockService.Object);

                var result =  controller.Post(property);

                Assert.IsType<CreatedResult>(result);
                var objectResult = (CreatedResult)result;
                Assert.IsType<Property>(objectResult.Value);
                Assert.Equal(property, objectResult.Value);
            }

            [Fact]
            public async void Post_OnNullProperty_ReturnsStatusCode400()
            {
                var mockService = new Mock<IPropertyData>();
                mockService
                    .Setup(s => s.Add(It.IsAny<Property>()))
                    .Returns(PropertyFixture.GetTestProperty());

                var controller = new PropertyController(mockService.Object);

                var result =  controller.Post(null);

                Assert.IsType<BadRequestObjectResult>(result);
                var objectResult = (BadRequestObjectResult)result;
                Assert.Equal(StatusCodes.Status400BadRequest, objectResult.StatusCode);
            }


            [Fact]
            public async void Post_OnExistingProperty_ReturnsStatusCode400()
            {
                Property property = PropertyFixture.GetTestProperty();
                var mockService = new Mock<IPropertyData>();
                mockService
                    .Setup(s => s.Add(It.IsAny<Property>()))
                    .Returns((Property)null);

                var controller = new PropertyController(mockService.Object);

                var result = controller.Post(property);

                Assert.IsType<BadRequestObjectResult>(result);
                var objectResult = (BadRequestObjectResult)result;
                Assert.Equal(StatusCodes.Status400BadRequest, objectResult.StatusCode);
            }
        }

        public class TestPatch
        {
            [Fact]
            public async void Patch_OnSuccess_ReturnsStatusCode200()
            {
                var mockService = new Mock<IPropertyData>();
                mockService
                    .Setup(s => s.Update(It.IsAny<int>(), It.IsAny<JsonPatchDocument<Property>>()))
                    .Returns(PropertyFixture.GetTestProperty());

                var controller = new PropertyController(mockService.Object);

                var result =  controller.Patch(propertyId: 1, PropertyFixture.GetFieldData());

                Assert.IsType<OkObjectResult>(result);
                var objectResult = (OkObjectResult)result;
                Assert.Equal(StatusCodes.Status200OK, objectResult.StatusCode);
            }


            [Fact]
            public async void Patch_OnSuccess_InvokesPropertyData()
            {
                var mockService = new Mock<IPropertyData>();
                mockService
                    .Setup(s => s.Update(It.IsAny<int>(), It.IsAny<JsonPatchDocument<Property>>()))
                    .Returns(PropertyFixture.GetTestProperty());

                var controller = new PropertyController(mockService.Object);

                var result =  controller.Patch(propertyId: 1, PropertyFixture.GetFieldData());

                mockService.Verify(s => s.Update(It.IsAny<int>(), It.IsAny<JsonPatchDocument<Property>>()), Times.Once());
            }

            [Fact]
            public async void Patch_OnSuccess_ReturnsProperty()
            {
                var mockService = new Mock<IPropertyData>();
                mockService
                    .Setup(s => s.Update(It.IsAny<int>(), It.IsAny<JsonPatchDocument<Property>>()))
                    .Returns(PropertyFixture.GetTestProperty());

                var controller = new PropertyController(mockService.Object);

                var result =  controller.Patch(propertyId: 1, PropertyFixture.GetFieldData());

                Assert.IsType<OkObjectResult>(result);
                var objectResult = (OkObjectResult)result;
                Assert.IsType<Property>(objectResult.Value);
            }

            [Fact]
            public async void Patch_OnNoPropertyFound_ReturnsStatusCode404()
            {
                var mockService = new Mock<IPropertyData>();
                mockService
                    .Setup(s => s.Update(It.IsAny<int>(), It.IsAny<JsonPatchDocument<Property>>()))
                    .Returns((Property) null);

                var controller = new PropertyController(mockService.Object);

                var result =  controller.Patch(propertyId: 1, PropertyFixture.GetFieldData());

                Assert.IsType<NotFoundResult>(result);
                var objectResult = (NotFoundResult)result;
                Assert.Equal(StatusCodes.Status404NotFound, objectResult.StatusCode); 
            }

            [Fact]
            public async void Patch_OnNoFields_ReturnsStatusCode400()
            {
                var mockService = new Mock<IPropertyData>();
                mockService
                    .Setup(s => s.Update(It.IsAny<int>(), It.IsAny<JsonPatchDocument<Property>>()))
                    .Returns((Property)null);

                var controller = new PropertyController(mockService.Object);

                var result =  controller.Patch(propertyId: 1, null);

                Assert.IsType<BadRequestObjectResult>(result);
                var objectResult = (BadRequestObjectResult)result;
                Assert.Equal(StatusCodes.Status400BadRequest, objectResult.StatusCode);
            }
        }

        public class TestDelete
        {
            [Fact]
            public async void Delete_OnSuccess_ReturnsStatusCode200()
            {
                var mockService = new Mock<IPropertyData>();
                mockService
                    .Setup(s => s.Delete(It.IsAny<int>()))
                    .Returns(PropertyFixture.GetTestProperty());

                var controller = new PropertyController(mockService.Object);

                var result =  controller.Delete(propertyId: 1);

                Assert.IsType<OkResult>(result);
                var objectResult = (OkResult)result;
                Assert.Equal(StatusCodes.Status200OK, objectResult.StatusCode);
            }

            [Fact]
            public async void Delete_OnSuccess_InvokesPropertyData()
            {
                var mockService = new Mock<IPropertyData>();
                mockService
                    .Setup(s => s.Delete(It.IsAny<int>()))
                    .Returns(PropertyFixture.GetTestProperty());

                var controller = new PropertyController(mockService.Object);

                var result =  controller.Delete(propertyId: 1);

                mockService.Verify(s => s.Delete(It.IsAny<int>()), Times.Once());
            }

            [Fact]
            public async void Delete_OnNoPropertyFound_ReturnsStatusCode404()
            {
                var mockService = new Mock<IPropertyData>();
                mockService
                    .Setup(s => s.Delete(It.IsAny<int>()))
                    .Returns((Property) null);

                var controller = new PropertyController(mockService.Object);

                var result =  controller.Delete(propertyId: 1);

                Assert.IsType<NotFoundResult>(result);
                var objectResult = (NotFoundResult)result;
                Assert.Equal(StatusCodes.Status404NotFound, objectResult.StatusCode);
            }
        }
    }
}
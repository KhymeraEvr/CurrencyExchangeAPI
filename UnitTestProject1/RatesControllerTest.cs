using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApplication1.Controllers;
using WebApplication1.Models;
using WebApplication1.Models.Repository;
using WebApplication1.Models.UnitOfWork;
using WebApplication1.Services;

namespace UnitTestProject1
{
    [TestClass]
    public class RatesControllerTest
    {
        [TestMethod]
        public async Task GetId_WhenNotFound_Test()
        {
            string testRateType = "ZZZ";
            var moq = new Mock<ICurrencyService>();
            var moq2 = new Mock<IGraphService>();
            moq.Setup(call => call.GetLatestRates(testRateType)).ReturnsAsync((ResponseModel)null);
            moq2.Setup(call => call.GetGraphData(testRateType,"","")).ReturnsAsync((GraphModel)null);
            var controller = new RatesController(moq.Object,moq2.Object);

            var result =  await controller.Get(testRateType);

            Assert.AreEqual(typeof(NotFoundResult),result.GetType());
        }

        [TestMethod]
        public async Task GetId_WhenFound_Test()
        {
            string testRateType = "USD";
            var moq2 = new Mock<IGraphService>();
            var moq = new Mock<ICurrencyService>();
            moq2.Setup(call => call.GetGraphData(testRateType,"","")).ReturnsAsync((GraphModel)null);
            moq.Setup(call => call.GetLatestRates(testRateType)).ReturnsAsync(new ResponseModel());
            var controller = new RatesController(moq.Object,moq2.Object);

            var result = await controller.Get(testRateType);

            Assert.AreEqual(typeof(OkObjectResult), result.GetType());
        }

        //[TestMethod]
        //public async Task Post_WhenBadRequest_Test()
        //{
        //    ConvertModel testModel = new ConvertModel(){From = "124as",Into = "else", Result = -1};
        //    var requestBody = new Dictionary<string, string>
        //    {
        //        {"From","asfg"},
        //        {"Into","asdff"},
        //        {"Result","-1" }
        //    };
        //    var request = new FormUrlEncodedContent(requestBody);
        //    var moq = new Mock<ICurrencyService>();
        //    var moqUnitOfWork = new Mock<IUnitOfWork>();
        //    moqUnitOfWork.Setup(call => call.Add(It.IsAny<ConvertModel>()));
        //    moq.Object.UnitOfWork = moqUnitOfWork.Object;
        //    moq.Setup(call => call.UnitOfWork.Add(It.IsAny<ConvertModel>()));
        //    var controller = new RatesController(moq.Object);

        //    using (HttpClient client = new HttpClient())
        //    {
        //        var result = await client.PostAsync("https://localhost:44370/api/rates/converts",request);
        //        Assert.AreEqual(typeof(BadRequestObjectResult), result);
        //    }
                

            
        //}
    }
}

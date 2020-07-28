using System.Threading.Tasks;
using ASPNETCORE.VUE.Models.TokenAuth;
using ASPNETCORE.VUE.Web.Controllers;
using Shouldly;
using Xunit;

namespace ASPNETCORE.VUE.Web.Tests.Controllers
{
    public class HomeController_Tests: VUEWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}
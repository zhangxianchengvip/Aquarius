using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Aquarius.Pages;

public class Index_Tests : AquariusWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}

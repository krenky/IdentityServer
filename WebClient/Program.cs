
using Microsoft.IdentityModel.Logging;

var builder = WebApplication.CreateBuilder(args);
IdentityModelEventSource.ShowPII = true;
try
{
    builder
        .ConfigureServices()
        .ConfigurePipeline()
        .Run();
}
catch
{

}
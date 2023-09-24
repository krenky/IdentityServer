using IdentityAPI;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

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
using Microsoft.AspNetCore.Routing;

namespace DigitalLibrary.Common.Infrastructure.Endpoints;

public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}

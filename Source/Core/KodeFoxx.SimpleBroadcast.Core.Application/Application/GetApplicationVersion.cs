using MediatR;
using System.Reflection;

namespace KodeFoxx.SimpleBroadcast.Core.Application.Application;

public sealed class GetApplicationVersion
{
    public sealed class Request : IRequest<Response> { }
    public sealed class Response
    {
        public string VersionString { get; }

        internal Response(string versionString)
            => VersionString = versionString;
    }

    private sealed class Handler : IRequestHandler<Request, Response>
    {
        public Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var dateTime = File.GetLastWriteTimeUtc(assembly.Location)
                    .ToString()
                    .Replace(" ", "-")
                    .Replace(":", "")
                    .Replace(@"/", "");

            return Task.FromResult(new Response($"preview 0.1 -{dateTime}"));
        }
    }
}

using System.Diagnostics;
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

    public sealed class Handler : IRequestHandler<Request, Response>
    {
        public Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var assembly = Assembly.GetExecutingAssembly();            
            var dateTime = File.GetLastWriteTimeUtc(assembly.Location)
                    .ToString()
                    .Replace(" ", "-")
                    .Replace(":", "")
                    .Replace(@"/", "");

            var versionString = $"0.2-{dateTime}-PRV";

#if(DEBUG)
            versionString = $"{versionString}-DBG";
#else
            versionString = $"{versionString}-RLS";
#endif

            if (Debugger.IsAttached)
                versionString = $"debugging: {versionString}";

            return Task.FromResult(new Response(versionString));
        }
    }
}
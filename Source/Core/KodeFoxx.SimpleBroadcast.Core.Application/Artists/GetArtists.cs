namespace KodeFoxx.SimpleBroadcast.Core.Application.Artists;

public sealed class GetArtists
{
    public sealed class Request : IRequest<Response> {
        public Request(string? query)
        {
            Query = query;
        }

        public string? Query { get; }
    }
    public sealed class Response
    {
        public IReadOnlyCollection<Artist> Artists { get; }

        internal Response(IEnumerable<Artist> artists)
            => Artists = artists.OrderBy(a => a.Principal).ToList();
    }

    private sealed class Handler : IRequestHandler<Request, Response>
    {
        private readonly SimpleBroadcastDatabase _db;

        public Handler(SimpleBroadcastDatabase database)
            => _db = database;

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var artists = _db.Artists.AsQueryable();
            if (!String.IsNullOrWhiteSpace(request.Query))
            {
                artists = artists.Where(a => a.Principal.ToLower().Contains(request.Query.ToLower()));
            }

            artists.OrderBy(a => a.Principal);

            return new Response(await artists.ToListAsync());
        }
    }
}

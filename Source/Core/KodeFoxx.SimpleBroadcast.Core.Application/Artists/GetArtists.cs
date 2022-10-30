namespace KodeFoxx.SimpleBroadcast.Core.Application.Artists;

public sealed class GetArtists
{
    public sealed class Request : IRequest<Response> { }
    public sealed class Response
    {
        public IReadOnlyCollection<Artist> Artists { get; }

        internal Response(IEnumerable<Artist> artists)
            => Artists = artists.ToList();
    }

    private sealed class Handler : IRequestHandler<Request, Response>
    {
        private readonly SimpleBroadcastDatabase _db;

        public Handler(SimpleBroadcastDatabase database)
            => _db = database;

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var artists = await _db.Artists.ToListAsync();
            return new Response(artists);
        }
    }
}

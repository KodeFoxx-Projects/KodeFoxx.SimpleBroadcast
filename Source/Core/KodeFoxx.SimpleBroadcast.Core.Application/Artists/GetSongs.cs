namespace KodeFoxx.SimpleBroadcast.Core.Application.Artists;

public sealed class GetSongs
{
    public sealed class Request : IRequest<Response>
    {
        public Request(string? query)
        {
            Query = query;
        }

        public string? Query { get; }
    }
    public sealed class Response
    {
        public IReadOnlyCollection<Song> Songs { get; }

        internal Response(IEnumerable<Song> songs)
            => Songs = songs
                .OrderBy(s => s.Title)
                .ThenBy(s => s.Artist.Principal)
                .ToList();
    }

    private sealed class Handler : IRequestHandler<Request, Response>
    {
        private readonly SimpleBroadcastDatabase _db;

        public Handler(SimpleBroadcastDatabase database)
            => _db = database;

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var songs = _db.Songs.Include(s => s.Artist).AsQueryable();
            if (!String.IsNullOrWhiteSpace(request.Query))
            {
                songs = songs.Where(s => s.Title.ToLower().Contains(request.Query.ToLower()));
            }

            songs = songs
                .OrderBy(s => s.Title)
                .ThenBy(s => s.Artist.Principal);

            return new Response(await songs.ToListAsync());
        }
    }
}

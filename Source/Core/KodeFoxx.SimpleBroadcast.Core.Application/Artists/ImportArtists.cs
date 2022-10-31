namespace KodeFoxx.SimpleBroadcast.Core.Application.Artists;

public sealed class ImportArtists
{
    public sealed class Request : IRequest<Response>
    {
        public string[] ArtistPrincipals { get; }

        public Request(string[] artistPrincipals)
        {
            ArtistPrincipals = artistPrincipals;
        }
    }
    public sealed class Response
    {
    }

    private sealed class Handler : IRequestHandler<Request, Response>
    {
        private readonly SimpleBroadcastDatabase _db;

        public Handler(SimpleBroadcastDatabase database)
            => _db = database;

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var newArtists = request.ArtistPrincipals
                .Distinct()
                .Where(ap => !String.IsNullOrWhiteSpace(ap))
                .Where(ap => !Exists(ap))
                .Select(ap => Artist.Create(ap.Trim()));            

            _db.Artists.AddRange(newArtists);
            await _db.SaveChangesAsync();

            return new Response() { };
        }

        private bool Exists(string principalName)
        {
            var exists = _db.Artists.FirstOrDefault(a => a.Principal.Equals(principalName));
            return exists != null;
        }
    }
}

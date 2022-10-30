

namespace KodeFoxx.SimpleBroadcast.Core.Application.Artists;

public sealed class EditArtistPrincipal
{
    public sealed class Request : IRequest<Response> 
    {
        public long ArtistId { get; }
        public string PrincipalName { get; }

        public Request(long artistId, string principalName)
        {
            ArtistId = artistId;
            PrincipalName = principalName;
        }
    }
    public sealed class Response { }

    private sealed class Handler : IRequestHandler<Request, Response>
    {
        private readonly SimpleBroadcastDatabase _db;

        public Handler(SimpleBroadcastDatabase database)
            => _db = database;

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var artist = await _db.Artists.Where(a => a.Id == request.ArtistId).FirstAsync();
            artist.EditPrincipal(request.PrincipalName);

            await _db.SaveChangesAsync();

            return new Response();
        }
    }
}
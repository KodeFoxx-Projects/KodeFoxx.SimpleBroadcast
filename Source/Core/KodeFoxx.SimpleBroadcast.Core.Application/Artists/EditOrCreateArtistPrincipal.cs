

namespace KodeFoxx.SimpleBroadcast.Core.Application.Artists;

public sealed class EditOrCreateArtistPrincipal
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
    public sealed class Response 
    {
        public string? ErrorMessage { get; }
        public bool HasError => ErrorMessage != null;

        public Response(string? errorMessage = null)
            => ErrorMessage = errorMessage;
    }

    private sealed class Handler : IRequestHandler<Request, Response>
    {
        private readonly SimpleBroadcastDatabase _db;

        public Handler(SimpleBroadcastDatabase database)
            => _db = database;

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var exists = await _db.Artists.FirstOrDefaultAsync(a => a.Principal.Equals(request.PrincipalName));
            if(exists != null)            
                return new Response($"An artist (id: '{exists.Id}') with the same name already exists.");

            try
            {
                var artist = await _db.Artists.Where(a => a.Id == request.ArtistId).FirstOrDefaultAsync();
                if (artist != null)
                {
                    artist.EditPrincipal(request.PrincipalName);
                }
                else
                {
                    var newArtist = Artist.Create(request.PrincipalName);
                    _db.Artists.Add(newArtist);
                }

                await _db.SaveChangesAsync();
                return new Response();
            } 
            catch(Exception exception)
            {
                return new Response(exception.Message);
            }
        }
    }
}
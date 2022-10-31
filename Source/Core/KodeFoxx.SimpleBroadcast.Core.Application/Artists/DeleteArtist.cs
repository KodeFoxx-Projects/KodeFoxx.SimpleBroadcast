using Microsoft.EntityFrameworkCore;

namespace KodeFoxx.SimpleBroadcast.Core.Application.Artists;

public sealed class DeleteArtist
{
    public sealed class Request : IRequest<Response>
    {
        public long ArtistId { get; }

        public Request(long artistId)
        {
            ArtistId = artistId;
        }        
    }
    public sealed class Response
    {
        public bool IsDeleted { get; }
        public string Error { get; }

        internal Response(bool isDeleted, string? error = null)
        {
            IsDeleted = isDeleted;
            Error = error;
        }
    }

    private sealed class Handler : IRequestHandler<Request, Response>
    {
        private readonly SimpleBroadcastDatabase _db;

        public Handler(SimpleBroadcastDatabase database)
            => _db = database;

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var artist = await _db.Artists
                .Include(a => a.Songs)
                .Where(a => a.Id == request.ArtistId)
                .FirstOrDefaultAsync();

            if (artist is null)
                return new Response(false, "Artist could not be found in database.");

            if (artist.Songs.Any())
                return new Response(false, "Artist can not be deleted as it has one or moe songs attached to it.");            

            try
            {
                var isDeleted = _db.Artists.Remove(artist);
                await _db.SaveChangesAsync();

                return new Response(true);
            } 
            catch(Exception exception)
            {
                return new Response(false, exception.Message);
            }
        }
    }
}

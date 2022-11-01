namespace KodeFoxx.SimpleBroadcast.Core.Application.Artists;

public sealed class EditSongTitle
{
    public sealed class Request : IRequest<Response>
    {
        public long SongId { get; }
        public string Title { get; }

        public Request(long songId, string title)
        {
            SongId = songId;
            Title = title.Trim();
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
            try
            {
                var song = await _db.Songs
                    .Include(s => s.Artist)
                    .Where(s => s.Id == request.SongId)
                    .FirstAsync();

                if(String.IsNullOrWhiteSpace(request.Title))
                    return new Response($"Song title can not be blank.");

                if (song.Title.Trim().Equals(request.Title))
                    return new Response();

                var artist = song.Artist;
                var songs = await _db.Songs
                    .Include(s => s.Artist)
                    .Where(s => s.Artist.Id == artist.Id)
                    .ToListAsync();

                var exists = songs.Any(s => s.Title.Equals(request.Title));
                if (exists)
                    return new Response($"A song (id: '{song.Id}', title: '{song.Title}') with the same name already exists.");
            
                song.EditTitle(request.Title);

                await _db.SaveChangesAsync();
                return new Response();
            }
            catch (Exception exception)
            {
                return new Response(exception.Message);
            }
        }
    }
}

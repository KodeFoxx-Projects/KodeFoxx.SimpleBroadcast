namespace KodeFoxx.SimpleBroadcast.Core.Domain.Artists
{
    public sealed class Song : SimpleBroadcastEntity
    {
        public static readonly Song Empty = new Song();

        private Song(
            long? id = null,
            string? title = null,
            Artist? artist = null
        )
            : base(id ?? 0)
        {
            Title = title ?? string.Empty;
            Artist = artist ?? Artist.Empty;
        }
        private Song() : this(0) { }

        public string Title { get; private set; }
        public Artist Artist { get; }

        public Song EditTitle(string title)
        {
            Title = title.Trim();
            return this;
        }
    }
}
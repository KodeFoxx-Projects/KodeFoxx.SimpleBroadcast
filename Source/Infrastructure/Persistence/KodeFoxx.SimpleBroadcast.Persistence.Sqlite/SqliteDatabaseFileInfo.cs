namespace KodeFoxx.SimpleBroadcast.Persistence.Sqlite;

public sealed class SqliteDatabaseFileInfo
{
    public static readonly SqliteDatabaseFileInfo Default = new SqliteDatabaseFileInfo();

    public static SqliteDatabaseFileInfo Create(
        string? fileName = null,
        string? directory = null,
        string? extension = null
    )
        => new SqliteDatabaseFileInfo(fileName, directory, extension);

    private SqliteDatabaseFileInfo(
        string? fileName = null,
        string? directory = null,
        string? extension = null
    )
    {
        var cleanedFileName = String.IsNullOrEmpty(fileName)
            ? "simplebroadcast"
            : CleanFileName(fileName);

        var cleanedDirectory = String.IsNullOrEmpty(directory)
            ? Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
            : CleanDirectoryPath(directory);

        var cleanedExtension = String.IsNullOrEmpty(extension)
            ? ".sbdb"
            : CleanFileNameExtension(extension);

        var cleanedFileNameAndPath = Path.Combine(
            cleanedDirectory,
            "KodeFoxx",
            "SimpleBroadcast",
            $"{cleanedFileName}{cleanedExtension}"
        );
        _fileInfo = new FileInfo(cleanedFileNameAndPath);
    }

    private readonly FileInfo _fileInfo;

    public string FileNameWithExtension => _fileInfo.Name;
    public string FileName => Path.GetFileNameWithoutExtension(_fileInfo.Name);
    public string Extension => _fileInfo.Extension;
    public string Directory => _fileInfo.Directory.FullName;
    public string FullPath => _fileInfo.FullName;
    public bool Exists => _fileInfo.Exists;

    private string CleanFileName(string fileName)
    {
        var invalidCharacters = Path.GetInvalidFileNameChars();
        var cleanedFileName = String.Concat(fileName.Split(invalidCharacters));
        if (cleanedFileName.Contains("."))
        {
            var extension = cleanedFileName.Substring(cleanedFileName.LastIndexOf("."));
            cleanedFileName.Replace(extension, "");
            cleanedFileName.Replace(".", "-");
        }

        return cleanedFileName;
    }

    private string CleanDirectoryPath(string fileName)
    {
        var invalidCharacters = Path.GetInvalidPathChars();
        return String.Concat(fileName.Split(invalidCharacters));
    }

    private string CleanFileNameExtension(string extension)
    {
        var invalidCharacters = Path.GetInvalidFileNameChars();
        var cleanedExtension = String.Concat(extension.Split(invalidCharacters));
        if (!cleanedExtension.StartsWith("."))
            cleanedExtension = $".{cleanedExtension}";

        return cleanedExtension;
    }
}

using Microsoft.EntityFrameworkCore.Infrastructure;

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

    internal static SqliteDatabaseFileInfo? CreateFromDatabase(
        DatabaseFacade database
    )
    {
        var connectionString = database.GetConnectionString();
        var fileInfo = new FileInfo(connectionString.ToLower().Replace("data source=", ""));
        return Create(
            Path.GetFileNameWithoutExtension(fileInfo.FullName),
            fileInfo.Directory.FullName,
            fileInfo.Extension);
    }

    private SqliteDatabaseFileInfo(
        string? fileName = null,
        string? directory = null,
        string? extension = null
    )
    {
        var cleanedFileName = String.IsNullOrEmpty(fileName)
            ? CleanFileName("simplebroadcast")
            : CleanFileName(fileName);

        var cleanedDirectory = String.IsNullOrEmpty(directory)
            ? CleanDirectoryPath(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData))
            : CleanDirectoryPath(directory);

        var cleanedExtension = String.IsNullOrEmpty(extension)
            ? CleanFileNameExtension(".sbdb")
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
            cleanedFileName = cleanedFileName
                .Replace(".", "-")
                .Replace(extension, "");
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
        var lowercaseAlphabet = "abcdefghijklmnopqrstuvwxyz".ToArray();
        var cleanedExtension = String.Concat(extension.Split(invalidCharacters));
        cleanedExtension = $".{cleanedExtension.Replace(".", "")}".ToLower();

        cleanedExtension = String.Join("", cleanedExtension
                .Where(@char => lowercaseAlphabet.Contains(@char) || @char.Equals('.'))
                .Select(@char => @char)
        );

        return cleanedExtension;
    }
}

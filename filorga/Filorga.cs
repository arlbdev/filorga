namespace filorga;

class Filorga
{
  static void Main(string[] args)
  {
    string sourcePath = GetValidDirectoryPath();


    if (sourcePath.ToLower().Equals("e"))
    {
      return;
    }

    bool organizeAllFiles = GetUserPref();

    CreateDirectories(sourcePath);

    if (organizeAllFiles)
    {
      OrganizeAllFiles(sourcePath);
    }
    else
    {
      OrganizeFilesInDirOnly(sourcePath);
    }
  }

  static bool GetUserPref()
  {
    while (true)
    {
      Console.WriteLine("Do you want to organize including the subfolders in the directory?");
      Console.WriteLine("Enter 'y' for Yes or 'n' for No: ");
      string input = Console.ReadLine();

      if (input.ToLower() == "y")
      {
        return true;
      }
      else if (input.ToLower() == "n")
      {
        return false;
      }
      else
      {
        Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
      }
    }
  }

  static void CreateDirectories(string sourcePath)
  {
    string[] fileTypes = { "Images", "Documents", "Videos", "Audio", "Compressed", "Others" };

    foreach (var type in fileTypes)
    {
      string path = Path.Combine(sourcePath, type);
      if (!Directory.Exists(path))
      {
        Directory.CreateDirectory(path);
      }
    }
  }

  static string GetValidDirectoryPath()
  {
    string sourcePath;
    while (true)
    {
      Console.WriteLine("Enter the source directory path (eg. C:\\Users\\username\\Files) or type 'e' to exit:");
      sourcePath = Console.ReadLine();

      if (sourcePath.Equals("e", StringComparison.OrdinalIgnoreCase))
      {
        Console.WriteLine("Exiting the program.");
        return "e";
      }

      if (!string.IsNullOrWhiteSpace(sourcePath) && Directory.Exists(sourcePath))
      {
        break;
      }

      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("Invalid directory path. Please make sure the path is correct and try again.");
      Console.ResetColor();
    }

    return sourcePath;
  }

  static void OrganizeFilesInDirOnly(string sourcePath)
  {
    var files = Directory.GetFiles(sourcePath);

    foreach (var file in files)
    {
      string extension = Path.GetExtension(file).ToLower();
      string destinationDirectory = GetDestinationDirectory(extension, sourcePath);

      if (destinationDirectory != null)
      {
        string fileName = Path.GetFileName(file);
        string destPath = Path.Combine(destinationDirectory, fileName);
        File.Move(file, destPath);
      }
    }

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Files organized successfully.");
    Console.ResetColor();
    Console.WriteLine("Press any key to exit.");
    Console.ReadKey();
  }

  static void OrganizeAllFiles(string sourcePath)
  {
    OrganizeFilesRecursively(sourcePath, sourcePath);

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Files organized successfully.");
    Console.ResetColor();
    Console.WriteLine("Press any key to exit.");
    Console.ReadKey();
  }

  static void OrganizeFilesRecursively(string currentPath, string sourcePath)
  {
    var files = Directory.GetFiles(currentPath);

    foreach (var file in files)
    {
      string extension = Path.GetExtension(file).ToLower();
      string destinationDirectory = GetDestinationDirectory(extension, sourcePath);

      if (destinationDirectory != null)
      {
        string fileName = Path.GetFileName(file);
        string destPath = Path.Combine(destinationDirectory, fileName);
        File.Move(file, destPath);
      }
    }

    var directories = Directory.GetDirectories(currentPath);
    foreach (var directory in directories)
    {
      OrganizeFilesRecursively(directory, sourcePath);
    }
  }

  static string GetDestinationDirectory(string extension, string sourcePath)
  {
    switch (extension)
    {
      case ".jpg":
      case ".jpeg":
      case ".png":
      case ".gif":
        return Path.Combine(sourcePath, "Images");
      case ".doc":
      case ".docx":
      case ".pdf":
      case ".txt":
        return Path.Combine(sourcePath, "Documents");
      case ".mp4":
      case ".avi":
      case ".mkv":
        return Path.Combine(sourcePath, "Videos");
      case ".mp3":
      case ".m4a":
      case ".wav":
        return Path.Combine(sourcePath, "Audio");
      case ".zip":
      case ".rar":
      case ".7z":
        return Path.Combine(sourcePath, "Compressed");
      default:
        return Path.Combine(sourcePath, "Others");
    }
  }
}

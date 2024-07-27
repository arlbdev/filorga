# Filorga - File Organizer

Filorga is a console application developed in C# .NET that helps you organize files within a directory based on their file extensions. You can choose to organize files only in the root directory or include subfolders for a more comprehensive organization.

## Features

- Organize files in the specified directory based on their file extensions.
- Option to include subfolders for organizing files recursively.
- Supports common file types such as images, documents, videos, audio, compressed files, and others.

## Usage

1. **Run the Application:**

   - Compile and run the `Filorga` application.
   - Enter the source directory path when prompted. You can specify the path like `C:\Users\username\Files`.

2. **Choose Organizing Mode:**

   - You will be asked whether you want to organize files in subfolders as well.
   - Type 'Y' for organizing files in subfolders or 'N' to organize only the files in the root directory.

3. **File Organization:**
   - Files will be moved to respective directories based on their file extensions.
   - Subfolders will be traversed if the recursive mode is enabled.

## Sample Directory Structure

```
- Root Directory
  - Images
    - image1.jpg
    - image2.png
  - Documents
    - doc1.pdf
    - doc2.docx
  - Videos
    - video1.mp4
  - Subfolder
    - SubfolderImage.jpg
```

## Notes

- Make sure to provide a valid source directory path.
- Exercise caution when organizing files in subfolders to avoid unintended file movements.

# 📂 File Organizer

<div align="center">

### Organize Files Automatically by Type

A simple C# console application that automatically organizes files inside a selected directory into categorized folders based on their file extensions.

<br>

![C#](https://img.shields.io/badge/C%23-.NET-purple?style=for-the-badge)
![Type](https://img.shields.io/badge/Type-Console%20Application-blue?style=for-the-badge)

<div>

---

📖 About

File Organizer is a console-based utility that helps users organize files within a directory.

The application scans all files in a selected folder, creates a structured directory tree, and automatically moves files into their appropriate categories such as Audio, Images, Videos, Documents, and Compressed files.

✨ Features

✅ Automatic file organization

✅ Creates categorized folders automatically

✅ Supports Audio, Video, Image, Document and Archive files

✅ Handles duplicate file names safely

✅ Detailed operation logs

✅ File transfer statistics

✅ Error handling and validation

✅ Simple console interface

📁 Folder Structure

The application creates the following structure:

File Organizer
│
├── Audio
├── Compressed
├── Images
├── Videos
└── Documents
    │
    ├── PDF
    ├── Text
    ├── Others
    │
    └── Office
        │
        ├── Word
        ├── Excel
        └── Power Point
📦 Supported File Types
Category	Extensions
Audio	.mp3, .wav, .aac, .flac, .ogg
Compressed	.zip, .rar, .7z
Word	.doc, .docx
Excel	.xls, .xlsx
PowerPoint	.ppt, .pptx
PDF	.pdf
Text	.txt
Other Documents	.html, .css, .js, .json, .xml, .xaml, .csv, .rtf, .md
Images	.jpg, .jpeg, .png, .gif, .bmp, .tiff, .webp, .svg
Videos	.mp4, .avi, .mov, .wmv, .flv, .mkv, .webm
🚀 How It Works
Run the application.
Enter the path of the folder you want to organize.
The application creates a new File Organizer directory.
Files are categorized and moved automatically.
A summary report is displayed at the end.

Example:

please enter your folder's location:

D:\Downloads
📊 Output Report

After processing, the application displays:

Number of audio files moved
Number of compressed files moved
Number of documents moved
Number of images moved
Number of videos moved
Total files transferred
🛡 Error Handling

The application handles common errors such as:

Invalid directory paths
Missing folders
Access denied errors
File transfer conflicts
Unexpected runtime exceptions
🛠 Technologies
Technology	Purpose
C#	Main programming language
.NET	Runtime Framework
System.IO	File and directory operations
Visual Studio 2022	Development Environment

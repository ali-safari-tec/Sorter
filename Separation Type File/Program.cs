namespace FileOrganizer
{
    public class FileOrganizer
    {
        public static void Main()
        {
            Console.WriteLine("please enter your folder's locatin : ");
            // Get location string from user
            string? mainFolderPath = Console.ReadLine();

            // We should check our data (mainFolderPath)
            // if it is not null and whitespace continue program and if user return null and whitespace we show comment for user
            // in this case if user dont write anything in console it means mainFolderPath = ""; and this means code get whitespace
            if (!string.IsNullOrWhiteSpace(mainFolderPath))
            {
                // this address is for main folder 
                // we use counter only for this folder because maybe there is some folder with similar name with our folder
                // this counter use for add number after name of folder
                string mainPath = Path.Combine(mainFolderPath, "File Organizer");
                int counter = 1;

                // this loop help us to make new name and address for main folder
                // search and if there is similar folder with our folder in user location code enter while loop
                // this loop work until we get uniqe name for main folder
                // we dont need this things for other folder because they placed on main folder
                // and we dont have similar folder in new folder
                while (Directory.Exists(mainPath))
                {
                    mainPath = Path.Combine(mainFolderPath, "File Organizer" + $" ({counter})");
                    counter++;
                }

                // fill address of each folder and name them
                string audioPath = Path.Combine(mainPath, "Audio");
                string compressedPath = Path.Combine(mainPath, "Compressed");
                string imagesPath = Path.Combine(mainPath, "Images");
                string videosPath = Path.Combine(mainPath, "Videos");
                string documentsPath = Path.Combine(mainPath, "Documents");
                string textPath = Path.Combine(documentsPath, "Text");
                string pdfPath = Path.Combine(documentsPath, "PDF");
                string othersPath = Path.Combine(documentsPath, "Others");
                string officeftPath = Path.Combine(documentsPath, "Office");
                string wordPath = Path.Combine(officeftPath, "Word");
                string exelPath = Path.Combine(officeftPath, "Exel");
                string powerPointPath = Path.Combine(officeftPath, "Power Point");

                // create all folder
                Directory.CreateDirectory(mainPath);
                Directory.CreateDirectory(audioPath);
                Directory.CreateDirectory(compressedPath);
                Directory.CreateDirectory(imagesPath);
                Directory.CreateDirectory(videosPath);
                Directory.CreateDirectory(documentsPath);
                Directory.CreateDirectory(textPath);
                Directory.CreateDirectory(pdfPath);
                Directory.CreateDirectory(othersPath);
                Directory.CreateDirectory(officeftPath);
                Directory.CreateDirectory(wordPath);
                Directory.CreateDirectory(exelPath);
                Directory.CreateDirectory(powerPointPath);

                // show dialog to the user
                // we can see all log that folders created successfuly
                Console.WriteLine("\n\n---------------------------------------------------- Create Folders ----------------------------------------------------\n");
                Console.WriteLine($" > {Path.GetFileName(mainPath)}");
                Console.WriteLine($"     > {Path.GetFileName(audioPath)}");
                Console.WriteLine($"     > {Path.GetFileName(compressedPath)}");
                Console.WriteLine($"     > {Path.GetFileName(documentsPath)}");
                Console.WriteLine($"         > {Path.GetFileName(officeftPath)}");
                Console.WriteLine($"            > {Path.GetFileName(exelPath)}");
                Console.WriteLine($"            > {Path.GetFileName(powerPointPath)}");
                Console.WriteLine($"            > {Path.GetFileName(wordPath)}");
                Console.WriteLine($"         > {Path.GetFileName(othersPath)}");
                Console.WriteLine($"         > {Path.GetFileName(pdfPath)}");
                Console.WriteLine($"         > {Path.GetFileName(textPath)}");
                Console.WriteLine($"     > {Path.GetFileName(imagesPath)}");
                Console.WriteLine($"     > {Path.GetFileName(videosPath)}");
                Console.WriteLine($"\nAll folder created successfuly.\n");
                Console.WriteLine("---------------------------------------------------- Transfer Files ----------------------------------------------------\n");

                // now we want begin to write main code of program
                // we want organized file in their folder 
                // we have audio files, compressed files, document files, image files and video files
                // and document have 4 part office for (word, exel and powerpoint files), pdf files, simple text files and other type of ducument

                // -> File Organizer
                //    -> Audio
                //    -> Compressed
                //    -> Documents
                //       -> Office
                //          -> Exel
                //          -> Power Point
                //          -> Word
                //       -> Others
                //       -> PDF
                //       -> Text
                //    -> Images
                //    -> videos

                // the folders created like this 

                try
                {
                    // get all files in user location
                    string[] files = Directory.GetFiles(mainFolderPath);

                    // we want show to the user how many files are transfer from location to their folders at the end of progress
                    // so we need numeric data type for count them and at the end show the to user with dialog
                    int audioCount = 0;
                    int compressedCount = 0;
                    int documentCount = 0;
                    int imageCount = 0;
                    int videoCount = 0;

                    // this foreach loop check all files in that location 
                    // so we should write wich extension we want and everyone of them should move to which folders
                    foreach (string file in files)
                    {
                        string fileName = Path.GetFileName(file);                   // get name of file with extension
                        string extension = Path.GetExtension(fileName).ToLower();   // get only extension

                        // this condition is for audio type
                        // we want only work on (.mp3, .wav, .acc, .flac, .ogg) audio type
                        // you can customize the extension whatever you want
                        if (extension == ".mp3" || extension == ".wav" || extension == ".acc" || extension == ".flac" || extension == ".ogg")
                        {
                            string nameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);   // get name of file without extension
                            string destFile = Path.Combine(audioPath, fileName);   // destination of file for move ---> (location of folder + current file name)
                            int destCounter = 1;  // for make sure we dont have 2 files with same name (just for confidence)

                            // check if we have 2 files with similar name go tothe loop and make uniqe
                            if (File.Exists(destFile))
                            {
                                while (File.Exists(destFile))
                                {
                                    destFile = Path.Combine(audioPath, nameWithoutExtension + $" ({destCounter})");
                                    destCounter++;
                                }
                                File.Move(file, destFile);   // and move file to the folder at the end
                            }
                            else
                            {
                                File.Move(file, destFile);   // if we dont have similar name just move file
                            }
                            audioCount++;   // add 1 for counting how many audio file we transfer 
                            // show dialog that which file move successfuly 
                            // and if we have error with transfer we can see
                            Console.WriteLine($"'{Path.GetFileName(destFile)}' is transfer to '{Path.GetFileName(audioPath)}' folder successfuly.");
                        }

                        // this condition is for compressed type
                        // we want only work on (.zip, .rar, .7z) compressed type
                        // you can customize the extension whatever you want
                        else if (extension == ".rar" || extension == ".zip" || extension == ".7z")
                        {
                            string nameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);   // get name of file without extension
                            string destFile = Path.Combine(compressedPath, fileName);   // destination of file for move ---> (location of folder + current file name)
                            int destCounter = 1;   // for make sure we dont have 2 files with same name (just for confidence)

                            // check if we have 2 files with similar name go tothe loop and make uniqe
                            if (File.Exists(destFile))
                            {
                                while (File.Exists(destFile))
                                {
                                    destFile = Path.Combine(compressedPath, nameWithoutExtension + $" ({destCounter})");
                                    destCounter++;
                                }
                                File.Move(file, destFile);   // and move file to the folder at the end
                            }
                            else
                            {
                                File.Move(file, destFile);   // if we dont have similar name just move file
                            }
                            compressedCount++;   // add 1 for counting how many compressed file we transfer
                            // show dialog that which file move successfuly 
                            // and if we have error with transfer we can see
                            Console.WriteLine($"'{Path.GetFileName(destFile)}' is transfer to '{Path.GetFileName(compressedPath)}' folder successfuly.");
                        }

                        // this condition is for exel type
                        // we want only work on (.xlsx, .xls) exel type
                        // you can customize the extension whatever you want
                        else if (extension == ".xlsx" || extension == ".xls")
                        {
                            string nameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);   // get name of file without extension
                            string destFile = Path.Combine(exelPath, fileName);   // destination of file for move ---> (location of folder + current file name)
                            int destCounter = 1;   // for make sure we dont have 2 files with same name (just for confidence)

                            // check if we have 2 files with similar name go tothe loop and make uniqe
                            if (File.Exists(destFile))
                            {
                                while (File.Exists(destFile))
                                {
                                    destFile = Path.Combine(exelPath, nameWithoutExtension + $" ({destCounter})");
                                    destCounter++;
                                }
                                File.Move(file, destFile);   // and move file to the folder at the end
                            }
                            else
                            {
                                File.Move(file, destFile);   // if we dont have similar name just move file
                            }
                            documentCount++;   // add 1 for counting how many exel file we transfer
                            // show dialog that which file move successfuly 
                            // and if we have error with transfer we can see
                            Console.WriteLine($"'{Path.GetFileName(destFile)}' is transfer to '{Path.GetFileName(exelPath)}' folder successfuly.");
                        }

                        // this condition is for power point type
                        // we want only work on (.pptx, .ppt) power point type
                        // you can customize the extension whatever you want
                        else if (extension == ".pptx" || extension == ".ppt")
                        {
                            string nameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);   // get name of file without extension
                            string destFile = Path.Combine(powerPointPath, fileName);   // destination of file for move ---> (location of folder + current file name)
                            int destCounter = 1;   // for make sure we dont have 2 files with same name (just for confidence)

                            // check if we have 2 files with similar name go tothe loop and make uniqe
                            if (File.Exists(destFile))
                            {
                                while (File.Exists(destFile))
                                {
                                    destFile = Path.Combine(powerPointPath, nameWithoutExtension + $" ({destCounter})");
                                    destCounter++;
                                }
                                File.Move(file, destFile);   // and move file to the folder at the end
                            }
                            else
                            {
                                File.Move(file, destFile);   // if we dont have similar name just move file
                            }
                            documentCount++;   // add 1 for counting how many power point file we transfer
                            // show dialog that which file move successfuly 
                            // and if we have error with transfer we can see
                            Console.WriteLine($"'{Path.GetFileName(destFile)}' is transfer to '{Path.GetFileName(powerPointPath)}' folder successfuly.");
                        }

                        // this condition is for word type
                        // we want only work on (.docx, .doc) word type
                        // you can customize the extension whatever you want
                        else if (extension == ".docx" || extension == ".doc")
                        {
                            string nameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);   // get name of file without extension
                            string destFile = Path.Combine(wordPath, fileName);   // destination of file for move ---> (location of folder + current file name)
                            int destCounter = 1;   // for make sure we dont have 2 files with same name (just for confidence)

                            // check if we have 2 files with similar name go tothe loop and make uniqe
                            if (File.Exists(destFile))
                            {
                                while (File.Exists(destFile))
                                {
                                    destFile = Path.Combine(wordPath, nameWithoutExtension + $" ({destCounter})");
                                    destCounter++;
                                }
                                File.Move(file, destFile);   // and move file to the folder at the end
                            }
                            else
                            {
                                File.Move(file, destFile);   // if we dont have similar name just move file
                            }
                            documentCount++;   // add 1 for counting how many word file we transfer
                            // show dialog that which file move successfuly 
                            // and if we have error with transfer we can see
                            Console.WriteLine($"'{Path.GetFileName(destFile)}' is transfer to '{Path.GetFileName(wordPath)}' folder successfuly.");
                        }

                        // this condition is for other text type
                        // we want only work on (.html, .htm, .css, .js, .json, .xml, .xaml, .csv, .rtf, .md) text type
                        // you can customize the extension whatever you want
                        else if (extension == ".html" || extension == ".htm" || extension == ".css" || extension == ".js" || extension == ".json" || extension == ".xml" || extension == ".xaml" || extension == ".csv" || extension == ".rtf" || extension == ".md")
                        {
                            string nameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);   // get name of file without extension
                            string destFile = Path.Combine(othersPath, fileName);   // destination of file for move ---> (location of folder + current file name)
                            int destCounter = 1;   // for make sure we dont have 2 files with same name (just for confidence)

                            // check if we have 2 files with similar name go tothe loop and make uniqe
                            if (File.Exists(destFile))
                            {
                                while (File.Exists(destFile))
                                {
                                    destFile = Path.Combine(othersPath, nameWithoutExtension + $" ({destCounter})");
                                    destCounter++;
                                }
                                File.Move(file, destFile);   // and move file to the folder at the end
                            }
                            else
                            {
                                File.Move(file, destFile);   // if we dont have similar name just move file
                            }
                            documentCount++;   // add 1 for counting how many other text file we transfer
                            // show dialog that which file move successfuly 
                            // and if we have error with transfer we can see
                            Console.WriteLine($"'{Path.GetFileName(destFile)}' is transfer to '{Path.GetFileName(othersPath)}' folder successfuly.");
                        }

                        // this condition is for pdf type
                        // we want only work on pdf type
                        // you can customize the extension whatever you want
                        else if (extension == ".pdf")
                        {
                            string nameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);   // get name of file without extension
                            string destFile = Path.Combine(pdfPath, fileName);   // destination of file for move ---> (location of folder + current file name)
                            int destCounter = 1;   // for make sure we dont have 2 files with same name (just for confidence)

                            // check if we have 2 files with similar name go tothe loop and make uniqe
                            if (File.Exists(destFile))
                            {
                                while (File.Exists(destFile))
                                {
                                    destFile = Path.Combine(pdfPath, nameWithoutExtension + $" ({destCounter})");
                                    destCounter++;
                                }
                                File.Move(file, destFile);   // and move file to the folder at the end
                            }
                            else
                            {
                                File.Move(file, destFile);   // if we dont have similar name just move file
                            }
                            documentCount++;   // add 1 for counting how many pdf file we transfer
                            // show dialog that which file move successfuly 
                            // and if we have error with transfer we can see
                            Console.WriteLine($"'{Path.GetFileName(destFile)}' is transfer to '{Path.GetFileName(pdfPath)}' folder successfuly.");
                        }

                        // this condition is for simple text type
                        // we want only work on text type
                        // you can customize the extension whatever you want
                        else if (extension == ".txt")
                        {
                            string nameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);   // get name of file without extension
                            string destFile = Path.Combine(textPath, fileName);   // destination of file for move ---> (location of folder + current file name)
                            int destCounter = 1;   // for make sure we dont have 2 files with same name (just for confidence)

                            // check if we have 2 files with similar name go tothe loop and make uniqe
                            if (File.Exists(destFile))
                            {
                                while (File.Exists(destFile))
                                {
                                    destFile = Path.Combine(textPath, nameWithoutExtension + $" ({destCounter})");
                                    destCounter++;
                                }
                                File.Move(file, destFile);   // and move file to the folder at the end
                            }
                            else
                            {
                                File.Move(file, destFile);
                            }
                            documentCount++;   // add 1 for counting how many simple text file we transfer
                            // show dialog that which file move successfuly 
                            // and if we have error with transfer we can see
                            Console.WriteLine($"'{Path.GetFileName(destFile)}' is transfer to '{Path.GetFileName(textPath)}' folder successfuly.");
                        }

                        // this condition is for image type
                        // we want only work on (.jpg, .jpeg, .png, .gif, .bmp, .tiff, .tif, .webp, .svg) image type
                        // you can customize the extension whatever you want
                        else if (extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".gif" || extension == ".bmp" || extension == ".tiff" || extension == ".tif" || extension == ".webp" || extension == ".svg")
                        {
                            string nameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);   // get name of file without extension
                            string destFile = Path.Combine(imagesPath, fileName);   // destination of file for move ---> (location of folder + current file name)
                            int destCounter = 1;   // for make sure we dont have 2 files with same name (just for confidence)

                            // check if we have 2 files with similar name go tothe loop and make uniqe
                            if (File.Exists(destFile))
                            {
                                while (File.Exists(destFile))
                                {
                                    destFile = Path.Combine(imagesPath, nameWithoutExtension + $" ({destCounter})");
                                    destCounter++;
                                }
                                File.Move(file, destFile);   // and move file to the folder at the end
                            }
                            else
                            {
                                File.Move(file, destFile);   // if we dont have similar name just move file
                            }
                            imageCount++;   // add 1 for counting how many image file we transfer
                            // show dialog that which file move successfuly 
                            // and if we have error with transfer we can see
                            Console.WriteLine($"'{Path.GetFileName(destFile)}' is transfer to '{Path.GetFileName(imagesPath)}' folder successfuly.");
                        }

                        // this condition is for video type
                        // we want only work on (.mp4, .avi, .mov, .wmv, .flv, .mkv, .webm) video type
                        // you can customize the extension whatever you want
                        else if (extension == ".mp4" || extension == ".avi" || extension == ".mov" || extension == ".wmv" || extension == ".flv" || extension == ".mkv" || extension == ".webm")
                        {
                            string nameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);   // get name of file without extension
                            string destFile = Path.Combine(videosPath, fileName);   // destination of file for move ---> (location of folder + current file name)
                            int destCounter = 1;   // for make sure we dont have 2 files with same name (just for confidence)

                            // check if we have 2 files with similar name go tothe loop and make uniqe
                            if (File.Exists(destFile))
                            {
                                while (File.Exists(destFile))
                                {
                                    destFile = Path.Combine(videosPath, nameWithoutExtension + $" ({destCounter})");
                                    destCounter++;
                                }
                                File.Move(file, destFile);   // and move file to the folder at the end
                            }
                            else
                            {
                                File.Move(file, destFile);   // if we dont have similar name just move file
                            }
                            videoCount++;   // add 1 for counting how many video file we transfer
                            // show dialog that which file move successfuly 
                            // and if we have error with transfer we can see
                            Console.WriteLine($"'{Path.GetFileName(destFile)}' is transfer to '{Path.GetFileName(videosPath)}' folder successfuly.");
                        }


                        // and if none of this condition (type) is true write which file with what extension are ignored
                        // this files stay at their posision
                        else
                        {
                            Console.WriteLine($"File '{fileName}' with extension '{extension}' is ignored.");
                        }
                    }

                    // this data can show all count of transfer files
                    int total = audioCount + compressedCount + documentCount + imageCount + videoCount;

                    // log dialog for show the count
                    Console.WriteLine("\n------------------------------------------------------- End Logs -------------------------------------------------------\n");
                    Console.WriteLine($"The proccess is finished.\n\n");                                                               
                    Console.WriteLine($"Total audio transfer to {Path.GetFileName(audioPath)} folder = {audioCount}");                  // audio count
                    Console.WriteLine($"Total compressed transfer to {Path.GetFileName(compressedPath)} folder = {compressedCount}");   // compressed count
                    Console.WriteLine($"Total document transfer to {Path.GetFileName(documentsPath)} folder = {documentCount}");        // document count  
                    Console.WriteLine($"Total image transfer to {Path.GetFileName(imagesPath)} folder = {imageCount}");                 // image count
                    Console.WriteLine($"Total video transfer to {Path.GetFileName(videosPath)} folder = {videoCount}\n");               // video count
                    Console.WriteLine($"Total files transfer = {total}\n");                                                             // total count       
                    Console.WriteLine("------------------------------------------------------- All Done -------------------------------------------------------\n");
                }

                // if program dont have access create main folder 
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine($"Error: Access to the path '{mainFolderPath}' is denied. Please try a different directory or ensure the program has the necessary permissions.");
                }

                // unvalid directory
                catch (DirectoryNotFoundException)
                {
                    Console.WriteLine($"Error: The main directory '{mainFolderPath}' was not found. Please check the path again.");
                }

                // error for transfer  the files
                catch (IOException ex)
                {
                    Console.WriteLine($"Error during file transfer: {ex.Message}");
                    Console.WriteLine("Please ensure that no file with the same name exists in the destination folders and that no other applications are currently using the files.");
                }

                // an unexpected error occurred
                catch (Exception ex)
                {
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                }

                Console.WriteLine("\nPress Enter to exit...");
                Console.ReadLine();
            }

            // if user dont write anything in console show this dialog
            else
            {
                Console.WriteLine("You should enter location.");
                return;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.Extensions;

namespace TranslationProject
{
    public static class HandleStore
    {
        //Handles the opening of a file
        public static string openFile(string path)
        {
            //Will hold the content of the given file
            string fileContent = null;

            //Gathers text from a text document
            if (path.Contains(".txt"))
            {
                StreamReader textIn = new StreamReader(new FileStream(path, FileMode.Open, FileAccess.Read));
                while (!textIn.EndOfStream)
                {
                    fileContent = textIn.ReadToEnd();
                }
                textIn.Close();

            }
            //Gathers text from a Word (2007+) document
            else if (path.Contains(".docx"))
            {
                //Represents our "document"
                WordprocessingDocument doc = WordprocessingDocument.Open(path, true);
                //Gather a "list" of all the separate paragraph elements from the xml
                IEnumerable<Paragraph> paragraphElements =
                            doc.MainDocumentPart.Document.Body.Descendants<Paragraph>();

                //Loop through each of the paragraph elements
                foreach (Paragraph p in paragraphElements)
                {
                    //And for each paragraph, gather all disparate "Text" elements
                    IEnumerable<Text> textElements = p.Descendants<Text>();

                    //Go through all the text elements
                    foreach (Text t in textElements)
                    {
                        //Appending them to our fileContent holder
                        fileContent += t.Text;
                    }
                    //It's the end of a paragraph, so why not?
                    fileContent += '\n';
                }
                //Close out our document
                doc.Close();
            }

            return fileContent;
        }

        //Handles the saving of data to a file
        public static void saveTranslation(string translation, string path)
        {
            //An error will occur if there is nothing in the path...
            try
            {
                //If the path contains the .txt format, handle it as a .txt
                if (path.Contains(".txt"))
                {
                    //Open the stream for writing a new .txt
                    StreamWriter textOut = new StreamWriter(new FileStream(path, FileMode.Create, FileAccess.Write));

                    //Write the string to the file
                    textOut.Write(translation);

                    //Close the stream
                    textOut.Close();
                }
                //Handles saving to a .docx format
                else if (path.Contains(".docx"))
                {
                    //Will hold the various lines of the translation
                    string[] paragraphs = null;

                    //Any number of errors could occur...
                    try
                    {
                        // Create the Wordprocessing document. 
                        using (WordprocessingDocument doc =
                               WordprocessingDocument.Create(path,
                                             WordprocessingDocumentType.Document))
                        {
                            // Add a "main document" to the .docx 
                            MainDocumentPart mainPart = doc.AddMainDocumentPart();
                            //Create Document tree for the new simple document. 
                            mainPart.Document = new Document();
                            //Create Body (this element contains
                            //the other elements that we want to include) 
                            Body body = new Body();
                            //Split up the translation text into a series of array elements
                            //These individual elements will each be a paragraph in the new document, to maintain the look
                            paragraphs = translation.Split(new char[] { '\n' });

                            //Loop through, for each paragraph in our array, and add a new paragraph element in the .docx
                            foreach (string s in paragraphs)
                            {
                                //Append to the body an anonymous Paragraph
                                //The paragraph has an anonymous "Run" with the text from our paragraph
                                body.Append(new Paragraph(new Run(new Text(s))));
                            }
                            //Append the body to the document.
                            mainPart.Document.Append(body);
                            // Save changes to the main document part. 
                            mainPart.Document.Save();
                        }

                    }
                    catch
                    {
                        //No clue what to do if an error shows up...
                        MessageBox.Show("Cannot read a document currently in use. Please close the document and try again.", "Error");
                    }
                }
            }
            //Errors include invalid directory
            catch (DirectoryNotFoundException ex)
            {
                MessageBox.Show("Error: \n" + ex.Message + "\nThe directory used does not exist. Please try again.", "Directory Not Found");
            }
            //No such file exists
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("Error: \n" + ex.Message +"\nThe file entered does not exist.", "Directory Not Found");
            }
            catch//Or who knows?
            {
                MessageBox.Show("Not expected...", "Oops!");
            }
        }
    }
}

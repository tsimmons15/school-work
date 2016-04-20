using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace TranslationProject
{
    public partial class frmTranslateDoc : Form
    {
        public frmTranslateDoc()
        {
            InitializeComponent();
        }
        
        private void appStart(object o, EventArgs e)
        {
            txtDocOrigin.Focus();
            cmbTranslateFrom.SelectedIndex = 0;
            cmbTranslateTo.SelectedIndex = 0;
        }

        //Handles automatic copy-ing and setting of the "Save To" field
        private void updateSaveTo(object o, EventArgs e)
        {
            //Will hold the file path entered
            string filePath = null;
            string extension = null;

            //If the user has opted to allow for the auto-completion
            if (chkAutoInsert.Checked)
            {
                //Check to make sure that the supplied path has an extension
                //Explicitly handles three character-length extensions (.txt / .doc)
                if (Regex.IsMatch(txtDocOrigin.Text, @"^(.){1,}[.](\w){3}$"))
                {
                    //If the filepath has an extension, copy/remove the extension
                    extension = txtDocOrigin.Text.Substring(txtDocOrigin.Text.Length - 4, 4);
                    filePath = txtDocOrigin.Text.Substring(0, txtDocOrigin.Text.Length - 4) + "-Translation" + extension;

                    //Place the new filePath into the textbox
                    txtSaveTo.Text = filePath;
                    
                }
                //Explicitly handles four character-length extensions (.docx )
                else if (Regex.IsMatch(txtDocOrigin.Text, @"^(.){1,}[.](\w){4}$"))
                {
                    //If the filepath has an extension, copy/remove the extension
                    extension = txtDocOrigin.Text.Substring(txtDocOrigin.Text.Length - 5, 5);
                    filePath = txtDocOrigin.Text.Substring(0, txtDocOrigin.Text.Length - 5) + "-Translation" + extension;

                    //Place the new filePath into the textbox
                    txtSaveTo.Text = filePath;
                }
            }
        }

        //Handles the translating of a document
        private void TranslateDocument(object sender, EventArgs e)
        {
            //If there is a document to read...
            if (txtDocOrigin.Text.Length > 0)
            {
                //Open the file and retrieve its contents
                string translateString = HandleStore.openFile(txtDocOrigin.Text);
                string translateTo = Translate.getLanguageCode(cmbTranslateTo.SelectedItem.ToString());
                string translateFrom = Translate.getLanguageCode(cmbTranslateFrom.SelectedItem.ToString());
                
                //If there is something to translate...
                if (translateString != null && translateString.Length > 0)
                {
                    try
                    {
                        if (!Translate.Authentication)
                        {
                            Translate.generateHeader();
                        }
                        translateString = Translate.translateText(translateString, translateFrom, translateTo);

                        //If the returned translation is not null, it succeeded without error
                        if (translateString != null)
                        {
                            //Set the translated text in the text control meant for it.
                            saveTranslation(translateString);

                        }
                    }
                    catch
                    {
                        if (cmbTranslateTo.SelectedIndex != 0)
                        {
                            MessageBox.Show("Unable to translate. Please check your internet connection and try again.", "Unable to connect");
                        }
                        else
                        {
                            MessageBox.Show("Unable to translate. Please check to make sure you have selected a language to translate to and try again",
                                                             "Error");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("There was an error. Please check the path name and try again.", "Sorry");
                }
            }
        }

        private void closeForm(object o, EventArgs e)
        {
            this.Close();
        }

        //Handles whether diaFileSave or diaFileOpen is launched
        private void RequestFile(object sender, EventArgs e)
        {
            if (sender.Equals(btnBrowseOrigin))
            {
                if (diaFileOpen.ShowDialog() == DialogResult.OK)
                {
                    txtDocOrigin.Text = diaFileOpen.FileName;
                    txtDocOrigin.Focus();
                }
            }
            else if (sender.Equals(btnBrowseSaveTo))
            {
                if (diaFileSave.ShowDialog() == DialogResult.OK)
                {
                    txtSaveTo.Text = diaFileOpen.FileName;
                    txtSaveTo.Focus();
                }
            }
        }

        //Preps the translation to save
        private void saveTranslation( string translation )
        {
            string path = null;
            
            //If there is something in txtSaveTo
            if (txtSaveTo.Text.Length > 0)
            {
                //Check to make sure it is a valid extension
                if (Regex.IsMatch(txtSaveTo.Text, @"^(.){1,}[.](\w){3,}$"))
                {
                    //If it is
                    path = txtSaveTo.Text.ToString();
                }
                else
                {
                    //If it needs an extension...
                    path = txtSaveTo.Text + "\\" + diaFileOpen.SafeFileName;
                }
            }
            //If txtSaveTo has nothing, but there is something in diaFileSave
            else if (diaFileSave.FileName != "")
            {
                //Then use diaFileSave
                path = diaFileSave.FileName;
            }
            else
            {
                //Else, try and save it from our current root.
                path = "...\\Translations\\" + diaFileOpen.SafeFileName;
            }

            //My handles may not work...
            try
            {
                HandleStore.saveTranslation(translation, txtSaveTo.Text);
            }
            catch (DirectoryNotFoundException ex)
            {
                MessageBox.Show("Error: \n" + ex.Message, "Directory Not Found");
                txtSaveTo.Focus();
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("Error: \n" + ex.Message, "Directory Not Found");
                txtSaveTo.Focus();
            }
            catch
            {
                MessageBox.Show("Not expected...", "Oops!");
            }
        }
    }
}

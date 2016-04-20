using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace TranslationProject
{
    public partial class frmTranslateMain : Form
    {
        public frmTranslateMain()
        {
            InitializeComponent();
            #region
            languages.Add("Arabic");
            languages.Add("Bulgarian");
            languages.Add("Catalan");
            languages.Add("Chinese(Simplified)");
            languages.Add("Chinese(Traditional)");
            languages.Add("Czech");
            languages.Add("Danish");
            languages.Add("Dutch");
            languages.Add("English");
            languages.Add("Estonian");
            languages.Add("Finnish");
            languages.Add("French");
            languages.Add("German");
            languages.Add("Greek");
            languages.Add("Haitian Creole");
            languages.Add("Hebrew");
            languages.Add("Hindi");
            languages.Add("Hmong Daw");
            languages.Add("Hungarian");
            languages.Add("Indonesian");
            languages.Add("Italian");
            languages.Add("Japanese");
            languages.Add("Korean");
            languages.Add("Latvian");
            languages.Add("Lithuanian");
            languages.Add("Norwegian");
            languages.Add("Persian");
            languages.Add("Farsi");
            languages.Add("Polish");
            languages.Add("Portuguese");
            languages.Add("Romanian");
            languages.Add("Russian");
            languages.Add("Slovak");
            languages.Add("Slovenian");
            languages.Add("Spanish");
            languages.Add("Swedish");
            languages.Add("Thai");
            languages.Add("Turkish");
            languages.Add("Ukrainian");
            languages.Add("Vietnamese");

            popup.FormattingEnabled = true;
            popup.Visible = false;
            popup.Click += new EventHandler(clearPopUp);
            popup.KeyDown += new KeyEventHandler(acceptSelected);
            #endregion
        }

        List<string> languages = new List<string>();
        ListBox popup = new ListBox();

        /// <summary>
        /// Begins translation from the main form.
        /// </summary>
        /// <param name="o">Reference to the calling object</param>
        /// <param name="e">Reference to the event that called the method</param>
        private void BeginTranslation(object o, EventArgs e)
        {
            //First decide if there is text to translate
            if (txtTranslateFrom.Text.Length <= 0)
            {
                //If not, then ask whether a document is what the user wishes to translate.
                if (MessageBox.Show("There appears to be no text to be translated.\n" +
                                                   "Do you wish to translate a document?", "Inquiry", MessageBoxButtons.YesNoCancel,
                                                   MessageBoxIcon.Question, MessageBoxDefaultButton.Button3) == DialogResult.Yes)
                {
                    //Generate a new instance of the document translation form
                    translateDoc = new frmTranslateDoc();
                    //Open it up and give it focus
                    translateDoc.ShowDialog();
                }
            }
            else
            {
                try
                {
                    if(!Translate.Authentication)
                    {
                        Translate.generateHeader();
                    }
                    string translation = getTranslation();

                    //If the returned translation is not null, it succeeded without error
                    if (translation != null)
                    {
                        //Set the translated text in the text control meant for it.
                        txtTranslateTo.Text = translation;
                    }
                }
                catch
                {
                    if (!String.IsNullOrEmpty(txtLangTo.Text))
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
        }

        //Ignore this code...
        #region
        /*
        private void wordSelection(object s, MouseEventArgs m)
        {
            if (txtTranslateFrom.TextLength > 0)
            {
                try
                {
                    if (txtTranslateFrom.SelectionLength == 0)
                    {
                        selectWord();
                    }
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    
                }
            }
        }

       private void beginDrag(object o, MouseEventArgs m)
        {
            if (txtTranslateFrom.Focused)
            {
                if (txtTranslateFrom.SelectionLength > 0)
                {
                    txtTranslateFrom.DoDragDrop(txtTranslateFrom.SelectedText, DragDropEffects.Copy | DragDropEffects.Move);
                    txtTranslateFrom.Cursor = Cursors.Hand;
                }
            }
            else if (txtTranslateTo.Focused)
            {
                if (txtTranslateTo.SelectionLength > 0)
                {
                    txtTranslateTo.DoDragDrop(txtTranslateTo.SelectedText, DragDropEffects.Copy | DragDropEffects.Move);
                }
            }
        }

        private void dragText(object o, DragEventArgs d)
        {
            if (d.Data.GetDataPresent(DataFormats.Text))
            {
                d.Effect = DragDropEffects.Copy;
            }
            else
            {
                d.Effect = DragDropEffects.None;
            }
        }

        private void dropText(object o, DragEventArgs d)
        {
            if (o.Equals(txtTranslateFrom))
            {
                if (d.Data.GetDataPresent(DataFormats.Text))
                {
                    txtTranslateFrom.Text = d.Data.GetData(DataFormats.Text).ToString();
                }
            }
            else if (o.Equals(txtTranslateTo))
            {
                if (d.Data.GetDataPresent(DataFormats.Text))
                {
                    txtTranslateTo.Text = d.Data.GetData(DataFormats.Text).ToString();
                }
            }
        }

        private void selectWord()
        {
            int wordBegin = 0, wordEnd = 0;

            wordBegin = findBeginningOfWord();
            wordEnd = findEndOfWord();
            try
            {
                txtTranslateFrom.Select(wordBegin, (wordEnd - wordBegin));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                txtTranslateFrom.Select(wordBegin, txtTranslateFrom.TextLength - 1);
            }
        }

        private int findBeginningOfWord()
        {
            int beginIndex = 0, index = 0;

            if (txtTranslateFrom.Focused)
            {
                beginIndex = txtTranslateFrom.SelectionStart;
                try
                {
                    while (isolateWord(beginIndex))
                    {
                        Console.Write((int)txtTranslateFrom.Text.ElementAt(beginIndex));
                        beginIndex--;
                    }
                }
                catch(ArgumentOutOfRangeException ex)
                {
                    beginIndex = -1;
                }
            }
            else if (txtTranslateTo.Focused)
            {
                beginIndex = txtTranslateTo.SelectionStart;
                try
                {
                    while (isolateWord(beginIndex))
                    {
                        beginIndex--;
                    }
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    beginIndex = -1;
                }
            }

            index = beginIndex + 1;

            return index;
        }

        private int findEndOfWord()
        {
            int beginIndex = 0, index = 0;

            if (txtTranslateFrom.Focused)
            {
                beginIndex = txtTranslateFrom.SelectionStart;
                try
                {
                    while (isolateWord(beginIndex))
                    {
                        beginIndex++;
                    }
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    beginIndex = txtTranslateFrom.TextLength;
                }
            }
            else if (txtTranslateTo.Focused)
            {
                beginIndex = txtTranslateTo.SelectionStart;
                try
                {
                    while (isolateWord(beginIndex))
                    {
                        beginIndex++;
                    }
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    beginIndex = txtTranslateTo.TextLength;
                }
            }

            index = beginIndex;

            return index;
        }

        private bool isolateWord( int index)
        {
            bool isolated = false;

            try
            {
                if (txtTranslateFrom.Focused)
                {
                    if (!Char.IsSeparator(txtTranslateFrom.Text, index) &&
                        !Char.IsWhiteSpace(txtTranslateFrom.Text, index) &&
                        !Char.IsPunctuation(txtTranslateFrom.Text, index) &&
                        txtTranslateFrom.Text.ElementAt(index) != '\0' &&
                        txtTranslateFrom.Text.ElementAt(index) != 32)
                    {
                        isolated = true;
                    }
                }
                else if (txtTranslateTo.Focused)
                {
                    if (!Char.IsSeparator(txtTranslateTo.Text, index) &&
                        !Char.IsWhiteSpace(txtTranslateTo.Text, index) &&
                        !Char.IsPunctuation(txtTranslateTo.Text, index) &&
                        txtTranslateTo.Text.ElementAt(index) != '\0' &&
                        txtTranslateTo.Text.ElementAt(index) != 32)
                    {
                        isolated = true;
                    }
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                //Nothing
            }

            return isolated;
        }
         */
        #endregion
        //End-Ignore

        //Attempt to keep things semi-consistent in size...
        private void changeFormSize(object o, EventArgs e)
        {
            decimal txtHeightAspectRatio = .347m;
            decimal txtWidthAspectRatio = .845m;

            txtTranslateFrom.Height = Convert.ToInt32(this.Height * txtHeightAspectRatio);
            txtTranslateFrom.Width = Convert.ToInt32(this.Width * txtWidthAspectRatio);
            txtTranslateTo.Height = Convert.ToInt32(this.Height * txtHeightAspectRatio);
            txtTranslateTo.Width = Convert.ToInt32(this.Width * txtWidthAspectRatio);
        }

        /// <summary>
        /// Boots the form
        /// </summary>
        private void appStartup(object sender, EventArgs e)
        {
            splshLoading = new splshLoad();
            splshLoading.Show();
            
           decimal txtHeightAspectRatio = .347m;
            decimal txtWidthAspectRatio = .845m;

            this.Height = 550;
            this.Width = 415;
            this.MaximumSize = new System.Drawing.Size(420, 540);
            this.MinimumSize = new System.Drawing.Size(100, 100);

            txtTranslateFrom.Height = Convert.ToInt32(this.Height * txtHeightAspectRatio);
            txtTranslateFrom.Width = Convert.ToInt32(this.Width * txtWidthAspectRatio);
            txtTranslateTo.Height = Convert.ToInt32(this.Height * txtHeightAspectRatio);
            txtTranslateTo.Width = Convert.ToInt32(this.Width * txtWidthAspectRatio);
        }
        
        //Launches an About screen
        private void mnuAbout_Click(object sender, EventArgs e)
        {
            aboutBabble = new abtProjectBabble();
            aboutBabble.Show();
        }

        /// <summary>
        /// "Pops" out the two text boxes, Not implemented
        /// </summary>
        private void popTranslateForm(object o, EventArgs e)
        {

        }

        private string getTranslation()
        {
            string translation = "";
            string translateTo = Translate.getLanguageCode(txtLangTo.Text);
            string translateFrom = Translate.getLanguageCode(txtLangFrom.Text);

            Translate.generateHeader();
            translation = Translate.translateText(txtTranslateFrom.Text, translateFrom, translateTo);


            return translation;
        }

        /// <summary>
        /// Handles the user choosing the option to translate a document
        /// </summary>
        private void translateDocument(object sender, EventArgs e)
        {
            translateDoc = new frmTranslateDoc();
            translateDoc.ShowDialog();
        }
        
        /// <summary>
        /// Speech synthesizer, possibly.
        /// Officially unsupported.
        /// </summary>
        private void Text2Speech(object o, EventArgs e)
        {
            //Console.WriteLine("This will one day be a speech synthethsizer");
        }

        /// <summary>
        /// Swaps the languages currently selected
        /// </summary>
        private void swapLanguages(object o, EventArgs e)
        {
            //If the base option isn't selected
            if (!String.IsNullOrEmpty(txtLangFrom.Text) && !String.IsNullOrEmpty(txtLangTo.Text))
            {
                //Swap space
                string temp = txtLangFrom.Text;
                //Swap places
                txtLangFrom.Text = txtLangTo.Text;
                txtLangTo.Text = temp;
            }
        }

        /// <summary>
        /// Handles swapping of the text selected, for whatever purpose we may want to do that...
        /// </summary>
        private void swapText(object o, EventArgs e)
        {
            if (txtTranslateFrom.TextLength > 0 && txtTranslateTo.TextLength > 0)
            {
                //Set up swap space
                string text = txtTranslateFrom.Text;

                //Swap places
                txtTranslateFrom.Text = txtTranslateTo.Text;
                txtTranslateTo.Text = text;
            }
        }

        //Handles user changing the font style and color of text.
        private void changeFontAndColor(object o, EventArgs e)
        {
            diaFont.ShowColor = true;
            //If a specific textbox is currently selected, only apply changes to that textbox
            if (txtTranslateFrom.Focused)
            {
                //If the user makes a selection, and accepts it:
                if (diaFont.ShowDialog() == DialogResult.OK)
                {
                    //Set changes
                    txtTranslateFrom.Font = diaFont.Font;
                    txtTranslateFrom.ForeColor = diaFont.Color;
                }
            }
            //Same thing, but with different textbox
            else if (txtTranslateTo.Focused)
            {
                if (diaFont.ShowDialog() == DialogResult.OK)
                {
                    txtTranslateTo.Font = diaFont.Font;
                    txtTranslateTo.ForeColor = diaFont.Color;
                }
            }
            //If no textbox is currently selected...
            else
            {
                //Just apply the changes accepted to both textboxes.
                if (diaFont.ShowDialog() == DialogResult.OK)
                {
                    txtTranslateTo.Font = diaFont.Font;
                    txtTranslateTo.ForeColor = diaFont.Color;
                    txtTranslateFrom.Font = diaFont.Font;
                    txtTranslateFrom.ForeColor = diaFont.Color;
                }
            }

            //Reset the showColor option to false, just to be evil.
            diaFont.ShowColor = false;
        }

        //If the user specifically selects the option to change font, alone
        private void ChangeFont(object sender, EventArgs e)
        {
            //Same as for fontAndColor, but with only font...
            diaFont.ShowColor = false;
            if (txtTranslateFrom.Focused)
            {
                if (diaFont.ShowDialog() == DialogResult.OK)
                {
                    txtTranslateFrom.Font = diaFont.Font;
                }
            }
            else if (txtTranslateTo.Focused)
            {
                if (diaFont.ShowDialog() == DialogResult.OK)
                {
                    txtTranslateTo.Font = diaFont.Font;
                }
            }
            else
            {
                if (diaFont.ShowDialog() == DialogResult.OK)
                {
                    txtTranslateTo.Font = diaFont.Font;
                    txtTranslateFrom.Font = diaFont.Font;
                }
            }
        }

        //If the user specifically selects to change the color of text...
        private void changeColor(object o, EventArgs e)
        {

            //Same thing as for changeFont, but only with color...
            if (txtTranslateFrom.Focused)
            {
                if (diaColor.ShowDialog() == DialogResult.OK)
                {
                    txtTranslateFrom.ForeColor = diaColor.Color;
                }
            }
            else if (txtTranslateTo.Focused)
            {
                if (diaColor.ShowDialog() == DialogResult.OK)
                {
                    txtTranslateTo.ForeColor = diaColor.Color;
                }
            }
            else
            {
                if (diaColor.ShowDialog() == DialogResult.OK)
                {
                    txtTranslateTo.ForeColor = diaColor.Color;
                    txtTranslateFrom.ForeColor = diaColor.Color;
                }
            }
        }

        //f the user selects the option to quit...
        private void mnuExit_Click(object o, EventArgs e)
        {
            //Ask whether the user wishes to save data, if there is any...
            appClosing(o, e);
            //Close
            this.Close();
        }

        //If the user elects to create a "new" translation...
        private void mnuFileNew_Click(object sender, EventArgs e)
        {
            //If there is a current translation, ask the user if they wish to save their translation
            if (txtTranslateTo.TextLength > 0)
            {
                if (MessageBox.Show("There appears to be a translation, do you wish to save?", "Save Translation",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    //If they agree to save, handle the saving
                    if (diaFileSave.ShowDialog() == DialogResult.OK)
                    {
                        HandleStore.saveTranslation("Translated Text:\n" +"Language:" + 
                                                                         Translate.getLanguageCode(txtLangTo.Text) + "\n" + 
                                                                          txtTranslateTo.Text + "\n",
                                                                         diaFileSave.FileName);
                    }
                }
            }
            //Reset the textboxes
            txtTranslateTo.ResetText();
            txtTranslateFrom.ResetText();
        }

        //If they wish to open a specific translation...
        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            //If there is a current translation, see if they want to save the translation.
            if (txtTranslateTo.TextLength > 0)
            {
                DialogResult toSave = MessageBox.Show("There appears to be a translation, do you wish to save?", "Save Translation",
                                                                                       MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question,
                                                                                       MessageBoxDefaultButton.Button1);
                if (toSave == DialogResult.Yes)
                {
                    if (diaFileSave.ShowDialog() == DialogResult.OK)
                    {
                        HandleStore.saveTranslation("Translated Text:\n" +"Language:" + Translate.getLanguageCode(txtLangTo.Text) + "\n" + txtTranslateTo.Text + "\n",
                                                 diaFileSave.FileName);
                    }
                }
            }
            //After possibly saving, ask the user to direct to a file
            if (diaFileOpen.ShowDialog() == DialogResult.OK)
            {
                bool translated = false;
                StringBuilder original = new StringBuilder();
                StringBuilder translation = new StringBuilder();
                //If we have a path to a file to open...
                if (diaFileOpen.FileName != null)
                {
                    //Will hold the individual paragraphs from our text document
                    string[] array = null;
                    //Populate our array
                    array = HandleStore.openFile(diaFileOpen.FileName).Split(new char[] { '\n' });
                    //If there was text to translate...
                    if (array != null)
                    {
                        //Cycle through all the elements of the array (hopefully, at least one...)
                        foreach (string s in array)
                        {
                            //If the string is the header "Translated Text:", we are currently reading from translated text
                            if (Regex.IsMatch(s, @"Translated Text:"))
                            {
                                translated = true;
                            }
                            //If the string is the header "Original Text:" we are currently reading from an original series of text
                            else if (Regex.IsMatch(s, @"Original Text:"))
                            {
                                translated = false;
                            }
                            //With the proper headers decoded,
                            else
                            {
                                //If we are currently under the Translated Text: header, then append it to the txtTranslateTo destination
                                if (translated)
                                {
                                    if (!Regex.IsMatch(s, @"Language:"))
                                    {
                                        translation.Append(s + '\n');
                                    }
                                    else
                                    {
                                        foreach (Match m in Regex.Matches(s, @"^Language:(\w{2,4})"))
                                        {
                                            foreach (Group g in m.Groups)
                                            {
                                                if (!g.Value.Contains("Language"))
                                                {
                                                    txtLangTo.Text = Translate.getLanguageWhole(g.Value.ToString());
                                                }
                                            }
                                        }
                                    }
                                }
                                //If we are currently under the Original Text: header, then append it to the txtTranslateFrom destination
                               else
                               {
                                    if (!Regex.IsMatch(s, @"Language:"))
                                    {
                                        original.Append(s + '\n');
                                    }
                                    else
                                    {
                                        foreach (Match m in Regex.Matches(s, @"^Language:(\w{2,4})"))
                                        {
                                            foreach (Group g in m.Groups)
                                            {
                                                if (!g.Value.Contains("Language"))
                                                {
                                                    txtLangFrom.Text = Translate.getLanguageWhole(g.Value.ToString());
                                                }
                                            }
                                        }
                                    }
                               }
                            }
                        }
                        //Set the StringBuilder to its appropriate text box
                        txtTranslateFrom.Text = original.ToString();
                        txtTranslateTo.Text = translation.ToString();

                    }
                }
            }
        }
        
        //Contains whether the current text is saved
        bool fileSaved = true;
        //If there is a need to save, save
        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            DialogResult response = new DialogResult();
            if (!fileSaved || string.IsNullOrEmpty(diaFileSave.FileName))
            {
                response = diaFileSave.ShowDialog();
            }

            if (response == DialogResult.OK)
            {
                HandleStore.saveTranslation("Original Text:\n" + "Language:" + Translate.getLanguageCode(txtLangFrom.Text) + "\n" + txtTranslateFrom.Text + 
                                                               "\nTranslated Text:\n" + "Language:" + Translate.getLanguageCode(txtLangTo.Text) + "\n" + txtTranslateTo.Text + "\n",
                                          diaFileSave.FileName);
                fileSaved = true;
            }
        }

        //If the user selects to save only the translation, save the translation portion of text, if it's not already saved
        private void mnuFileSaveTranslation_Click(object sender, EventArgs e)
        {
            DialogResult response = new DialogResult();

            if (!fileSaved || string.IsNullOrEmpty(diaFileSave.FileName))
            {
                response = diaFileSave.ShowDialog();
            }

            if (response == DialogResult.OK)
            {
                HandleStore.saveTranslation("Translated Text:\n" + "Language:" + Translate.getLanguageCode(txtLangTo.Text)+ txtTranslateTo.Text + "\n",
                                         diaFileSave.FileName);
                fileSaved = true;
            }
        }

        //If the user selects to save the current text somewhere, open the dialog by default
        private void mnuFileSaveAs_Click(object sender, EventArgs e)
        {
            if (diaFileSave.ShowDialog() == DialogResult.OK)
            {
                HandleStore.saveTranslation("Original Text:\n" + "Language:" + Translate.getLanguageCode(txtLangFrom.Text) + "\n" + txtTranslateFrom.Text +
                                                               "\nTranslated Text:\n" + "Language:" + Translate.getLanguageCode(txtLangTo.Text) + "\n" + txtTranslateTo.Text + "\n",
                                                               diaFileSave.FileName);
                fileSaved = true;
            }
                                     
        }

        //If the user asks to "Close" a translation, just reset the text...
        private void mnuFileClose_Click(object sender, EventArgs e)
        {
            if (txtTranslateTo.TextLength > 0 && !fileSaved)
            {
                if (MessageBox.Show("There appears to be a translation, do you wish to save?", "Save Translation",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    if (diaFileSave.ShowDialog() == DialogResult.OK)
                    {
                        HandleStore.saveTranslation("Translated Text:\n" +"Language:" + 
                                                                         Translate.getLanguageCode(txtLangTo.Text) + 
                                                                        "\n"+ txtTranslateTo.Text + "\n",
                                                                         diaFileSave.FileName);
                    }
                }
                txtTranslateTo.ResetText();
                txtTranslateFrom.ResetText();
            }
        }

        //Controls setting text into the ClipBoard
        private void mnuEditCopy_Click(object sender, EventArgs e)
        {
            if (txtTranslateTo.SelectionLength > 0 || txtTranslateFrom.SelectionLength > 0)
            {
                if (txtTranslateFrom.Focused)
                {
                    Clipboard.SetText(txtTranslateFrom.SelectedText, TextDataFormat.Text);
                    mnuEditPaste.Enabled = true;
                }
                else if (txtTranslateTo.Focused)
                {
                    Clipboard.SetText(txtTranslateTo.SelectedText, TextDataFormat.Text);
                    mnuEditPaste.Enabled = true;
                }
            }
        }

        //Removes text from the string, and places it into the ClipBoard
        private void mnuEditCut_Click(object sender, EventArgs e)
        {
            if (txtTranslateTo.SelectionLength > 0 || txtTranslateFrom.SelectionLength > 0)
            {
                if (txtTranslateFrom.Focused)
                {
                    Clipboard.SetText(txtTranslateFrom.SelectedText, TextDataFormat.Text);
                    txtTranslateFrom.Text = txtTranslateFrom.Text.Remove(txtTranslateFrom.SelectionStart, txtTranslateFrom.SelectionLength);
                    mnuEditPaste.Enabled = true;
                }
                else if (txtTranslateTo.Focused)
                {
                    Clipboard.SetText(txtTranslateTo.SelectedText, TextDataFormat.Text);
                    txtTranslateTo.Text = txtTranslateTo.Text.Remove(txtTranslateTo.SelectionStart, txtTranslateTo.SelectionLength);
                    mnuEditPaste.Enabled = true;
                }
            }
        }

        //Takes text from the ClipBoard and places it into the textbox at the appropriate index
        private void mnuEditPaste_Click(object sender, EventArgs e)
        {
            int selection;
            if (txtTranslateFrom.Focused)
            {
                selection = txtTranslateFrom.SelectionStart;
                txtTranslateFrom.Text = txtTranslateFrom.Text.Insert(txtTranslateFrom.SelectionStart, Clipboard.GetText());
                txtTranslateFrom.SelectionStart = selection;
            }
            else if (txtTranslateTo.Focused)
            {
                selection = txtTranslateTo.SelectionStart;
                txtTranslateTo.Text = txtTranslateTo.Text.Insert(txtTranslateTo.SelectionStart, Clipboard.GetText());
                txtTranslateTo.SelectionStart = selection;

            }
        }
        //Limited set of undo options.
        private void mnuEditUndo_Click(object sender, EventArgs e)
        {
            if (txtTranslateFrom.Focused)
            {
                txtTranslateFrom.Undo();
            }
            else if (txtTranslateTo.Focused)
            {
                txtTranslateTo.Undo();
            }
        }

        //Selects all text in the selected textbox
        private void mnuEditSelectAll_Click(object sender, EventArgs e)
        {
            if (txtTranslateFrom.Focused)
            {
                txtTranslateFrom.SelectAll();
            }
            else if (txtTranslateTo.Focused)
            {
                txtTranslateTo.SelectAll();
            }
        }

        //Operates as the "delete key", but within the program
        private void mnuEditDelete_Click(object sender, EventArgs e)
        {
            int selection;
            if (txtTranslateFrom.Focused)
            {
                selection = txtTranslateFrom.SelectionStart;
                if (txtTranslateFrom.SelectionLength > 0)
                {
                    txtTranslateFrom.Text = txtTranslateFrom.Text.Remove(txtTranslateFrom.SelectionStart, txtTranslateFrom.SelectionLength);
                }
                else
                {
                    txtTranslateFrom.Text = txtTranslateFrom.Text.Remove(txtTranslateFrom.SelectionStart, 1);
                }
                txtTranslateFrom.SelectionStart = selection;
            }
            else if (txtTranslateTo.Focused)
            {
                selection = txtTranslateTo.SelectionStart;
                if (txtTranslateTo.SelectionLength > 0)
                {
                    txtTranslateTo.Text.Remove(txtTranslateTo.SelectionStart, txtTranslateTo.SelectionLength);
                }
                else
                {
                    txtTranslateTo.Text = txtTranslateTo.Text.Remove(txtTranslateTo.SelectionStart, 1);
                }
                txtTranslateTo.SelectionStart = selection;
            }
        }

        //Handles the "auto-load" feature of the program
        bool takeData = false;
        private void getClipText(object sender, EventArgs e)
        {
            //If the user wants to allow auto-uptake (currently always disabled...)
            if (takeData)
            {
                //Go into the clipboard, and make sure it is of an appropriate type of data
                if (Clipboard.ContainsText(TextDataFormat.Text) || Clipboard.ContainsText(TextDataFormat.Rtf))
                {
                    //If the current length of the text is greater than zero, don't because it may erase data...
                    if (txtTranslateFrom.TextLength == 0)
                    {
                        txtTranslateFrom.Text = Clipboard.GetText();
                    }
                }
            }
        }

        //Handles the when the application is closing
        private void appClosing(object o, EventArgs e)
        {
            //If the file is not saved, and there is text in either of the textboxes...
            if (!fileSaved && (txtTranslateFrom.TextLength > 0 || txtTranslateTo.TextLength > 0))
            {
                //Ask if they wish to save
                DialogResult close = MessageBox.Show("There appears to be a translation, do you wish to save?", "Save Translation",
                                     MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                //If they do...
                if (close == DialogResult.Yes)
                {
                    //Save the file
                    if (diaFileSave.ShowDialog() == DialogResult.OK)
                    {
                        HandleStore.saveTranslation("Translated Text:\n" + "Language:" + 
                                                                          Translate.getLanguageCode(txtLangTo.Text)+ 
                                                                        "\n" + txtTranslateTo.Text + "\n",
                                                                        diaFileSave.FileName);
                    }
                }
            }
        }

        private void textChanged(object sender, EventArgs e)
        {
            fileSaved = false;
        }

        //Since I changed the "list" to only have "language" matches for what the user types in, have the list ready at hand...
        private void languagesSupportedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Arabic                     \t" + "Italian                \t" + "Indonesian\n" +
                                            "Bulgarian                \t" + "Japanese\n" +
                                            "Catalan                   \t" + "Korean\n" +
                                            "Chinese(Simplified)\t" + "Latvian\n" +
                                            "Chinese(Traditional)\t" + "Lithuanian\n" +
                                            "Czech                      \t" + "Norwegian\n" +
                                            "Danish                     \t" + "Persian(Farsi)\n" +
                                            "Dutch                       \t" + "Polish\n" +
                                            "English                     \t" + "Portuguese\n" +
                                            "Estonian                   \t" + "Romanian\n" +
                                            "Finnish                      \t" + "Russian\n" +
                                            "French                      \t" + "Slovak\n" +
                                            "German                    \t" + "Slovenian\n" +
                                            "Greek                        \t" + "Spanish\n" +
                                            "Haitian Creole           \t" + "Swedish\n" +
                                            "Hebrew                     \t" + "Thai\n" +
                                            "Hindi                         \t" + "Turkish\n" +
                                            "Hmong Daw             \t" + "Ukrainian\n" +
                                            "Hungarian                 \t" + "Vietnamese\n", "Support",
                                            MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        //The below code handles the function of our "make-shift" combolist since I didn't like how they worked.
        
        /// <summary>
        /// Creates the list used by the ListBox portion of our combobox
        /// </summary>
        /// <param name="txtInput">Gives direct access to the textbox that raises the event</param>
        /// <returns>A List (of string variables) that holds the languages which may be what the user wants</returns>
        private List<string> createList(TextBox txtInput)
        {
            List<string> temp = new List<string>();
            temp.Clear();
            if (txtInput.TextLength > 0)
            {
                foreach (string language in languages)
                {
                    if (language.ToLower().Contains(txtInput.Text.ToLower()) && !temp.Contains(language))
                    {
                        temp.Add(language);
                    }
                }
            }
            return temp;
        }

        /// <summary>
        /// Occurs when the text inside our textboxes changes
        /// </summary>
        /// <param name="o">A reference to the calling textbox</param>
        /// <param name="e">The event information</param>
        private void setList(object o, EventArgs e)
        {
            createBox((o as TextBox));
            currText = (o as TextBox);
        }

        /// <summary>
        /// Sets up the list and readies it to be displayed/added to the form
        /// </summary>
        /// <param name="txtInput">Reference to the calling textbox</param>
        private void createBox(TextBox txtInput)
        {
            popup.Location = new Point(txtInput.Location.X,
                                                          txtInput.Location.Y + txtInput.Size.Height + 2);
            popup.Items.Clear();
            foreach (string s in createList(txtInput))
            {
                popup.Items.Add(s);
            }
            sizeList(popup, txtInput);
            popup.Visible = true;
            if (popup.Items.Count > 0)
            {
                this.Controls.Add(popup);
                popup.BringToFront();
                popup.Focus();
            }
            else
            {
                this.Controls.Remove(popup);
                popup.BringToFront();
            }
        }

        /// <summary>
        /// Sets the size of our listbox so that it is only a certain size
        /// If there are less than 5 elements in our list, set its size depending on that number (~13/element)
        /// If there are greater, limit showing to 5 elements
        /// </summary>
        /// <param name="list">The list which will be the basis for the size</param>
        /// <param name="txtInput">Direct reference to the calling textbox, 
        /// so that the listbox can have its width based on the textbox</param>
        private void sizeList(ListBox list, TextBox txtInput)
        {
            int y = 0;
            int count = list.Items.Count <= 5 ? list.Items.Count : 5;

            for (int x = 0; x <= count; x++)
            {
                y += 13;
            }

            list.Size = new Size(txtInput.Size.Width, y);
        }

        //I wanted to avoid this, but the "clearPopUp" and "acceptSelected" methods
        //are called by popup, so o is a reference to the listbox.
        //In order to keep a reference for them, we need an external reference
        TextBox currText;

        //Clears the popup once a selection has been made
        private void clearPopUp(object o, EventArgs e)
        {
            currText.Text = popup.SelectedItem.ToString();
            this.Controls.Remove(popup);
            //Because a selection has been made, null out the currText to make sure that bugs are limited
            currText = null;
        }

        //If the user, while the textbox is focused, clicks the down/up arrows, move the selectedIndex for the listbox
        private void determine(object sender, KeyEventArgs e)
        {
            if (popup.Items.Count > 0)
            {
                switch (e.KeyValue)
                {
                    case 40:
                        if (popup.SelectedIndex < popup.Items.Count - 1)
                        {
                            if (popup.SelectedIndex == -1)
                            {
                                popup.SelectedIndex = 1;
                            }
                            else
                            {
                                popup.SelectedIndex++;
                            }
                        }
                        break;
                    case 38:
                        if (popup.SelectedIndex > 0)
                        {
                            popup.SelectedIndex--;
                        }
                        break;
                    case 13:
                        currText.Text = popup.SelectedItem.ToString();
                        this.Controls.Remove(popup);
                        break;
                    default:
                        Console.WriteLine(e.KeyValue);
                        break;
                }

                (sender as TextBox).Focus();
            }
        }

        //If, while the listbox is selected, the user pressed "Enter", enter the selected value into the textbox
        //Normally does nothing
        private void acceptSelected(object o, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                currText.Text = popup.SelectedItem.ToString();
                this.Controls.Remove(popup);
                currText = null;
            }
        }
    }
}

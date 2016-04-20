namespace TranslationProject
{
    partial class frmTranslateMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private frmTranslateDoc translateDoc;
        private abtProjectBabble aboutBabble;
        private splshLoad splshLoading;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTranslateMain));
            this.txtTranslateFrom = new System.Windows.Forms.TextBox();
            this.mnuTranslateMain = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSaveDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSaveTranslation = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileClose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuEditCut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuEditDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView = new System.Windows.Forms.ToolStripMenuItem();
            this.textFontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTranslate = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTranslateRun = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTranslateDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.txtTranslateTo = new System.Windows.Forms.TextBox();
            this.btnTranslate = new System.Windows.Forms.Button();
            this.diaFileOpen = new System.Windows.Forms.OpenFileDialog();
            this.diaFileSave = new System.Windows.Forms.SaveFileDialog();
            this.diaFont = new System.Windows.Forms.FontDialog();
            this.diaColor = new System.Windows.Forms.ColorDialog();
            this.btnTranslateFrom = new System.Windows.Forms.Button();
            this.btnTranslateTo = new System.Windows.Forms.Button();
            this.btnSwapLang = new System.Windows.Forms.Button();
            this.btnSwapText = new System.Windows.Forms.Button();
            this.btnTxt2Speech = new System.Windows.Forms.Button();
            this.languagesSupportedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtLangFrom = new System.Windows.Forms.TextBox();
            this.txtLangTo = new System.Windows.Forms.TextBox();
            this.mnuTranslateMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTranslateFrom
            // 
            this.txtTranslateFrom.AllowDrop = true;
            this.txtTranslateFrom.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTranslateFrom.Location = new System.Drawing.Point(12, 75);
            this.txtTranslateFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTranslateFrom.Multiline = true;
            this.txtTranslateFrom.Name = "txtTranslateFrom";
            this.txtTranslateFrom.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTranslateFrom.Size = new System.Drawing.Size(355, 188);
            this.txtTranslateFrom.TabIndex = 0;
            this.txtTranslateFrom.TextChanged += new System.EventHandler(this.textChanged);
            // 
            // mnuTranslateMain
            // 
            this.mnuTranslateMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.mnuTranslateMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuEdit,
            this.mnuView,
            this.mnuTranslate,
            this.mnuHelp,
            this.mnuAbout});
            this.mnuTranslateMain.Location = new System.Drawing.Point(0, 0);
            this.mnuTranslateMain.Name = "mnuTranslateMain";
            this.mnuTranslateMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuTranslateMain.Size = new System.Drawing.Size(404, 24);
            this.mnuTranslateMain.TabIndex = 4;
            this.mnuTranslateMain.Text = "Translate Menu Strip";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileNew,
            this.mnuFileOpen,
            this.mnuFileSave,
            this.mnuFileClose,
            this.toolStripSeparator2,
            this.mnuExit});
            this.mnuFile.Image = ((System.Drawing.Image)(resources.GetObject("mnuFile.Image")));
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(53, 20);
            this.mnuFile.Text = "File";
            // 
            // mnuFileNew
            // 
            this.mnuFileNew.Name = "mnuFileNew";
            this.mnuFileNew.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.N)));
            this.mnuFileNew.Size = new System.Drawing.Size(187, 22);
            this.mnuFileNew.Text = "New";
            this.mnuFileNew.Click += new System.EventHandler(this.mnuFileNew_Click);
            // 
            // mnuFileOpen
            // 
            this.mnuFileOpen.Name = "mnuFileOpen";
            this.mnuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.O)));
            this.mnuFileOpen.Size = new System.Drawing.Size(187, 22);
            this.mnuFileOpen.Text = "Open...";
            this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // mnuFileSave
            // 
            this.mnuFileSave.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileSaveDoc,
            this.mnuFileSaveTranslation,
            this.mnuFileSaveAs});
            this.mnuFileSave.Name = "mnuFileSave";
            this.mnuFileSave.Size = new System.Drawing.Size(187, 22);
            this.mnuFileSave.Text = "Save";
            // 
            // mnuFileSaveDoc
            // 
            this.mnuFileSaveDoc.Name = "mnuFileSaveDoc";
            this.mnuFileSaveDoc.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuFileSaveDoc.Size = new System.Drawing.Size(242, 22);
            this.mnuFileSaveDoc.Text = "Save...";
            this.mnuFileSaveDoc.Click += new System.EventHandler(this.mnuFileSave_Click);
            // 
            // mnuFileSaveTranslation
            // 
            this.mnuFileSaveTranslation.Name = "mnuFileSaveTranslation";
            this.mnuFileSaveTranslation.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.T)));
            this.mnuFileSaveTranslation.Size = new System.Drawing.Size(242, 22);
            this.mnuFileSaveTranslation.Text = "Save Translation...";
            this.mnuFileSaveTranslation.Click += new System.EventHandler(this.mnuFileSaveTranslation_Click);
            // 
            // mnuFileSaveAs
            // 
            this.mnuFileSaveAs.Name = "mnuFileSaveAs";
            this.mnuFileSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.A)));
            this.mnuFileSaveAs.Size = new System.Drawing.Size(242, 22);
            this.mnuFileSaveAs.Text = "Save As...";
            this.mnuFileSaveAs.Click += new System.EventHandler(this.mnuFileSaveAs_Click);
            // 
            // mnuFileClose
            // 
            this.mnuFileClose.Name = "mnuFileClose";
            this.mnuFileClose.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.C)));
            this.mnuFileClose.Size = new System.Drawing.Size(187, 22);
            this.mnuFileClose.Text = "Close";
            this.mnuFileClose.Click += new System.EventHandler(this.mnuFileClose_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(184, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.mnuExit.Size = new System.Drawing.Size(187, 22);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.appClosing);
            // 
            // mnuEdit
            // 
            this.mnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEditUndo,
            this.toolStripSeparator1,
            this.mnuEditCut,
            this.mnuEditCopy,
            this.mnuEditPaste,
            this.toolStripMenuItem1,
            this.mnuEditDelete,
            this.mnuEditSelectAll});
            this.mnuEdit.Image = ((System.Drawing.Image)(resources.GetObject("mnuEdit.Image")));
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(55, 20);
            this.mnuEdit.Text = "Edit";
            // 
            // mnuEditUndo
            // 
            this.mnuEditUndo.Name = "mnuEditUndo";
            this.mnuEditUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.mnuEditUndo.Size = new System.Drawing.Size(164, 22);
            this.mnuEditUndo.Text = "Undo";
            this.mnuEditUndo.Click += new System.EventHandler(this.mnuEditUndo_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(161, 6);
            // 
            // mnuEditCut
            // 
            this.mnuEditCut.Name = "mnuEditCut";
            this.mnuEditCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.mnuEditCut.Size = new System.Drawing.Size(164, 22);
            this.mnuEditCut.Text = "Cut";
            this.mnuEditCut.Click += new System.EventHandler(this.mnuEditCut_Click);
            // 
            // mnuEditCopy
            // 
            this.mnuEditCopy.Name = "mnuEditCopy";
            this.mnuEditCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mnuEditCopy.Size = new System.Drawing.Size(164, 22);
            this.mnuEditCopy.Text = "Copy";
            this.mnuEditCopy.Click += new System.EventHandler(this.mnuEditCopy_Click);
            // 
            // mnuEditPaste
            // 
            this.mnuEditPaste.Enabled = false;
            this.mnuEditPaste.Name = "mnuEditPaste";
            this.mnuEditPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.mnuEditPaste.Size = new System.Drawing.Size(164, 22);
            this.mnuEditPaste.Text = "Paste";
            this.mnuEditPaste.Click += new System.EventHandler(this.mnuEditPaste_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(161, 6);
            // 
            // mnuEditDelete
            // 
            this.mnuEditDelete.Name = "mnuEditDelete";
            this.mnuEditDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.mnuEditDelete.Size = new System.Drawing.Size(164, 22);
            this.mnuEditDelete.Text = "Delete";
            this.mnuEditDelete.Click += new System.EventHandler(this.mnuEditDelete_Click);
            // 
            // mnuEditSelectAll
            // 
            this.mnuEditSelectAll.Name = "mnuEditSelectAll";
            this.mnuEditSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.mnuEditSelectAll.Size = new System.Drawing.Size(164, 22);
            this.mnuEditSelectAll.Text = "Select All";
            this.mnuEditSelectAll.Click += new System.EventHandler(this.mnuEditSelectAll_Click);
            // 
            // mnuView
            // 
            this.mnuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textFontToolStripMenuItem,
            this.textColorToolStripMenuItem,
            this.fontColorToolStripMenuItem});
            this.mnuView.Image = ((System.Drawing.Image)(resources.GetObject("mnuView.Image")));
            this.mnuView.Name = "mnuView";
            this.mnuView.Size = new System.Drawing.Size(60, 20);
            this.mnuView.Text = "View";
            // 
            // textFontToolStripMenuItem
            // 
            this.textFontToolStripMenuItem.Name = "textFontToolStripMenuItem";
            this.textFontToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.textFontToolStripMenuItem.Text = "Text Font";
            this.textFontToolStripMenuItem.Click += new System.EventHandler(this.ChangeFont);
            // 
            // textColorToolStripMenuItem
            // 
            this.textColorToolStripMenuItem.Name = "textColorToolStripMenuItem";
            this.textColorToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.textColorToolStripMenuItem.Text = "Text Color";
            this.textColorToolStripMenuItem.Click += new System.EventHandler(this.changeColor);
            // 
            // fontColorToolStripMenuItem
            // 
            this.fontColorToolStripMenuItem.Name = "fontColorToolStripMenuItem";
            this.fontColorToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.fontColorToolStripMenuItem.Text = "Font/Color";
            this.fontColorToolStripMenuItem.Click += new System.EventHandler(this.changeFontAndColor);
            // 
            // mnuTranslate
            // 
            this.mnuTranslate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTranslateRun,
            this.mnuTranslateDoc});
            this.mnuTranslate.Name = "mnuTranslate";
            this.mnuTranslate.Size = new System.Drawing.Size(67, 20);
            this.mnuTranslate.Text = "Translate";
            // 
            // mnuTranslateRun
            // 
            this.mnuTranslateRun.Name = "mnuTranslateRun";
            this.mnuTranslateRun.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.mnuTranslateRun.Size = new System.Drawing.Size(223, 22);
            this.mnuTranslateRun.Text = "Run Translation";
            this.mnuTranslateRun.Click += new System.EventHandler(this.BeginTranslation);
            // 
            // mnuTranslateDoc
            // 
            this.mnuTranslateDoc.Name = "mnuTranslateDoc";
            this.mnuTranslateDoc.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.mnuTranslateDoc.Size = new System.Drawing.Size(223, 22);
            this.mnuTranslateDoc.Text = "Translate Document";
            this.mnuTranslateDoc.Click += new System.EventHandler(this.translateDocument);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languagesSupportedToolStripMenuItem});
            this.mnuHelp.Image = ((System.Drawing.Image)(resources.GetObject("mnuHelp.Image")));
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(60, 20);
            this.mnuHelp.Text = "Help";
            // 
            // mnuAbout
            // 
            this.mnuAbout.Image = ((System.Drawing.Image)(resources.GetObject("mnuAbout.Image")));
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(68, 20);
            this.mnuAbout.Text = "About";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // txtTranslateTo
            // 
            this.txtTranslateTo.AllowDrop = true;
            this.txtTranslateTo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTranslateTo.Location = new System.Drawing.Point(12, 302);
            this.txtTranslateTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTranslateTo.Multiline = true;
            this.txtTranslateTo.Name = "txtTranslateTo";
            this.txtTranslateTo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTranslateTo.Size = new System.Drawing.Size(355, 188);
            this.txtTranslateTo.TabIndex = 7;
            this.txtTranslateTo.TextChanged += new System.EventHandler(this.textChanged);
            // 
            // btnTranslate
            // 
            this.btnTranslate.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTranslate.Location = new System.Drawing.Point(271, 41);
            this.btnTranslate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTranslate.Name = "btnTranslate";
            this.btnTranslate.Size = new System.Drawing.Size(96, 24);
            this.btnTranslate.TabIndex = 13;
            this.btnTranslate.Text = "Translate Text";
            this.btnTranslate.UseVisualStyleBackColor = true;
            this.btnTranslate.Click += new System.EventHandler(this.BeginTranslation);
            // 
            // diaFileOpen
            // 
            this.diaFileOpen.FileName = "openFileDialog1";
            // 
            // diaFont
            // 
            this.diaFont.FontMustExist = true;
            this.diaFont.ShowApply = true;
            this.diaFont.ShowColor = true;
            // 
            // diaColor
            // 
            this.diaColor.AnyColor = true;
            this.diaColor.FullOpen = true;
            this.diaColor.SolidColorOnly = true;
            // 
            // btnTranslateFrom
            // 
            this.btnTranslateFrom.Font = new System.Drawing.Font("Arial", 9.5F);
            this.btnTranslateFrom.Location = new System.Drawing.Point(12, 41);
            this.btnTranslateFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTranslateFrom.Name = "btnTranslateFrom";
            this.btnTranslateFrom.Size = new System.Drawing.Size(113, 24);
            this.btnTranslateFrom.TabIndex = 14;
            this.btnTranslateFrom.Text = "Translate From:";
            this.btnTranslateFrom.UseVisualStyleBackColor = true;
            // 
            // btnTranslateTo
            // 
            this.btnTranslateTo.Font = new System.Drawing.Font("Arial", 12F);
            this.btnTranslateTo.Location = new System.Drawing.Point(12, 270);
            this.btnTranslateTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTranslateTo.Name = "btnTranslateTo";
            this.btnTranslateTo.Size = new System.Drawing.Size(113, 24);
            this.btnTranslateTo.TabIndex = 15;
            this.btnTranslateTo.Text = "Translate To:";
            this.btnTranslateTo.UseVisualStyleBackColor = true;
            // 
            // btnSwapLang
            // 
            this.btnSwapLang.BackgroundImage = global::TranslationProject.Properties.Resources.swapLang;
            this.btnSwapLang.Location = new System.Drawing.Point(271, 270);
            this.btnSwapLang.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSwapLang.Name = "btnSwapLang";
            this.btnSwapLang.Size = new System.Drawing.Size(28, 24);
            this.btnSwapLang.TabIndex = 12;
            this.btnSwapLang.UseVisualStyleBackColor = true;
            this.btnSwapLang.Click += new System.EventHandler(this.swapLanguages);
            // 
            // btnSwapText
            // 
            this.btnSwapText.BackgroundImage = global::TranslationProject.Properties.Resources.swapText;
            this.btnSwapText.Location = new System.Drawing.Point(305, 270);
            this.btnSwapText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSwapText.Name = "btnSwapText";
            this.btnSwapText.Size = new System.Drawing.Size(28, 24);
            this.btnSwapText.TabIndex = 11;
            this.btnSwapText.UseVisualStyleBackColor = true;
            this.btnSwapText.Click += new System.EventHandler(this.swapText);
            // 
            // btnTxt2Speech
            // 
            this.btnTxt2Speech.Image = ((System.Drawing.Image)(resources.GetObject("btnTxt2Speech.Image")));
            this.btnTxt2Speech.Location = new System.Drawing.Point(339, 270);
            this.btnTxt2Speech.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTxt2Speech.Name = "btnTxt2Speech";
            this.btnTxt2Speech.Size = new System.Drawing.Size(28, 24);
            this.btnTxt2Speech.TabIndex = 10;
            this.btnTxt2Speech.UseVisualStyleBackColor = true;
            this.btnTxt2Speech.Click += new System.EventHandler(this.Text2Speech);
            // 
            // languagesSupportedToolStripMenuItem
            // 
            this.languagesSupportedToolStripMenuItem.Name = "languagesSupportedToolStripMenuItem";
            this.languagesSupportedToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.languagesSupportedToolStripMenuItem.Text = "Languages Supported";
            this.languagesSupportedToolStripMenuItem.Click += new System.EventHandler(this.languagesSupportedToolStripMenuItem_Click);
            // 
            // txtLangFrom
            // 
            this.txtLangFrom.Location = new System.Drawing.Point(131, 44);
            this.txtLangFrom.Name = "txtLangFrom";
            this.txtLangFrom.Size = new System.Drawing.Size(134, 20);
            this.txtLangFrom.TabIndex = 18;
            this.txtLangFrom.TextChanged += new System.EventHandler(this.setList);
            this.txtLangFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.determine);
            // 
            // txtLangTo
            // 
            this.txtLangTo.Location = new System.Drawing.Point(131, 274);
            this.txtLangTo.Name = "txtLangTo";
            this.txtLangTo.Size = new System.Drawing.Size(134, 20);
            this.txtLangTo.TabIndex = 19;
            this.txtLangTo.TextChanged += new System.EventHandler(this.setList);
            this.txtLangTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.determine);
            // 
            // frmTranslateMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 507);
            this.Controls.Add(this.txtLangTo);
            this.Controls.Add(this.txtLangFrom);
            this.Controls.Add(this.btnTranslateTo);
            this.Controls.Add(this.btnTranslateFrom);
            this.Controls.Add(this.btnTranslate);
            this.Controls.Add(this.btnSwapLang);
            this.Controls.Add(this.btnSwapText);
            this.Controls.Add(this.btnTxt2Speech);
            this.Controls.Add(this.txtTranslateTo);
            this.Controls.Add(this.txtTranslateFrom);
            this.Controls.Add(this.mnuTranslateMain);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuTranslateMain;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(420, 540);
            this.Name = "frmTranslateMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "googol Translate";
            this.Activated += new System.EventHandler(this.getClipText);
            this.Load += new System.EventHandler(this.appStartup);
            this.Resize += new System.EventHandler(this.changeFormSize);
            this.mnuTranslateMain.ResumeLayout(false);
            this.mnuTranslateMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTranslateFrom;
        private System.Windows.Forms.MenuStrip mnuTranslateMain;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuView;
        private System.Windows.Forms.ToolStripMenuItem mnuTranslate;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.ToolStripMenuItem mnuFileNew;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSave;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSaveDoc;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSaveTranslation;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSaveAs;
        private System.Windows.Forms.TextBox txtTranslateTo;
        private System.Windows.Forms.Button btnTxt2Speech;
        private System.Windows.Forms.Button btnSwapText;
        private System.Windows.Forms.Button btnSwapLang;
        private System.Windows.Forms.Button btnTranslate;
        private System.Windows.Forms.OpenFileDialog diaFileOpen;
        private System.Windows.Forms.SaveFileDialog diaFileSave;
        private System.Windows.Forms.FontDialog diaFont;
        private System.Windows.Forms.ColorDialog diaColor;
        private System.Windows.Forms.Button btnTranslateFrom;
        private System.Windows.Forms.Button btnTranslateTo;
        private System.Windows.Forms.ToolStripMenuItem mnuTranslateRun;
        private System.Windows.Forms.ToolStripMenuItem mnuTranslateDoc;
        private System.Windows.Forms.ToolStripMenuItem textFontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fontColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuEditUndo;
        private System.Windows.Forms.ToolStripMenuItem mnuEditPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuEditCut;
        private System.Windows.Forms.ToolStripMenuItem mnuEditCopy;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuEditDelete;
        private System.Windows.Forms.ToolStripMenuItem mnuEditSelectAll;
        private System.Windows.Forms.ToolStripMenuItem mnuFileClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem languagesSupportedToolStripMenuItem;
        private System.Windows.Forms.TextBox txtLangFrom;
        private System.Windows.Forms.TextBox txtLangTo;
    }
}


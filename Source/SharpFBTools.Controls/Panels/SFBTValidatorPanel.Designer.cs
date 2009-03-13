﻿/*
 * Created by SharpDevelop.
 * User: Вадим Кузнецов (DikBSD)
 * Date: 13.03.2009
 * Time: 14:34
 * 
 * License: GPL 2.1
 */
namespace SharpFBTools.Controls.Panels
{
	partial class SFBTpValidator
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the control.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFBTpValidator));
			this.tsValidator = new System.Windows.Forms.ToolStrip();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.panelMode = new System.Windows.Forms.Panel();
			this.tboxSourceDir = new System.Windows.Forms.TextBox();
			this.lblDir = new System.Windows.Forms.Label();
			this.tcResult = new System.Windows.Forms.TabControl();
			this.tpNonValid = new System.Windows.Forms.TabPage();
			this.gbFB2NonValid = new System.Windows.Forms.GroupBox();
			this.lblFB2NonValidFilesMoveDir = new System.Windows.Forms.Label();
			this.btnFB2NonValidMoveTo = new System.Windows.Forms.Button();
			this.tboxFB2NonValidDirMoveTo = new System.Windows.Forms.TextBox();
			this.lblFB2NonValidFilesCopyDir = new System.Windows.Forms.Label();
			this.btnFB2NonValidCopyTo = new System.Windows.Forms.Button();
			this.tboxFB2NonValidDirCopyTo = new System.Windows.Forms.TextBox();
			this.pErrors = new System.Windows.Forms.Panel();
			this.rеboxNonValid = new System.Windows.Forms.RichTextBox();
			this.listViewNonValid = new System.Windows.Forms.ListView();
			this.chNonValidFile = new System.Windows.Forms.ColumnHeader();
			this.chNonValidError = new System.Windows.Forms.ColumnHeader();
			this.chNonValidLenght = new System.Windows.Forms.ColumnHeader();
			this.tpValid = new System.Windows.Forms.TabPage();
			this.gbFB2Valid = new System.Windows.Forms.GroupBox();
			this.lblFB2ValidFilesMoveDir = new System.Windows.Forms.Label();
			this.btnFB2ValidMoveTo = new System.Windows.Forms.Button();
			this.tboxFB2ValidDirMoveTo = new System.Windows.Forms.TextBox();
			this.lblFB2ValidFilesCopyDir = new System.Windows.Forms.Label();
			this.btnFB2ValidCopyTo = new System.Windows.Forms.Button();
			this.tboxFB2ValidDirCopyTo = new System.Windows.Forms.TextBox();
			this.tpNotFB2Files = new System.Windows.Forms.TabPage();
			this.gbNotFB2 = new System.Windows.Forms.GroupBox();
			this.lblNotFB2FilesMoveDir = new System.Windows.Forms.Label();
			this.btnNotFB2MoveTo = new System.Windows.Forms.Button();
			this.tboxNotFB2DirMoveTo = new System.Windows.Forms.TextBox();
			this.lblNotFB2FilesCopyDir = new System.Windows.Forms.Label();
			this.btnNotFB2CopyTo = new System.Windows.Forms.Button();
			this.tboxNotFB2DirCopyTo = new System.Windows.Forms.TextBox();
			this.pValidLV = new System.Windows.Forms.Panel();
			this.listViewValid = new System.Windows.Forms.ListView();
			this.chValidFile = new System.Windows.Forms.ColumnHeader();
			this.chValidLenght = new System.Windows.Forms.ColumnHeader();
			this.pNotValidLV = new System.Windows.Forms.Panel();
			this.listViewNotFB2 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.tsValidator.SuspendLayout();
			this.panelMode.SuspendLayout();
			this.tcResult.SuspendLayout();
			this.tpNonValid.SuspendLayout();
			this.gbFB2NonValid.SuspendLayout();
			this.pErrors.SuspendLayout();
			this.tpValid.SuspendLayout();
			this.gbFB2Valid.SuspendLayout();
			this.tpNotFB2Files.SuspendLayout();
			this.gbNotFB2.SuspendLayout();
			this.pValidLV.SuspendLayout();
			this.pNotValidLV.SuspendLayout();
			this.SuspendLayout();
			// 
			// tsValidator
			// 
			this.tsValidator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.toolStripButton1});
			this.tsValidator.Location = new System.Drawing.Point(0, 0);
			this.tsValidator.Name = "tsValidator";
			this.tsValidator.Size = new System.Drawing.Size(722, 25);
			this.tsValidator.TabIndex = 0;
			this.tsValidator.Text = "toolStrip1";
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton1.Text = "toolStripButton1";
			// 
			// panelMode
			// 
			this.panelMode.Controls.Add(this.tboxSourceDir);
			this.panelMode.Controls.Add(this.lblDir);
			this.panelMode.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelMode.Location = new System.Drawing.Point(0, 25);
			this.panelMode.Name = "panelMode";
			this.panelMode.Size = new System.Drawing.Size(722, 33);
			this.panelMode.TabIndex = 9;
			// 
			// tboxSourceDir
			// 
			this.tboxSourceDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.tboxSourceDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tboxSourceDir.Location = new System.Drawing.Point(162, 5);
			this.tboxSourceDir.Name = "tboxSourceDir";
			this.tboxSourceDir.ReadOnly = true;
			this.tboxSourceDir.Size = new System.Drawing.Size(557, 20);
			this.tboxSourceDir.TabIndex = 4;
			// 
			// lblDir
			// 
			this.lblDir.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
			this.lblDir.Location = new System.Drawing.Point(2, 8);
			this.lblDir.Name = "lblDir";
			this.lblDir.Size = new System.Drawing.Size(162, 19);
			this.lblDir.TabIndex = 3;
			this.lblDir.Text = "Папка для сканирования:";
			// 
			// tcResult
			// 
			this.tcResult.Controls.Add(this.tpNonValid);
			this.tcResult.Controls.Add(this.tpValid);
			this.tcResult.Controls.Add(this.tpNotFB2Files);
			this.tcResult.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tcResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tcResult.Location = new System.Drawing.Point(0, 58);
			this.tcResult.Name = "tcResult";
			this.tcResult.SelectedIndex = 0;
			this.tcResult.Size = new System.Drawing.Size(722, 362);
			this.tcResult.TabIndex = 11;
			// 
			// tpNonValid
			// 
			this.tpNonValid.Controls.Add(this.gbFB2NonValid);
			this.tpNonValid.Controls.Add(this.pErrors);
			this.tpNonValid.Controls.Add(this.listViewNonValid);
			this.tpNonValid.Location = new System.Drawing.Point(4, 22);
			this.tpNonValid.Name = "tpNonValid";
			this.tpNonValid.Padding = new System.Windows.Forms.Padding(3);
			this.tpNonValid.Size = new System.Drawing.Size(714, 336);
			this.tpNonValid.TabIndex = 0;
			this.tpNonValid.Text = " Не валидные fb2-файлы ";
			this.tpNonValid.UseVisualStyleBackColor = true;
			// 
			// gbFB2NonValid
			// 
			this.gbFB2NonValid.Controls.Add(this.lblFB2NonValidFilesMoveDir);
			this.gbFB2NonValid.Controls.Add(this.btnFB2NonValidMoveTo);
			this.gbFB2NonValid.Controls.Add(this.tboxFB2NonValidDirMoveTo);
			this.gbFB2NonValid.Controls.Add(this.lblFB2NonValidFilesCopyDir);
			this.gbFB2NonValid.Controls.Add(this.btnFB2NonValidCopyTo);
			this.gbFB2NonValid.Controls.Add(this.tboxFB2NonValidDirCopyTo);
			this.gbFB2NonValid.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbFB2NonValid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.gbFB2NonValid.Location = new System.Drawing.Point(3, 3);
			this.gbFB2NonValid.Name = "gbFB2NonValid";
			this.gbFB2NonValid.Size = new System.Drawing.Size(708, 75);
			this.gbFB2NonValid.TabIndex = 6;
			this.gbFB2NonValid.TabStop = false;
			this.gbFB2NonValid.Text = " Обработка не валидных fb2-файлов: ";
			// 
			// lblFB2NonValidFilesMoveDir
			// 
			this.lblFB2NonValidFilesMoveDir.AutoSize = true;
			this.lblFB2NonValidFilesMoveDir.Location = new System.Drawing.Point(6, 49);
			this.lblFB2NonValidFilesMoveDir.Name = "lblFB2NonValidFilesMoveDir";
			this.lblFB2NonValidFilesMoveDir.Size = new System.Drawing.Size(101, 13);
			this.lblFB2NonValidFilesMoveDir.TabIndex = 9;
			this.lblFB2NonValidFilesMoveDir.Text = "Переместить в:";
			this.lblFB2NonValidFilesMoveDir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnFB2NonValidMoveTo
			// 
			this.btnFB2NonValidMoveTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFB2NonValidMoveTo.Image = ((System.Drawing.Image)(resources.GetObject("btnFB2NonValidMoveTo.Image")));
			this.btnFB2NonValidMoveTo.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnFB2NonValidMoveTo.Location = new System.Drawing.Point(656, 44);
			this.btnFB2NonValidMoveTo.Name = "btnFB2NonValidMoveTo";
			this.btnFB2NonValidMoveTo.Size = new System.Drawing.Size(37, 24);
			this.btnFB2NonValidMoveTo.TabIndex = 8;
			this.btnFB2NonValidMoveTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnFB2NonValidMoveTo.UseVisualStyleBackColor = true;
			// 
			// tboxFB2NonValidDirMoveTo
			// 
			this.tboxFB2NonValidDirMoveTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.tboxFB2NonValidDirMoveTo.Location = new System.Drawing.Point(109, 46);
			this.tboxFB2NonValidDirMoveTo.Name = "tboxFB2NonValidDirMoveTo";
			this.tboxFB2NonValidDirMoveTo.ReadOnly = true;
			this.tboxFB2NonValidDirMoveTo.Size = new System.Drawing.Size(541, 20);
			this.tboxFB2NonValidDirMoveTo.TabIndex = 7;
			// 
			// lblFB2NonValidFilesCopyDir
			// 
			this.lblFB2NonValidFilesCopyDir.AutoSize = true;
			this.lblFB2NonValidFilesCopyDir.Location = new System.Drawing.Point(6, 23);
			this.lblFB2NonValidFilesCopyDir.Name = "lblFB2NonValidFilesCopyDir";
			this.lblFB2NonValidFilesCopyDir.Size = new System.Drawing.Size(92, 13);
			this.lblFB2NonValidFilesCopyDir.TabIndex = 6;
			this.lblFB2NonValidFilesCopyDir.Text = "Копировать в:";
			this.lblFB2NonValidFilesCopyDir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnFB2NonValidCopyTo
			// 
			this.btnFB2NonValidCopyTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFB2NonValidCopyTo.Image = ((System.Drawing.Image)(resources.GetObject("btnFB2NonValidCopyTo.Image")));
			this.btnFB2NonValidCopyTo.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnFB2NonValidCopyTo.Location = new System.Drawing.Point(656, 18);
			this.btnFB2NonValidCopyTo.Name = "btnFB2NonValidCopyTo";
			this.btnFB2NonValidCopyTo.Size = new System.Drawing.Size(37, 24);
			this.btnFB2NonValidCopyTo.TabIndex = 5;
			this.btnFB2NonValidCopyTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnFB2NonValidCopyTo.UseVisualStyleBackColor = true;
			// 
			// tboxFB2NonValidDirCopyTo
			// 
			this.tboxFB2NonValidDirCopyTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.tboxFB2NonValidDirCopyTo.Location = new System.Drawing.Point(109, 20);
			this.tboxFB2NonValidDirCopyTo.Name = "tboxFB2NonValidDirCopyTo";
			this.tboxFB2NonValidDirCopyTo.ReadOnly = true;
			this.tboxFB2NonValidDirCopyTo.Size = new System.Drawing.Size(541, 20);
			this.tboxFB2NonValidDirCopyTo.TabIndex = 0;
			// 
			// pErrors
			// 
			this.pErrors.Controls.Add(this.rеboxNonValid);
			this.pErrors.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pErrors.Location = new System.Drawing.Point(3, 274);
			this.pErrors.Name = "pErrors";
			this.pErrors.Size = new System.Drawing.Size(708, 59);
			this.pErrors.TabIndex = 1;
			// 
			// rеboxNonValid
			// 
			this.rеboxNonValid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rеboxNonValid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.rеboxNonValid.Location = new System.Drawing.Point(0, 0);
			this.rеboxNonValid.Name = "rеboxNonValid";
			this.rеboxNonValid.Size = new System.Drawing.Size(708, 59);
			this.rеboxNonValid.TabIndex = 2;
			this.rеboxNonValid.Text = "";
			// 
			// listViewNonValid
			// 
			this.listViewNonValid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.listViewNonValid.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.chNonValidFile,
									this.chNonValidError,
									this.chNonValidLenght});
			this.listViewNonValid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.listViewNonValid.FullRowSelect = true;
			this.listViewNonValid.GridLines = true;
			this.listViewNonValid.Location = new System.Drawing.Point(3, 84);
			this.listViewNonValid.MultiSelect = false;
			this.listViewNonValid.Name = "listViewNonValid";
			this.listViewNonValid.ShowItemToolTips = true;
			this.listViewNonValid.Size = new System.Drawing.Size(708, 184);
			this.listViewNonValid.TabIndex = 0;
			this.listViewNonValid.UseCompatibleStateImageBehavior = false;
			this.listViewNonValid.View = System.Windows.Forms.View.Details;
			// 
			// chNonValidFile
			// 
			this.chNonValidFile.Text = "fb2-файл";
			this.chNonValidFile.Width = 400;
			// 
			// chNonValidError
			// 
			this.chNonValidError.Text = "Ошибка";
			this.chNonValidError.Width = 300;
			// 
			// chNonValidLenght
			// 
			this.chNonValidLenght.Text = "Размер";
			this.chNonValidLenght.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// tpValid
			// 
			this.tpValid.Controls.Add(this.pValidLV);
			this.tpValid.Controls.Add(this.gbFB2Valid);
			this.tpValid.Location = new System.Drawing.Point(4, 22);
			this.tpValid.Name = "tpValid";
			this.tpValid.Padding = new System.Windows.Forms.Padding(3);
			this.tpValid.Size = new System.Drawing.Size(714, 336);
			this.tpValid.TabIndex = 1;
			this.tpValid.Text = " Валидные fb2-файлы ";
			this.tpValid.UseVisualStyleBackColor = true;
			// 
			// gbFB2Valid
			// 
			this.gbFB2Valid.Controls.Add(this.lblFB2ValidFilesMoveDir);
			this.gbFB2Valid.Controls.Add(this.btnFB2ValidMoveTo);
			this.gbFB2Valid.Controls.Add(this.tboxFB2ValidDirMoveTo);
			this.gbFB2Valid.Controls.Add(this.lblFB2ValidFilesCopyDir);
			this.gbFB2Valid.Controls.Add(this.btnFB2ValidCopyTo);
			this.gbFB2Valid.Controls.Add(this.tboxFB2ValidDirCopyTo);
			this.gbFB2Valid.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbFB2Valid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.gbFB2Valid.Location = new System.Drawing.Point(3, 3);
			this.gbFB2Valid.Name = "gbFB2Valid";
			this.gbFB2Valid.Size = new System.Drawing.Size(708, 75);
			this.gbFB2Valid.TabIndex = 8;
			this.gbFB2Valid.TabStop = false;
			this.gbFB2Valid.Text = " Обработка валидных fb2-файлов: ";
			// 
			// lblFB2ValidFilesMoveDir
			// 
			this.lblFB2ValidFilesMoveDir.AutoSize = true;
			this.lblFB2ValidFilesMoveDir.Location = new System.Drawing.Point(6, 49);
			this.lblFB2ValidFilesMoveDir.Name = "lblFB2ValidFilesMoveDir";
			this.lblFB2ValidFilesMoveDir.Size = new System.Drawing.Size(101, 13);
			this.lblFB2ValidFilesMoveDir.TabIndex = 9;
			this.lblFB2ValidFilesMoveDir.Text = "Переместить в:";
			this.lblFB2ValidFilesMoveDir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnFB2ValidMoveTo
			// 
			this.btnFB2ValidMoveTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFB2ValidMoveTo.Image = ((System.Drawing.Image)(resources.GetObject("btnFB2ValidMoveTo.Image")));
			this.btnFB2ValidMoveTo.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnFB2ValidMoveTo.Location = new System.Drawing.Point(656, 44);
			this.btnFB2ValidMoveTo.Name = "btnFB2ValidMoveTo";
			this.btnFB2ValidMoveTo.Size = new System.Drawing.Size(37, 24);
			this.btnFB2ValidMoveTo.TabIndex = 8;
			this.btnFB2ValidMoveTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnFB2ValidMoveTo.UseVisualStyleBackColor = true;
			// 
			// tboxFB2ValidDirMoveTo
			// 
			this.tboxFB2ValidDirMoveTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.tboxFB2ValidDirMoveTo.Location = new System.Drawing.Point(109, 46);
			this.tboxFB2ValidDirMoveTo.Name = "tboxFB2ValidDirMoveTo";
			this.tboxFB2ValidDirMoveTo.ReadOnly = true;
			this.tboxFB2ValidDirMoveTo.Size = new System.Drawing.Size(541, 20);
			this.tboxFB2ValidDirMoveTo.TabIndex = 7;
			// 
			// lblFB2ValidFilesCopyDir
			// 
			this.lblFB2ValidFilesCopyDir.AutoSize = true;
			this.lblFB2ValidFilesCopyDir.Location = new System.Drawing.Point(6, 23);
			this.lblFB2ValidFilesCopyDir.Name = "lblFB2ValidFilesCopyDir";
			this.lblFB2ValidFilesCopyDir.Size = new System.Drawing.Size(92, 13);
			this.lblFB2ValidFilesCopyDir.TabIndex = 6;
			this.lblFB2ValidFilesCopyDir.Text = "Копировать в:";
			this.lblFB2ValidFilesCopyDir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnFB2ValidCopyTo
			// 
			this.btnFB2ValidCopyTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFB2ValidCopyTo.Image = ((System.Drawing.Image)(resources.GetObject("btnFB2ValidCopyTo.Image")));
			this.btnFB2ValidCopyTo.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnFB2ValidCopyTo.Location = new System.Drawing.Point(656, 18);
			this.btnFB2ValidCopyTo.Name = "btnFB2ValidCopyTo";
			this.btnFB2ValidCopyTo.Size = new System.Drawing.Size(37, 24);
			this.btnFB2ValidCopyTo.TabIndex = 5;
			this.btnFB2ValidCopyTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnFB2ValidCopyTo.UseVisualStyleBackColor = true;
			// 
			// tboxFB2ValidDirCopyTo
			// 
			this.tboxFB2ValidDirCopyTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.tboxFB2ValidDirCopyTo.Location = new System.Drawing.Point(109, 20);
			this.tboxFB2ValidDirCopyTo.Name = "tboxFB2ValidDirCopyTo";
			this.tboxFB2ValidDirCopyTo.ReadOnly = true;
			this.tboxFB2ValidDirCopyTo.Size = new System.Drawing.Size(541, 20);
			this.tboxFB2ValidDirCopyTo.TabIndex = 0;
			// 
			// tpNotFB2Files
			// 
			this.tpNotFB2Files.Controls.Add(this.pNotValidLV);
			this.tpNotFB2Files.Controls.Add(this.gbNotFB2);
			this.tpNotFB2Files.Location = new System.Drawing.Point(4, 22);
			this.tpNotFB2Files.Name = "tpNotFB2Files";
			this.tpNotFB2Files.Padding = new System.Windows.Forms.Padding(3);
			this.tpNotFB2Files.Size = new System.Drawing.Size(714, 336);
			this.tpNotFB2Files.TabIndex = 2;
			this.tpNotFB2Files.Text = " Не fb2-файлы ";
			this.tpNotFB2Files.UseVisualStyleBackColor = true;
			// 
			// gbNotFB2
			// 
			this.gbNotFB2.Controls.Add(this.lblNotFB2FilesMoveDir);
			this.gbNotFB2.Controls.Add(this.btnNotFB2MoveTo);
			this.gbNotFB2.Controls.Add(this.tboxNotFB2DirMoveTo);
			this.gbNotFB2.Controls.Add(this.lblNotFB2FilesCopyDir);
			this.gbNotFB2.Controls.Add(this.btnNotFB2CopyTo);
			this.gbNotFB2.Controls.Add(this.tboxNotFB2DirCopyTo);
			this.gbNotFB2.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbNotFB2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.gbNotFB2.Location = new System.Drawing.Point(3, 3);
			this.gbNotFB2.Name = "gbNotFB2";
			this.gbNotFB2.Size = new System.Drawing.Size(708, 75);
			this.gbNotFB2.TabIndex = 9;
			this.gbNotFB2.TabStop = false;
			this.gbNotFB2.Text = " Обработка не валидных fb2-файлов: ";
			// 
			// lblNotFB2FilesMoveDir
			// 
			this.lblNotFB2FilesMoveDir.AutoSize = true;
			this.lblNotFB2FilesMoveDir.Location = new System.Drawing.Point(6, 49);
			this.lblNotFB2FilesMoveDir.Name = "lblNotFB2FilesMoveDir";
			this.lblNotFB2FilesMoveDir.Size = new System.Drawing.Size(101, 13);
			this.lblNotFB2FilesMoveDir.TabIndex = 9;
			this.lblNotFB2FilesMoveDir.Text = "Переместить в:";
			this.lblNotFB2FilesMoveDir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnNotFB2MoveTo
			// 
			this.btnNotFB2MoveTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNotFB2MoveTo.Image = ((System.Drawing.Image)(resources.GetObject("btnNotFB2MoveTo.Image")));
			this.btnNotFB2MoveTo.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnNotFB2MoveTo.Location = new System.Drawing.Point(656, 44);
			this.btnNotFB2MoveTo.Name = "btnNotFB2MoveTo";
			this.btnNotFB2MoveTo.Size = new System.Drawing.Size(37, 24);
			this.btnNotFB2MoveTo.TabIndex = 8;
			this.btnNotFB2MoveTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnNotFB2MoveTo.UseVisualStyleBackColor = true;
			// 
			// tboxNotFB2DirMoveTo
			// 
			this.tboxNotFB2DirMoveTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.tboxNotFB2DirMoveTo.Location = new System.Drawing.Point(109, 46);
			this.tboxNotFB2DirMoveTo.Name = "tboxNotFB2DirMoveTo";
			this.tboxNotFB2DirMoveTo.ReadOnly = true;
			this.tboxNotFB2DirMoveTo.Size = new System.Drawing.Size(541, 20);
			this.tboxNotFB2DirMoveTo.TabIndex = 7;
			// 
			// lblNotFB2FilesCopyDir
			// 
			this.lblNotFB2FilesCopyDir.AutoSize = true;
			this.lblNotFB2FilesCopyDir.Location = new System.Drawing.Point(6, 23);
			this.lblNotFB2FilesCopyDir.Name = "lblNotFB2FilesCopyDir";
			this.lblNotFB2FilesCopyDir.Size = new System.Drawing.Size(92, 13);
			this.lblNotFB2FilesCopyDir.TabIndex = 6;
			this.lblNotFB2FilesCopyDir.Text = "Копировать в:";
			this.lblNotFB2FilesCopyDir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnNotFB2CopyTo
			// 
			this.btnNotFB2CopyTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNotFB2CopyTo.Image = ((System.Drawing.Image)(resources.GetObject("btnNotFB2CopyTo.Image")));
			this.btnNotFB2CopyTo.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnNotFB2CopyTo.Location = new System.Drawing.Point(656, 18);
			this.btnNotFB2CopyTo.Name = "btnNotFB2CopyTo";
			this.btnNotFB2CopyTo.Size = new System.Drawing.Size(37, 24);
			this.btnNotFB2CopyTo.TabIndex = 5;
			this.btnNotFB2CopyTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnNotFB2CopyTo.UseVisualStyleBackColor = true;
			// 
			// tboxNotFB2DirCopyTo
			// 
			this.tboxNotFB2DirCopyTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.tboxNotFB2DirCopyTo.Location = new System.Drawing.Point(109, 20);
			this.tboxNotFB2DirCopyTo.Name = "tboxNotFB2DirCopyTo";
			this.tboxNotFB2DirCopyTo.ReadOnly = true;
			this.tboxNotFB2DirCopyTo.Size = new System.Drawing.Size(541, 20);
			this.tboxNotFB2DirCopyTo.TabIndex = 0;
			// 
			// pValidLV
			// 
			this.pValidLV.Controls.Add(this.listViewValid);
			this.pValidLV.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pValidLV.Location = new System.Drawing.Point(3, 78);
			this.pValidLV.Name = "pValidLV";
			this.pValidLV.Size = new System.Drawing.Size(708, 255);
			this.pValidLV.TabIndex = 9;
			// 
			// listViewValid
			// 
			this.listViewValid.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.chValidFile,
									this.chValidLenght});
			this.listViewValid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listViewValid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.listViewValid.FullRowSelect = true;
			this.listViewValid.GridLines = true;
			this.listViewValid.Location = new System.Drawing.Point(0, 0);
			this.listViewValid.MultiSelect = false;
			this.listViewValid.Name = "listViewValid";
			this.listViewValid.ShowItemToolTips = true;
			this.listViewValid.Size = new System.Drawing.Size(708, 255);
			this.listViewValid.TabIndex = 1;
			this.listViewValid.UseCompatibleStateImageBehavior = false;
			this.listViewValid.View = System.Windows.Forms.View.Details;
			// 
			// chValidFile
			// 
			this.chValidFile.Text = "fb2-файл";
			this.chValidFile.Width = 700;
			// 
			// chValidLenght
			// 
			this.chValidLenght.Text = "Размер";
			this.chValidLenght.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// pNotValidLV
			// 
			this.pNotValidLV.Controls.Add(this.listViewNotFB2);
			this.pNotValidLV.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pNotValidLV.Location = new System.Drawing.Point(3, 78);
			this.pNotValidLV.Name = "pNotValidLV";
			this.pNotValidLV.Size = new System.Drawing.Size(708, 255);
			this.pNotValidLV.TabIndex = 10;
			// 
			// listViewNotFB2
			// 
			this.listViewNotFB2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1,
									this.columnHeader2,
									this.columnHeader3});
			this.listViewNotFB2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listViewNotFB2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.listViewNotFB2.FullRowSelect = true;
			this.listViewNotFB2.GridLines = true;
			this.listViewNotFB2.Location = new System.Drawing.Point(0, 0);
			this.listViewNotFB2.MultiSelect = false;
			this.listViewNotFB2.Name = "listViewNotFB2";
			this.listViewNotFB2.ShowItemToolTips = true;
			this.listViewNotFB2.Size = new System.Drawing.Size(708, 255);
			this.listViewNotFB2.TabIndex = 2;
			this.listViewNotFB2.UseCompatibleStateImageBehavior = false;
			this.listViewNotFB2.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Разные файлы и zip, rar архивы";
			this.columnHeader1.Width = 600;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Тип";
			this.columnHeader2.Width = 40;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Размер";
			this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader3.Width = 80;
			// 
			// SFBTpValidator
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tcResult);
			this.Controls.Add(this.panelMode);
			this.Controls.Add(this.tsValidator);
			this.Name = "SFBTpValidator";
			this.Size = new System.Drawing.Size(722, 420);
			this.Tag = "validator";
			this.tsValidator.ResumeLayout(false);
			this.tsValidator.PerformLayout();
			this.panelMode.ResumeLayout(false);
			this.panelMode.PerformLayout();
			this.tcResult.ResumeLayout(false);
			this.tpNonValid.ResumeLayout(false);
			this.gbFB2NonValid.ResumeLayout(false);
			this.gbFB2NonValid.PerformLayout();
			this.pErrors.ResumeLayout(false);
			this.tpValid.ResumeLayout(false);
			this.gbFB2Valid.ResumeLayout(false);
			this.gbFB2Valid.PerformLayout();
			this.tpNotFB2Files.ResumeLayout(false);
			this.gbNotFB2.ResumeLayout(false);
			this.gbNotFB2.PerformLayout();
			this.pValidLV.ResumeLayout(false);
			this.pNotValidLV.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Panel pValidLV;
		private System.Windows.Forms.Panel pNotValidLV;
		private System.Windows.Forms.TabPage tpNotFB2Files;
		private System.Windows.Forms.GroupBox gbNotFB2;
		private System.Windows.Forms.Label lblNotFB2FilesMoveDir;
		private System.Windows.Forms.Button btnNotFB2MoveTo;
		private System.Windows.Forms.TextBox tboxNotFB2DirMoveTo;
		private System.Windows.Forms.Label lblNotFB2FilesCopyDir;
		private System.Windows.Forms.Button btnNotFB2CopyTo;
		private System.Windows.Forms.TextBox tboxNotFB2DirCopyTo;
		private System.Windows.Forms.ListView listViewNotFB2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader chValidLenght;
		private System.Windows.Forms.ColumnHeader chValidFile;
		private System.Windows.Forms.ListView listViewValid;
		private System.Windows.Forms.TextBox tboxFB2ValidDirCopyTo;
		private System.Windows.Forms.Button btnFB2ValidCopyTo;
		private System.Windows.Forms.Label lblFB2ValidFilesCopyDir;
		private System.Windows.Forms.TextBox tboxFB2ValidDirMoveTo;
		private System.Windows.Forms.Button btnFB2ValidMoveTo;
		private System.Windows.Forms.Label lblFB2ValidFilesMoveDir;
		private System.Windows.Forms.GroupBox gbFB2Valid;
		private System.Windows.Forms.TabPage tpValid;
		private System.Windows.Forms.ColumnHeader chNonValidLenght;
		private System.Windows.Forms.ColumnHeader chNonValidError;
		private System.Windows.Forms.ColumnHeader chNonValidFile;
		private System.Windows.Forms.ListView listViewNonValid;
		private System.Windows.Forms.RichTextBox rеboxNonValid;
		private System.Windows.Forms.Panel pErrors;
		private System.Windows.Forms.TextBox tboxFB2NonValidDirCopyTo;
		private System.Windows.Forms.Button btnFB2NonValidCopyTo;
		private System.Windows.Forms.Label lblFB2NonValidFilesCopyDir;
		private System.Windows.Forms.TextBox tboxFB2NonValidDirMoveTo;
		private System.Windows.Forms.Button btnFB2NonValidMoveTo;
		private System.Windows.Forms.Label lblFB2NonValidFilesMoveDir;
		private System.Windows.Forms.GroupBox gbFB2NonValid;
		private System.Windows.Forms.TabPage tpNonValid;
		private System.Windows.Forms.TabControl tcResult;
		private System.Windows.Forms.Label lblDir;
		private System.Windows.Forms.TextBox tboxSourceDir;
		private System.Windows.Forms.Panel panelMode;
		private System.Windows.Forms.ToolStrip tsValidator;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
	}
}

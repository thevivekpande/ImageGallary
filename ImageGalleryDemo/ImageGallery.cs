using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using C1.Win.C1Tile;
using C1.C1Pdf;
using System.Drawing.Imaging;

//
// Author :- Vivek Pandey
// github :- thevivekpande
// Assignment for Summer Internship Program at GrapeCity india Pvt. Ltd.
//

namespace ImageGalleryDemo
{
    public partial class ImageGallery : Form
    {
        // instance of DataFetcher()
        DataFetcher datafetch = new DataFetcher();

        List<ImageItem> imagesList;
        int checkedItems = 0;
        C1PdfDocument imagePdfDocument = new C1PdfDocument();

        private SplitContainer splitContainer1 = new SplitContainer();

        private Panel panel1 = new Panel();
        private Panel panel2 = new Panel();

        private TextBox _searchBox = new TextBox();

        private PictureBox _search = new PictureBox();
        private PictureBox _exportImage = new PictureBox();
        private PictureBox _exportfileDialog = new PictureBox();

        private Label exportPDFLabel = new Label();
        private Label saveDialogLabel = new Label();

        private Group _group = new Group();
        private Group group1 = new Group();

        private Tile tile1 = new Tile();
        private Tile tile2 = new Tile();
        private Tile tile3 = new Tile();

        private PanelElement panelElement2 = new PanelElement();

        private ImageElement imageElement2 = new ImageElement();

        private TextElement textElement2 = new TextElement();

        private StatusStrip statusStrip1 = new StatusStrip();

        private TableLayoutPanel tableLayoutPanel1 = new TableLayoutPanel();

        private C1PdfDocument c1PdfDocument1 = new C1PdfDocument();

        private C1TileControl _imageTileControl = new C1TileControl();

        private ToolStripProgressBar toolStripProgressBar1 = new ToolStripProgressBar();

        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageGallery));

        public ImageGallery()
        {
            //
            // Initialize Component
            //
            InitializeComponent();

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageGallery));


            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._search)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._exportfileDialog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._exportImage)).BeginInit();


            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;

            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);

            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this._exportfileDialog);
            this.splitContainer1.Panel2.Controls.Add(this._imageTileControl);
            this.splitContainer1.Panel2.Controls.Add(this._exportImage);
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(764, 749);
            this.splitContainer1.SplitterDistance = 40;
            this.splitContainer1.TabIndex = 0;

            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.5F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(764, 40);
            this.tableLayoutPanel1.TabIndex = 0;

            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._searchBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(194, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 34);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);

            // 
            // panel2
            // 
            this.panel2.Controls.Add(this._search);
            this.panel2.Location = new System.Drawing.Point(479, 12);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 12, 45, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(40, 16);
            this.panel2.TabIndex = 1;

            // 
            // _search
            // 
            this._search.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._search.Image = ((System.Drawing.Image)(resources.GetObject("_search.Image")));
            this._search.Location = new System.Drawing.Point(4, 1);
            this._search.Margin = new System.Windows.Forms.Padding(0);
            this._search.Name = "_search";
            this._search.Size = new System.Drawing.Size(40, 16);
            this._search.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._search.TabIndex = 0;
            this._search.TabStop = false;
            this._search.Click += new System.EventHandler(this._search_Click);

            // 
            // _exportfileDialog
            // 
            this._exportfileDialog.Image = ((System.Drawing.Image)(resources.GetObject("_exportfileDialog.Image")));
            this._exportfileDialog.Location = new System.Drawing.Point(229, 3);
            this._exportfileDialog.Name = "_exportfileDialog";
            this._exportfileDialog.Size = new System.Drawing.Size(135, 28);
            this._exportfileDialog.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._exportfileDialog.TabIndex = 3;
            this._exportfileDialog.TabStop = false;
            this._exportfileDialog.Visible = false;
            this._exportfileDialog.Click += new System.EventHandler(this._exportfileDialog_Click);
            this._exportfileDialog.Paint += new System.Windows.Forms.PaintEventHandler(this._exportfileDialog_Paint);

            // 
            // _imageTileControl
            // 
            this._imageTileControl.AllowChecking = true;
            this._imageTileControl.AllowRearranging = true;
            this._imageTileControl.CellHeight = 78;
            this._imageTileControl.CellSpacing = 11;
            this._imageTileControl.CellWidth = 78;

            //
            // _imageTileControl
            //  
            panelElement2.Alignment = System.Drawing.ContentAlignment.BottomLeft;
            panelElement2.Children.Add(imageElement2);
            panelElement2.Children.Add(textElement2);
            panelElement2.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this._imageTileControl.DefaultTemplate.Elements.Add(panelElement2);
            this._imageTileControl.Groups.Add(this.group1);
            this._imageTileControl.Location = new System.Drawing.Point(29, 51);
            this._imageTileControl.Name = "_imageTileControl";
            this._imageTileControl.Size = new System.Drawing.Size(700, 616);
            this._imageTileControl.SurfacePadding = new System.Windows.Forms.Padding(12, 4, 12, 4);
            this._imageTileControl.SwipeDistance = 20;
            this._imageTileControl.SwipeRearrangeDistance = 98;
            this._imageTileControl.TabIndex = 1;
            this._imageTileControl.TileChecked += new System.EventHandler<C1.Win.C1Tile.TileEventArgs>(this._imageTileControl_TileChecked);
            this._imageTileControl.TileUnchecked += new System.EventHandler<C1.Win.C1Tile.TileEventArgs>(this._imageTileControl_TileUnchecked);
            this._imageTileControl.VisibleChanged += new System.EventHandler(this._search_Click);
            this._imageTileControl.Paint += new System.Windows.Forms.PaintEventHandler(this._imageTileControl_Paint);

            // 
            // group1
            // 
            this.group1.Name = "group1";
            this.group1.Text = "Search Results";
            this.group1.Visible = true;

            // 
            // _exportImage
            // 
            this._exportImage.Image = ((System.Drawing.Image)(resources.GetObject("_exportImage.Image")));
            this._exportImage.Location = new System.Drawing.Point(29, 3);
            this._exportImage.Name = "_exportImage";
            this._exportImage.Size = new System.Drawing.Size(135, 28);
            this._exportImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._exportImage.TabIndex = 0;
            this._exportImage.TabStop = false;
            this._exportImage.Visible = false;
            this._exportImage.Click += new System.EventHandler(this._exportImage_Click);
            this._exportImage.Paint += new System.Windows.Forms.PaintEventHandler(this._exportImage_Paint);

            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 683);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(764, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.Visible = false;

            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;

            // 
            // c1PdfDocument1
            // 
            this.c1PdfDocument1.DocumentInfo.Author = "";
            this.c1PdfDocument1.DocumentInfo.CreationDate = new System.DateTime(((long)(0)));
            this.c1PdfDocument1.DocumentInfo.Creator = "";
            this.c1PdfDocument1.DocumentInfo.Keywords = "";
            this.c1PdfDocument1.DocumentInfo.Producer = "ComponentOne C1Pdf";
            this.c1PdfDocument1.DocumentInfo.Subject = "";
            this.c1PdfDocument1.DocumentInfo.Title = "";
            this.c1PdfDocument1.MaxHeaderBookmarkLevel = 0;
            this.c1PdfDocument1.PdfVersion = "1.3";
            this.c1PdfDocument1.RefDC = null;
            this.c1PdfDocument1.RotateAngle = 0F;
            this.c1PdfDocument1.UseFastTextOut = true;
            this.c1PdfDocument1.UseFontShaping = true;

            // 
            // _searchBox
            // 
            this._searchBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._searchBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._searchBox.Location = new System.Drawing.Point(16, 9);
            this._searchBox.Name = "_searchBox";
            this._searchBox.Size = new System.Drawing.Size(244, 13);
            this._searchBox.TabIndex = 0;
            this._searchBox.Text = "Search Image";

            // 
            // ImageGallery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 749);
            this.Controls.Add(this.splitContainer1);
            this.MaximumSize = new System.Drawing.Size(810, 810);
            this.MinimizeBox = true;
            this.MaximizeBox = true;
            this.Name = "ImageGallery";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Image Gallery";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._search)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._exportfileDialog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._exportImage)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
        }

        //
        // Pannel Paint Event Handling
        //
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle r = _searchBox.Bounds;
            r.Inflate(3, 3);
            Pen p = new Pen(Color.LightGray);
            e.Graphics.DrawRectangle(p, r);
        }

        //
        // _search Click Event Handling
        // 
        private async void _search_Click(object sender, EventArgs e)
        {
            statusStrip1.Visible = true;
            if (_searchBox.Text == "")
            {
                MessageBox.Show("Enter any valid search.");
            }
            imagesList = await datafetch.GetImageData(_searchBox.Text);
            AddTiles(imagesList);
            statusStrip1.Visible = false;
        }

        //
        // Add Tiles to Windows Form
        // 
        private void AddTiles(List<ImageItem> imageList)
        {
            _imageTileControl.Groups[0].Tiles.Clear();
            foreach (var imageitem in imageList)
            {
                Tile tile = new Tile();
                tile.HorizontalSize = 2;
                tile.VerticalSize = 2;
                _imageTileControl.Groups[0].Tiles.Add(tile);

                Image img = Image.FromStream(new MemoryStream(imageitem.Base64));

                Template tl = new Template();
                ImageElement ie = new ImageElement();
                ie.ImageLayout = ForeImageLayout.Stretch;
                tl.Elements.Add(ie);
                tile.Template = tl;
                tile.Image = img;
            }
        }

        //
        // _exportImage (Exporting images to Pdf) Event Handling
        // 
        private void _exportImage_Click(object sender, EventArgs e)
        {
            List<Image> images = new List<Image>();
            foreach (Tile tile in _imageTileControl.Groups[0].Tiles)
            {
                if (tile.Checked)
                {
                    images.Add(tile.Image);

                }
            }

            ConvertToPdf(images);
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.DefaultExt = "pdf";
            saveFile.Filter = "PDF files (*.pdf)|*.pdf*";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                imagePdfDocument.Save(saveFile.FileName);
            }

        }

        //
        // ConvertToPdf Method for converting images to pdf format.
        //
        private void ConvertToPdf(List<Image> images)
        {


            RectangleF rect = imagePdfDocument.PageRectangle;
            bool firstPage = true;
            foreach (var selectedimg in images)
            {
                if (!firstPage)
                {
                    imagePdfDocument.NewPage();
                }

                firstPage = false;
                rect.Inflate(-72, -72);
                imagePdfDocument.DrawImage(selectedimg, rect);
            }
        }

        //
        // _exportImage Paint Event Handling
        //
        private void _exportImage_Paint(object sender, PaintEventArgs e)
        {
            Rectangle r = new Rectangle(_exportImage.Location.X, _exportImage.Location.Y, _exportImage.Width, _exportImage.Height);
            r.X -= 29;
            r.Y -= 3;
            r.Width--;
            r.Height--;
            Pen p = new Pen(Color.LightGray);
            e.Graphics.DrawRectangle(p, r);
            e.Graphics.DrawLine(p, new Point(0, 43), new Point(this.Width, 43));
        }

        //
        // Event Handling for _imageTileControl after checking the Tiles.
        //
        private void _imageTileControl_TileChecked(object sender, C1.Win.C1Tile.TileEventArgs e)
        {
            checkedItems++;
            _exportImage.Visible = true;
            _exportfileDialog.Visible = true;
        }

        //
        // Event Handling for _imageTileControl after unchecking the Tiles.
        //
        private void _imageTileControl_TileUnchecked(object sender, C1.Win.C1Tile.TileEventArgs e)
        {
            checkedItems--;
            _exportImage.Visible = checkedItems > 0;
            _exportfileDialog.Visible = checkedItems > 0;
        }

        //
        // Paint Event Handling for _imageTileControl
        //
        private void _imageTileControl_Paint(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.LightGray);
            e.Graphics.DrawLine(p, 0, 43, 800, 43);
        }

        //
        // Paint event Handiing of _exportfileDialog(Saving image to local directory using file Dialog).
        //
        private void _exportfileDialog_Paint(object sender, PaintEventArgs e)
        {
            Rectangle r = new Rectangle(_exportfileDialog.Location.X, _exportfileDialog.Location.Y, _exportfileDialog.Width, _exportfileDialog.Height);
            r.X -= 229;
            r.Y -= 3;
            r.Width--;
            r.Height--;
            Pen p = new Pen(Color.LightGray);
            e.Graphics.DrawRectangle(p, r);
            e.Graphics.DrawLine(p, new Point(0, 43), new Point(this.Width, 43));
        }

        //
        // Click event Handiing of _exportfileDialog(Saving image to local directory using file Dialog).
        //
        private void _exportfileDialog_Click(object sender, EventArgs e)
        {
            List<Image> images = new List<Image>();
            foreach (Tile tile in _imageTileControl.Groups[0].Tiles)
            {
                if (tile.Checked)
                {
                    images.Add(tile.Image);

                }
            }
            foreach (var selectedImage in images)
            {

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Images|*.png;*.bmp;*.jpg";
                ImageFormat format = ImageFormat.Png;
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string ext = System.IO.Path.GetExtension(sfd.FileName);
                    switch (ext)
                    {
                        case ".jpg":
                            format = ImageFormat.Jpeg;
                            break;
                        case ".bmp":
                            format = ImageFormat.Bmp;
                            break;
                    }
                    selectedImage.Save(sfd.FileName, format);
                }
            }



        }

    }
}





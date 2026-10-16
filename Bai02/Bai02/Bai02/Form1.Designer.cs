#nullable disable
namespace Bai02
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            mnuSystem = new ToolStripMenuItem();
            mnuOpen = new ToolStripMenuItem();
            mnuSaveReport = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            mnuExit = new ToolStripMenuItem();
            mnuTools = new ToolStripMenuItem();
            mnuImport = new ToolStripMenuItem();
            mnuExport = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            tsbOpen = new ToolStripButton();
            tsbSaveReport = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            tsbImport = new ToolStripButton();
            tsbExport = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            tsbExit = new ToolStripButton();
            statusStrip1 = new StatusStrip();
            tslTotalQty = new ToolStripStatusLabel();
            tslTotalValue = new ToolStripStatusLabel();
            tslSpring = new ToolStripStatusLabel();
            tslTime = new ToolStripStatusLabel();
            grpInput = new GroupBox();
            lblId = new Label();
            txtId = new TextBox();
            lblName = new Label();
            txtName = new TextBox();
            lblQuantity = new Label();
            numQuantity = new NumericUpDown();
            lblCategory = new Label();
            cboCategory = new ComboBox();
            lblPrice = new Label();
            txtPrice = new TextBox();
            picProductImage = new PictureBox();
            btnChooseImage = new Button();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            dgvProducts = new DataGridView();
            errorProvider1 = new ErrorProvider(components);
            timer1 = new System.Windows.Forms.Timer(components);
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            grpInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picProductImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { mnuSystem, mnuTools });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(898, 28);
            menuStrip1.TabIndex = 8;
            // 
            // mnuSystem
            // 
            mnuSystem.DropDownItems.AddRange(new ToolStripItem[] { mnuOpen, mnuSaveReport, toolStripSeparator1, mnuExit });
            mnuSystem.Name = "mnuSystem";
            mnuSystem.Size = new Size(70, 24);
            mnuSystem.Text = "System";
            // 
            // mnuOpen
            // 
            mnuOpen.Name = "mnuOpen";
            mnuOpen.ShortcutKeys = Keys.Control | Keys.O;
            mnuOpen.Size = new Size(222, 26);
            mnuOpen.Text = "Open File";
            // 
            // mnuSaveReport
            // 
            mnuSaveReport.Name = "mnuSaveReport";
            mnuSaveReport.ShortcutKeys = Keys.Control | Keys.S;
            mnuSaveReport.Size = new Size(222, 26);
            mnuSaveReport.Text = "Save Report";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(219, 6);
            // 
            // mnuExit
            // 
            mnuExit.Name = "mnuExit";
            mnuExit.ShortcutKeys = Keys.Alt | Keys.F4;
            mnuExit.Size = new Size(222, 26);
            mnuExit.Text = "Exit";
            // 
            // mnuTools
            // 
            mnuTools.DropDownItems.AddRange(new ToolStripItem[] { mnuImport, mnuExport });
            mnuTools.Name = "mnuTools";
            mnuTools.Size = new Size(58, 24);
            mnuTools.Text = "Tools";
            // 
            // mnuImport
            // 
            mnuImport.Name = "mnuImport";
            mnuImport.Size = new Size(167, 26);
            mnuImport.Text = "Import CSV";
            // 
            // mnuExport
            // 
            mnuExport.Name = "mnuExport";
            mnuExport.Size = new Size(167, 26);
            mnuExport.Text = "Export CSV";
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsbOpen, tsbSaveReport, toolStripSeparator2, tsbImport, tsbExport, toolStripSeparator3, tsbExit });
            toolStrip1.Location = new Point(0, 28);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(898, 27);
            toolStrip1.TabIndex = 7;
            // 
            // tsbOpen
            // 
            tsbOpen.Name = "tsbOpen";
            tsbOpen.Size = new Size(49, 24);
            tsbOpen.Text = "Open";
            tsbOpen.ToolTipText = "Mở file dữ liệu (Ctrl+O)";
            // 
            // tsbSaveReport
            // 
            tsbSaveReport.Name = "tsbSaveReport";
            tsbSaveReport.Size = new Size(93, 24);
            tsbSaveReport.Text = "Save Report";
            tsbSaveReport.ToolTipText = "Lưu báo cáo (Ctrl+S)";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 27);
            // 
            // tsbImport
            // 
            tsbImport.Name = "tsbImport";
            tsbImport.Size = new Size(88, 24);
            tsbImport.Text = "Import CSV";
            // 
            // tsbExport
            // 
            tsbExport.Name = "tsbExport";
            tsbExport.Size = new Size(86, 24);
            tsbExport.Text = "Export CSV";
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 27);
            // 
            // tsbExit
            // 
            tsbExit.Name = "tsbExit";
            tsbExit.Size = new Size(37, 24);
            tsbExit.Text = "Exit";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { tslTotalQty, tslTotalValue, tslSpring, tslTime });
            statusStrip1.Location = new Point(0, 602);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(898, 30);
            statusStrip1.TabIndex = 6;
            // 
            // tslTotalQty
            // 
            tslTotalQty.BorderSides = ToolStripStatusLabelBorderSides.Right;
            tslTotalQty.Name = "tslTotalQty";
            tslTotalQty.Size = new Size(124, 24);
            tslTotalQty.Text = "Tổng số lượng: 0";
            // 
            // tslTotalValue
            // 
            tslTotalValue.Name = "tslTotalValue";
            tslTotalValue.Size = new Size(142, 24);
            tslTotalValue.Text = "Tổng giá trị kho: 0 đ";
            // 
            // tslSpring
            // 
            tslSpring.Name = "tslSpring";
            tslSpring.Size = new Size(617, 24);
            tslSpring.Spring = true;
            // 
            // tslTime
            // 
            tslTime.Name = "tslTime";
            tslTime.Size = new Size(0, 24);
            // 
            // grpInput
            // 
            grpInput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpInput.Controls.Add(lblId);
            grpInput.Controls.Add(txtId);
            grpInput.Controls.Add(lblName);
            grpInput.Controls.Add(txtName);
            grpInput.Controls.Add(lblQuantity);
            grpInput.Controls.Add(numQuantity);
            grpInput.Controls.Add(lblCategory);
            grpInput.Controls.Add(cboCategory);
            grpInput.Controls.Add(lblPrice);
            grpInput.Controls.Add(txtPrice);
            grpInput.Controls.Add(picProductImage);
            grpInput.Controls.Add(btnChooseImage);
            grpInput.Location = new Point(12, 70);
            grpInput.Name = "grpInput";
            grpInput.Size = new Size(874, 195);
            grpInput.TabIndex = 5;
            grpInput.TabStop = false;
            grpInput.Text = "Thông tin sản phẩm";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(20, 33);
            lblId.Name = "lblId";
            lblId.Size = new Size(101, 20);
            lblId.TabIndex = 0;
            lblId.Text = "Mã sản phẩm:";
            // 
            // txtId
            // 
            txtId.Location = new Point(125, 30);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(220, 27);
            txtId.TabIndex = 1;
            txtId.TabStop = false;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(20, 73);
            lblName.Name = "lblName";
            lblName.Size = new Size(103, 20);
            lblName.TabIndex = 2;
            lblName.Text = "Tên sản phẩm:";
            // 
            // txtName
            // 
            txtName.Location = new Point(125, 70);
            txtName.Name = "txtName";
            txtName.Size = new Size(220, 27);
            txtName.TabIndex = 3;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(20, 113);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(98, 20);
            lblQuantity.TabIndex = 4;
            lblQuantity.Text = "Số lượng tồn:";
            // 
            // numQuantity
            // 
            numQuantity.Location = new Point(125, 110);
            numQuantity.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(220, 27);
            numQuantity.TabIndex = 5;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(370, 33);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(40, 20);
            lblCategory.TabIndex = 6;
            lblCategory.Text = "Loại:";
            // 
            // cboCategory
            // 
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.Location = new Point(450, 30);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(200, 28);
            cboCategory.TabIndex = 7;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(370, 73);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(65, 20);
            lblPrice.TabIndex = 8;
            lblPrice.Text = "Đơn giá:";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(450, 70);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(200, 27);
            txtPrice.TabIndex = 9;
            txtPrice.TextAlign = HorizontalAlignment.Right;
            // 
            // picProductImage
            // 
            picProductImage.BorderStyle = BorderStyle.FixedSingle;
            picProductImage.Location = new Point(690, 25);
            picProductImage.Name = "picProductImage";
            picProductImage.Size = new Size(170, 120);
            picProductImage.SizeMode = PictureBoxSizeMode.Zoom;
            picProductImage.TabIndex = 10;
            picProductImage.TabStop = false;
            // 
            // btnChooseImage
            // 
            btnChooseImage.Location = new Point(690, 152);
            btnChooseImage.Name = "btnChooseImage";
            btnChooseImage.Size = new Size(170, 32);
            btnChooseImage.TabIndex = 11;
            btnChooseImage.Text = "Chọn ảnh";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(12, 278);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(120, 36);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Thêm mới";
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(142, 278);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(120, 36);
            btnUpdate.TabIndex = 3;
            btnUpdate.Text = "Cập nhật";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(272, 278);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(120, 36);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Xóa";
            // 
            // btnClear
            // 
            btnClear.Location = new Point(402, 278);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(120, 36);
            btnClear.TabIndex = 1;
            btnClear.Text = "Làm mới / Hủy";
            // 
            // dgvProducts
            // 
            dgvProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProducts.ColumnHeadersHeight = 29;
            dgvProducts.Location = new Point(12, 325);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.Size = new Size(874, 242);
            dgvProducts.TabIndex = 0;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1000;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(898, 632);
            Controls.Add(dgvProducts);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(grpInput);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(916, 679);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý kho và xuất báo cáo tổng hợp";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            grpInput.ResumeLayout(false);
            grpInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)picProductImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private MenuStrip menuStrip1;
        private ToolStripMenuItem mnuSystem, mnuOpen, mnuSaveReport, mnuExit, mnuTools, mnuImport, mnuExport;
        private ToolStripSeparator toolStripSeparator1, toolStripSeparator2, toolStripSeparator3;
        private ToolStrip toolStrip1;
        private ToolStripButton tsbOpen, tsbSaveReport, tsbImport, tsbExport, tsbExit;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel tslTotalQty, tslTotalValue, tslSpring, tslTime;
        private GroupBox grpInput;
        private Label lblId, lblName, lblCategory, lblPrice, lblQuantity;
        private TextBox txtId, txtName, txtPrice;
        private ComboBox cboCategory;
        private NumericUpDown numQuantity;
        private PictureBox picProductImage;
        private Button btnChooseImage, btnAdd, btnUpdate, btnDelete, btnClear;
        private DataGridView dgvProducts;
        private ErrorProvider errorProvider1;
        private System.Windows.Forms.Timer timer1;
    }
}
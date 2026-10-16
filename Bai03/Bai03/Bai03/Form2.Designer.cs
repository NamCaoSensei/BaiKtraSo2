#nullable disable
namespace Bai03
{
    partial class Form2
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
            grpInput = new GroupBox();
            lblId = new Label();
            lblName = new Label();
            lblCategory = new Label();
            lblPrice = new Label();
            lblQuantity = new Label();
            txtId = new TextBox();
            txtName = new TextBox();
            cboCategory = new ComboBox();
            txtPrice = new TextBox();
            numQuantity = new NumericUpDown();
            picProductImage = new PictureBox();
            btnChooseImage = new Button();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            dgvProducts = new DataGridView();
            errorProvider1 = new ErrorProvider(components);

            grpInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picProductImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();

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
            grpInput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpInput.Location = new Point(12, 12);
            grpInput.Name = "grpInput";
            grpInput.Size = new Size(876, 195);
            grpInput.Text = "Thông tin sản phẩm";

            lblId.AutoSize = true;
            lblId.Location = new Point(20, 33);
            lblId.Name = "lblId";
            lblId.Text = "Mã sản phẩm:";

            txtId.Location = new Point(125, 30);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(220, 27);
            txtId.TabStop = false;

            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(370, 33);
            lblCategory.Name = "lblCategory";
            lblCategory.Text = "Loại:";

            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.Location = new Point(450, 30);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(200, 28);

            lblName.AutoSize = true;
            lblName.Location = new Point(20, 73);
            lblName.Name = "lblName";
            lblName.Text = "Tên sản phẩm:";

            txtName.Location = new Point(125, 70);
            txtName.Name = "txtName";
            txtName.Size = new Size(220, 27);

            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(370, 73);
            lblPrice.Name = "lblPrice";
            lblPrice.Text = "Đơn giá:";

            txtPrice.Location = new Point(450, 70);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(200, 27);
            txtPrice.TextAlign = HorizontalAlignment.Right;

            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(20, 113);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Text = "Số lượng tồn:";

            numQuantity.Location = new Point(125, 110);
            numQuantity.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(220, 27);

            picProductImage.BorderStyle = BorderStyle.FixedSingle;
            picProductImage.Location = new Point(690, 25);
            picProductImage.Name = "picProductImage";
            picProductImage.Size = new Size(170, 120);
            picProductImage.SizeMode = PictureBoxSizeMode.Zoom;
            picProductImage.TabStop = false;

            btnChooseImage.Location = new Point(690, 152);
            btnChooseImage.Name = "btnChooseImage";
            btnChooseImage.Size = new Size(170, 32);
            btnChooseImage.Text = "Chọn ảnh";

            btnAdd.Location = new Point(12, 220);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(120, 36);
            btnAdd.Text = "Thêm mới";

            btnUpdate.Location = new Point(142, 220);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(120, 36);
            btnUpdate.Text = "Cập nhật";

            btnDelete.Location = new Point(272, 220);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(120, 36);
            btnDelete.Text = "Xóa";

            btnClear.Location = new Point(402, 220);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(120, 36);
            btnClear.Text = "Làm mới / Hủy";

            dgvProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProducts.Location = new Point(12, 268);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.Size = new Size(876, 250);

            errorProvider1.ContainerControl = this;

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 530);
            Controls.Add(grpInput);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(btnClear);
            Controls.Add(dgvProducts);
            Name = "Form2";
            Text = "Quản lý sản phẩm";

            grpInput.ResumeLayout(false);
            grpInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)picProductImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        private GroupBox grpInput;
        private Label lblId, lblName, lblCategory, lblPrice, lblQuantity;
        private TextBox txtId, txtName, txtPrice;
        private ComboBox cboCategory;
        private NumericUpDown numQuantity;
        private PictureBox picProductImage;
        private Button btnChooseImage, btnAdd, btnUpdate, btnDelete, btnClear;
        private DataGridView dgvProducts;
        private ErrorProvider errorProvider1;
    }
}
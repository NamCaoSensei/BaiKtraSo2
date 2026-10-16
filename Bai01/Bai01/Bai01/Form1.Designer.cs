#nullable disable
namespace Bai01
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
            grpInput = new GroupBox();
            lblId = new Label();
            lblName = new Label();
            lblCategory = new Label();
            lblPrice = new Label();
            lblQuantity = new Label();
            txtDeviceId = new TextBox();
            txtDeviceName = new TextBox();
            cboCategory = new ComboBox();
            txtPrice = new TextBox();
            numQuantity = new NumericUpDown();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            dgvDevices = new DataGridView();
            errorProvider1 = new ErrorProvider(components);

            grpInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDevices).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();

            // grpInput
            grpInput.Controls.Add(lblId);
            grpInput.Controls.Add(txtDeviceId);
            grpInput.Controls.Add(lblName);
            grpInput.Controls.Add(txtDeviceName);
            grpInput.Controls.Add(lblQuantity);
            grpInput.Controls.Add(numQuantity);
            grpInput.Controls.Add(lblCategory);
            grpInput.Controls.Add(cboCategory);
            grpInput.Controls.Add(lblPrice);
            grpInput.Controls.Add(txtPrice);
            grpInput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpInput.Location = new Point(12, 12);
            grpInput.Name = "grpInput";
            grpInput.Size = new Size(776, 160);
            grpInput.Text = "Thông tin thiết bị";

            // Hàng 1
            lblId.AutoSize = true;
            lblId.Location = new Point(20, 33);
            lblId.Name = "lblId";
            lblId.Text = "Mã thiết bị:";

            txtDeviceId.Location = new Point(120, 30);
            txtDeviceId.Name = "txtDeviceId";
            txtDeviceId.ReadOnly = true;
            txtDeviceId.Size = new Size(230, 27);
            txtDeviceId.TabStop = false;

            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(400, 33);
            lblCategory.Name = "lblCategory";
            lblCategory.Text = "Loại thiết bị:";

            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.Location = new Point(500, 30);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(250, 28);

            // Hàng 2
            lblName.AutoSize = true;
            lblName.Location = new Point(20, 73);
            lblName.Name = "lblName";
            lblName.Text = "Tên thiết bị:";

            txtDeviceName.Location = new Point(120, 70);
            txtDeviceName.Name = "txtDeviceName";
            txtDeviceName.Size = new Size(230, 27);

            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(400, 73);
            lblPrice.Name = "lblPrice";
            lblPrice.Text = "Đơn giá (VNĐ):";

            txtPrice.Location = new Point(500, 70);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(250, 27);
            txtPrice.TextAlign = HorizontalAlignment.Right;

            // Hàng 3
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(20, 113);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Text = "Số lượng tồn:";

            numQuantity.Location = new Point(120, 110);
            numQuantity.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(230, 27);

            // Buttons
            btnAdd.Location = new Point(12, 185);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(120, 36);
            btnAdd.Text = "Thêm mới";

            btnUpdate.Location = new Point(142, 185);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(120, 36);
            btnUpdate.Text = "Cập nhật";

            btnDelete.Location = new Point(272, 185);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(120, 36);
            btnDelete.Text = "Xóa";

            btnClear.Location = new Point(402, 185);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(120, 36);
            btnClear.Text = "Làm mới / Hủy";

            // dgvDevices
            dgvDevices.Anchor = AnchorStyles.Top | AnchorStyles.Bottom
                              | AnchorStyles.Left | AnchorStyles.Right;
            dgvDevices.Location = new Point(12, 235);
            dgvDevices.Name = "dgvDevices";
            dgvDevices.Size = new Size(776, 303);

            // errorProvider1
            errorProvider1.ContainerControl = this;

            // Form1
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 550);
            Controls.Add(grpInput);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(btnClear);
            Controls.Add(dgvDevices);
            MinimumSize = new Size(816, 589);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý danh mục thiết bị điện tử";

            grpInput.ResumeLayout(false);
            grpInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDevices).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        private GroupBox grpInput;
        private Label lblId, lblName, lblCategory, lblPrice, lblQuantity;
        private TextBox txtDeviceId, txtDeviceName, txtPrice;
        private ComboBox cboCategory;
        private NumericUpDown numQuantity;
        private Button btnAdd, btnUpdate, btnDelete, btnClear;
        private DataGridView dgvDevices;
        private ErrorProvider errorProvider1;
    }
}
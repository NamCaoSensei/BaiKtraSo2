using System.ComponentModel;
using System.Globalization;

namespace Bai01
{
    public partial class Form1 : Form
    {
        private readonly BindingList<Device> _devices = new();
        private readonly BindingSource _bs = new();
        private readonly CultureInfo _vn = new("vi-VN");
        private int _nextId = 1;

        public Form1()
        {
            InitializeComponent();

            ConfigureGrid();
            LoadCategories();
            SeedData();

            // Ràng buộc dữ liệu: BindingList -> BindingSource -> DataGridView
            _bs.DataSource = _devices;
            dgvDevices.DataSource = _bs;

            dgvDevices.SelectionChanged += dgvDevices_SelectionChanged;
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnClear.Click += btnClear_Click;

            // Xóa icon lỗi ngay khi người dùng sửa lại
            txtDeviceName.TextChanged += (s, e) => errorProvider1.SetError(txtDeviceName, "");
            txtPrice.TextChanged += (s, e) => errorProvider1.SetError(txtPrice, "");
            cboCategory.SelectedIndexChanged += (s, e) => errorProvider1.SetError(cboCategory, "");

            ClearForm();
        }

        #region Khởi tạo
        private void ConfigureGrid()
        {
            dgvDevices.AutoGenerateColumns = false;
            dgvDevices.AllowUserToAddRows = false;
            dgvDevices.AllowUserToDeleteRows = false;
            dgvDevices.ReadOnly = true;
            dgvDevices.MultiSelect = false;
            dgvDevices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDevices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDevices.RowHeadersVisible = false;
            dgvDevices.BackgroundColor = SystemColors.Window;
            dgvDevices.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvDevices.ColumnHeadersDefaultCellStyle.Font =
                new Font(dgvDevices.Font, FontStyle.Bold);
            dgvDevices.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvDevices.Columns.Clear();

            dgvDevices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colId",
                HeaderText = "Mã thiết bị",
                DataPropertyName = nameof(Device.Id),
                FillWeight = 14
            });
            dgvDevices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colName",
                HeaderText = "Tên thiết bị",
                DataPropertyName = nameof(Device.Name),
                FillWeight = 36
            });
            dgvDevices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCategory",
                HeaderText = "Loại thiết bị",
                DataPropertyName = nameof(Device.Category),
                FillWeight = 20
            });

            var colPrice = new DataGridViewTextBoxColumn
            {
                Name = "colPrice",
                HeaderText = "Đơn giá",
                DataPropertyName = nameof(Device.Price),
                FillWeight = 18
            };
            colPrice.DefaultCellStyle.Format = "N0";
            colPrice.DefaultCellStyle.FormatProvider = _vn;
            colPrice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDevices.Columns.Add(colPrice);

            var colQty = new DataGridViewTextBoxColumn
            {
                Name = "colQuantity",
                HeaderText = "Tồn kho",
                DataPropertyName = nameof(Device.Quantity),
                FillWeight = 12
            };
            colQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDevices.Columns.Add(colQty);
        }

        private void LoadCategories()
        {
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.Items.AddRange(new object[]
            {
                "Điện thoại", "Máy tính bảng", "Laptop", "Tivi", "Phụ kiện"
            });
            cboCategory.SelectedIndex = -1;
        }

        private void SeedData()
        {
            _devices.Add(new Device { Id = NextId(), Name = "iPhone 15", Category = "Điện thoại", Price = 22000000, Quantity = 10 });
            _devices.Add(new Device { Id = NextId(), Name = "Dell XPS 13", Category = "Laptop", Price = 35000000, Quantity = 5 });
            _devices.Add(new Device { Id = NextId(), Name = "Samsung Smart TV 55\"", Category = "Tivi", Price = 15000000, Quantity = 8 });
        }

        private string NextId() => $"TB{_nextId++:000}";
        #endregion

        #region Validation
        private bool TryGetPrice(out decimal price)
        {
            return decimal.TryParse(txtPrice.Text.Trim(),
                NumberStyles.Number, _vn, out price) && price >= 0;
        }

        private bool ValidateInput()
        {
            bool ok = true;
            errorProvider1.Clear();

            if (string.IsNullOrWhiteSpace(txtDeviceName.Text))
            {
                errorProvider1.SetError(txtDeviceName, "Tên thiết bị không được để trống.");
                ok = false;
            }

            if (cboCategory.SelectedIndex < 0)
            {
                errorProvider1.SetError(cboCategory, "Vui lòng chọn loại thiết bị.");
                ok = false;
            }

            if (!TryGetPrice(out _))
            {
                errorProvider1.SetError(txtPrice, "Đơn giá phải là số hợp lệ và không nhỏ hơn 0.");
                ok = false;
            }

            return ok;
        }
        #endregion

        #region Sự kiện
        // Grid -> Controls
        private void dgvDevices_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvDevices.SelectedRows.Count == 0) return;
            if (dgvDevices.SelectedRows[0].DataBoundItem is not Device d) return;

            txtDeviceId.Text = d.Id;
            txtDeviceName.Text = d.Name;
            cboCategory.SelectedItem = d.Category;
            txtPrice.Text = d.Price.ToString("0.##", _vn);
            numQuantity.Value = Math.Clamp(d.Quantity,
                (int)numQuantity.Minimum, (int)numQuantity.Maximum);

            errorProvider1.Clear();
        }

        // Controls -> BindingList -> Grid
        private void btnAdd_Click(object? sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            TryGetPrice(out decimal price);

            _devices.Add(new Device
            {
                Id = NextId(),
                Name = txtDeviceName.Text.Trim(),
                Category = cboCategory.SelectedItem!.ToString()!,
                Price = price,
                Quantity = (int)numQuantity.Value
            });

            ClearForm();
            _bs.MoveLast(); // chọn dòng vừa thêm
        }

        private void btnUpdate_Click(object? sender, EventArgs e)
        {
            if (dgvDevices.SelectedRows.Count == 0 ||
                dgvDevices.SelectedRows[0].DataBoundItem is not Device d)
            {
                MessageBox.Show("Vui lòng chọn thiết bị cần cập nhật.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidateInput()) return;
            TryGetPrice(out decimal price);

            d.Name = txtDeviceName.Text.Trim();
            d.Category = cboCategory.SelectedItem!.ToString()!;
            d.Price = price;
            d.Quantity = (int)numQuantity.Value;
            // INotifyPropertyChanged tự làm Grid cập nhật
        }

        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (dgvDevices.SelectedRows.Count == 0 ||
                dgvDevices.SelectedRows[0].DataBoundItem is not Device d)
            {
                MessageBox.Show("Vui lòng chọn thiết bị cần xóa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var rs = MessageBox.Show($"Bạn có chắc muốn xóa thiết bị \"{d.Name}\" không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                _devices.Remove(d);
                ClearForm();
            }
        }

        private void btnClear_Click(object? sender, EventArgs e) => ClearForm();

        private void ClearForm()
        {
            txtDeviceId.Text = "(Tự động)";
            txtDeviceName.Clear();
            cboCategory.SelectedIndex = -1;
            txtPrice.Clear();
            numQuantity.Value = 0;
            errorProvider1.Clear();
            dgvDevices.ClearSelection();
            txtDeviceName.Focus();
        }
        #endregion
    }
}
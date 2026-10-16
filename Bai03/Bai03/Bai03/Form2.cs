using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Bai03
{
    public partial class Form2 : Form
    {
        private readonly BindingList<Product> _products = new();
        private readonly BindingSource _bs = new();
        private readonly CultureInfo _vn = new("vi-VN");
        private int _nextId = 1;
        private string _currentImagePath = "";

        public Form2()
        {
            InitializeComponent();

            ConfigureGrid();
            LoadCategories();
            SeedData();

            _bs.DataSource = _products;
            dgvProducts.DataSource = _bs;

            dgvProducts.SelectionChanged += dgvProducts_SelectionChanged;
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnClear.Click += (s, e) => ClearForm();
            btnChooseImage.Click += btnChooseImage_Click;

            txtName.TextChanged += (s, e) => errorProvider1.SetError(txtName, "");
            txtPrice.TextChanged += (s, e) => errorProvider1.SetError(txtPrice, "");
            cboCategory.SelectedIndexChanged += (s, e) => errorProvider1.SetError(cboCategory, "");

            ClearForm();
        }

        private void ConfigureGrid()
        {
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.ReadOnly = true;
            dgvProducts.MultiSelect = false;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.BackgroundColor = SystemColors.Window;
            dgvProducts.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvProducts.ColumnHeadersDefaultCellStyle.Font = new Font(dgvProducts.Font, FontStyle.Bold);
            dgvProducts.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvProducts.Columns.Clear();
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "colId", HeaderText = "Mã SP", DataPropertyName = nameof(Product.Id), FillWeight = 10 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "colName", HeaderText = "Tên sản phẩm", DataPropertyName = nameof(Product.Name), FillWeight = 28 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "colCategory", HeaderText = "Loại", DataPropertyName = nameof(Product.Category), FillWeight = 16 });

            var colPrice = new DataGridViewTextBoxColumn
            { Name = "colPrice", HeaderText = "Đơn giá", DataPropertyName = nameof(Product.Price), FillWeight = 16 };
            colPrice.DefaultCellStyle.Format = "N0";
            colPrice.DefaultCellStyle.FormatProvider = _vn;
            colPrice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProducts.Columns.Add(colPrice);

            var colQty = new DataGridViewTextBoxColumn
            { Name = "colQty", HeaderText = "Tồn kho", DataPropertyName = nameof(Product.Quantity), FillWeight = 10 };
            colQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProducts.Columns.Add(colQty);

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "colImage", HeaderText = "Tên file ảnh", DataPropertyName = nameof(Product.ImageFileName), FillWeight = 20 });
        }

        private void LoadCategories()
        {
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.Items.AddRange(new object[]
            { "Thực phẩm", "Đồ uống", "Gia dụng", "Hóa mỹ phẩm", "Đồ dùng cá nhân" });
            cboCategory.SelectedIndex = -1;
        }

        private void SeedData()
        {
            _products.Add(new Product { Id = NextId(), Name = "Gạo ST25 5kg", Category = "Thực phẩm", Price = 140000, Quantity = 40 });
            _products.Add(new Product { Id = NextId(), Name = "Nước ngọt lon 330ml", Category = "Đồ uống", Price = 10000, Quantity = 200 });
            _products.Add(new Product { Id = NextId(), Name = "Nước rửa chén 750ml", Category = "Gia dụng", Price = 38000, Quantity = 60 });
        }

        private string NextId() => $"SP{_nextId++:000}";

        private void btnChooseImage_Click(object? sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Title = "Chọn ảnh sản phẩm",
                Filter = "Ảnh (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp",
                CheckFileExists = true
            };

            if (ofd.ShowDialog() != DialogResult.OK) return;

            if (ShowImage(ofd.FileName))
                _currentImagePath = ofd.FileName;
        }

        private bool ShowImage(string? path)
        {
            var old = picProductImage.Image;
            picProductImage.Image = null;
            old?.Dispose();

            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path)) return false;

            try
            {
                using var fs = File.OpenRead(path);
                using var img = Image.FromStream(fs);
                picProductImage.Image = new Bitmap(img);
                return true;
            }
            catch
            {
                MessageBox.Show("Không thể mở file ảnh này.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool TryGetPrice(out decimal price) =>
            decimal.TryParse(txtPrice.Text.Trim(), NumberStyles.Number, _vn, out price) && price >= 0;

        private bool ValidateInput()
        {
            bool ok = true;
            errorProvider1.Clear();

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorProvider1.SetError(txtName, "Tên sản phẩm không được để trống.");
                ok = false;
            }
            if (cboCategory.SelectedIndex < 0)
            {
                errorProvider1.SetError(cboCategory, "Vui lòng chọn loại sản phẩm.");
                ok = false;
            }
            if (!TryGetPrice(out _))
            {
                errorProvider1.SetError(txtPrice, "Đơn giá phải là số hợp lệ và không nhỏ hơn 0.");
                ok = false;
            }
            return ok;
        }

        private void dgvProducts_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0) return;
            if (dgvProducts.SelectedRows[0].DataBoundItem is not Product p) return;

            txtId.Text = p.Id;
            txtName.Text = p.Name;
            cboCategory.SelectedItem = p.Category;
            txtPrice.Text = p.Price.ToString("0.##", _vn);
            numQuantity.Value = Math.Clamp(p.Quantity, (int)numQuantity.Minimum, (int)numQuantity.Maximum);

            _currentImagePath = p.ImagePath;
            ShowImage(p.ImagePath);
            errorProvider1.Clear();
        }

        private void btnAdd_Click(object? sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            TryGetPrice(out decimal price);

            _products.Add(new Product
            {
                Id = NextId(),
                Name = txtName.Text.Trim(),
                Category = cboCategory.SelectedItem!.ToString()!,
                Price = price,
                Quantity = (int)numQuantity.Value,
                ImagePath = _currentImagePath
            });

            ClearForm();
            _bs.MoveLast();
        }

        private void btnUpdate_Click(object? sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0 ||
                dgvProducts.SelectedRows[0].DataBoundItem is not Product p)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần cập nhật.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!ValidateInput()) return;
            TryGetPrice(out decimal price);

            p.Name = txtName.Text.Trim();
            p.Category = cboCategory.SelectedItem!.ToString()!;
            p.Price = price;
            p.Quantity = (int)numQuantity.Value;
            p.ImagePath = _currentImagePath;
        }

        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0 ||
                dgvProducts.SelectedRows[0].DataBoundItem is not Product p)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var rs = MessageBox.Show($"Bạn có chắc muốn xóa sản phẩm \"{p.Name}\" không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                _products.Remove(p);
                ClearForm();
            }
        }

        private void ClearForm()
        {
            txtId.Text = "(Tự động)";
            txtName.Clear();
            cboCategory.SelectedIndex = -1;
            txtPrice.Clear();
            numQuantity.Value = 0;
            _currentImagePath = "";
            ShowImage(null);
            errorProvider1.Clear();
            dgvProducts.ClearSelection();
            txtName.Focus();
        }
    }

    public class Product : INotifyPropertyChanged
    {
        private string _id = "";
        private string _name = "";
        private string _category = "";
        private decimal _price;
        private int _quantity;
        private string _imagePath = "";

        public string Id { get => _id; set => Set(ref _id, value); }
        public string Name { get => _name; set => Set(ref _name, value); }
        public string Category { get => _category; set => Set(ref _category, value); }
        public decimal Price { get => _price; set => Set(ref _price, value); }
        public int Quantity { get => _quantity; set => Set(ref _quantity, value); }

        public string ImagePath
        {
            get => _imagePath;
            set
            {
                if (Set(ref _imagePath, value))
                    OnPropertyChanged(nameof(ImageFileName));
            }
        }

        public string ImageFileName => string.IsNullOrEmpty(_imagePath) ? "" : Path.GetFileName(_imagePath);

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string prop) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        private bool Set<T>(ref T field, T value, [CallerMemberName] string? prop = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(prop!);
            return true;
        }
    }
}
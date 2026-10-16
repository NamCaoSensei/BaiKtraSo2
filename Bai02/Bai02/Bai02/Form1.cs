using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace Bai02
{
    public partial class Form1 : Form
    {
        private readonly BindingList<Product> _products = new();
        private readonly BindingSource _bs = new();
        private readonly CultureInfo _vn = new("vi-VN");
        private int _nextId = 1;
        private string _currentImagePath = "";
        private const char Sep = ';';

        public Form1()
        {
            InitializeComponent();

            SetupIcons();
            ConfigureGrid();
            LoadCategories();
            SeedData();

            _bs.DataSource = _products;
            dgvProducts.DataSource = _bs;

            _products.ListChanged += (s, e) => UpdateStatus();
            UpdateStatus();

            dgvProducts.SelectionChanged += dgvProducts_SelectionChanged;
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnClear.Click += (s, e) => ClearForm();
            btnChooseImage.Click += btnChooseImage_Click;

            mnuOpen.Click += (s, e) => OpenFile();
            tsbOpen.Click += (s, e) => OpenFile();
            mnuSaveReport.Click += (s, e) => SaveReport();
            tsbSaveReport.Click += (s, e) => SaveReport();
            mnuImport.Click += (s, e) => ImportCsv();
            tsbImport.Click += (s, e) => ImportCsv();
            mnuExport.Click += (s, e) => ExportCsv();
            tsbExport.Click += (s, e) => ExportCsv();
            mnuExit.Click += (s, e) => Close();
            tsbExit.Click += (s, e) => Close();

            timer1.Tick += (s, e) => tslTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            tslTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            FormClosing += Form1_FormClosing;

            txtName.TextChanged += (s, e) => errorProvider1.SetError(txtName, "");
            txtPrice.TextChanged += (s, e) => errorProvider1.SetError(txtPrice, "");
            cboCategory.SelectedIndexChanged += (s, e) => errorProvider1.SetError(cboCategory, "");

            ClearForm();
        }

        private static Bitmap MakeIcon(string glyph, Color color)
        {
            var bmp = new Bitmap(24, 24);
            using var g = Graphics.FromImage(bmp);
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            using var f = new Font("Segoe MDL2 Assets", 14f);
            using var b = new SolidBrush(color);
            var size = g.MeasureString(glyph, f);
            g.DrawString(glyph, f, b, (24 - size.Width) / 2, (24 - size.Height) / 2);
            return bmp;
        }

        private void SetupIcons()
        {
            var iOpen = MakeIcon("\uE8E5", Color.SteelBlue);
            var iSave = MakeIcon("\uE74E", Color.SeaGreen);
            var iImport = MakeIcon("\uE896", Color.DarkOrange);
            var iExport = MakeIcon("\uE898", Color.MediumPurple);
            var iExit = MakeIcon("\uE7E8", Color.Firebrick);

            tsbOpen.Image = mnuOpen.Image = iOpen;
            tsbSaveReport.Image = mnuSaveReport.Image = iSave;
            tsbImport.Image = mnuImport.Image = iImport;
            tsbExport.Image = mnuExport.Image = iExport;
            tsbExit.Image = mnuExit.Image = iExit;
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
            { "Điện thoại", "Máy tính bảng", "Laptop", "Tivi", "Phụ kiện" });
            cboCategory.SelectedIndex = -1;
        }

        private void SeedData()
        {
            _products.Add(new Product { Id = NextId(), Name = "iPhone 15", Category = "Điện thoại", Price = 22000000, Quantity = 10 });
            _products.Add(new Product { Id = NextId(), Name = "Dell XPS 13", Category = "Laptop", Price = 35000000, Quantity = 5 });
        }

        private string NextId() => $"SP{_nextId++:000}";

        private void SyncNextId()
        {
            int max = 0;
            foreach (var p in _products)
                if (p.Id.StartsWith("SP", StringComparison.OrdinalIgnoreCase) &&
                    int.TryParse(p.Id.AsSpan(2), out int n) && n > max)
                    max = n;
            _nextId = max + 1;
        }

        private void UpdateStatus()
        {
            int totalQty = _products.Sum(p => p.Quantity);
            decimal totalValue = _products.Sum(p => p.Price * p.Quantity);

            tslTotalQty.Text = $"Tổng số lượng: {totalQty.ToString("N0", _vn)}";
            tslTotalValue.Text = $"Tổng giá trị kho: {totalValue.ToString("N0", _vn)} đ";
        }

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

        private static string Esc(string s)
        {
            if (s.Contains(Sep) || s.Contains('"') || s.Contains('\n') || s.Contains('\r'))
                return "\"" + s.Replace("\"", "\"\"") + "\"";
            return s;
        }

        private void ExportCsv()
        {
            using var sfd = new SaveFileDialog
            {
                Title = "Xuất dữ liệu kho ra CSV",
                Filter = "CSV (*.csv)|*.csv",
                FileName = $"Kho_{DateTime.Now:yyyyMMdd_HHmm}.csv",
                OverwritePrompt = true
            };
            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                var sb = new StringBuilder();
                sb.AppendLine(string.Join(Sep, "Id", "Name", "Category", "Price", "Quantity", "ImagePath"));
                foreach (var p in _products)
                {
                    sb.AppendLine(string.Join(Sep,
                        Esc(p.Id), Esc(p.Name), Esc(p.Category),
                        p.Price.ToString(CultureInfo.InvariantCulture),
                        p.Quantity.ToString(),
                        Esc(p.ImagePath)));
                }
                File.WriteAllText(sfd.FileName, sb.ToString(), new UTF8Encoding(true));

                MessageBox.Show($"Đã xuất {_products.Count} sản phẩm.", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể ghi file: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static List<string> ParseCsvLine(string line, char sep)
        {
            var result = new List<string>();
            var cur = new StringBuilder();
            bool inQuotes = false;

            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];
                if (inQuotes)
                {
                    if (c == '"')
                    {
                        if (i + 1 < line.Length && line[i + 1] == '"') { cur.Append('"'); i++; }
                        else inQuotes = false;
                    }
                    else cur.Append(c);
                }
                else if (c == '"') inQuotes = true;
                else if (c == sep) { result.Add(cur.ToString()); cur.Clear(); }
                else cur.Append(c);
            }
            result.Add(cur.ToString());
            return result;
        }

        private void ImportCsv()
        {
            using var ofd = new OpenFileDialog
            {
                Title = "Chọn file CSV để nhập",
                Filter = "CSV (*.csv)|*.csv|Text (*.txt)|*.txt|Tất cả (*.*)|*.*",
                CheckFileExists = true
            };
            if (ofd.ShowDialog() != DialogResult.OK) return;
            LoadFromFile(ofd.FileName);
        }

        private void OpenFile()
        {
            using var ofd = new OpenFileDialog
            {
                Title = "Mở file dữ liệu kho",
                Filter = "Dữ liệu kho (*.csv;*.txt)|*.csv;*.txt|Tất cả (*.*)|*.*",
                CheckFileExists = true
            };
            if (ofd.ShowDialog() != DialogResult.OK) return;
            LoadFromFile(ofd.FileName);
        }

        private void LoadFromFile(string path)
        {
            try
            {
                var lines = File.ReadAllLines(path, Encoding.UTF8)
                                .Where(l => !string.IsNullOrWhiteSpace(l)).ToList();
                if (lines.Count == 0)
                {
                    MessageBox.Show("File rỗng.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                char sep = lines[0].Contains(';') ? ';' : ',';
                int start = lines[0].StartsWith("Id", StringComparison.OrdinalIgnoreCase) ? 1 : 0;

                var loaded = new List<Product>();
                int errors = 0;

                for (int i = start; i < lines.Count; i++)
                {
                    var f = ParseCsvLine(lines[i], sep);
                    if (f.Count < 5 ||
                        !decimal.TryParse(f[3], NumberStyles.Number, CultureInfo.InvariantCulture, out decimal price) ||
                        !int.TryParse(f[4], out int qty) || price < 0 || qty < 0)
                    {
                        errors++;
                        continue;
                    }

                    loaded.Add(new Product
                    {
                        Id = f[0].Trim(),
                        Name = f[1].Trim(),
                        Category = f[2].Trim(),
                        Price = price,
                        Quantity = qty,
                        ImagePath = f.Count > 5 ? f[5].Trim() : ""
                    });
                }

                _products.RaiseListChangedEvents = false;
                _products.Clear();
                foreach (var p in loaded) _products.Add(p);
                _products.RaiseListChangedEvents = true;
                SyncNextId();
                foreach (var p in _products)
                    if (string.IsNullOrEmpty(p.Id)) p.Id = NextId();
                _products.ResetBindings();

                ClearForm();

                MessageBox.Show($"Đã nạp {loaded.Count} sản phẩm" +
                                (errors > 0 ? $", bỏ qua {errors} dòng lỗi." : "."),
                    "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể đọc file: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveReport()
        {
            using var sfd = new SaveFileDialog
            {
                Title = "Lưu báo cáo tổng hợp",
                Filter = "Text (*.txt)|*.txt",
                FileName = $"BaoCao_Kho_{DateTime.Now:yyyyMMdd_HHmm}.txt"
            };
            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                var sb = new StringBuilder();
                sb.AppendLine("BÁO CÁO TỔNG HỢP KHO HÀNG");
                sb.AppendLine($"Thời gian lập: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                sb.AppendLine(new string('-', 80));
                sb.AppendLine($"{"Mã",-8}{"Tên sản phẩm",-30}{"Loại",-16}{"Đơn giá",15}{"SL",8}");
                sb.AppendLine(new string('-', 80));

                foreach (var p in _products)
                    sb.AppendLine($"{p.Id,-8}{p.Name,-30}{p.Category,-16}{p.Price.ToString("N0", _vn),15}{p.Quantity,8}");

                sb.AppendLine(new string('-', 80));
                sb.AppendLine($"Tổng số sản phẩm : {_products.Count}");
                sb.AppendLine($"Tổng số lượng    : {_products.Sum(p => p.Quantity).ToString("N0", _vn)}");
                sb.AppendLine($"Tổng giá trị kho : {_products.Sum(p => p.Price * p.Quantity).ToString("N0", _vn)} đ");

                File.WriteAllText(sfd.FileName, sb.ToString(), new UTF8Encoding(true));
                MessageBox.Show("Đã lưu báo cáo.", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể ghi file: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            var rs = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?",
                "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.No) e.Cancel = true;
        }
    }
}
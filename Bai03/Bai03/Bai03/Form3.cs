using System.ComponentModel;
using System.Globalization;

namespace Bai03
{
    public partial class Form3 : Form
    {
        private readonly CultureInfo _vn = new("vi-VN");
        private readonly BindingList<SyncLogRow> _syncLog = new();
        private CancellationTokenSource? _syncCts;

        public Form3()
        {
            InitializeComponent();

            ConfigureRevenueGrid();
            ConfigureSyncGrid();
            dgvSyncLog.DataSource = _syncLog;

            btnLoadReport.Click += btnLoadReport_Click;
            btnStartSync.Click += (s, e) => StartSync();
            btnStopSync.Click += (s, e) => StopSync();
            FormClosing += (s, e) => StopSync();

            btnStopSync.Enabled = false;
        }

        private void ConfigureRevenueGrid()
        {
            dgvRevenue.AutoGenerateColumns = false;
            dgvRevenue.AllowUserToAddRows = false;
            dgvRevenue.ReadOnly = true;
            dgvRevenue.RowHeadersVisible = false;
            dgvRevenue.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRevenue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRevenue.BackgroundColor = SystemColors.Window;
            dgvRevenue.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;

            dgvRevenue.Columns.Clear();

            var colDate = new DataGridViewTextBoxColumn
            { HeaderText = "Ngày", DataPropertyName = nameof(RevenueRow.Date) };
            colDate.DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvRevenue.Columns.Add(colDate);

            var colOrders = new DataGridViewTextBoxColumn
            { HeaderText = "Số đơn", DataPropertyName = nameof(RevenueRow.Orders) };
            colOrders.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRevenue.Columns.Add(colOrders);

            var colRevenue = new DataGridViewTextBoxColumn
            { HeaderText = "Doanh thu (đ)", DataPropertyName = nameof(RevenueRow.Revenue) };
            colRevenue.DefaultCellStyle.Format = "N0";
            colRevenue.DefaultCellStyle.FormatProvider = _vn;
            colRevenue.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvRevenue.Columns.Add(colRevenue);

            var colProfit = new DataGridViewTextBoxColumn
            { HeaderText = "Lợi nhuận (đ)", DataPropertyName = nameof(RevenueRow.Profit) };
            colProfit.DefaultCellStyle.Format = "N0";
            colProfit.DefaultCellStyle.FormatProvider = _vn;
            colProfit.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvRevenue.Columns.Add(colProfit);
        }

        private void ConfigureSyncGrid()
        {
            dgvSyncLog.AutoGenerateColumns = false;
            dgvSyncLog.AllowUserToAddRows = false;
            dgvSyncLog.ReadOnly = true;
            dgvSyncLog.RowHeadersVisible = false;
            dgvSyncLog.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSyncLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSyncLog.BackgroundColor = SystemColors.Window;
            dgvSyncLog.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;

            dgvSyncLog.Columns.Clear();

            var colTime = new DataGridViewTextBoxColumn
            { HeaderText = "Thời gian", DataPropertyName = nameof(SyncLogRow.Time) };
            colTime.DefaultCellStyle.Format = "HH:mm:ss";
            dgvSyncLog.Columns.Add(colTime);

            var colRate = new DataGridViewTextBoxColumn
            { HeaderText = "Tỷ giá USD/VND", DataPropertyName = nameof(SyncLogRow.Rate) };
            colRate.DefaultCellStyle.Format = "N0";
            colRate.DefaultCellStyle.FormatProvider = _vn;
            colRate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvSyncLog.Columns.Add(colRate);

            var colNew = new DataGridViewTextBoxColumn
            { HeaderText = "Đơn mới", DataPropertyName = nameof(SyncLogRow.NewOrders) };
            colNew.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSyncLog.Columns.Add(colNew);

            var colTotal = new DataGridViewTextBoxColumn
            { HeaderText = "Tổng đơn", DataPropertyName = nameof(SyncLogRow.TotalOrders) };
            colTotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSyncLog.Columns.Add(colTotal);
        }

        private async void btnLoadReport_Click(object? sender, EventArgs e)
        {
            var main = MdiParent as Form1;

            btnLoadReport.Enabled = false;
            lblReportState.Text = "Đang xử lý... 0%";
            main?.BeginBusy("Đang tải báo cáo doanh thu...");

            var progress = new Progress<int>(v =>
            {
                main?.SetProgress(v);
                if (!IsDisposed) lblReportState.Text = $"Đang xử lý... {v}%";
            });

            try
            {
                var data = await Task.Run(() => BuildRevenueData(progress));

                if (IsDisposed) return;

                dgvRevenue.DataSource = data;
                decimal totalRevenue = data.Sum(r => r.Revenue);
                decimal totalProfit = data.Sum(r => r.Profit);
                lblTotal.Text = $"Tổng doanh thu: {totalRevenue.ToString("N0", _vn)} đ    |    Tổng lợi nhuận: {totalProfit.ToString("N0", _vn)} đ";
                lblReportState.Text = "Hoàn tất.";
            }
            catch (Exception ex)
            {
                if (!IsDisposed)
                {
                    lblReportState.Text = "Lỗi.";
                    MessageBox.Show("Không thể tải báo cáo: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                main?.EndBusy("Sẵn sàng");
                if (!IsDisposed) btnLoadReport.Enabled = true;
            }
        }

        private static List<RevenueRow> BuildRevenueData(IProgress<int> progress)
        {
            var rows = new List<RevenueRow>();
            var start = DateTime.Today.AddDays(-29);
            const int days = 30;

            for (int i = 0; i < days; i++)
            {
                int orders = Random.Shared.Next(40, 160);
                decimal revenue = 0;
                for (int k = 0; k < orders; k++)
                    revenue += Random.Shared.Next(20, 800) * 1000m;

                rows.Add(new RevenueRow
                {
                    Date = start.AddDays(i),
                    Orders = orders,
                    Revenue = revenue,
                    Profit = Math.Round(revenue * (decimal)(0.08 + Random.Shared.NextDouble() * 0.1), 0)
                });

                Thread.Sleep(130);
                progress.Report((i + 1) * 100 / days);
            }

            return rows;
        }

        private void StartSync()
        {
            if (_syncCts != null) return;

            _syncCts = new CancellationTokenSource();
            var token = _syncCts.Token;

            btnStartSync.Enabled = false;
            btnStopSync.Enabled = true;

            Task.Run(() => SyncLoopAsync(token));
        }

        private void StopSync()
        {
            if (_syncCts == null) return;

            _syncCts.Cancel();
            _syncCts.Dispose();
            _syncCts = null;

            btnStartSync.Enabled = true;
            btnStopSync.Enabled = false;
        }

        private async Task SyncLoopAsync(CancellationToken token)
        {
            decimal rate = 25400m;
            int totalOrders = 0;

            try
            {
                while (!token.IsCancellationRequested)
                {
                    await Task.Delay(2000, token);

                    rate += Random.Shared.Next(-50, 51);
                    int newOrders = Random.Shared.Next(0, 8);
                    totalOrders += newOrders;

                    PushToUi(rate, newOrders, totalOrders, DateTime.Now);
                }
            }
            catch (OperationCanceledException)
            {
            }
        }

        private void PushToUi(decimal rate, int newOrders, int totalOrders, DateTime time)
        {
            if (IsDisposed || Disposing) return;

            try
            {
                if (InvokeRequired)
                    Invoke(new Action(() => ApplySync(rate, newOrders, totalOrders, time)));
                else
                    ApplySync(rate, newOrders, totalOrders, time);
            }
            catch (ObjectDisposedException)
            {
            }
            catch (InvalidOperationException)
            {
            }
        }

        private void ApplySync(decimal rate, int newOrders, int totalOrders, DateTime time)
        {
            lblRate.Text = $"Tỷ giá USD/VND: {rate.ToString("N0", _vn)}";
            lblOrders.Text = $"Đơn hàng mới: {newOrders}   (tổng: {totalOrders})";

            _syncLog.Insert(0, new SyncLogRow
            {
                Time = time,
                Rate = rate,
                NewOrders = newOrders,
                TotalOrders = totalOrders
            });
            while (_syncLog.Count > 100)
                _syncLog.RemoveAt(_syncLog.Count - 1);

            (MdiParent as Form1)?.SetStatus($"Đồng bộ lúc {time:HH:mm:ss}");
        }
    }

    public class RevenueRow
    {
        public DateTime Date { get; set; }
        public int Orders { get; set; }
        public decimal Revenue { get; set; }
        public decimal Profit { get; set; }
    }

    public class SyncLogRow
    {
        public DateTime Time { get; set; }
        public decimal Rate { get; set; }
        public int NewOrders { get; set; }
        public int TotalOrders { get; set; }
    }
}
#nullable disable
namespace Bai03
{
    partial class Form3
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
            grpReport = new GroupBox();
            btnLoadReport = new Button();
            lblReportState = new Label();
            dgvRevenue = new DataGridView();
            lblTotal = new Label();
            grpSync = new GroupBox();
            btnStartSync = new Button();
            btnStopSync = new Button();
            lblRate = new Label();
            lblOrders = new Label();
            dgvSyncLog = new DataGridView();

            grpReport.SuspendLayout();
            grpSync.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRevenue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSyncLog).BeginInit();
            SuspendLayout();

            grpReport.Controls.Add(btnLoadReport);
            grpReport.Controls.Add(lblReportState);
            grpReport.Controls.Add(dgvRevenue);
            grpReport.Controls.Add(lblTotal);
            grpReport.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpReport.Location = new Point(12, 10);
            grpReport.Name = "grpReport";
            grpReport.Size = new Size(796, 290);
            grpReport.Text = "Báo cáo doanh thu";

            btnLoadReport.Location = new Point(12, 25);
            btnLoadReport.Name = "btnLoadReport";
            btnLoadReport.Size = new Size(230, 36);
            btnLoadReport.Text = "Tải Báo Cáo Doanh Thu";

            lblReportState.AutoSize = true;
            lblReportState.Location = new Point(256, 33);
            lblReportState.Name = "lblReportState";
            lblReportState.Text = "Chưa tải dữ liệu.";

            dgvRevenue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvRevenue.Location = new Point(12, 72);
            dgvRevenue.Name = "dgvRevenue";
            dgvRevenue.Size = new Size(772, 180);

            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(12, 260);
            lblTotal.Name = "lblTotal";
            lblTotal.Text = "Tổng doanh thu: 0 đ";

            grpSync.Controls.Add(btnStartSync);
            grpSync.Controls.Add(btnStopSync);
            grpSync.Controls.Add(lblRate);
            grpSync.Controls.Add(lblOrders);
            grpSync.Controls.Add(dgvSyncLog);
            grpSync.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpSync.Location = new Point(12, 310);
            grpSync.Name = "grpSync";
            grpSync.Size = new Size(796, 280);
            grpSync.Text = "Đồng bộ dữ liệu thời gian thực (2 giây/lần)";

            btnStartSync.Location = new Point(12, 25);
            btnStartSync.Name = "btnStartSync";
            btnStartSync.Size = new Size(130, 36);
            btnStartSync.Text = "Bắt đầu";

            btnStopSync.Location = new Point(152, 25);
            btnStopSync.Name = "btnStopSync";
            btnStopSync.Size = new Size(130, 36);
            btnStopSync.Text = "Dừng";

            lblRate.AutoSize = true;
            lblRate.Location = new Point(310, 22);
            lblRate.Name = "lblRate";
            lblRate.Text = "Tỷ giá USD/VND: --";

            lblOrders.AutoSize = true;
            lblOrders.Location = new Point(310, 46);
            lblOrders.Name = "lblOrders";
            lblOrders.Text = "Đơn hàng mới: --";

            dgvSyncLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSyncLog.Location = new Point(12, 75);
            dgvSyncLog.Name = "dgvSyncLog";
            dgvSyncLog.Size = new Size(772, 195);

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(820, 600);
            Controls.Add(grpReport);
            Controls.Add(grpSync);
            Name = "Form3";
            Text = "Báo cáo thống kê và đồng bộ";

            grpReport.ResumeLayout(false);
            grpReport.PerformLayout();
            grpSync.ResumeLayout(false);
            grpSync.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRevenue).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSyncLog).EndInit();
            ResumeLayout(false);
        }

        private GroupBox grpReport, grpSync;
        private Button btnLoadReport, btnStartSync, btnStopSync;
        private Label lblReportState, lblTotal, lblRate, lblOrders;
        private DataGridView dgvRevenue, dgvSyncLog;
    }
}
#nullable disable
namespace Bai03
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
            mnuLogout = new ToolStripMenuItem();
            mnuExit = new ToolStripMenuItem();
            mnuCatalog = new ToolStripMenuItem();
            mnuProducts = new ToolStripMenuItem();
            mnuInOut = new ToolStripMenuItem();
            mnuReport = new ToolStripMenuItem();
            mnuRevenue = new ToolStripMenuItem();
            mnuWindow = new ToolStripMenuItem();
            mnuCascade = new ToolStripMenuItem();
            mnuTileH = new ToolStripMenuItem();
            mnuTileV = new ToolStripMenuItem();

            statusStrip1 = new StatusStrip();
            tslUser = new ToolStripStatusLabel();
            tslStatus = new ToolStripStatusLabel();
            tslSpring = new ToolStripStatusLabel();
            tspbMain = new ToolStripProgressBar();

            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();

            menuStrip1.Items.AddRange(new ToolStripItem[] { mnuSystem, mnuCatalog, mnuReport, mnuWindow });
            menuStrip1.MdiWindowListItem = mnuWindow;
            menuStrip1.Name = "menuStrip1";

            mnuSystem.DropDownItems.AddRange(new ToolStripItem[] { mnuLogout, mnuExit });
            mnuSystem.Name = "mnuSystem";
            mnuSystem.Text = "Hệ thống";

            mnuLogout.Name = "mnuLogout";
            mnuLogout.Text = "Đăng xuất";

            mnuExit.Name = "mnuExit";
            mnuExit.Text = "Thoát";

            mnuCatalog.DropDownItems.AddRange(new ToolStripItem[] { mnuProducts, mnuInOut });
            mnuCatalog.Name = "mnuCatalog";
            mnuCatalog.Text = "Danh mục";

            mnuProducts.Name = "mnuProducts";
            mnuProducts.Text = "Quản lý Sản phẩm";

            mnuInOut.Name = "mnuInOut";
            mnuInOut.Text = "Quản lý Nhập xuất";

            mnuReport.DropDownItems.AddRange(new ToolStripItem[] { mnuRevenue });
            mnuReport.Name = "mnuReport";
            mnuReport.Text = "Báo cáo";

            mnuRevenue.Name = "mnuRevenue";
            mnuRevenue.Text = "Thống kê Doanh thu";

            mnuWindow.DropDownItems.AddRange(new ToolStripItem[] { mnuCascade, mnuTileH, mnuTileV });
            mnuWindow.Name = "mnuWindow";
            mnuWindow.Text = "Cửa sổ";

            mnuCascade.Name = "mnuCascade";
            mnuCascade.Text = "Cascade";

            mnuTileH.Name = "mnuTileH";
            mnuTileH.Text = "Tile Horizontal";

            mnuTileV.Name = "mnuTileV";
            mnuTileV.Text = "Tile Vertical";

            statusStrip1.Items.AddRange(new ToolStripItem[] { tslUser, tslStatus, tslSpring, tspbMain });
            statusStrip1.Name = "statusStrip1";

            tslUser.BorderSides = ToolStripStatusLabelBorderSides.Right;
            tslUser.Name = "tslUser";
            tslUser.Text = "Người dùng:";

            tslStatus.Name = "tslStatus";
            tslStatus.Text = "Sẵn sàng";

            tslSpring.Name = "tslSpring";
            tslSpring.Spring = true;

            tspbMain.Name = "tspbMain";
            tspbMain.Size = new Size(200, 18);
            tspbMain.Visible = false;

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 700);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hệ thống quản lý siêu thị";
            WindowState = FormWindowState.Maximized;

            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private MenuStrip menuStrip1;
        private ToolStripMenuItem mnuSystem, mnuLogout, mnuExit;
        private ToolStripMenuItem mnuCatalog, mnuProducts, mnuInOut;
        private ToolStripMenuItem mnuReport, mnuRevenue;
        private ToolStripMenuItem mnuWindow, mnuCascade, mnuTileH, mnuTileV;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel tslUser, tslStatus, tslSpring;
        private ToolStripProgressBar tspbMain;
    }
}
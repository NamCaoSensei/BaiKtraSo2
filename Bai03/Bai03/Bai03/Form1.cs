namespace Bai03
{
    public partial class Form1 : Form
    {
        private bool _loggedIn = true;
        private readonly string _userName = Environment.UserName;

        public Form1()
        {
            InitializeComponent();

            mnuProducts.Click += (s, e) => OpenChild<Form2>();
            mnuInOut.Click += (s, e) => OpenChild<Form2>();
            mnuRevenue.Click += (s, e) => OpenChild<Form3>();

            mnuCascade.Click += (s, e) => LayoutMdi(MdiLayout.Cascade);
            mnuTileH.Click += (s, e) => LayoutMdi(MdiLayout.TileHorizontal);
            mnuTileV.Click += (s, e) => LayoutMdi(MdiLayout.TileVertical);

            mnuLogout.Click += mnuLogout_Click;
            mnuExit.Click += (s, e) => Close();

            UpdateLoginState();
        }

        private void OpenChild<T>() where T : Form, new()
        {
            foreach (var child in MdiChildren)
            {
                if (child is T)
                {
                    if (child.WindowState == FormWindowState.Minimized)
                        child.WindowState = FormWindowState.Normal;
                    child.Activate();
                    return;
                }
            }

            var frm = new T { MdiParent = this };
            frm.Show();
        }

        private void mnuLogout_Click(object? sender, EventArgs e)
        {
            if (_loggedIn)
            {
                var rs = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs != DialogResult.Yes) return;

                foreach (var child in MdiChildren.ToArray())
                    child.Close();

                _loggedIn = false;
            }
            else
            {
                _loggedIn = true;
            }

            UpdateLoginState();
        }

        private void UpdateLoginState()
        {
            tslUser.Text = _loggedIn ? $"Người dùng: {_userName}" : "Chưa đăng nhập";
            mnuLogout.Text = _loggedIn ? "Đăng xuất" : "Đăng nhập";
            mnuCatalog.Enabled = _loggedIn;
            mnuReport.Enabled = _loggedIn;
            mnuWindow.Enabled = _loggedIn;
        }

        public void BeginBusy(string message)
        {
            tslStatus.Text = message;
            tspbMain.Value = 0;
            tspbMain.Visible = true;
        }

        public void SetProgress(int value)
        {
            tspbMain.Value = Math.Clamp(value, 0, 100);
        }

        public void EndBusy(string message)
        {
            tspbMain.Visible = false;
            tspbMain.Value = 0;
            tslStatus.Text = message;
        }

        public void SetStatus(string message)
        {
            tslStatus.Text = message;
        }
    }
}
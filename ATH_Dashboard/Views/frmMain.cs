

namespace ATH_Dashboard.Views
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKhachHang frmCustomer = new frmKhachHang();
            frmCustomer.Show();
        }

        private void servicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDichVu frmDichVu = new frmDichVu();
            frmDichVu.Show();
        }

        private void billToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHoaDon frmHoaDon = new frmHoaDon();
            frmHoaDon.Show();
        }

        private void staffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhanVien frmNhanVien = new frmNhanVien();
            frmNhanVien.Show();
        }

        private void itemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMatHang frmMatHang = new frmMatHang();
            frmMatHang.Show();
        }
    }
}

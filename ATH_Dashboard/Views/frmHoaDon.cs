using ATH_Dashboard.Connection;
using ATH_Dashboard.Model;
using System.Data;

namespace ATH_Dashboard.Views
{
    public partial class frmHoaDon : Form
    {
        HoaDonDAL hddal;
        public frmHoaDon()
        {
            InitializeComponent();
            hddal = new HoaDonDAL();
        }
        public void showAllHoaDon()
        {
            DataTable dataTable = hddal.getAllHoaDon();
            dataGridViewHoaDon.DataSource = dataTable;
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            showAllHoaDon();
        }

        private void dataGridViewHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                txtMaHD.Text = dataGridViewHoaDon.Rows[index].Cells["MaHD"].Value.ToString();
                dateTimePickerNgayXuat.Text = dataGridViewHoaDon.Rows[index].Cells["NgayXuat"].Value.ToString();
                txtMaKhach.Text = dataGridViewHoaDon.Rows[index].Cells["MaKhach"].Value.ToString();
                txtMaHang.Text = dataGridViewHoaDon.Rows[index].Cells["MaHang"].Value.ToString();
                txtMaNV.Text = dataGridViewHoaDon.Rows[index].Cells["MaNV"].Value.ToString();
                txtTongTien.Text = dataGridViewHoaDon.Rows[index].Cells["TongTien"].Value.ToString();

            }
        }
        private void __setDataIntoModel(HoaDon hoaDon)
        {
            hoaDon.MaHD = txtMaHD.Text;
            hoaDon.NgayXuat = DateTime.Parse(dateTimePickerNgayXuat.Text);
            hoaDon.MaKhach = txtMaKhach.Text;
            hoaDon.MaHang = txtMaHang.Text;
            hoaDon.MaNV = txtMaNV.Text;
            hoaDon.TongTien = float.Parse(txtTongTien.Text);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            HoaDon hoaDon = new HoaDon();
            this.__setDataIntoModel(hoaDon);
            if (hddal.insertHoaDon(hoaDon))
            {
                showAllHoaDon();
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra! Hãy xem lại các dữ liệu nhập vào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            HoaDon hoaDon = new HoaDon();
            this.__setDataIntoModel(hoaDon);
            if (hddal.updateHoaDon(hoaDon))
            {
                showAllHoaDon();
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra! Hãy xem lại các dữ liệu nhập vào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            HoaDon hoaDon = new HoaDon();
            this.__setDataIntoModel(hoaDon);
            if (hddal.deleteHoaDon(hoaDon))
            {
                showAllHoaDon();
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra! Hãy xem lại các dữ liệu nhập vào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}

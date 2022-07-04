using ATH_Dashboard.Connection;
using ATH_Dashboard.Model;
using System.Data;

namespace ATH_Dashboard.Views
{
    public partial class frmKhachHang : Form
    {
        KhachHangDAL khdal;
        public frmKhachHang()
        {
            InitializeComponent();
            khdal = new KhachHangDAL();
        }

        public void showAllKhachHang()
        {
            DataTable dataTable = khdal.getAllKhachHang();
            dataGridViewKhachHang.DataSource = dataTable;
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            showAllKhachHang();
        }
        private void dataGridViewKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                txtMaKhach.Text = dataGridViewKhachHang.Rows[index].Cells["MaKhach"].Value.ToString();
                txtTenKhach.Text = dataGridViewKhachHang.Rows[index].Cells["TenKhach"].Value.ToString();
                txtTuoi.Text = dataGridViewKhachHang.Rows[index].Cells["Tuoi"].Value.ToString();
                txtSdt.Text = dataGridViewKhachHang.Rows[index].Cells["Sdt"].Value.ToString();
                txtDiaChi.Text = dataGridViewKhachHang.Rows[index].Cells["DiaChi"].Value.ToString();
            }
        }

        private void __setDataIntoModel(KhachHang khachHang)
        {
            khachHang.MaKhach = txtMaKhach.Text;
            khachHang.TenKhach = txtTenKhach.Text;
            khachHang.Tuoi = Int32.Parse(txtTuoi.Text);
            khachHang.Sdt = txtSdt.Text;
            khachHang.DiaChi = txtDiaChi.Text;
            
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            KhachHang khachHang = new KhachHang();
            this.__setDataIntoModel(khachHang);
            if (khdal.insertKhachHang(khachHang))
            {
                showAllKhachHang();
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra! Hãy xem lại các dữ liệu nhập vào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            KhachHang khachHang = new KhachHang();
            this.__setDataIntoModel(khachHang);
            if (khdal.updateKhachHang(khachHang))
            {
                showAllKhachHang();
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra! Hãy xem lại các dữ liệu nhập vào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?", "Cảnh báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                KhachHang khachHang = new KhachHang();
                this.__setDataIntoModel(khachHang);
                if (khdal.deleteKhachHang(khachHang))
                {
                    showAllKhachHang();
                }
                else
                {
                    MessageBox.Show("Đã có lỗi xảy ra! Hãy xem lại các dữ liệu nhập vào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            
        }
    }
}

using ATH_Dashboard.Connection;
using ATH_Dashboard.Model;
using System.Data;

namespace ATH_Dashboard.Views
{
    public partial class frmNhanVien : Form
    {
        NhanVienDAL nvdal;
        public frmNhanVien()
        {
            InitializeComponent();
            nvdal = new NhanVienDAL();
        }

        public void showAllNhanVien()
        {
            DataTable dataTable = nvdal.getAllNhanVien();
            dataGridViewNhanVien.DataSource = dataTable;
        }
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            showAllNhanVien();
        }

        private void dataGridViewNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                txtMaNV.Text = dataGridViewNhanVien.Rows[index].Cells["MaNV"].Value.ToString();
                txtTenNV.Text = dataGridViewNhanVien.Rows[index].Cells["TenNV"].Value.ToString();
                txtTuoi.Text = dataGridViewNhanVien.Rows[index].Cells["Tuoi"].Value.ToString();
                txtCongViec.Text = dataGridViewNhanVien.Rows[index].Cells["CongViec"].Value.ToString();
                txtMaDV.Text = dataGridViewNhanVien.Rows[index].Cells["MaDV"].Value.ToString();
            }
        }
        private void __setDataIntoModel(NhanVien nhanVien)
        {
            nhanVien.MaNV = txtMaNV.Text;
            nhanVien.TenNV = txtTenNV.Text;
            nhanVien.Tuoi = Int32.Parse(txtTuoi.Text);
            nhanVien.CongViec = txtCongViec.Text;
            nhanVien.MaDV = txtMaDV.Text;

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            NhanVien nhanVien = new NhanVien();
            this.__setDataIntoModel(nhanVien);
            if (nvdal.insertNhanVien(nhanVien))
            {
                showAllNhanVien();
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra! Hãy xem lại các dữ liệu nhập vào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            NhanVien nhanVien = new NhanVien();
            this.__setDataIntoModel(nhanVien);
            if (nvdal.updateNhanVien(nhanVien))
            {
                showAllNhanVien();
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra! Hãy xem lại các dữ liệu nhập vào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            NhanVien nhanVien = new NhanVien();
            this.__setDataIntoModel(nhanVien);
            if (nvdal.deleteNhanVien(nhanVien))
            {
                showAllNhanVien();
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra! Hãy xem lại các dữ liệu nhập vào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}

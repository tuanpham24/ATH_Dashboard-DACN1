using ATH_Dashboard.Connection;
using ATH_Dashboard.Model;
using System.Data;

namespace ATH_Dashboard.Views
{
    public partial class frmMatHang : Form
    {
        MatHangDAL mhdal;
        public frmMatHang()
        {
            InitializeComponent();
            mhdal = new MatHangDAL();
        }
        public void showAllMatHang()
        {
            DataTable dataTable = mhdal.getAllMatHang();
            dataGridViewMatHang.DataSource = dataTable;
        }
        private void frmMatHang_Load(object sender, EventArgs e)
        {
            showAllMatHang();
        }

        private void dataGridViewMatHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                txtMaHang.Text = dataGridViewMatHang.Rows[index].Cells["MaHang"].Value.ToString();
                txtTenHang.Text = dataGridViewMatHang.Rows[index].Cells["TenHang"].Value.ToString();
                txtGiaMua.Text = dataGridViewMatHang.Rows[index].Cells["GiaMua"].Value.ToString();
                txtGiaBan.Text = dataGridViewMatHang.Rows[index].Cells["GiaBan"].Value.ToString();
                txtSoLuongTon.Text = dataGridViewMatHang.Rows[index].Cells["SoLuongTon"].Value.ToString();
            }
        }
        private void __setDataIntoModel(MatHang matHang)
        {
            matHang.MaHang = txtMaHang.Text;
            matHang.TenHang = txtTenHang.Text;
            matHang.GiaMua = float.Parse(txtGiaMua.Text);
            matHang.GiaBan = float.Parse(txtGiaBan.Text);
            matHang.SoLuongTon = Int32.Parse(txtSoLuongTon.Text);

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            MatHang matHang = new MatHang();
            this.__setDataIntoModel(matHang);
            if (mhdal.insertMatHang(matHang))
            {
                showAllMatHang();
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra! Hãy xem lại các dữ liệu nhập vào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            MatHang matHang = new MatHang();
            this.__setDataIntoModel(matHang);
            if (mhdal.updateMatHang(matHang))
            {
                showAllMatHang();
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra! Hãy xem lại các dữ liệu nhập vào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            MatHang matHang = new MatHang();
            this.__setDataIntoModel(matHang);
            if (mhdal.deleteMatHang(matHang))
            {
                showAllMatHang();
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra! Hãy xem lại các dữ liệu nhập vào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}

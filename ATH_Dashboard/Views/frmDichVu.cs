using ATH_Dashboard.Connection;
using ATH_Dashboard.Model;
using System.Data;


namespace ATH_Dashboard.Views
{
    public partial class frmDichVu : Form
    {
        DichVuDAL dvdal;
        public frmDichVu()
        {
            InitializeComponent();
            dvdal = new DichVuDAL();
        }


        public void shoAllDichVu()
        {
            DataTable dataTable = dvdal.getAllDichVu();
            dataGridViewDichVu.DataSource = dataTable;
        }

        private void frmDichVu_Load(object sender, EventArgs e)
        {
            shoAllDichVu();
        }

        private void dataGridViewDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                txtMaDV.Text = dataGridViewDichVu.Rows[index].Cells["MaDV"].Value.ToString();
                txtTenDV.Text = dataGridViewDichVu.Rows[index].Cells["TenDV"].Value.ToString();
                txtMoTa.Text = dataGridViewDichVu.Rows[index].Cells["MoTa"].Value.ToString();
            }
        }

        private void __setDataIntoModel(DichVu dichVu)
        {
            dichVu.MaDV = txtMaDV.Text;
            dichVu.TenDV = txtTenDV.Text;
            dichVu.MoTa = txtMoTa.Text;

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DichVu dichVu = new DichVu();
            this.__setDataIntoModel(dichVu);
            if (dvdal.insertDichVu(dichVu))
            {
                shoAllDichVu();
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra! Hãy xem lại các dữ liệu nhập vào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DichVu dichVu = new DichVu();
            this.__setDataIntoModel(dichVu);
            if (dvdal.updateDichVu(dichVu))
            {
                shoAllDichVu();
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
                DichVu dichVu = new DichVu();
                this.__setDataIntoModel(dichVu);
                if (dvdal.deleteDichVu(dichVu))
                {
                    shoAllDichVu();
                }
                else
                {
                    MessageBox.Show("Đã có lỗi xảy ra! Hãy xem lại các dữ liệu nhập vào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
    }
}

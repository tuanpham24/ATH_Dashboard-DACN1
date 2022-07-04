using ATH_Dashboard.Model;
using System.Data.SqlClient;
using System.Data;

namespace ATH_Dashboard.Connection
{
    public class NhanVienDAL
    {
        ConnectDB connectDB;
        SqlDataAdapter dataAdapter;
        SqlCommand sqlCmd;

        public NhanVienDAL()
        {
            connectDB = new ConnectDB();
        }

        public DataTable getAllNhanVien()
        {
            DataTable dataTable = new DataTable();
            string sql = "SELECT * FROM dbo.NhanVien";
            using (SqlConnection sqlConnection = connectDB.connect())
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(sql, sqlConnection);

                dataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }
            return dataTable;
        }

        private bool __setDataIntoDB(NhanVien nhanVien, string sql)
        {
            SqlConnection sqlConnection = connectDB.connect();
            try
            {
                sqlCmd = new SqlCommand(sql, sqlConnection);
                sqlConnection.Open();
                sqlCmd.Parameters.Add("@MaNV", SqlDbType.Char).Value = nhanVien.MaNV;
                sqlCmd.Parameters.Add("@TenNV", SqlDbType.NVarChar).Value = nhanVien.TenNV;
                sqlCmd.Parameters.Add("@Tuoi", SqlDbType.Char).Value = nhanVien.Tuoi;
                sqlCmd.Parameters.Add("@CongViec", SqlDbType.NVarChar).Value = nhanVien.CongViec;
                sqlCmd.Parameters.Add("@MaDV", SqlDbType.Char).Value = nhanVien.MaDV;
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Err: " + ex.Message, "Err", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }

        public bool insertNhanVien(NhanVien nhanVien)
        {
            string sql = "INSERT INTO dbo.NhanVien VALUES(@MaNV, @TenNV, @Tuoi, @CongViec, @MaDV)";
            if (this.__setDataIntoDB(nhanVien, sql))
            {
                return true;
            }
            return false;
        }
        public bool updateNhanVien(NhanVien nhanVien)
        {
            string sql = "UPDATE dbo.NhanVien SET MaNV = @MaNV, TenNV = @TenNV, Tuoi = @Tuoi, CongViec = @CongViec, MaDV = @MaDV WHERE MaNV = @MaNV";
            if (this.__setDataIntoDB(nhanVien, sql))
            {
                return true;
            }
            return false;
        }
        public bool deleteNhanVien(NhanVien nhanVien)
        {
            string sql = "DELETE dbo.NhanVien WHERE MaNV = @MaNV";
            if (this.__setDataIntoDB(nhanVien, sql))
            {
                return true;
            }
            return false;
        }

    }
}

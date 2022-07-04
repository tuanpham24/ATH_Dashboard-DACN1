using ATH_Dashboard.Model;
using System.Data.SqlClient;
using System.Data;

namespace ATH_Dashboard.Connection
{
    public class KhachHangDAL
    {
        ConnectDB connectDB;
        SqlDataAdapter dataAdapter;
        SqlCommand sqlCmd;

        public KhachHangDAL()
        {
            connectDB = new ConnectDB();
        }

        public DataTable getAllKhachHang()
        {
            DataTable dataTable = new DataTable();
            string sql = "SELECT * FROM dbo.KhachHang";
            using (SqlConnection sqlConnection = connectDB.connect())
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(sql, sqlConnection);

                dataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }
            return dataTable;
        }
        
        private bool __setDataIntoDB(KhachHang khachHang, string sql)
        {
            SqlConnection sqlConnection = connectDB.connect();
            try
            {
                sqlCmd = new SqlCommand(sql, sqlConnection);
                sqlConnection.Open();
                sqlCmd.Parameters.Add("@MaKhach", SqlDbType.Char).Value = khachHang.MaKhach;                
                sqlCmd.Parameters.Add("@TenKhach", SqlDbType.NVarChar).Value = khachHang.TenKhach;
                sqlCmd.Parameters.Add("@Tuoi", SqlDbType.Char).Value = khachHang.Tuoi;
                sqlCmd.Parameters.Add("@Sdt", SqlDbType.Char).Value = khachHang.Sdt;
                sqlCmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = khachHang.DiaChi;
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

        public bool insertKhachHang(KhachHang khachHang)
        {
            string sql = "INSERT INTO dbo.KhachHang VALUES(@MaKhach, @TenKhach, @Tuoi, @Sdt, @DiaChi)";
            if(this.__setDataIntoDB(khachHang, sql)){
                return true;
            }
            return false;
        }
        public bool updateKhachHang(KhachHang khachHang)
        {
            string sql = "UPDATE dbo.KhachHang SET MaKhach = @MaKhach, TenKhach = @TenKhach, Tuoi = @Tuoi, Sdt = @Sdt, DiaChi = @DiaChi WHERE MaKhach = @MaKhach";
            if (this.__setDataIntoDB(khachHang, sql))
            {
                return true;
            }
            return false;
            
        }
        public bool deleteKhachHang(KhachHang khachHang)
        {
            string sql = "DELETE dbo.KhachHang WHERE MaKhach = @MaKhach AND TenKhach = @TenKhach";
            if (this.__setDataIntoDB(khachHang, sql))
            {
                return true;
            }
            return false;
        }
    }
}

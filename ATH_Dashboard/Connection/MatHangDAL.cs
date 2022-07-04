using ATH_Dashboard.Model;
using System.Data.SqlClient;
using System.Data;

using System.Threading.Tasks;

namespace ATH_Dashboard.Connection
{
    public class MatHangDAL
    {
        ConnectDB connectDB;
        SqlDataAdapter dataAdapter;
        SqlCommand sqlCmd;
        public MatHangDAL()
        {
            connectDB = new ConnectDB();
        }
        public DataTable getAllMatHang()
        {
            DataTable dataTable = new DataTable();
            string sql = "SELECT * FROM dbo.MatHang";
            using (SqlConnection sqlConnection = connectDB.connect())
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(sql, sqlConnection);

                dataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }
            return dataTable;
        }

        private bool __setDataIntoDB(MatHang matHang, string sql)
        {
            SqlConnection sqlConnection = connectDB.connect();
            try
            {
                sqlCmd = new SqlCommand(sql, sqlConnection);
                sqlConnection.Open();
                sqlCmd.Parameters.Add("@MaHang", SqlDbType.Char).Value = matHang.MaHang;
                sqlCmd.Parameters.Add("@TenHang", SqlDbType.NVarChar).Value = matHang.TenHang;
                sqlCmd.Parameters.Add("@GiaMua", SqlDbType.Char).Value = matHang.GiaMua;
                sqlCmd.Parameters.Add("@GiaBan", SqlDbType.Char).Value = matHang.GiaBan;
                sqlCmd.Parameters.Add("@SoLuongTon", SqlDbType.NVarChar).Value = matHang.SoLuongTon;
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

        public bool insertMatHang(MatHang matHang)
        {
            string sql = "INSERT INTO dbo.MatHang VALUES(@MaHang, @TenHang, @GiaMua, @GiaBan, @SoLuongTon)";
            if (this.__setDataIntoDB(matHang, sql))
            {
                return true;
            }
            return false;
        }
        public bool updateMatHang(MatHang matHang)
        {
            string sql = "UPDATE dbo.MatHang set MaHang = @MaHang, TenHang = @TenHang, GiaMua = @GiaMua, GiaBan = @GiaBan, SoLuongTon = @SoLuongTon WHERE MaHang = @MaHang";
            if (this.__setDataIntoDB(matHang, sql))
            {
                return true;
            }
            return false;
        }
        public bool deleteMatHang(MatHang matHang)
        {
            string sql = "DELETE FROM dbo.MatHang WHERE MaHang = @MaHang";
            if (this.__setDataIntoDB(matHang, sql))
            {
                return true;
            }
            return false;
        }
    }
}

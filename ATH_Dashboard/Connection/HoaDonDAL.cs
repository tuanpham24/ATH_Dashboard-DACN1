using ATH_Dashboard.Model;
using System.Data;
using System.Data.SqlClient;

namespace ATH_Dashboard.Connection
{
    public class HoaDonDAL
    {
        ConnectDB connectDB;
        SqlDataAdapter dataAdapter;
        SqlCommand sqlCmd;

        public HoaDonDAL()
        {
            connectDB = new ConnectDB();
        }

        public DataTable getAllHoaDon()
        {
            DataTable dataTable = new DataTable();
            string sql = "SELECT * FROM dbo.HoaDon";
            using (SqlConnection sqlConnection = connectDB.connect())
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(sql, sqlConnection);

                dataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }
            return dataTable;
        }

        private bool __setDataIntoDB(HoaDon hoaDon, string sql)
        {
            SqlConnection sqlConnection = connectDB.connect();
            
            try
            {
                sqlCmd = new SqlCommand(sql, sqlConnection);
                sqlConnection.Open();
                sqlCmd.Parameters.Add("@MaHD", SqlDbType.Char).Value = hoaDon.MaHD;
                sqlCmd.Parameters.Add("@MaKhach", SqlDbType.Char).Value = hoaDon.MaKhach;
                sqlCmd.Parameters.Add("@MaHang", SqlDbType.Char).Value = hoaDon.MaHang;
                sqlCmd.Parameters.Add("@MaNV", SqlDbType.Char).Value = hoaDon.MaNV;
                sqlCmd.Parameters.Add("@TongTien", SqlDbType.Float).Value = hoaDon.TongTien;
                sqlCmd.Parameters.Add("@NgayXuat", SqlDbType.DateTime).Value = hoaDon.NgayXuat;
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

        public bool insertHoaDon(HoaDon hoaDon)
        {
            string sql = "INSERT INTO dbo.HoaDon VALUES(@MaHD, @NgayXuat, @TongTien, @MaKhach, @MaHang, @MaNV)";

            if (this.__setDataIntoDB(hoaDon, sql))
            {
                return true;
            }
            return false;
        }
        public bool updateHoaDon(HoaDon hoaDon)
        {
            string sql = "UPDATE dbo.HoaDon SET MaHD = @MaHD, NgayXuat = @NgayXuat, MaKhach = @MaKhach, MaHang = @MaHang, MaNV = @MaNV, TongTien = @TongTien WHERE MaHD = @MaHD";
            if (this.__setDataIntoDB(hoaDon, sql))
            {
                return true;
            }
            return false;
        }
        public bool deleteHoaDon(HoaDon hoaDon)
        {
            string sql = "DELETE dbo.HoaDon WHERE MaHD = @MaHD";

            if (this.__setDataIntoDB(hoaDon, sql))
            {
                return true;
            }
            return false;
        }

    }
}

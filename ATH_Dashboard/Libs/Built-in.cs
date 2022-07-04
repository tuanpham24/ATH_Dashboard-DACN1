
using ATH_Dashboard.Model;
using ATH_Dashboard.Connection;
using System.Data.SqlClient;

namespace ATH_Dashboard.Libs
{
    public class Built_in
    {
        ConnectDB connectDB;
        SqlDataAdapter dataAdapter;
        SqlCommand sqlCmd;
        public Built_in()
        {
            connectDB = new ConnectDB();
        }

        /*
        public void __insertData(string dbName, string sql, SqlConnection sqlConnection)
        {

            if(dbName == "KhachHang")
            {
                //SqlConnection sqlConnection = connectDB.connect();
                sqlCmd = new SqlCommand(sql, sqlConnection);
                sqlConnection.Open();
                sqlCmd.Parameters.Add("@MaKhach", SqlDbType.Char).Value = khachHang.MaKhach;
                sqlCmd.Parameters.Add("@TenKhach", SqlDbType.NVarChar).Value = khachHang.TenKhach;
                sqlCmd.Parameters.Add("@Tuoi", SqlDbType.Char).Value = khachHang.Tuoi;
                sqlCmd.Parameters.Add("@Sdt", SqlDbType.Char).Value = khachHang.Sdt;
                sqlCmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = khachHang.DiaChi;
                sqlCmd.ExecuteNonQuery();
            }
        }*/
    }
}

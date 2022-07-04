using ATH_Dashboard.Model;
using System.Data.SqlClient;
using System.Data;

namespace ATH_Dashboard.Connection
{
    public class DichVuDAL
    {
        ConnectDB connectDB;
        SqlDataAdapter dataAdapter;
        SqlCommand sqlCmd;

        public DichVuDAL()
        {
            connectDB = new ConnectDB();
        }

        public DataTable getAllDichVu()
        {
            DataTable dataTable = new DataTable();
            string sql = "SELECT * FROM dbo.DichVu";
            using (SqlConnection sqlConnection = connectDB.connect())
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(sql, sqlConnection);

                dataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }
            return dataTable;
        }

        private bool __setDataIntoDB(DichVu dichVu, string sql)
        {
            SqlConnection sqlConnection = connectDB.connect();
            try
            {
                sqlCmd = new SqlCommand(sql, sqlConnection);
                sqlConnection.Open();
                sqlCmd.Parameters.Add("@MaDV", SqlDbType.Char).Value = dichVu.MaDV;
                sqlCmd.Parameters.Add("@TenDV", SqlDbType.NVarChar).Value = dichVu.TenDV;
                sqlCmd.Parameters.Add("@MoTa", SqlDbType.NVarChar).Value = dichVu.MoTa;
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

        public bool insertDichVu(DichVu dichVu)
        {
            string sql = "INSERT INTO dbo.DichVu VALUES(@MaDV, @TenDV, @MoTa)";
            if (this.__setDataIntoDB(dichVu, sql))
            {
                return true;
            }
            return false;
        }
        public bool updateDichVu(DichVu dichVu)
        {
            string sql = "UPDATE dbo.DichVu SET MaDV = @MaDV, TenDV = @TenDV, MoTa = @MoTa WHERE MaDV = @MaDV";

            if (this.__setDataIntoDB(dichVu, sql))
            {
                return true;
            }
            return false;

        }
        public bool deleteDichVu(DichVu dichVu)
        {
            string sql = "DELETE dbo.DichVu WHERE MaDV = @MaDV AND TenDV = @TenDV";
            if (this.__setDataIntoDB(dichVu, sql))
            {
                return true;
            }
            return false;
        }
    }
}

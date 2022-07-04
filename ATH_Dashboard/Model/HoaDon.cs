

namespace ATH_Dashboard.Model
{
    public class HoaDon
    {
        private string maHD;
        private DateTime ngayXuat;
        private string maKhach;
        private string maHang;
        private string maNV;
        private float tongTien;

        public HoaDon() { }

        public HoaDon(string maHD, DateTime ngayXuat, string maKhach, string maHang, string maNV, float tongTien)
        {
            this.maHD = maHD;
            this.ngayXuat = ngayXuat;
            this.maKhach = maKhach;
            this.maHang = maHang;
            this.maNV = maNV;
            this.tongTien = tongTien;
        }

        public string MaHD { get => maHD; set => maHD = value; }
        public DateTime NgayXuat { get => ngayXuat; set => ngayXuat = value; }
        public string MaKhach { get => maKhach; set => maKhach = value; }
        public string MaHang { get => maHang; set => maHang = value; }
        public string MaNV { get => maNV; set => maNV = value; }
        public float TongTien { get => tongTien; set => tongTien = value; }

    }
}

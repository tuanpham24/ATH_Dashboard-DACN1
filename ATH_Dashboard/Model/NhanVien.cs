

namespace ATH_Dashboard.Model
{
    public class NhanVien
    {
        private string maNV;
        private string tenNV;
        private int tuoi;
        private string congViec;
        private string maDV;

        public NhanVien() { }

        public NhanVien(string maNV, string tenNV, int tuoi, string congViec, string maDV)
        {
            this.maNV = maNV;
            this.tenNV = tenNV;
            this.tuoi = tuoi;
            this.congViec = congViec;
            this.maDV = maDV;
        }

        public string MaNV { get => maNV; set => maNV = value; }
        public string TenNV { get => tenNV; set => tenNV = value; }
        public int Tuoi { get => tuoi; set => tuoi = value; }
        public string CongViec { get => congViec; set => congViec = value; }
        public string MaDV { get => maDV; set => maDV = value; }
    }
}

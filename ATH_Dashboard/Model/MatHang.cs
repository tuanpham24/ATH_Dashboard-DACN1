

namespace ATH_Dashboard.Model
{
    public class MatHang
    {
        private string maHang;
        private string tenHang;
        private float giaMua;
        private float giaBan;
        private int soLuongTon;

        public MatHang() { }

        public MatHang(string maHang, string tenHang, float giaMua, float giaBan, int soLuongTon)
        {
            this.maHang = maHang;
            this.tenHang = tenHang;
            this.giaMua = giaMua;
            this.giaBan = giaBan;
            this.soLuongTon = soLuongTon;
        }

        public string MaHang { get => maHang; set => maHang = value; }
        public string TenHang { get => tenHang; set => tenHang = value; }
        public float GiaMua { get => giaMua; set => giaMua = value; }
        public float GiaBan { get => giaBan; set => giaBan = value; }
        public int SoLuongTon { get => soLuongTon; set => soLuongTon = value; }
    }
}

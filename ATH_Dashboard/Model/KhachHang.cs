

namespace ATH_Dashboard.Model
{
    public class KhachHang
    {
        private string maKhach;
        private string tenKhach;
        private int tuoi;
        private string sdt;
        private string diaChi;  

        public KhachHang() { }

        public KhachHang(string maKhach, string tenKhach, int tuoi, string sdt, string diaChi)
        {
            this.maKhach = maKhach;
            this.tenKhach = tenKhach;
            this.tuoi = tuoi;
            this.sdt = sdt;
            this.diaChi = diaChi;
        }

        public string MaKhach { get => maKhach; set => maKhach = value; }
        public string TenKhach { get => tenKhach; set => tenKhach = value; }
        public int Tuoi { get => tuoi; set => tuoi = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
    }
}

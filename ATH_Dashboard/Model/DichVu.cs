

namespace ATH_Dashboard.Model
{
    public class DichVu
    {
        private string maDV;
        private string tenDV;
        private string moTa;

        public DichVu() { }

        public DichVu(string maDV, string tenDV, string moTa)
        {
            this.maDV = maDV;
            this.tenDV = tenDV;
            this.moTa = moTa;
        }


        public string MaDV { get => maDV; set => maDV = value; }
        public string TenDV { get => tenDV; set => tenDV = value; }
        public string MoTa { get => moTa; set => moTa = value; }
    }
}

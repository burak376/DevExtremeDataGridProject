namespace DevExtremeAspNetCoreApp1.Models.Ef
{
    public partial class DataList
    {
        public int ID { get; set; }
        public int SiraNo { get; set; }
        public string IslemTurString { get; set; }
        public string EvrakNo { get; set; }
        public DateTime Tarihh { get; set; }
        public int GirisMiktar { get; set; }
        public int CikisMiktar { get; set; }
        public int Stok { get; set; }
    }
}

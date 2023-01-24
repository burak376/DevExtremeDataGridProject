using System;
using System.Collections.Generic;

namespace DevExtremeAspNetCoreApp1.Models.Ef;

public partial class Stk
{
    public int Id { get; set; }

    public string MalKodu { get; set; }

    public string MalAdi { get; set; }
}

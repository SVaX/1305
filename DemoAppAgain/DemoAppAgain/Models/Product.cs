using System;
using System.Collections.Generic;

namespace DemoAppAgain.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string Article { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int ProductTypeId { get; set; }

    public string? Description { get; set; }

    public string? Picture { get; set; }

    public double MinimalCost { get; set; }

    public string? PackageSize { get; set; }

    public double? WeightOfProduct { get; set; }

    public double? WeightWithPackage { get; set; }

    public int? ProductStandartId { get; set; }

    public string? CertificatePicture { get; set; }

    public virtual ICollection<Manufacture> Manufactures { get; set; } = new List<Manufacture>();

    public virtual ICollection<PriceHistory> PriceHistories { get; set; } = new List<PriceHistory>();

    public virtual ICollection<ProductApplication> ProductApplications { get; set; } = new List<ProductApplication>();

    public virtual ProductStandart? ProductStandart { get; set; }

    public virtual ProductType ProductType { get; set; } = null!;

    public virtual ICollection<SaleHistory> SaleHistories { get; set; } = new List<SaleHistory>();
}

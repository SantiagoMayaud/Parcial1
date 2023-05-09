namespace Parcial1SM.Models;
using System.ComponentModel.DataAnnotations;
using Parcial1SM.Utils;

public class ModelMaker{
    public int Id {get; set;}
    [Display(Name = "Fabricante del Modelo")]
    public string? BrandName {get; set;}
    [Display(Name = "Pais del Fabricante")]
    public string? Country {get; set; }
    [Display(Name = "Maquetas")]
    public virtual List<ModelKit> ModelKits {get; set; } = new();
}
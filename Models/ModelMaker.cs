namespace Parcial1SM.Models;
using System.ComponentModel.DataAnnotations;
using Parcial1SM.Utils;

public class ModelMaker{
    public int Id {get; set;}
    [Display(Name = "Fabricante del Modelo")]
    public string? BrandName {get; set;}
    public int ModelMakerId {get; set;}
    public virtual List<ModelKit> ModelKits {get; set; }
}
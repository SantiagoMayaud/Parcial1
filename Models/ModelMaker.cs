namespace Parcial1SM.Models;
using System.ComponentModel.DataAnnotations;
using SantiagoMayaudParcial1.Utils;

public class ModelMaker{
    public int Id {get; set;}
    [Display(Name = "Fabricante del Modelo")]
    public string? BrandName {get; set;}
}
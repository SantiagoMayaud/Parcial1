namespace Parcial1SM.Models;
using System.ComponentModel.DataAnnotations;
using Parcial1SM.Utils;

public class ModelKit{
    public int Id {get; set;}
    [Display(Name="Modelo")]
    public string Name { get; set; }
    [Display(Name="Tipo de Modelo")]
    public ModelType Type {get; set; }
    [Display(Name="Cantidad de piezas")]
    public int Pieces {get; set;}
    [Display(Name="Esta terminada?")]
    public bool Finished {get; set; } = true;
    public int ModelMakerId { get; set; }
    [Display(Name="Marca o Fabricante")]
    public virtual ModelMaker? ModelMaker {get; set; }
    
}
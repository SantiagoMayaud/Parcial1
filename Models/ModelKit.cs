namespace Parcial1SM.Models;
using System.ComponentModel.DataAnnotations;
using SantiagoMayaudParcial1.Utils;

public class ModelKit{
    public int Id {get; set;}
    [Display(Name="Modelo")]
    public string? Name { get; set; }
    [Display(Name="Cantidad de piezas")]
    public int Pieces {get; set;}
    [Display(Name="Terminado")]
    public bool Finished {get; set; } = true;
}
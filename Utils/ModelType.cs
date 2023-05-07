namespace Parcial1SM.Utils;
using System.ComponentModel.DataAnnotations;

    public enum ModelType
    {
        [Display(Name = "Avion Militar")]
        AvionMilitar,
        [Display(Name = "Avion Comercial")]
        AvionComercial,
        [Display(Name = "Helicoptero")]
        Helicoptero,
        [Display(Name = "Tanque")]
        Tanque,
        [Display(Name = "Naval")]
        Naval,
        [Display(Name = "Auto")]
        Auto,
        [Display(Name = "Otros")]
        Otros
    }
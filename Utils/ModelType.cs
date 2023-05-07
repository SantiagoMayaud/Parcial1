namespace SantiagoMayaudParcial1.Utils;
using System.ComponentModel.DataAnnotations;

class ModelType{
    public enum Tipo
    {
        AvionMilitar,
        AvionComercial,
        Helicoptero,
        Tanque,
        Naval,
        Auto,
        Otros
    }
}
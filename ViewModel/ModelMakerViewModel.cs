using Parcial1SM.Models;
namespace Parcial1SM.ViewModels;

public class ModelMakerViewModel{
    public List<ModelMaker> ModelMakers { get; set; } = new List<ModelMaker>();
    public string? NameFilter { get; set;}
    
}
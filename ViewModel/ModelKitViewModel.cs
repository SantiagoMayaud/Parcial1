using Parcial1SM.Models;
namespace Parcial1SM.ViewModels;

public class ModelKitViewModel{
    public List<ModelKit> ModelKits { get; set; } = new List<ModelKit>();
    public string? NameFilter { get; set;}
    public string? Name { get; set; }
    public int Pieces {get; set;}
    public bool Finished {get; set; } = true;
}
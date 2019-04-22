namespace Game.Models
{
    public interface IGameConfig
    {
        int FieldWidth { get; }
        int FieldHeight { get; }
        float CellSize { get; set; }
    }
}
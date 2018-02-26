namespace ArenaBase
{
    public class ArenaTile : BaseTile
    {
        public bool Passable { get; set; }
        public bool Immovable { get; set; } //Cannot be destroyed, changed, moved etc.
    }
}

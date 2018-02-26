using ArenaBase;

namespace Interfaces
{
    public interface IMapsContainer
    {
        ActorsMap Actors { get; set; }
        ArenaMap Arena { get; set; }
    }
}

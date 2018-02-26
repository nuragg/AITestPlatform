using ArenaBase;

namespace Interfaces
{
    public interface ITurnManager
    {        
        Actor GetNextActor();
        void NextTurn();
    }
}

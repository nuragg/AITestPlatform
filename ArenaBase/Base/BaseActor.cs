namespace ArenaBase
{
    public class BaseActor : BaseTile
    {
        public int Speed { get; set; }
        public int DisplayPriority { get; set; }
        public bool TurnFinished { get { return Enegry >= 1000; }}
        public int Enegry { get; set; }
    }
}

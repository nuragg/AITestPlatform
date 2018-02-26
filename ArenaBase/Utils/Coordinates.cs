namespace ArenaBase
{
    public class Coordinates
    {
        public Coordinates(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }


        public static Coordinates NewCoord(int x, int y)
        {
            return new Coordinates(x, y);
        }

        public override bool Equals(object obj)
        {
            // If parameter cannot be cast to ThreeDPoint return false:
            Coordinates p = obj as Coordinates;
            if ((object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return base.Equals(obj) && X == p.X && Y == p.Y;
        }

        public bool Equals(Coordinates p)
        {
            // Return true if the fields match:
            return base.Equals((Coordinates)p) &&  X == p.X && Y == p.Y;
        }

        public override int GetHashCode()
        {
            var hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(Coordinates a, Coordinates b)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            // Return true if the fields match:
            return a.X == b.X && a.Y == b.Y;
        }

        public static bool operator !=(Coordinates a, Coordinates b)
        {
            return !(a == b);
        }


    }

    
}

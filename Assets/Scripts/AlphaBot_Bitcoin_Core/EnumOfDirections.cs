namespace AlphaBot_Bitcoin
{

    class OperatorsForDirections
    {
        static public Directions Sum(int direction, int delta)
        {
            return (Directions)((direction + delta) % 4);
        }
    }
    public enum Directions : byte
    {
        North, 
        East, 
        South,
        West
    }
}
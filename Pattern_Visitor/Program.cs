namespace Pattern_Visitor
{
    internal class Program
    {
        interface IVisitor
        {
            public void Visit(Zoo zoo);
            public void Visit(Cinema cinema);
            public void Visit(Circus circus);

        }

        interface IPlace
        {

        }
        public static void Main(string[] args)
        {

        }
    }
}

/*
пример поведенческого шаблона проектирования программ «Посетитель», 
позволяющий добавлять в программу новые операции, не изменяя классы объектов,
над которыми эти операции могут выполняться. Преимуществом паттерна является
то, что он объединяет родственный операции в одном классе, упрощает добавление операций,
работающих со сложными структурами объектов. Отрицательным моментом является возможное
нарушение инкапсуляции элементов.
*/

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
            void Accept(IVisitor visitor);
        }

        public class Zoo : IPlace
        {
            void IPlace.Accept(IVisitor visitor) => visitor.Visit(this);
        }

        public class Cinema : IPlace
        {
            void IPlace.Accept(IVisitor visitor) => visitor.Visit(this);
        }

        public class Circus : IPlace
        {
            void IPlace.Accept(IVisitor visitor) => visitor.Visit(this);
        }

        class Holidaymaker : IVisitor
        {
            public string value;

            public void Visit(Zoo zoo) => value = "Visit ZOO";

            public void Visit(Cinema cinema) => value = "Visit CINEMA";

            public void Visit(Circus circus) => value = "Visit CIRCUS";
        }

        public static void Main(string[] args)
        {
            List<IPlace> places = new List<IPlace>() { new Zoo(), new Cinema(), new Circus() };

            foreach (var place in places)
            {
                Holidaymaker visitor = new Holidaymaker();
                place.Accept(visitor);

                Console.WriteLine(visitor.value);
            }

            Console.ReadKey();
        }
    }
}

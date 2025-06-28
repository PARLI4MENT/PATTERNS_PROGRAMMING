/*
Пример порождающего шаблона проектирования программ «Абстрактная фабрика»,
который предоставляет интерфейс взаимосвязанных или взаимозависимых объектов,
не специфицируя их конкретных классов. Шаблон применяется в случаях, когда программа
должна быть не зависимой от процессов и типов создаваемых новых объектов, а также,
когда необходимо создавать группы взаимосвязанных объектов.
*/

namespace Pattern_AbstractFactory
{
    interface IEngine
    {
        void ReleaseEngine();
    }

    class JapaneeseEngine : IEngine
    {
        public void ReleaseEngine() => Console.WriteLine("Japaneese engine");
    }

    class RussianEngine : IEngine
    {
        public void ReleaseEngine() => Console.WriteLine("Russian engine");
    }

    interface ICar
    {
        void ReleaseCar(IEngine engine);
    }

    class JapaneeseCar : ICar
    {
        public void ReleaseCar(IEngine engine)
        {
            Console.Write("Release Japanees car: ");
            engine.ReleaseEngine();
        }
    }

    class RussianCar : ICar
    {
        public void ReleaseCar(IEngine engine)
        {
            Console.Write("Release Russian car: ");
            engine.ReleaseEngine();
        }
    }

    interface IFactory
    {
        IEngine createEngine();
        ICar createCar();
    }

    class JapaneeseFactory : IFactory
    {
        public IEngine createEngine() => new JapaneeseEngine();
        public ICar createCar() => new JapaneeseCar();

    }

    class RussianFactory : IFactory
    {
        public IEngine createEngine() => new RussianEngine();
        public ICar createCar() => new RussianCar();
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var jFactory = new JapaneeseFactory();
            var jEngine = jFactory.createEngine();
            var jCar = new JapaneeseCar();
            jCar.ReleaseCar(jEngine);

            var rFactory = new RussianFactory();
            var rEngine = rFactory.createEngine();
            var rCar = new RussianCar();
            rCar.ReleaseCar(rEngine);


            Console.ReadKey();
        }
    }
}

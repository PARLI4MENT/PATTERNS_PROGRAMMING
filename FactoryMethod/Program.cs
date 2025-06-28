/*
Пример порождающего шаблона проектирования программ «Фабричный метод»,
который предоставляет дочерним классам интерфейс для создания экземпляров
некоторого класса. В момент создания наследники могут определить какой
класс создавать. Это позволяет использовать в коде программы неспецифические
классы, а манипулировать абстрактными объектами на более высоком уровне.
*/

namespace Pattern_FactoryMethod
{
    interface IProduction
    {
        void Release();
    }

    public class Car: IProduction
    {
        public void Release() => Console.WriteLine("Release new Car!");
    }

    public class Truck : IProduction
    {
        public void Release() => Console.WriteLine("Release new Truck!");
    }

    interface IWorkshop
    {
        IProduction Create();
    }

    public class CarWorkshop : IWorkshop
    {
        IProduction IWorkshop.Create() => new Car();
    }

    public class TruckWorkshop : IWorkshop
    {
        IProduction IWorkshop.Create() => new Truck();
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            IWorkshop creator = new CarWorkshop();
            IProduction car = creator.Create();

            creator = new TruckWorkshop();
            IProduction truck = creator.Create();

            car.Release();
            truck.Release();

            Console.ReadKey();
        }
    }
}

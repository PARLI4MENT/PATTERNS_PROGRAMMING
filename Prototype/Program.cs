/*
Пример порождающего шаблона проектирования программ «Прототип», который
позволяет копировать объекты, не вдаваясь в подробности их реализации.
Преимуществом паттерна является то, что он позволяет клонировать объекты,
не привязываясь к их конкретным классам, уменьшает повторяющийся код при
инициализации объектов. Однако составные объекты, имеющие ссылки на другие
классы, клонировать сложнее.
*/

using System.Diagnostics.CodeAnalysis;

namespace Pattern_Prototype
{
    interface IAnimal
    { 
        void SetName(string name);
        string GetName();
        IAnimal Clone();
    }

    class Sheep: IAnimal
    {
        private string? name;

        public Sheep() { }
        public Sheep(Sheep sheep) => this.name = sheep.name;

        public void SetName(string name) => this.name = name;
        public string? GetName() => name;
        
        public IAnimal Clone() => new Sheep(this);
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var sheepDonor = new Sheep();
            sheepDonor.SetName("Dolly");
            Console.WriteLine(sheepDonor.GetName());

            var sheepClone = sheepDonor.Clone();
            sheepClone.SetName("Dolly clone");
            Console.WriteLine(sheepClone.GetName());

            Console.ReadKey();
        }
    }
}

/*
Пример структурного шаблона проектирования программ «Адаптер»,
предназначенный для организации использования функций объекта,
недоступного для модификации, через специально созданный интерфейс.
Другими словами, он позволяет объектам с несовместимыми интерфейсами
работать вместе.
*/

using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Adapter_Object
{
    interface IScales
    {
        float GetWeight();
    }

    public class RussianScales : IScales
    {
        private float currentWeight;
        public RussianScales(float currentWeight) => this.currentWeight = currentWeight;

        public float GetWeight() => currentWeight;
    }

    public class BritishScales : IScales
    {
        private float currentWeight;
        public BritishScales(float currentWeight) => this.currentWeight = currentWeight;

        public float GetWeight() => currentWeight;
    }

    public class AdapterForBritishScales : IScales
    {
        private BritishScales britishScales;
        public AdapterForBritishScales(BritishScales britishScales) => this.britishScales = britishScales;

        public float GetWeight() => britishScales.GetWeight() * 0.453f;
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            float kg = 55.0f;   // kg
            float lb = 55.0f;   // pound

            var rScale = new RussianScales(kg);
            var bScale = new AdapterForBritishScales(new BritishScales(lb));

            Console.WriteLine(rScale.GetWeight());
            Console.WriteLine(bScale.GetWeight());

            Console.ReadKey();
        }
    }
}
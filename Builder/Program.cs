/*
Пример порождающего шаблона проектирования программ «Строитель»,
который предоставляет способ создания составного объекта. Он отделяет
конструирование сложного объекта от его представления так, что в результате
одного и того же процесса конструирования могут получаться разные представления.
*/

using System.Runtime.CompilerServices;

namespace Pattern_Builder
{
    class Phone
    {
        public string data { get; private set; }

        public Phone() => data = string.Empty;

        public string AboutPhone() => data;
        public void AppentData(string str) => data += str;
    }

    interface IDeveloper
    {
        void CreateDisplay();
        void CreateBox();
        void SystemInstall();

        Phone GetPhone();
    }

    public class AndroidDeveloper : IDeveloper
    {
        private Phone phone;

        public AndroidDeveloper() => phone = new Phone();

        public void CreateDisplay() => phone.AppentData("Create Android display." + Environment.NewLine);

        public void CreateBox() => phone.AppentData("Create box for Android." + Environment.NewLine);

        public void SystemInstall() => phone.AppentData("Android System install." + Environment.NewLine);

        Phone IDeveloper.GetPhone() => phone;
    }

    public class IphoneDeveloper : IDeveloper
    {
        private Phone phone;

        public IphoneDeveloper() => phone = new Phone();

        public void CreateDisplay() => phone.AppentData("Create iPhone display." + Environment.NewLine);

        public void CreateBox() => phone.AppentData("Create box for iPhone." + Environment.NewLine);

        public void SystemInstall() => phone.AppentData("Iphone System install." + Environment.NewLine);

        Phone IDeveloper.GetPhone() => phone;
    }

    class Director
    {
        private IDeveloper developer;

        public Director(IDeveloper developer) => this.developer = developer;

        public void SetDeveloper(IDeveloper developer) => this.developer = developer;

        public Phone MountOnlyPhone()
        {
            developer.CreateBox();
            developer.CreateDisplay();
            return developer.GetPhone();
        }

        public Phone MountFullPhone()
        {
            developer.CreateBox();
            developer.CreateDisplay();
            developer.SystemInstall();
            return developer.GetPhone();
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            var androidDev = new AndroidDeveloper();
            var director = new Director(androidDev);

            var samsung = director.MountFullPhone();
            Console.WriteLine(samsung.AboutPhone());

            var iosDev = new IphoneDeveloper();
            director.SetDeveloper(iosDev);
            var iphone = director.MountOnlyPhone();
            Console.WriteLine(iphone.AboutPhone());

            Console.ReadKey();
        }
    }
}
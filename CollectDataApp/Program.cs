using System;
using CollectDataApp.Views;

namespace CollectDataApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Start App
            new Menu().StartApp().GetAwaiter().GetResult();
        }
    }
}

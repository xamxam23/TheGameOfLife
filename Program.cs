using System;
using System.Threading;
using System.Text;
namespace GameOfLife
{
    class Program
    {
       static void Main(string[] args)
        {
            var rand = new Random();
            var view = new View();
            var presenter = new Presenter(view);

            while(true) {
                presenter.Execute();
                Thread.Sleep(500);
            }
        }
    }
}

using System;
using System.Threading;
using System.Text;

namespace GameOfLife
{
    class View {
        // const string dot =  "\u25A0";
        const string dot =  "O";
        public View() {
            Console.CursorVisible = false;
            Console.Clear();
        }
        public void Draw(int[][] data) {
            Console.SetCursorPosition(0, 0);
            for(int i=0; i<data.Length; i++, Console.WriteLine(""))
                for(int j=0; j<data[i].Length; j++)
                    Console.Write(data[i][j] == 1 ? dot: " ");
        }
    }
}
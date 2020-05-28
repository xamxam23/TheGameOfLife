using System;
using System.Threading;
using System.Text;

namespace GameOfLife
{
    class Presenter
    {
        View view;
        private Model model;
        private int[][] present;
        public Presenter(View view) {
            this.view = view;
            // Sample model
            this.model = new Model(rows: 20, cols: 32);
            this.present = model.Create();
            // Sample data: The legendary glider
            model.Set(present, 3, 11, 1);
            model.Set(present, 4, 12, 1);
            model.Set(present, 5, 10, 1);
            model.Set(present, 5, 11, 1);
            model.Set(present, 5, 12, 1);
        }
        public void Execute()  {
            var future = model.Create();
            for(int i=0; i<present.Length; i++) {
                for(int j=0; j<present[i].Length; j++) {
                    future[i][j] = Process(i, j, present);
                }
            }
            view.Draw(future);
            present = future;
        }
        private int Process(int r, int c, int[][] data) {
            int neighbhors = Neighbhors(r, c, data);
            if (data[r][c] == 1) {
                if (neighbhors < 2) return 0; // UnderPopulation
                if (2<=neighbhors && neighbhors<=3) return 1; // Life
                if (neighbhors > 3) return 0; // OverPopulation
            }
            if (data[r][c] == 0 && neighbhors == 3) return 1; // Birth
            return data[r][c];
        }
        private int Neighbhors(int r, int c, int[][] data) {
            int people = 0-data[r][c];
            for(int dr =-1 ;dr<=1; dr++) {
                for(int dc=-1; dc<=1; dc++) {
                    int nr = r+dr, nc = c+dc;
                    if (model.IsValid(nr, nc)) 
                        if (data[nr][nc] == 1) 
                            people++;
                }
            }
            return people;
        }
    }
}

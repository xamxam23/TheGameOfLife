class Model {
    private int rows = 20, cols = 32;
    public Model(int rows, int cols) {
        this.rows = rows;
        this.cols = cols;
    }
    public void Set(int[][] data, int r, int c, int value) {
        if (IsValid(r,c)) data[r][c] = value;
    }
    public bool IsValid(int r, int c) {
        return 0 <= r && r < rows&& 0<= c && c <cols;
    }
    public int[][] Create() {
        int[][] data = new int[rows][];
        for(int i=0; i<rows; i++) {
            data[i] = new int[cols];
            for(int j=0; j<cols; j++)
                data[i][j] = 0;
        }
        return data;
    }
}
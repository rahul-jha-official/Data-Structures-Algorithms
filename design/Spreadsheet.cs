// LINK - https://leetcode.com/problems/design-spreadsheet/description/

public class Spreadsheet 
{
    private readonly int[][] _grid;
    public Spreadsheet(int rows) 
    {
        _grid = new int[rows][];

        for (int i = 0; i < rows; i++) 
        {
            _grid[i] = new int[26];
        }
    }
    
    public void SetCell(string cell, int value) 
    {
        var c = GetCell(cell);
        _grid[c.Row][c.Column] = value;        
    }
    
    public void ResetCell(string cell) 
    {        
        var c = GetCell(cell);
        _grid[c.Row][c.Column] = 0;
    }
    
    public int GetValue(string formula) 
    {
        var f = formula[1..].Split('+');
        return GetVal(f[0]) + GetVal(f[1]);
    }

    private int GetVal(string data)
    {
        if (data[0] >= 'A' && data[0] <= 'Z')
        {
            var c = GetCell(data);
            return _grid[c.Row][c.Column];
        }
        return int.Parse(data);
    }

    private static (int Row, int Column) GetCell(string cell)
    {
        return (int.Parse(cell[1..]) - 1, cell[0] - 'A');
    }
}

/**
 * Your Spreadsheet object will be instantiated and called as such:
 * Spreadsheet obj = new Spreadsheet(rows);
 * obj.SetCell(cell,value);
 * obj.ResetCell(cell);
 * int param_3 = obj.GetValue(formula);
 */

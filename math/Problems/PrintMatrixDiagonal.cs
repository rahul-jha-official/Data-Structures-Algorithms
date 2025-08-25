// LINK - https://leetcode.com/problems/diagonal-traverse/description/

public class PrintMatrixDiagonal
{
    public int[] FindDiagonalOrder(int[][] mat)
    {
        var result = new int[mat.Length * mat[0].Length];
        result[0] = mat[0][0];
        var index = 1;
        (int r, int c) cords = (0, 0);
        (int dr, int dc) delta = (1, -1);
        while (index < result.Length)
        {
            if (delta.dr == 1)
            {
                if (cords.c + 1 < mat[0].Length)
                {
                    cords = (cords.r, cords.c + 1);
                }
                else if (cords.r + 1 < mat.Length)
                {
                    cords = (cords.r + 1, cords.c);
                }
            }
            else
            {
                if (cords.r + 1 < mat.Length)
                {
                    cords = (cords.r + 1, cords.c);
                }
                else if (cords.c + 1 < mat[0].Length)
                {
                    cords = (cords.r, cords.c + 1);
                }
            }
            result[index++] = mat[cords.r][cords.c];
            var nr = cords.r + delta.dr;
            var nc = cords.c + delta.dc;
            while (index < result.Length && (nr >= 0 && nr < mat.Length) && (nc >= 0 && nc < mat[0].Length))
            {
                result[index++] = mat[nr][nc];
                cords = (nr, nc);
                nr = cords.r + delta.dr;
                nc = cords.c + delta.dc;
            }
            delta = (delta.dr * -1, delta.dc * -1);
        }
        return result;
    }
}

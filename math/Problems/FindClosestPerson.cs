// LINK - https://leetcode.com/problems/find-closest-person/description

public class FindClosestPerson 
{
    public int FindClosest(int x, int y, int z) 
    {
        var xz = Math.Abs(x - z);
        var yz = Math.Abs(y - z);     
        return xz == yz ? 0 : xz < yz ? 1 : 2;   
    }
}



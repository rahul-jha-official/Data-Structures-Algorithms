// Link - https://leetcode.com/problems/convert-binary-number-in-a-linked-list-to-integer/description/

public class Solution 
{
    private int i = 0;
    public int GetDecimalValue(ListNode head) 
    {
        if (head == null)
        {
            return 0;
        }
        else
        {
            var result = GetDecimalValue(head.next);
            result += head.val * (int)Math.Pow(2, i++);
            return result;
        }
    }
}

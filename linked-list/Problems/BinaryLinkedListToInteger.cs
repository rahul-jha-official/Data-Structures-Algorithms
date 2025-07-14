// Link - https://leetcode.com/problems/convert-binary-number-in-a-linked-list-to-integer/description/

// Approach - 1
public class BinaryLinkedListToInteger 
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

// Approach - 2
public class BinaryLinkedListToInteger 
{
    public int GetDecimalValue(ListNode head) 
    {
        var result = 0;
        for (var node = head; node is not null; node = node.next)
        {
            result = result * 2 + node.val;
        }
        return result;
    }
}

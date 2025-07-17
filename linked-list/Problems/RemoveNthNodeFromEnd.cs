// LINK - https://leetcode.com/problems/remove-nth-node-from-end-of-list/description/

public class RemoveNthNodeFromEnd 
{
    public ListNode RemoveNthFromEnd(ListNode head, int n) 
    {
        var t = head;
        var size = 0;
        while (t != null)
        {
            size++;
            t = t.next;
        }

        if (n == size) return head.next;
        else
        {
            n = size - n - 1;
            int count = 0;
            t = head;
            while (count != n)
            {
                count++;
                t = t.next;
            }
            t.next = t.next.next;
            return head;
        }     
    }
}

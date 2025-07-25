// LINK - https://leetcode.com/problems/reverse-linked-list-ii/description/

public class ReverseLikedList2 
{
    private ListNode start;
    public ListNode ReverseBetween(ListNode head, int left, int right) 
    {
        if (left == right) return head;

        int count = 1;
        start = head;

        while (count != left)
        {
            start = start.next;
            count++;
        }

        FindEndAndReplace(start.next, count + 1, left, right);
        return head;
    }

    private void FindEndAndReplace(ListNode node, int current,int  left, int right)
    {
        if (current < right) FindEndAndReplace(node.next, current + 1, left, right);

        int mid = (left + right) / 2;

        if (current > mid)
        {
            int t = start.val;
            start.val = node.val;
            node.val = t;

            start = start.next;
        }
    }
}

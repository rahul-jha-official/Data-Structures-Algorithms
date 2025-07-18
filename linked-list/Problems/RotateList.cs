// Link - https://leetcode.com/problems/rotate-list/description/

public class RotateList
{
    private ListNode node;
    private int size = 0;
    public ListNode RotateRight(ListNode head, int k)
    {
        GetKthNode(head, 1, k);

        if (node == null) return head;

        var h = node;

        while (h.next != null) h = h.next;
        h.next = head;
        return node;
    }

    private void GetKthNode(ListNode t, int n, int k)
    {
        if (t == null) return;
        size = Math.Max(size, n);
        if (t != null) GetKthNode(t.next, n + 1, k);


        int x = k % size;

        if (n == (size - x + 1))
        {
            node = t;
        }

        if (n == (size - x))
        {
            t.next = null;
        }
    }
}

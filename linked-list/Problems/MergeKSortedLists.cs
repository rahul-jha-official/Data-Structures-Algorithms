// LINK - https://leetcode.com/problems/merge-k-sorted-lists/description/

public class MergeKSortedLists 
{
    public ListNode MergeKLists(ListNode[] lists) 
    {
        if (lists is null || !lists.Any()) return null;
        var head = lists[0];

        foreach (var item in lists.Skip(1))
        {
            head = MergeTwoLists(head, item);
        }

        return head;
    }

    private ListNode MergeTwoLists(ListNode list1, ListNode list2) 
    {
        ListNode l1 = list1, l2 = list2;
        ListNode l3 = null, head = null;
        while (l1 != null || l2 != null)
        {
            ListNode temp = null;
            if (l1 != null && l2 != null)
            {
                if (l1.val <= l2.val)
                {
                    temp = l1;
                    l1 = l1.next;
                }
                else 
                {
                    temp = l2;
                    l2 = l2.next;
                }
            }
            else 
            {
                if (l1 != null)
                {
                    temp = l1;
                    l1 = l1.next;
                }
                else 
                {
                    temp = l2;
                    l2 = l2.next;
                }
            }

            if (l3 is null)
            {
                l3 = temp;
                head = temp;
            }
            else
            {
                l3.next = temp;
                l3 = temp;
            }
        }

        if (l3 != null) l3.next = null;

        return head;     
    }
}

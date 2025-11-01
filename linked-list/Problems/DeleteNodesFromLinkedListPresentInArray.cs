// LINK - https://leetcode.com/problems/delete-nodes-from-linked-list-present-in-array/description/

public class DeleteNodesFromLinkedListPresentInArray 
{
    public ListNode ModifiedList(int[] nums, ListNode head) 
    {
        var ex = new HashSet<int>(nums);
        ListNode result = null, partialResult = null;
        ListNode temp = head;
        while (temp != null)
        {
            if (!ex.Contains(temp.val))
            {
                if (result is null)
                {
                    result = new ListNode(temp.val);
                    partialResult = result;
                }
                else
                {
                    partialResult.next = new ListNode(temp.val);
                    partialResult = partialResult.next;
                }
            }
            temp = temp.next;
        }
        return result;
    }
}

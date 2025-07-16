// LINK - http://leetcode.com/problems/add-two-numbers/description/

public class AddTwoNumber 
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) 
    {
        ListNode head = null;
        ListNode node = null;
        int carry = 0;
        while (l1 != null || l2 != null)
        {
            int n1 = 0, n2 = 0;
            if (l1 != null) 
            {
                n1 = l1.val;
                l1 = l1.next;
            }
            if (l2 != null) 
            {
                n2 = l2.val;
                l2 = l2.next;
            }

            int sum = n1 + n2 + carry;
            int digit = sum % 10;
            carry = sum / 10;

            var newNode = new ListNode(digit);
            if (node is null)
            {
                node = newNode;        
                head = node;
            }
            else 
            {
                node.next = newNode;
                node = newNode;
            }
        }

        if (carry > 0)
        {
            node.next = new ListNode(carry);
        }

        return head;
    }
}

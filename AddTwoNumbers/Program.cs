using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
        }


        //Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }


        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            // This variable is used for return.
            ListNode resultList = new ListNode(0);
            // This is a pointer for do-while loop.
            ListNode rPointer = resultList;
            int carry = 0;
            do
            {
                int v1 = l1 != null ? l1.val : 0;
                int v2 = l2 != null ? l2.val : 0;

                // set result for current digit.
                rPointer.val = (v1 + v2 + carry) % 10;


                carry = (v1 + v2 + carry) > 9 ? 1 : 0;
                l1 = (l1 != null && l1.next != null) ? l1.next : null;
                l2 = (l2 != null && l2.next != null) ? l2.next : null;

                // check does it need to do the next round.
                if (l1 == null && l2 == null && carry == 0)
                {
                    break;
                }

                // initial for next round.
                rPointer.next = new ListNode(0);
                rPointer = rPointer.next;

            } while (true);

            return resultList;
        }
    }
}

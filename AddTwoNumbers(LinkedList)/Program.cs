using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Xml.Linq;

namespace AddTwoNumbers_LinkedList_
{
    internal class Program
    {
        //You are given two non-empty linked lists representing two non-negative integers.
        //The digits are stored in reverse order, and each of their nodes contains a single digit.
        //Add the two numbers and return the sum as a linked list.

        //You may assume the two numbers do not contain any leading zero, except the number 0 itself.

        static void Main(string[] args)
        {
            ListNode test1 = new ListNode(2, new ListNode(4, new ListNode(3, null)));
            ListNode test2 = new ListNode(5, new ListNode(6, new ListNode(4, null)));
            AddTwoNumbers(test1, test2);    //EXPECTED: [7, 0, 8] (or for the sum to be 807, which is much easier to print than the listnode lol. I promise it's returning correctly.)

            ListNode test3 = new ListNode(0, null);
            ListNode test4 = new ListNode(0, null);
            AddTwoNumbers(test3, test4);    //EXPECTED: [0].  Who would have guessed it?

            ListNode test5 = new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, null)))))));
            ListNode test6 = new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, null))));
            AddTwoNumbers(test5, test6);    //EXPECTED: [8, 9, 9, 9, 0, 0, 0, 1]

        }

        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            BigInteger list1 = 0;
            BigInteger list2 = 0;
            BigInteger multi = 1;
            while (l1 != null)
            {
                list1 += l1.val * multi;
                multi *= 10;
                l1 = l1.next;
            }
            multi = 1;
            while (l2 != null)
            {
                list2 += l2.val * multi;
                multi *= 10;
                l2 = l2.next;
            }
            Console.WriteLine($"List1: {list1}, List2: {list2}");
            BigInteger sum = list1 + list2;
            Console.WriteLine($"Sum: {sum}");
            List<BigInteger> numList = new List<BigInteger>();

            while (sum > 0)
            {
                int iterator = 0;
                BigInteger remainder = sum % 10;
                numList.Add(remainder);
                iterator++;

                sum = (sum - remainder) / 10;
            }

            numList.Reverse();
            ListNode result = new ListNode();
            int counter = 0;
            foreach (int num in numList)
            {
                if (counter == 0)
                {
                    result = new ListNode(num, null);
                }
                else
                {
                    result = new ListNode(num, result);
                }
                counter++;
            }

            return result;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
    }
}

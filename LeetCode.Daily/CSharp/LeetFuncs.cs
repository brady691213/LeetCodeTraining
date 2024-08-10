using System.Diagnostics;

namespace Designer;

public class LeetFuncs
{
    /// <summary>
    /// Given an integer array nums sorted in non-decreasing order, remove some duplicates in-place such that each unique element appears at most twice. The relative order of the elements should be kept the same.
    /// </summary>
    /// <remarks>
    /// https://leetcode.com/problems/remove-duplicates-from-sorted-array-ii/description/?envType=study-plan-v2&envId=top-interview-150
    /// </remarks>
    public static int RemoveMostDuplicates(int[] nums)
    {
        var numSpan = nums.AsSpan();
        var pos = 0;
        for (int i = 0; i < numSpan.Length; i++)
        {
            int count = 0;
            for (int c = 0; c < pos; c++)
            {
                if (numSpan[c] == numSpan[i])
                {
                    count += 1;
                    if (count > 1);
                }
            }

            if (count <= 1) numSpan[pos++] = numSpan[i];
        }

        return pos;
    }

    public static int RemoveDuplicates(int[] nums)
    {
        var numSpan = nums.AsSpan();
        var pos = 0;
        for (int i = 0; i < numSpan.Length; i++)
        {
            bool cont = false;
            for (int c = 0; c < pos; c++)
            {
                if (numSpan[c] == numSpan[i])
                {
                    cont = true;
                    break;
                }
            }

            if (!cont) numSpan[pos++] = numSpan[i];
        }

        return pos;
    }

    public static int RemoveElement(int[] nums, int val)
    {
        var numSpan = nums.AsSpan();
        var pos = 0;
        for (int i = 0; i < numSpan.Length; i++)
        {
            if (numSpan[i] != val)
            {
                numSpan[pos++] = numSpan[i];
            }
        }

        return pos;
    }

    public static void MergeSorted(int[] nums1, int m, int[] nums2, int n)
    {
        List<int> both = [..nums1.Take(m), ..nums2.Take(n)];
        var list3 = both.OrderBy(x => x).ToList();
        for (int i = 0; i < nums1.Length; i++)
        {
            nums1[i] = list3[i];
        }
    }


    public static void TestMergeSorted(int[] nums1, int[] nums2, int n)
    {
        int[] arr1 = [1, 2, 3, 0, 0, 0];
        MergeSorted(arr1, 3, [2, 5, 6], 3);
    }

    public static void TestRemoveElement()
    {
        List<int> nums = [3, 2, 2, 3];
        var result = RemoveElement([3, 2, 2, 3], 3);
        var x = nums.Where(x => x != 3).ToArray();
    }


    //  public unsafe static int RemoveElementWithPointers(int[] nums, int val)
    //  {
    //      var noVal = nums.Where(x => x != val).ToArray();
    //      fixed (int* pNums = nums)
    //      {
    //          var valP = pNums;
    //          var lenP = pNums + nums.Length;
    //          for (var p = pNums; p < lenP; p++)
    //          {
    //              if (*p == val) continue;
    //              *valP = *p != val ? *p : *valP;
    //              valP++;
    //          }
    //          return (int)(valP - pNums);
    //      }   
    // }    
}
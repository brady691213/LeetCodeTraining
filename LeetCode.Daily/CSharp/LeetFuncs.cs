using System.Diagnostics;

namespace Designer;

public class LeetFuncs
{
    public static void MergeSorted(int[] nums1, int m, int[] nums2, int n)
    {
        List<int> both = [..nums1.Take(m), ..nums2.Take(n)];
        var list3 = both.OrderBy(x => x).ToList();
        for (int i = 0; i < nums1.Length; i++)
        {
            nums1[i] = list3[i];
        }
    }

    public unsafe static int RemoveElementWithPointers(int[] nums, int val)
    {
        var noVal = nums.Where(x => x != val).ToArray();
        fixed (int* pNums = nums)
        {
            var valP = pNums;
            var lenP = pNums + nums.Length;
            for (var p = pNums; p < lenP; p++)
            {
                if (*p == val) continue;
                *valP = *p != val ? *p : *valP;
                valP++;
            }
            return (int)(valP - pNums);
        }   
   }

    public static void TestRemoveElement()
    {
        List<int> nums = [3, 2, 2, 3];
        var result = RemoveElement([3,2,2,3], 3);
        var x = nums.Where(x => x != 3).ToArray();
    }
}

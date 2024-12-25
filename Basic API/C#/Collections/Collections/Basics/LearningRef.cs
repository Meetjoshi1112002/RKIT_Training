using System;

namespace Collections.Basics
{
    public class LearnRefernces
    {
        public static IList<IList<int>> DebugWhyEmptyAnswer(int[] nums)
        {
            // Beacause arr.Clear() also clear the array refferec by ans as it all about references in C#
            IList<IList<int>> ans = new List<IList<int>>();
            HashSet<int> mp = new HashSet<int>();
            List<int> arr = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int first = nums[i];
                int target = 0 - first;
                mp.Clear();
                arr.Clear();
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (mp.Contains(target - nums[j]) /*&& !arr.Contains(target - nums[j])*/ )
                    {
                        Console.WriteLine(nums[j] + " " + first + " " + (target - nums[j]));
                        arr.Add(first);
                        arr.Add(nums[j]);
                        arr.Add(target - nums[j]);
                        ans.Add(arr);
                    }
                    mp.Add(nums[j]);
                }
            }
            return ans;
        }
    }
}

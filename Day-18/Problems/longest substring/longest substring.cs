public class Solution {
    public int LengthOfLongestSubstring(string s) {
        HashSet<char> set = new HashSet<char>();
        int left = 0, right = 0;
        int maxLength = 0;

        while (right < s.Length) {
            if (!set.Contains(s[right])) {
                set.Add(s[right]);
                maxLength = Math.Max(maxLength, right - left + 1);
                right++;
            } else {
                set.Remove(s[left]);
                left++;
            }
        }

        return maxLength;
    }
}
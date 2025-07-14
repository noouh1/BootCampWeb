﻿public class Solution {
    public string SimplifyPath(string path) {
        Stack<string> stack = new Stack<string>();
        string[] parts = path.Split('/');

        foreach (string part in parts) {
            if (part == "" || part == ".") {
                continue;
            } else if (part == "..") {
                if (stack.Count > 0)
                    stack.Pop(); 
            } else {
                stack.Push(part); 
            }
        }

        var result = new List<string>(stack);
        result.Reverse();

        return "/" + string.Join("/", result);
    }
}
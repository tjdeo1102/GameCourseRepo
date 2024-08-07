using System;
using System.Collections.Generic;


/// <summary>
/// 올바른 괄호
/// 1. 들어오는 문자 차례로 스택에 '(' 인 경우엔 담고, ')'의 경우, 스택의 top이 '(' 인지 유효성 검사
/// 2. foreach 이후, 아직 처리되지 않은 문자가 있다면, 정상적으로 처리되지 않는 괄호만 남은 경우이므로 오류
/// </summary>
public class Solution {
    public bool solution(string s) {
        bool answer = true;
        
        Stack<int> stack = new Stack<int>();
        
        foreach(char c in s)
        {
            if (c == '(')
            {
                stack.Push(c);
            }
            else
            {
                if (stack.Count < 1 || stack.Pop() != '(')
                {
                    answer = false;
                    break;
                }
            }
        }
        if (stack.Count > 0 )
        {
            answer = false;
        }
        
        return answer;
    }
}
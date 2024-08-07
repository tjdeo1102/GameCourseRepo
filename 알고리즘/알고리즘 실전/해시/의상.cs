using System;
using System.Collections.Generic;
/// <summary>
/// 의상
/// 1. 의상의 종류를 키로 하여, 값을 추가
/// 2, 이미 같은 종류의 키가 존재하는 경우, 기존 값의 1을 더해준다.
/// 3. 각 종류별의 조합으로 만들어 질 수있는 조합을 계산 (종류가 안골라질 수 있는 경우가 있으므로 +1하여 곱한다.)
/// </summary>
public class Solution {
    public int solution(string[,] clothes) {
        int answer = 1;
        Dictionary<string,int> dic = new Dictionary<string,int>();
        for(int i =0; i<clothes.GetLength(0); i++)
        {
            if (dic.ContainsKey(clothes[i,1]))
            {
                dic[clothes[i,1]] += 1;
            }
            else dic.Add(clothes[i,1],1);
        }
        foreach (var key in dic.Keys)
        {
            answer *= (dic[key] + 1);
        }
        return answer - 1;
    }
}
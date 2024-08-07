using System;
using System.Collections.Generic;

/// <summary>
/// K번째 수
/// 1. 각 커맨드의 자를 범위에 따라 새로운 배열 할당
/// 2. 해당 배열로 기존 배열에서 범위에 해당하는 데이터 복사
/// 3. 해당 배열 정렬 후, 해당되는 숫자를 정답에 추가
/// </summary>
public class Solution {
    public int[] solution(int[] array, int[,] commands) {
        List<int> answer = new List<int>();
        for(int i = 0 ; i < commands.GetLength(0) ; i++)
        {
            int len = commands[i, 1] - commands[i,0];
            int[] copyArr = new int[len+1];
            for (int j = 0; j <= len; j++)
            {
                int idx = commands[i,0] + j - 1;
                copyArr[j] = array[idx];
            }
            Array.Sort(copyArr);
            answer.Add(copyArr[commands[i,2]-1]);
        }
        return answer.ToArray();
    }
}
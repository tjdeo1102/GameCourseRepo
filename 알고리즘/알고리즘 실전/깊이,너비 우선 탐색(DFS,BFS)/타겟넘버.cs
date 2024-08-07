using System;
using System.Collections.Generic;

/// <summary>
/// 타겟 넘버
/// 1. 큐에 처음 들어온 수는 양수, 음수의 경우만 생각해서 삽입
/// 2. 이후로 들어온 수는 큐에 있는 숫자들에서 더해주거나 빼주는 방식으로, 이전에 저장된 수가 추후, 가질 수 있는 가능한 수들을 새로운 큐에 저장 
/// 3. 새로운 큐는 기존 큐를 대체
/// 4. 마지막 시점 큐에는 가질 수 있는 모든 결과에 대한 정보가 담겨있으므로, 타겟 넘버와 같은 숫자가 있으면 카운팅
/// </summary>
public class Solution {
    public int solution(int[] numbers, int target) {
        int answer = 0;
        Queue<int> q = new Queue<int>();
        foreach(int num in numbers)
        {
            Queue<int> new_q = new Queue<int>();
            if (q.Count == 0)
            {
                new_q.Enqueue(num);
                new_q.Enqueue(-num);
            }
            while(q.Count > 0)
            {
                int cur = q.Dequeue();
                new_q.Enqueue(cur + num);
                new_q.Enqueue(cur - num);
            }
            q = new_q;
        }
        while(q.Count > 0)
        {
            if (q.Dequeue() == target) answer++;
        }
        return answer;
    }
}
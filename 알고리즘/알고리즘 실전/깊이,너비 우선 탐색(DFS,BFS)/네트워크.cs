using System;
using System.Collections.Generic;

/// <summary>
/// 네트워크
/// 1. 차례로 각 컴퓨터를 순회, 그러나, 큐에 의해 이미 방문된 컴퓨터는 제외
/// 2. 각 컴퓨터를 큐에 넣고, 큐가 비어있을 때까지 아래의 과정 반복
/// 3. 큐에 있는 컴퓨터에서 이어진 컴퓨터들을 탐색
/// 4. 이어진 컴퓨터가 이미 방문되었으면 제외, 방문하지 않았다면, 방문 표시 이후, 큐에 삽입
/// 5. 3~4의 과정 반복 후, 하나의 네트워크가 생성되었으므로 정답 카운트 1 상승
/// </summary>
public class Solution {
    public int solution(int n, int[,] computers) {
        int answer = 0;
        bool[] isVisit = new bool[n];
        for(int i = 0; i < n; i++)
        {
            if (isVisit[i] == true) continue;
            Queue<int> q = new Queue<int>();
            q.Enqueue(i);
            isVisit[i] = true;
            while(q.Count >0)
            {
                var cur = q.Dequeue();
                for (int j = 0; j <n; j++)
                {
                    if(isVisit[j] == true) continue;
                    if(computers[cur,j] == 0) continue;
                    isVisit[j] = true;
                    q.Enqueue(j);
                }
            }
            answer++;
        }
        return answer;
    }
}
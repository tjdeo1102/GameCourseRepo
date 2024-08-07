using System;
using System.Collections.Generic;

/// <summary>
/// 게임 맵 최단거리
/// 1. 먼저, 방문 이력을 담은 배열을 -1로 초기화
/// 2. 출발지점을 큐에 넣은 후, 큐가 비어있을 때까지 아래 과정 반복
/// 3. 각 큐에서 값을 꺼내, 해당 지점에서 갈 수 있는 다음 위치들 고려
/// 4. 다음 위치마다 맵 범위 내인지, 벽이 있는 곳인지, 방문한적 있는지, 현재 방문 칸수 + 1가 다음 위치의 방문 칸 수 이상인지 확인
/// 5. 4의 조건인 경우, 다음 위치를 가는 것은 불가능, 다른 다음위치를 고려
/// 6. 유효한 다음 위치인경우, 방문이력을 갱신하고 큐에 다음 위치를 추가
/// 7. 4~6의 과정 이후, 출발지점으로 부터 갈 수 있는 모든 방문 가능 지점을 방문하게 된다.
/// 8. 도착 지점에 저장되어 있는 값은 모든 방문 가능성을 비교해서 나온 최소값이므로 해당 값이 정답
/// </summary>
class Solution {
    public int solution(int[,] maps) {
        int answer = 0;
        Tuple<int,int>[] dirs = {Tuple.Create(1,0),Tuple.Create(-1,0),Tuple.Create(0,1),Tuple.Create(0,-1)};
        int lenX = maps.GetLength(1);
        int lenY = maps.GetLength(0);
        Queue<Tuple<int,int>> q = new Queue<Tuple<int,int>>(); 
        int[,] visit_history = new int[lenY,lenX];
        for (int i = 0 ; i < lenY ; i++)
        {
            for(int j =0 ; j< lenX ; j++)
            {
                visit_history[i,j] = -1;
            }
        }
        visit_history[0,0] = 1;
        q.Enqueue(Tuple.Create(0,0));
        while(q.Count > 0)
        {
            var cur = q.Dequeue();
            foreach(var dir in dirs)
            {
                var nxtY = cur.Item1+dir.Item1;
                var nxtX = cur.Item2+dir.Item2;
                
                if (nxtX < 0 || nxtY<0 || nxtX >= lenX || nxtY >= lenY) continue;
                if (maps[nxtY,nxtX] == 0) continue;
                var curPoint = visit_history[cur.Item1,cur.Item2] + 1;
                if (visit_history[nxtY,nxtX] != -1 && curPoint >= visit_history[nxtY,nxtX]) continue;
                visit_history[nxtY,nxtX] = curPoint;
                q.Enqueue(Tuple.Create(nxtY,nxtX));
            }
        }
        answer = visit_history[lenY-1,lenX-1];
        return answer;
    }
}
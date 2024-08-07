#include <vector>
#include <string>
#include <iostream>

using namespace std;

/// <summary>
/// 기능개발
/// 1. 스택에 일을 계속 담되, 담을 때, top까지의 일 소요시간과 새로 들어오는 업무의 소요시간을 비교하여, 들어오는 업무시간이 큰경우에만 담기
/// 2. 새로 들어오는 업무시간이 같거나 작으면, 스택에 담겨진 처리된 업무의 수를 1 더한다.
/// </summary>

vector<int> solution(vector<int> progresses, vector<int> speeds) {
    vector<int> answer;
    int last_finished_day = 0;
    for (int i = 0 ; i <progresses.size(); i++)
    {
        int work_day = (100 - progresses[i]) / speeds[i];
        if ((100 - progresses[i]) % speeds[i] > 0) work_day++;
        
        if (last_finished_day < work_day) 
        {
            answer.push_back(1);
            last_finished_day = work_day;
        }
        else answer[answer.size()-1]++;
    }
    return answer;
}
#include <vector>
#include <iostream>

using namespace std;

/// <summary>
/// 같은 숫자는 싫어
/// 1. 스택에 값을 넣을 때, 스택의 top을 비교하여 다른 숫자인 경우에만 삽입
/// </summary>
vector<int> solution(vector<int> arr) 
{
    vector<int> answer;

    for (int i : arr)
    {
        if (answer.size() > 0 && answer.back() == i) continue;
        answer.push_back(i);
    }

    return answer;
}
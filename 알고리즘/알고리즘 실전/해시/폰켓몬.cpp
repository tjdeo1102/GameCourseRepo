#include <vector>
#include <set>
using namespace std;

/// <summary>
/// 폰켓몬
/// 1. set을 이용해 같은 종류는 하나만 존재하도록 입력받음
/// 2. selectNum만큼 종류를 선택하기
/// </summary>
int solution(vector<int> nums)
{
    int answer = 0;
    int selPoketNum = nums.size() / 2;
    set<int> s;
    for (int poket : nums)
    {
        s.insert(poket);
    }
    for (int n : s)
    {
        if (selPoketNum > 0)
        {
            answer++;
            selPoketNum--;
        }
    }
    return answer;
}
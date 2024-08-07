#include <vector>
#include <set>
using namespace std;

/// <summary>
/// ���ϸ�
/// 1. set�� �̿��� ���� ������ �ϳ��� �����ϵ��� �Է¹���
/// 2. selectNum��ŭ ������ �����ϱ�
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
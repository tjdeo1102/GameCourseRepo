#include <string>
#include <vector>
#include <set>
#include <algorithm>
using namespace std;

/// <summary>
/// 전화번호 목록
/// 1. set에 전화번호들을 넣을 때, 길이 오름차순 기준으로 정렬되도록 설정
/// 2. 전화번호 넣을 때마다, 해당 문자를 부분문자열로 잘라, 모든 가능한 문자열에 대해 탐색
/// </summary>
bool solution(vector<string> phone_book) {
    bool answer = true;
    set<string> phone_set;
    sort(phone_book.begin(), phone_book.end(), [](const string &a, const string &b) {
        return a.length() < b.length();
    });
    for (string s:phone_book)
    {
        for (int i = 1; i <= s.length(); i++)
        {
            if (phone_set.find(s.substr(0,i)) != phone_set.end())
            {
                answer = false;
            }
        }
        phone_set.insert(s);
    }
    return answer;
}
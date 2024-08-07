#include <string>
#include <vector>
#include <set>
#include <algorithm>
using namespace std;
/// <summary>
/// 완주하지 못한 선수
/// 1. multiset에 중복된 참자가 이름도 넣을 수 있도록 만들기
/// 2. 완주자의 이름을 받아와서, 해당 이름에 일치하는 참가자를 하나씩 지우기
/// </summary>
string solution(vector<string> participant, vector<string> completion) {
    multiset<string> participant_set;
    for(string s : participant)
    {
        participant_set.insert(s);
    }
    for(string s : completion)
    {
        participant_set.erase(participant_set.find(s));
    }
    string answer = *(participant_set.begin());
    return answer;
}
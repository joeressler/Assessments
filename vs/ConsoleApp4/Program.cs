using System.Linq;

bool solution(string inputString)
{
    if (inputString == new string(inputString.Reverse().ToArray())) {  return true; } return false;
}



Console.WriteLine(solution("abac"));
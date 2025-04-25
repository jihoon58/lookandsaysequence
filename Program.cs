namespace _0417_lookandsaysequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("원하는 수열의 항을 입력하세요: ");
            int wantedNumber = int.Parse(Console.ReadLine()); //원하는 항수 입력받기
            List<int> lookAndSaySequence = new List<int>(); //개미수열
            lookAndSaySequence.Add(1); //a_1 선언, 1항 선언
            lookAndSaySequence = WantedLASSN(lookAndSaySequence, wantedNumber); //원하는 개미수열의 항 
            Console.WriteLine($"개미수열의 {wantedNumber}항은 {string.Join("", lookAndSaySequence)}입니다"); // 개미수열 출력
        }
        static int CountSame(List<int> a, int i) //같은 숫자 개수 세기
        {
            int count = 1;
            for (; ; i++)
            {
                if (i + 1 == a.Count)
                {
                    break;
                }
                else if (a[i] == a[i + 1])
                {
                    count++;
                }
                else
                {
                    break;
                }
            }
            return count;
        }
        static List<int> NextNumber(List<int> before) //개미수열 다음 항 구하기
        {
            int i = 0;
            List<int> after = new List<int>();
            while (true)
            {
                if (i == before.Count)
                {
                    break;
                }

                after.Add(before[i]);
                int num = CountSame(before, i);
                after.Add(num);
                i += num;
            }
            return after;
        }
        static List<int> WantedLASSN(List<int> lookAndSaySequence, int wantedNumber) //원하는 개미수열 항 구하기
        {
            for (int i = 0; i < wantedNumber - 1; i++)
            {
                lookAndSaySequence = NextNumber(lookAndSaySequence);
            }
            return lookAndSaySequence;
        }
    }
}

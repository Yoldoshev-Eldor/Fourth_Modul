using System.Text;

namespace LeetCode
{
    internal class Program 
    {
        static void Main(string[] args)
        {
            // Console.Write("Massiv uzunligini kiriting: ");
            // var arrayLength = int.Parse(Console.ReadLine());
            // var array = new int[arrayLength];
            //for(var i =0; i<array.Length-1;i++)
            // {
            //     Console.Write($"arrayni {i+1} xonasini kiriting: ");
            //     array[i] = int.Parse(Console.ReadLine());
            // }

            // var res = 0;

            // Console.Write("res qiymatni kiriting: ");
            // res = int.Parse(Console.ReadLine());

            // var finish = AddNumsToArray(array, res);
            // Console.WriteLine($"natija : {finish}");

            Console.WriteLine(IsPalindrome(121));
        }
        public static bool IsPalindrome(int x)
        {
            var res = 0;
            var orign = x;
            while(x>0)
            {
                res += (x % 10);
                res *= 10;
                x = x / 10;
            }
      
            if (res == orign) return true;
            else return false;

        }
        public static void ReverseString(char[] s)
        {
            var res = new char[s.Length];
            for(var i = s.Length-1; i >= 0;i--)
            {
                res[i] += s[i];
            }
            s = res;
            
        }
        public static bool IsPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s)) return true;

            var res1 = new StringBuilder();
            var res2 = new StringBuilder();

            foreach (char c in s)
            {
                if (char.IsLetterOrDigit(c))
                {
                    res1.Append(char.ToLower(c));
                }
            }

            for (int i = res1.Length - 1; i >= 0; i--)
            {
                res2.Append(res1[i]);
            }

            return res1.ToString() == res2.ToString();



        }

        public static bool AddNumsToArray(int[] array, int res)
        {
            var result = false;

            for (var i = 0; i < array.Length - 1; i++)
            {
                for (var j = i; j < array.Length - 1; j++)
                {
                    if (array[i] + array[j] == res)
                    {
                        result = true;
                        Console.WriteLine($"[{array[j]} , {array[i]}]");
                    }
                }
            }
            return result;
        }

        public static int LengthOfLastWord(string str)
        {

            var count = 0;
            var s = str.TrimEnd();
            for (var i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == ' ') break;
                if (s[i] != ' ')
                {
                    count++;
                }

            }
            return count;
        }

    }
}

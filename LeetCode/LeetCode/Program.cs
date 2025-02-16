using System.Numerics;

namespace LeetCode
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(AddStrings("43","43"));
        }


        public   string AddStrings(string num1, string num2)
        {

            var res1 = Int128.Parse(num1);
            var res2 = Int128.Parse(num2);

           
            var result = "0";
            if(res1 == 0 && res2 ==0)
            {
                return result; 
            }

            BigInteger result2 = (res1 + res2);

            return result2.ToString();
        }

    }


}

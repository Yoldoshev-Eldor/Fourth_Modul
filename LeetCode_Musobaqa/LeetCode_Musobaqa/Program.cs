using System.Collections.Immutable;

namespace LeetCode_Musobaqa
{
    internal class Program
    {
        static void Main(string[] args)
        {

            

          

        }

        //1-misol
        public  int[] LittleElementInMassiv(int[] massiv)
        {

            var res = new int[massiv.Length];
            for (var i = 0; i < massiv.Length; i++)
            {
                var count = 0;
                for (var j = 0; j < massiv.Length; j++)
                {
                    if (massiv[j] < massiv[i])
                    {
                        count++;
                    }
                }
                res[i] = count;
            }
            return res;
        }

        ///2-misol

        public static int KattaTub(int[,] array)
        {
            var res = new List<int>();
            for(var i = 0; i<array.Length;i++)
            {
                for(var j = 0;j< array.Length;j++)
                {
                    if(i==j || i==0&& j==2 || i==2&&j==0)
                    {
                        res.Add(array[i, j]);
                    }
                }
            }
            var res2 = new List<int>();
             for(var i = 0; i<res.Count;i++)
            {
                var count = 0;
                for(var j = 0;j>= res[i];j++)
                {
                    if (res[i]%j==0)
                    {
                        count++;
                    }
                    if(count==2)
                    {
                        res2.Add(res[i]);
                    }
                }
               

            }
            var f = res2.Max();
            return f;

        }
        ///3-misol

        public static int NotMaxAndNotMin(int[] nums)
        {
            var res = new List<int>();
            for (var i = 0; i < nums.Length; i++)
            {
                res.Add(nums[i]);
            }
            res.Sort();


            if (res.Count > 2)
            {
                for (var i = 0; i < res.Count - 1; i++)
                {
                    if (res[0] < res[i])
                    {
                        return res[i];

                    }
                }
            }

            return -1;
        }

        //4-misol

        public static int CountJewels(string jewels, string strones)
        {
            if (jewels.Length > 1)
            {
                var res1 = jewels[0];
                var res2 = jewels[1];
                var count1 = 0;

                for (var i = 0; i < strones.Length; i++)
                {
                    if (strones[i] == res1 || strones[i] == res2)
                    {
                        count1++;
                    }

                }
                return count1;
            }
            var count = 0;
            foreach (var i in strones)
            {
                if (i == jewels[0])
                {
                    count++;
                }
            }
            return count;
        }


        
        
        //6-misol

        public static string PalindromStr(string s)
        {
           
            while(true)
            {
                var res = string.Empty;
                if (s[0] != s[s.Length-1])
                {
                    s = s.Substring(1, s.Length - 2);
                }
                for(var i = s.Length-1; i<=0; i--)
                {
                    res += s[i];
                }
                if(res==s)
                {
                    return res;
                    
                }
                if (s.Length < 1) break;

            }
            return "";
        }

    }



}


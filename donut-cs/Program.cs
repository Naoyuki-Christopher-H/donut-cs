using System;

namespace donut_cs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Smooth Centered Donut";
            Console.CursorVisible = false;

            try
            {
                Solution solution = new Solution();
                solution.RunDonut();
            }
            finally
            {
                Console.CursorVisible = true;
            }
        }
    }
}
using System;

namespace donut_cs
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Configure console window
                Console.Title = "ASCII Donut Animation";
                Console.CursorVisible = false;

                // Adjust window size to match our buffer (minimum 80x24)
                try
                {
                    Console.WindowWidth = 80;
                    Console.WindowHeight = 24;
                    Console.BufferWidth = 80;
                    Console.BufferHeight = 24;
                }
                catch
                {
                    // If we can't resize, continue with current size
                    Console.WriteLine("Note: Couldn't resize console window");
                }

                // Start the animation
                var donutAnimation = new Solution();
                donutAnimation.RunDonut();
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine($"An error occurred: {ex.Message}");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
            finally
            {
                // Clean up
                Console.CursorVisible = true;
                Console.ResetColor();
                Console.Clear();
            }
        }
    }
}
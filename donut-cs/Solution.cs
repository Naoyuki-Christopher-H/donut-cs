using System;
using System.Threading;

namespace donut_cs
{
    class Solution
    {
        public Solution()
        {
        }

        public void RunDonut()
        {
            double A = 0;
            double B = 0;
            var z = new double[7040];
            var b = new char[1760];

            // Adjustable parameters
            const double rotationSpeed = 0.03; // Reduced from 0.04/0.02 to 0.75x speed
            const int xOffset = 0;  // Center adjustment
            const int yOffset = -3; // Center adjustment
            const int frameDelay = 16; // ~60fps for smooth animation

            while (true)
            {
                memset(b, ' ', 1760);
                memset(z, 0.0, 7040);

                for (double j = 0; j < 6.28; j += 0.07)
                {
                    for (double i = 0; i < 6.28; i += 0.02)
                    {
                        double c = Math.Sin(i);
                        double d = Math.Cos(j);
                        double e = Math.Sin(A);
                        double f = Math.Sin(j);
                        double g = Math.Cos(A);
                        double h = d + 2;
                        double D = 1 / (c * h * e + f * g + 5);
                        double l = Math.Cos(i);
                        double m = Math.Cos(B);
                        double n = Math.Sin(B);
                        double t = c * h * g - f * e;

                        // Added offsets to center the donut
                        int x = (int)(40 + 30 * D * (l * h * m - t * n)) + xOffset;
                        int y = (int)(12 + 15 * D * (l * h * n + t * m)) + yOffset;
                        int o = x + 80 * y;
                        int N = (int)(8 * ((f * e - c * d * g) * m - c * d * e - f * g - l * d * n));

                        if (y < 22 && y > 0 && x > 0 && x < 80 && D > z[o])
                        {
                            z[o] = D;
                            b[o] = ".,-~:;=!*#$@"[N > 0 ? N : 0];
                        }
                    }
                }

                Console.Clear();
                AddNewlines(b);
                Console.Write(b);

                // Apply slower rotation
                A += rotationSpeed;
                B += rotationSpeed * 0.5;

                // Smooth frame timing
                Thread.Sleep(frameDelay);
            }
        }

        private void memset<T>(T[] buf, T val, int bufsz)
        {
            if (buf == null)
            {
                buf = new T[bufsz];
            }

            for (int i = 0; i < bufsz; i++)
            {
                buf[i] = val;
            }
        }

        private void AddNewlines(char[] b)
        {
            for (int i = 80; i < 1760; i += 80)
            {
                b[i] = '\n';
            }
        }
    }
}
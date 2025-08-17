using System;
using System.Threading;

namespace donut_cs
{
    public class Solution
    {
        // Screen dimensions
        private const int ScreenWidth = 80;
        private const int ScreenHeight = 22;
        private const int BufferSize = ScreenWidth * ScreenHeight;

        // Animation parameters
        private const double RotationSpeedA = 0.03;
        private const double RotationSpeedB = 0.015;
        private const int FrameDelayMs = 16;

        // Donut parameters
        private const double DonutRadius = 1.0;
        private const double TubeRadius = 2.0;
        private const double ViewDistance = 5.0;

        // Centering offsets
        private const int HorizontalOffset = 0;
        private const int VerticalOffset = -3;

        public void RunDonut()
        {
            double angleA = 0;
            double angleB = 0;

            var zBuffer = new double[BufferSize];
            var frameBuffer = new char[BufferSize];

            while (true)
            {
                // Replace Array.Fill with manual initialization
                for (int i = 0; i < BufferSize; i++)
                {
                    frameBuffer[i] = ' ';
                    zBuffer[i] = 0;
                }

                // Iterate through torus angles
                for (double theta = 0; theta < 2 * Math.PI; theta += 0.07)
                {
                    for (double phi = 0; phi < 2 * Math.PI; phi += 0.02)
                    {
                        // Precompute trigonometric values
                        double sinPhi = Math.Sin(phi);
                        double cosTheta = Math.Cos(theta);
                        double sinAngleA = Math.Sin(angleA);
                        double sinTheta = Math.Sin(theta);
                        double cosAngleA = Math.Cos(angleA);

                        // Torus geometry calculations
                        double circleDistance = TubeRadius + DonutRadius * cosTheta;
                        double inverseDistance = 1 / (sinPhi * circleDistance * sinAngleA + sinTheta * cosAngleA + ViewDistance);

                        double cosPhi = Math.Cos(phi);
                        double cosAngleB = Math.Cos(angleB);
                        double sinAngleB = Math.Sin(angleB);
                        double t = sinPhi * circleDistance * cosAngleA - sinTheta * sinAngleA;

                        // Calculate screen coordinates
                        int x = (int)(ScreenWidth / 2 + (ScreenWidth / 2.7) * inverseDistance *
                                      (cosPhi * circleDistance * cosAngleB - t * sinAngleB)) + HorizontalOffset;

                        int y = (int)(ScreenHeight / 2 + (ScreenHeight / 2) * inverseDistance *
                                      (cosPhi * circleDistance * sinAngleB + t * cosAngleB)) + VerticalOffset;

                        int bufferIndex = x + ScreenWidth * y;

                        // Luminance calculation
                        int luminanceIndex = (int)(8 * (
                            (sinTheta * sinAngleA - sinPhi * cosTheta * cosAngleA) * cosAngleB -
                            sinPhi * cosTheta * sinAngleA -
                            sinTheta * cosAngleA -
                            cosPhi * cosTheta * sinAngleB));

                        if (y >= 0 && y < ScreenHeight &&
                            x >= 0 && x < ScreenWidth &&
                            inverseDistance > zBuffer[bufferIndex])
                        {
                            zBuffer[bufferIndex] = inverseDistance;
                            frameBuffer[bufferIndex] = ".,-~:;=!*#$@"[Math.Max(luminanceIndex, 0)];
                        }
                    }
                }

                // Render frame
                Console.SetCursorPosition(0, 0);
                Console.Write(FormatFrameBuffer(frameBuffer));

                // Update rotation angles
                angleA += RotationSpeedA;
                angleB += RotationSpeedB;

                Thread.Sleep(FrameDelayMs);
            }
        }

        private char[] FormatFrameBuffer(char[] buffer)
        {
            // Create a copy to avoid modifying the original buffer
            var formattedBuffer = new char[BufferSize + ScreenHeight - 1];
            int targetIndex = 0;

            for (int y = 0; y < ScreenHeight; y++)
            {
                for (int x = 0; x < ScreenWidth; x++)
                {
                    formattedBuffer[targetIndex++] = buffer[x + y * ScreenWidth];
                }

                // Add newline except after last row
                if (y < ScreenHeight - 1)
                {
                    formattedBuffer[targetIndex++] = '\n';
                }
            }

            return formattedBuffer;
        }
    }
}
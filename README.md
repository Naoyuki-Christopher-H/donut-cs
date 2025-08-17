# Donut Animation in C#

Donut Animation in C# is a console-based 3D rendering of a spinning donut using ASCII art. 
The mathematically-generated torus rotates in 3D space while shaded with ASCII characters. 
Clean code structure maintains the original algorithm while adding centering and speed controls. 
A classic programming demo showcasing 3D math in console.

## Features

- Smooth 3D donut animation rendered in console
- Adjustable rotation speed
- Centered display in console window
- Optimized for C# 7.0 compatibility
- Clean, well-structured code in Allman style

## Requirements

- .NET Framework (version supporting C# 7.0)
- Console terminal that supports ANSI (standard Windows Console works)

## Installation

1. Clone the repository:
```
git clone https://github.com/Naoyuki-Christopher-H/donut-cs.git
```

2. Open the solution in Visual Studio (2017 or later recommended)

3. Build and run the project

## Usage

Simply run the compiled executable. The animation will start automatically.

To exit: Press Ctrl+C in the console window.

## Customization

You can adjust these parameters in Solution.cs:
- `rotationSpeed`: Controls how fast the donut spins
- `xOffset` and `yOffset`: Adjust the donut's position
- `frameDelay`: Controls animation smoothness (milliseconds per frame)

## Technical Details

The animation uses:
- 3D coordinate transformations
- Z-buffering for proper depth sorting
- ASCII character shading based on surface normal
- Fixed timestep animation for smooth rotation

## DISCLAIMER  

UNDER NO CIRCUMSTANCES SHOULD IMAGES OR EMOJIS BE INCLUDED DIRECTLY IN 
THE README FILE. ALL VISUAL MEDIA, INCLUDING SCREENSHOTS AND IMAGES OF 
THE APPLICATION, MUST BE STORED IN A DEDICATED FOLDER WITHIN THE PROJECT 
DIRECTORY. THIS FOLDER SHOULD BE CLEARLY STRUCTURED AND NAMED ACCORDINGLY 
TO INDICATE THAT IT CONTAINS ALL VISUAL CONTENT RELATED TO THE APPLICATION 
(FOR EXAMPLE, A FOLDER NAMED IMAGES, SCREENSHOTS, OR MEDIA).

I AM NOT LIABLE OR RESPONSIBLE FOR ANY MALFUNCTIONS, DEFECTS, OR ISSUES THAT 
MAY OCCUR AS A RESULT OF COPYING, MODIFYING, OR USING THIS SOFTWARE. IF YOU 
ENCOUNTER ANY PROBLEMS OR ERRORS, PLEASE DO NOT ATTEMPT TO FIX THEM SILENTLY 
OR OUTSIDE THE PROJECT. INSTEAD, KINDLY SUBMIT A PULL REQUEST OR OPEN AN ISSUE 
ON THE CORRESPONDING GITHUB REPOSITORY, SO THAT IT CAN BE ADDRESSED APPROPRIATELY 
BY THE MAINTAINERS OR CONTRIBUTORS.

---

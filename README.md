# JobProc_without_threads
Tools and technologies:
- MS Visual Studio;
- .NET 5.0;
- three-layer architecture;
- Microsoft.Extensions.DependencyInjection;
- Windows Forms;
- Xunit.

Task: A job of 1000 images is going to be edited by a crew of 3 people:
- P1: 1 image per 2 minutes;
- P2: 1 image per 3 minutes;
- P3: 1 image per 4 minutes.

Count of pictures and people can be changed. For calculation using special algorithm.
For the test - uncomment line 125 in main.cs (to check the total count of processed images).

Result:
- total time;
- count of images edited by each person.

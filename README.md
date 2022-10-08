# TOY ROBOT SIMULATOR

### About Simulator

The library simulates a toy robot moving on a square 5 x 5 table without any obstructions. To start the simulator, the robot has to be placed on the table. 
However, all the movements until the robot is placed on the table surface are ignored. The robot is free to roam around the table and is programmed to prevent it from falling off the 
table. Valid movements that cause the robot to fall off the table are ignored but further moves are still allowed. Library read inputs
as commands line inputs.

### Sample commands should be in the following format:

PLACE X,Y,DIRECTION
MOVE
LEFT
RIGHT
REPORT

PLACE: will put the toy robot on the table in positions X, Y and facing NORTH, SOUTH, EAST or WEST. (0,0) can be considered as the SOUTH WEST corner
and (5,5) as the NORTH EAST corner. The first valid command to the robot is a PLACE command. After that, any sequence of commands may be issued, 
in any order, including another PLACE command. The library should discard all commands in the sequence until a valid PLACE command has been 
executed. The PLACE command should be discarded if it places the robot outside of the table surface.

MOVE: will move the toy robot one unit forward in the direction it is currently facing.

LEFT and RIGHT: the robot will rotate 90 degrees in the specified direction without changing the position of the robot.

REPORT: will announce the X, Y and orientation of the robot.

A robot that is not on the table can choose to ignore the MOVE, LEFT, RIGHT and REPORT commands.

### Example Input and Output:

PLACE 0, 0, NORTH
MOVE
REPORT

Output: 0,1,NORTH

PLACE 0, 0, NORTH
LEFT
REPORT

Output: 0, 0, WEST

PLACE 1, 2, EAST
MOVE
MOVE
LEFT
MOVE
REPORT

Output: 3, 3, NORTH

### Running the solution:

The application is written in Visual Studio 2022. The application is a .Net Core 3.1 application. RobotLibrary 
contains all the functionalities of the robot. A robot Simulator is used to pass the given command to the robot. When
you run the console application, commands will be executed automatically and output displayed on the console window.

### Running Unit Tests:

Tests are running using xUnit V 2.4.0 and xUnit runner V 2.4.0 NuGet packages.

### Supporting Operating system:
This application was tested on Windows 11 Pro.
# ConsoleTable
A [blog](https://github.com/SoupyzInc/ConsoleTable/wiki) on how I made a library that can help create beautiful, easy-to-use tables for console applications. This project is heavily inspired by [Spectre.Console](https://github.com/spectresystems/spectre.console) by [Patrik Svensson](https://github.com/patriksvensson). Go check him and his project out!

```cs
Table table = new Table();

table.AddRow(@" ", @"Foo", @"Bar", @"Green, Eggs, and Ham");
table.AddRow(@"12/18", @"56", @"67", @"93247");
table.AddRow(@"12/19", @"-342879374927894", @"0", @"Fourty-two");

Console.WriteLine("Foo and Bar Inventory");
table.Render();
```

![](https://github.com/SoupyzInc/ConsoleTable/blob/main/Wiki/Images/Foo%20and%20Bar%20Inventory.png)

*A table printed into the console using ConsoleTable.*

# Table of Contents
## [Home](https://github.com/SoupyzInc/ConsoleTable/wiki/Home)
## [Basic Functionality](https://github.com/SoupyzInc/ConsoleTable/wiki/Basic-Functionality)
### [Goal](https://github.com/SoupyzInc/ConsoleTable/wiki/Basic-Functionality#goal)
### [Planning](https://github.com/SoupyzInc/ConsoleTable/wiki/Basic-Functionality#planning)
### [Coding](https://github.com/SoupyzInc/ConsoleTable/wiki/Basic-Functionality#coding)
[The Row Class](https://github.com/SoupyzInc/ConsoleTable/wiki/Basic-Functionality#the-row-class)

[The Table Class](https://github.com/SoupyzInc/ConsoleTable/wiki/Basic-Functionality#the-table-class)

### [Example](https://github.com/SoupyzInc/ConsoleTable/wiki/Basic-Functionality#example)
## [Advanced Functionality](https://github.com/SoupyzInc/ConsoleTable/wiki/Advanced-Functionality)
### [A New AddRow Method](https://github.com/SoupyzInc/ConsoleTable/wiki/Advanced-Functionality#a-new-addrow-method)
### [No-Fix List](https://github.com/SoupyzInc/ConsoleTable/wiki/Advanced-Functionality#no-fix-issues)

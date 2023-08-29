# Windows Forms Demo for SYSTEMTECHNIK GmbH

## Description

A simple .NET Windows Forms, build with VScode (unfortunately has no build-in UI editor).
For demonstration purposes kept simple and easy to a minimum, using classic .NET 4.7.
Project exists only of the initial Program.cs to start-up the Windows Form and the Form1.cs (no separate data layer, etc.).

The json file is received by a simple Http GET request and de-serialized into a simple ```<string, string>``` datastructure, then added into a classic DataGridView.

---

## Build

Open the demo.sln with an .NET C# IDE, then build & run the project.
Alternatively can build and run the application by CLI, using ```dotnet run```.

---

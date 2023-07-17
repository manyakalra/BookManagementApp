@echo off 

csc -t:library -out:Math.dll Permutation.cs Combination.cs Factorial.cs

csc -out:CalculatorApp.exe -r:Math.dll Program.cs Input.cs
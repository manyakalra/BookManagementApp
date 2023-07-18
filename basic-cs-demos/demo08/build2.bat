@echo off

md bin

csc data\*.cs -t:library -out:bin\data.dll

csc furnitures\*.cs -t:library -out:bin\furnitures.dll

csc utils\*.cs -t:library -out:bin\utils.dll

csc Program.cs -r:bin\utils.dll,bin\furnitures.dll,bin\data.dll -out:bin\program.exe

echo @bin\program >run.bat
@echo off

md %2

set classname=%1
set foldername=%2

set filename=.\%foldername%\%classname%.cs

md %foldername%
 


echo public class %1 >%filename%
echo { >>%filename%
echo } >>%filename%



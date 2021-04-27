@ECHO OFF

ECHO Kornyezet kialakitasa...
MKDIR Snake\Snake\bin\Debug
TIMEOUT /t 1 /nobreak > NUL
ECHO Fajlok masolasa...
CP config.txt Snake/Snake/bin/Debug/config.txt
TIMEOUT /t 1 /nobreak > NUL
ECHO KESZ!

PAUSE
# Snake
School project

## Config file

K�GY�:
======

### K�gy� gyorsas�ga millisecben (ms)
snake\_speed: [sz�m]

### Ha a k�gy� nekimegy a falnak, akkor meghaljon-e vagy tov�bb menjen
snake\_dieOnWallColl: [logikai �rt�k]

EREDM�NYEK:
===========

### Eredm�ny f�jl el�rhet�s�g�nek �tvonala
score\_file: [�tvonal]

### �tel �rt�k�nek a be�ll�t�sa (Ha a k�gy� megeszik egy kaj�t, akkor h�ny pontot adjon hozz� a scorehoz)
score\_add: [sz�m]


P�LD�K:
=======

snake\_speed: 1000 (Vagyis a k�gy�, 1 mp -enk�nt egyet halad el�re, mivel 1000 ms = 1 mp)
snake\_dieOnWall: true (Vagyis amikor a k�gy� neki�tk�zik a falnak, akkor meghal)
score\_file: "myScores.txt" (Lehet relat�v �s abszol�t el�r�si c�met is megadni)
score\_add: 20 (Amikor a k�gy� megeszik egy doll�rjelet, akkor 20 pont fog hozz�ad�dni a jelenlegi pontj�hoz)

# Snake
School project

## Config file

KÍGYÓ:
======

### Kígyó gyorsasága millisecben (ms)
snake\_speed: [szám]

### Ha a kígyó nekimegy a falnak, akkor meghaljon-e vagy tovább menjen
snake\_dieOnWallColl: [logikai érték]

EREDMÉNYEK:
===========

### Eredmény fájl elérhetõségének útvonala
score\_file: [útvonal]

### Étel értékének a beállítása (Ha a kígyó megeszik egy kaját, akkor hány pontot adjon hozzá a scorehoz)
score\_add: [szám]


PÉLDÁK:
=======

snake\_speed: 1000 (Vagyis a kígyó, 1 mp -enként egyet halad elõre, mivel 1000 ms = 1 mp)<br>
snake\_dieOnWall: true (Vagyis amikor a kígyó nekiütközik a falnak, akkor meghal)<br>
score\_file: "myScores.txt" (Lehet relatív és abszolút elérési címet is megadni)<br>
score\_add: 20 (Amikor a kígyó megeszik egy dollárjelet, akkor 20 pont fog hozzáadódni a jelenlegi pontjához)<br>

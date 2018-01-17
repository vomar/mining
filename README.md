# Mining

Program przy pierwszym uruchomieniu poinformuje cie że musisz skonfigurować aplikacje kopiące i gry.

Zrobisz to naciskając prawym przyciskiem w menu głównym programu.

Aplikacje kopiące to nic innego jak skonfigurowane pliki bat przekonwertowane do exe.

Converter Bat to exe możecie pobrać stąd:

http://www.f2ko.de/en/b2e.php

Jest także wersja online:

http://www.f2ko.de/en/ob2e.php

Przykładowy plik bat którego używam do kopania standardowego.

ccminer.exe -o stratum+tcp://zen.suprnova.cc:3620 -a equi -u Vomar.test -p xd -d 1,2 -i 22

-d 1,2 Oznacza że tylko karta o numerze 1 i 2 będzie używana podczas kopania, pamiętaj że liczymy od zera.

Przykładowy plik bat którego używam do kopania zaawansowanego.

ccminer.exe -o stratum+tcp://zen.suprnova.cc:3620 -a equihash -u Vomar.test -p xd -i 22

Bez -d (device) ponieważ przy zaawansowanym chcę używać wszystkich kart.

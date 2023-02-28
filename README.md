# RentalCar - kleines Tool f�r die Verwaltung von einem Autoverleih

Dies ist ein kleines Programm, zur Organisation eines Autoverleihs. Das Programm erm�glicht es Mitarbeitern , Autos und zu vermieten, sowie den die Verwaltung von Buchungen und Kunden.

**Installation**
Um das Programm zu installieren, m�ssen Sie zuerst das Repository klonen:

`https://github.com/Rob183/RentalCar.git`

`cd RentalCar`

Als n�chstes m�ssen Sie via Docker ein Image erstellen.

`docker build -t carsharing .`

Nun das zuletzt erstellte Image nehmen und..

`docker run -it <8412731>` (<8412731> ersetzen und passende ID des Images eingeben)

Das Programm wird �ber die Konsole gestartet.

Das Hauptmen� des Programms wird angezeigt. Von dort aus k�nnen Sie verschiedene Aktionen ausf�hren, 
einschlie�lich der Anzeige verf�gbarer Autos, der Buchungungen und Anziege der Kunden.

Neue Eintr�ge werden an eine externe NoSQL DB geliefert.
<br>

So k�nnte eine GUI aussehen.
  <img src="./Docs/gui.jpg" width="100%"/>




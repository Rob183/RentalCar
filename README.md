# RentalCar - kleines Tool für die Verwaltung eines Autoverleihs

Dies ist ein kleines Programm, zur Organisation eines Autoverleihs. Das Programm ermöglicht es Mitarbeitern , Autos und zu vermieten, sowie den die Verwaltung von Buchungen und Kunden.

**Installation**
Um das Programm zu installieren, müssen Sie zuerst das Repository klonen:

`https://github.com/Rob183/RentalCar.git`

`cd RentalCar`

Als nächstes müssen Sie via Docker ein Image erstellen.

`docker build -t carsharing .`

Nun das zuletzt erstellte Image nehmen und..

`docker run -it <8412731>` (<8412731> ersetzen und passende ID des Images eingeben)

Das Programm wird über die Konsole gestartet.

Das Hauptmenü des Programms wird angezeigt. Von dort aus können Sie verschiedene Aktionen ausführen, 
einschließlich der Anzeige verfügbarer Autos, der Buchungungen und Anziege der Kunden.
Beim Starten des Programmes werden die Daten von einer externen NoSQL DB geladen.
  <img src="./Docs/cmd.jpg" width="100%"/>



<br>

So könnte eine GUI aussehen:
  <img src="./Docs/gui.jpg" width="100%"/>




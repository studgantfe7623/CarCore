# Lösungsstrategie

## Technologieentscheidungen
![architecture-overview](images/drawio-architecture-overview.png)

### Backend: ASP.NET
Da das Team am meisten Erfahrung im .NET Ökosystem würde sich für diesen Stack entschieden. 
Außerdem ist das ASP.NET Framework speziell für die Entwicklung von Web APIs entwickelt worden und bringt deswegen alle notwendigen Funktionen mit sich.

### Frontend: Angular
Im Frontend wird eine Single-Page-Anwendung gebaut.
Daher schien Angular aufgrund der komponentenbasierten Entwicklung und dem dynamischen Nachladen als gute Wahl.
Angular ist ein sehr umfangreiches Framework (vielleicht zu umfangreich für dieses Projekt), aber mit ein wenig Erfahrung ist es schnell.

### Datenbank: MongoDB
Der Hauptgrund für die Verwendung der Document Database MongoDB ist, dass die externe API eine JSON-Datei zurückgibt.
Strukturierte Datenformate wie JSON können in MongoDB gut gespeichert werden.
Außerdem kann MongoDB mit dem Testcontainers-Projekt containerisiert werden, was das Schreiben von Integrationstests vereinfacht.
Zuletzt wird MongoDB durch ein NuGet Paket in .NET unterstützt, was das Schreiben der Anfragen vereinfacht.



## Top-Level-Zerlegung des Systems

*NHTSA Vehicle API*
Als externe API wird die Vehicle API von der US Behörde für Straßen und Fahrzeugsicherheit (NHTSA) eingebunden.
Über die API kann eine umfassende Liste von Fahrzeugmarken- und Modellen abgerufen werden.
Die API wurde ausgewählt, weil sie im Vergleich zu anderen Fahrzeugdaten-APIs kostenlos und frei verfügbar ist (kein API-Key notwendig). 
Dafür enthält die API jedoch keine Daten zu den Fahrzeugpreisen.


## Entscheidungen zur Erreichung der wichtigsten Qualitätsanforderungen 

### Performance 
Um das Qualitätskriterium Performance zu testen wurde das Performance Testing Tool K6 verwendet.
Das Performance Testing beschränkt sich auf die HTTP-GET Methoden, da für die HTTP-POST Methoden eine Payload hätte generiert werden müssen.
Für einen ersten Test der Performance erschien dieser Mehraufwand nicht gerechtfertigt.
Um die Performance des Systems zu bestimmen, wurden Lasttests, Stresstests und Spike-Tests durchgeführt.

**Lasttest** \
Bei Lasttests geht es in erster Linie darum, die aktuelle Performance des Systems in Bezug auf die Anzahl der gleichzeitigen Benutzer oder Anfragen pro Sekunde zu bewerten.
![Kategorien von Qualitätsanforderungen](images\Performance\last-test.png)
Die Abbildung zeigt wie der Lasttest für die Anfwendung aufgebaut ist. 
Die Anfragelast wird langsam auf 100 Benutzeranfragen pro Sekunde gesteigert.
Dieser Wert wird dann für 10 Minuten gehalten und anschließend wieder reduziert.

**Ergebnis** 
- Das System beantwortet Anfragen in weniger als 4 Sekunden für das 90%-Perzentil bei 100 Anfragen/Sekunde. 


**Stresstest** \
Stresstests sind dazu da um die Grenzen des Systems zu ermitteln.
Ziel ist es, die Stabilität und Zuverlässigkeit des Systems unter extremen Bedingungen zu überprüfen.
![Kategorien von Qualitätsanforderungen](images\Performance\stress-test.png)
Im durchgeführten Stresstest wird die Anzahl der Anfragen pro Sekunde bis zur Belastungsgrenze und darüber hinaus gesteigert.
Im Detail wird der Maximalwert von 400 Nutzeranfragen pro Sekunde nach 28 Minuten erreicht.
Danach wird die Anforderungslast langsam reduziert, um zu sehen, ob sich das System erholt.

**Ergebnisse**
- Bei 300 gleichzeitigen Anfragen kommt es vereinzelt zu Fehlern (Zeitüberschreitungen).
- Je näher man an die 400 gleichzeitigen Benutzer kommt, desto wahrscheinlicher wird eine Zeitüberschreitung.
- Das System erholt sich wieder, wenn die Anforderungslast abnimmt.
- Die Belastungsgrenze des Systems liegt bei ca. 300 gleichzeitigen Benutzern.
- Während des Lasttests wurden insgesamt 52920 erfolgreiche und 35 fehlgeschlagene Anfragen ausgeführt.


**Spike Test** \
Der Spike-Test ist eine Variante des Stresstests, bei dem die Belastung nicht schrittweise erhöht wird, sondern in einem sehr kurzen Zeitfenster Spitzenwerte erreicht werden.
Stresstests werden durchgeführt, um festzustellen, wie sich das System bei einem plötzlichen Anstieg der Anfragelast verhält.

![Kategorien von Qualitätsanforderungen](images\Performance\spike-test.png)

**Ergebnisse** 
- Das System reagierte schlecht. 
Es produzierte Fehler während des Anfrage-Spikes, konnte sich aber erholen, nachdem der Spike nachgelassen hatte.

**Threats to Validity** \
Die Ergebnisse sind mit Vorsicht zu genießen, da die Lasttests in diesem Fall die Leistung des lokalen Rechners und nicht die der Anwendung testen.
Wie in der folgenden Abbildung zu sehen ist, war die CPU-Auslastung auf dem lokalen Rechner ab 100 Anfragen pro Sekunde fast immer bei 100 %,
![Kategorien von Qualitätsanforderungen](images\Performance\cpu-load.png)

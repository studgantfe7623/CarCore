# Qualitätsanforderungen

**Functional Suitability** <!-- (Funktions- und Unit Tests)  -->
- Die Anwendung kann Daten in eine externe Datenbank schreiben und die Daten erfolgreich daraus lesen. <!-- Testcontainers -->
- Die Anwendung kann eine API aufrufen und die erwarteten Antworten empfangen. <!-- Testcontainers -->


**Performance** <!-- (Lasttests) -->
- Die erwartete Benutzerlast sind 100 gleichzeitige Benutzeranfragen.
- Die durchschnittliche Reaktionszeit der Anwendung bei der definierten Benutzerlast liegt unter 1 Sekunde.
- Die Anwendung ist in der Lage, 100 gleichzeitige Benutzeranfragen pro Sekunde zu verarbeiten, ohne dass die Antwortzeiten signifikant steigen.


**Maintainability**
- Quellcode soll durch den Einsatz der passenden Patterns modular aufgebaut sein
- Das Code Repository wird bei jedem Checkin automatisiert gebaut <!-- GitHub Actions -->
- Alle Datenzugriffsoperationen erfolgen ausschließlich über die definierte Schnittstelle 
- Alle Schnelllaufenden Tests (Unit Test, ..., halt keine End-to-end tests oder so) werden bei jedem Check-in getestet. <!-- GitHub Actions -->
- Alle Auffälligkeiten aus der statischen Codeanalyse müssen beseitigt werden (0 Violation Policy) <!-- Sonarcloud -->


**Sicherheit**
- Die Anwendung soll den Entwickler über veraltete Abhängigkeiten zu NuGet Paketen informieren und diese bei Bedarf direkt aktualisieren. <!-- GitHub Dependabot -->
- Die Anwendung soll gegen die OWASP Top 10 Application Security Risks geschützt sein <!-- OWASP DependencyCheck -->
- Es werden ausschließliche sichere Kommunikationsprotokolle verwendet (HTTPS statt HTTP)


Weitere Qualitätsanforderungen: Reliability, Skalierbarkeit

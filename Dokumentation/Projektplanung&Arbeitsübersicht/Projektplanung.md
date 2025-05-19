# **Projektplanung: Personal Expense Tracker**

## **Schritt 1: Projektbeschreibung**
- Ziel: Festlegen der Projektziele, Funktionen und Technologien.
- Erstellung einer klaren und detaillierten Beschreibung des Projekts, um den Umfang und die Anforderungen zu definieren.

---

## **Schritt 2: Erstellung eines PAP (Programmablaufplan)**
- **Ziel**: Visualisierung der logischen Abläufe innerhalb der Anwendung.
- **Inhalte**:
  - Hauptabläufe wie Anmeldung, Hinzufügen von Ausgaben, Anzeigen von Berichten.
  - Darstellung der Entscheidungslogik (z. B. Budgeteingabe).

---

## **Schritt 3: ER-Diagramm (Entity-Relationship-Diagramm)**
- **Ziel**: Entwurf der Datenbankstruktur.
- **Inhalte**:
  - Identifikation der Entitäten wie `Benutzer`, `Ausgaben`, `Kategorien`, `Budgets`.
  - Festlegung der Beziehungen zwischen den Entitäten.
  - Bestimmung der Primär- und Fremdschlüssel.

---

## **Schritt 4: UML-Diagramme**
- **Ziel**: Modellierung der objektorientierten Struktur und Abläufe.
- **Diagrammtypen**:
  1. **Klassendiagramm**:
     - Darstellung der Klassen, ihrer Attribute und Methoden.
     - Beziehungen zwischen Klassen wie Vererbung und Assoziationen.
  2. **Use-Case Diagramm**:
     - Visualisierung der Benutzerinteraktionen mit der Anwendung.
     - Darstellung der Hauptfunktionen.
  3. **Sequenzdiagramm**:
     - Beschreibung der Abläufe innerhalb spezifischer Szenarien (z. B. "Transaktion speichern").

---

## **Schritt 5: Setup der Entwicklungsumgebung**
- **Ziel**: Einrichtung der technischen Grundlagen.
- **Aufgaben**:
  - Installation der benötigten Software (Visual Studio, SQLite).
  - Anlegen eines neuen C# WPF-Projekts.
  - Einrichtung der SQLite-Datenbank und erste Verbindung zur Anwendung.

---

## **Schritt 6: Datenbankentwurf und Implementierung**
- **Ziel**: Aufbau der SQLite-Datenbank.
- **Aufgaben**:
  - Erstellung der Tabellen basierend auf dem ER-Diagramm.
  - Schreiben von SQL-Skripten für CRUD-Operationen (Create, Read, Update, Delete).
  - Testen der Datenbankverbindung in der Anwendung.

---

## **Schritt 7: Entwicklung der Benutzeroberfläche (UI)**
- **Ziel**: Design und Implementierung einer intuitiven Benutzeroberfläche.
- **Aufgaben**:
  - Gestaltung der Hauptansichten:
    1. Login- und Registrierungsfenster.
    2. Dashboard mit Ausgabenübersicht.
    3. Formulare für das Hinzufügen/Bearbeiten von Transaktionen.
    4. Statistik- und Berichtsansichten.
  - Integration von WPF-Styling und Layout-Management.

---

## **Schritt 8: Implementierung der Kernfunktionen**
- **Ziel**: Entwicklung der Hauptfunktionen basierend auf der Projektbeschreibung.
- **Aufgaben**:
  - Benutzerregistrierung und anmeldung mit Validierung.
  - Eingabe Operationen für Transaktionen und Budgets.
  - Budgetprüfung und Warnmeldungen.
  - Filter- und Suchfunktionen für Ausgaben.

---

## **Schritt 9: Statistiken und Berichte**
- **Ziel**: Erstellung von grafischen Auswertungen und Berichtsmodulen.
- **Aufgaben**:
  - Integration von Diagrammen (z. B. Balken- und Tortendiagrammen) mit LiveCharts oder OxyPlot.

---

## **Schritt 10: Testing und Debugging**
- **Ziel**: Sicherstellen, dass die Anwendung stabil und fehlerfrei ist.
- **Aufgaben**:
  - Testen aller Funktionalitäten (manuelles und automatisiertes Testen).
  - Überprüfen der Benutzeroberfläche auf Fehler und Usability-Probleme.
  - Fehlerbehebung und Optimierung.

---

## **Schritt 11: Dokumentation**
- **Ziel**: Erstellung einer vollständigen Projekt- und Nutzerdokumentation.
- **Aufgaben**:
  - Technische Dokumentation (Code-Struktur, Datenbankentwurf).
  - Benutzerhandbuch (Anleitung zur Nutzung der Software).

---

## **Schritt 12: Deployment**
- **Ziel**: Bereitstellung der Anwendung.
- **Aufgaben**:
  - Verpackung der Anwendung für den Endbenutzer (z. B. Erstellen einer .exe).
  - Anleitung zur Installation und Nutzung.

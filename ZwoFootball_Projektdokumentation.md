# Projekt: Zwo Football
**Klasse:** 2AHIF  
**Jahr:** 2024/2025  
**Projektgruppe:** Colin Küer, Jakob Seeberger  
**Betreuer:** Lukas Diem  

---

## 📄 hallo

Programm zur Simulation von digitalen Filtern (FIR oder IIR).  
Durch Angabe des Filtertyps, der Ordnung und der Koeffizienten wird die Übertragungsfunktion ermittelt und das PN-Diagramm erstellt oder anhand eines PN-Diagramms die Filterkoeffizienten ermittelt.

👉 *Hier bitte die Projektidee zu Zwo Football anpassen und kurz beschreiben.*

---

## 🖼️ Collage

Füge mindestens zwei Screenshots des Projekts ein.

```
![Screenshot 1](pfad/zum/screenshot1.png)
![Screenshot 2](pfad/zum/screenshot2.png)
```

---

## 💻 Relevanter Programmcode

```csharp
for (int i = 0; i < ausgangswerte.Length; i++)
{
    double omega0 = eingangswerte[i] + t1 * a1 + t2 * a2;
    ausgangswerte[i] = omega0 * b0 + t1 * b1 + t2 * b2;
    t2 = t1;
    t1 = omega0;
}
```

👉 *Hier kann eigener relevanter Code aus Zwo Football ergänzt werden.*

---

## 📅 Projektzeitplan

| Datum       | Aufgabe                                      | Bearbeiter   | Status (%) |
|-------------|----------------------------------------------|--------------|------------|
| 19.04.2022  | Solve Funktion für quadr. Gleichungen        | Nesensohn    | 100%       |
| 26.04.2022  | IIR Filter 2. Ordnung berechnen              | Pircher      | 80%        |


---

# Lastenheft

## 2.1 Kurzbeschreibung
👉 *Spielprinzip mit einigen Sätzen erklären.*

## 2.2 Skizzen
👉 *Spielprinzip visuell und genau erklären.*

## 2.3 Funktionsumfang

### 🎯 Must-Haves
- Beispiel: `Taste D` → Spielerfigur bewegt sich 5 Pixel nach rechts
- Beispiel: `Taste S` → Speichert aktuellen Zustand
- Beispiel: `Mausklick` → Zerstört Sprite unter Cursor

### 💡 Nice-to-Haves
- 👉 *Hier alle weiteren geplanten Funktionen listen.*

---

# Pflichtenheft

## 🔧 Interner Programmaufbau

- 👉 *Programmlogik beschreiben*
- 👉 *Klassendiagramm oder Beschreibung der Klassenstruktur*
- 👉 *Wie arbeiten die Klassen zusammen (ggf. Flussdiagramm)?*

## ⚙️ Umsetzungsdetails
- 👉 *Was wurde wie programmiert?*
- 👉 *Welche Fehler sind aufgetreten und wie wurden sie gelöst?*

## ✅ Ergebnisse & Tests
- 👉 *Wie läuft das Programm aktuell?*
- 👉 *Was sind erkennbare Schwachstellen?*

---

# Anleitung

## 📥 Installationsanleitung
👉 *Welche Programme / Bibliotheken müssen installiert werden?*

## 🕹️ Bedienungsanleitung
👉 *Genaue Beschreibung der Steuerung und Bedienung für neue Benutzer.*

---

# 🐞 Bekannte Bugs / Probleme
👉 *Welche Bugs bestehen? Warum konnten sie nicht behoben werden?*

---

# 🔮 Erweiterungsmöglichkeiten
👉 *Was würde bei mehr Zeit verbessert oder ergänzt werden?*

---


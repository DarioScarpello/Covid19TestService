# Covid19TestService

**Kurzbeschreibung:**

Dieses Projekt ist ein Corona Test Service bei dem PCR oder Antigentest gemacht werden können zwischen den beiden wird auch in der Datenbank entschieden Es können User erstellt werden, die dann auch mehrere Profile anlegen können unter denen getestet werden kann damit zum Beispiel eine Familie mit nur einem User auskommen kann. Die gemachten Tests werden unter den Profilen gespeichert und können jederzeit wieder eingesehen werden. Die Tests werden zufällig ausgewertet.

**Wichtige Routen:**

- Post: Route die für den Login verwendet wird.
- Get: Alle Profile die der User erstellt hat.
- Get: Alle PCR Tests die über das Profil gemacht wurden.
- Get: Alle Antigen Tests die über das Profil gemacht wurden.
- Post: Um ein Profil zu erstellen.
- Delete: Um ein Profil zu löschen.
- Post: Um einen neuen PCR Test zu erstellen.
- Post: Um einen neunen Antigen Test zu erstellen.
- Patch: Um Daten in einem Profil zu ändern.

**User Interface:**

Beim Starten des Programms wird es ein Fenster geben bei dem man sich mit seinem Account anmelden kann, danach wird die Profilauswahl geöffnet, bei der Profile gelöscht, geändert und erstellt werden können. Für das Erstellen und bearbeiten der Profile werden Textboxen verwendet in denen alle Daten eingeben werden können. Wenn dann ein Profil ausgewäht wird wird in einem neuen Fenster eine Liste der gemachten Tests angezeigt, auf der gleichen Seite wird es auch die Möglichkeit geben neue Tests zu machen.

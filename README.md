# Restaurant Booking API

## Beskrivning:
Det här projektet är en ASP.NET Web API som tillhandahåller två endpoints för att kryptera och dekryptera meddelanden med hjälp av Caesar Cipher-algoritmen. API:et exponerar endpoints för krypterings- och dekrypteringsoperationer och är utformat för att användas programmatiskt.

## Funktioner:

Lägg till bokning Endpoint: /api/booking [POST] - Lägger till en ny bokning med det angivna kundnamnet och bokningsdatumet.
Uppdatera bokning Endpoint: /api/booking/{id} [PUT] - Uppdaterar en befintlig bokning med det angivna ID:t med det nya kundnamnet och bokningsdatumet.
Hämta bokningar Endpoint: /api/booking [GET] - Hämtar alla bokningar i systemet.
Installation:

Klona detta repository till din lokala maskin.
Öppna projektet i din föredragna C#-utvecklingsmiljö.
Se till att du har .NET SDK installerat.
Kör följande kommandon för att återställa beroenden och bygga projektet:
```cs
dotnet restore
dotnet build
```

## Användning:
Starta API-applikationen. Använd en API-testverktyg som Insomnia eller använd en webbläsare för att interagera med API:et. Använd ovanstående endpoints för att lägga till, uppdatera eller hämta bokningar.

## Enhetsprov:
Projektet levereras med ett enhetstest för att säkerställa korrekt funktionalitet av krypterings- och avkrypteringsfunktionerna i CryptographyService-klassen. För att köra enhetstestet, navigera till testprojektet och kör följande kommando:
```cs
dotnet test
```

## Continuous Integration (CI):
Projektet är integrerat med GitHub Actions för att automatiskt köra enhetstester vid varje push till huvudgrenen. Dessutom är det anslutet till AWS Elastic Beanstalk för distribution.

Unit Tests Workflow: Workflow-filen UnitTest.yml definierar en workflow som körs enhetstester vid varje push till huvudgrenen, exklusive ändringar som gjorts på huvudgrenen.
AWS Deployment Workflow: Workflow-filen Aws.yml definierar en workflow som bygger och distribuerar applikationen till AWS Elastic Beanstalk vid varje push till huvudgrenen.
Setup:
För att ställa in projektet lokalt, följ dessa steg:

- Klona detta repository.
- Navigera till projektmappen.
- Se till att du har .NET SDK installerat.
- Kör följande kommandon för att återställa beroenden och bygga projektet:
```cs
    dotnet restore
    dotnet build
```

## CI/CD-process:
Se FigJam-skissen över processen för både backend och frontend av applikationen här.

## Användning av API:et:

**Kryptera ett meddelande**
För att kryptera ett meddelande kan du skicka en HTTP GET-förfrågan till följande URL med meddelandet du vill kryptera som en parameter:

http://localhost:5103/encrypt?input="hej"

Exemel:
```cs
encrypt?input="hej"
```
Svar:
```cs
ZlinZ
```

Det förväntade svaret är den krypterade versionen av meddelandet. Observera att det finns en bugg i koden som kan lägga till en extra bokstav i början och en extra bokstav i slutet av ordet.

Exempel: En förfrågan till http://localhost:5103/encrypt?input="hej" kan ge svaret ZlinZ.

Dekryptera ett meddelande
För att dekryptera ett meddelande kan du skicka en HTTP GET-förfrågan till följande URL med det krypterade meddelandet som en parameter:

http://localhost:5103/decrypt?input="lin"

Exemel:
```cs
decrypt?input="Lin"
```
Svar:
```cs
RhejR
```

Det förväntade svaret är den dekrypterade versionen av meddelandet. Observera att samma bugg som nämns ovan kan också påverka dekrypteringsprocessen och här måste du också ta bort den första bokataven och den sista.

Exempel: En förfrågan till http://localhost:5103/decrypt?input="lin" kan ge svaret RhejR.

Arbetet är utförat av Madeleine Sigersted 
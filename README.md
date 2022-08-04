# Project C# Mobile 2021-2022
* Naam: Gencay Turan
* Onderwerp: <u>Operator app</u> voor Video platform van eigen bedrijf (GencoVideo)
## Korte uitleg doel applicatie:
Een operator app voor de eigenaar om allerlei taken uit te voeren zoals:
- reservaties nakijken, aanmaken, wijzigen 
- agenda nakijken, wijzigen
- prijslijst aanmaken, wijzigen
- Rapporten bekijken over het bedrijf (over winst of projecten van het afgelopen jaar bijvoorbeeld)
- alle gemaakte video kunnen raadplegen
- navigatie naar externe pagina's 

*CHANGE: user gedeelte zal later op een webapp gemaakt worden. Nu is het enkel een native Operator app voor de Admin*

(uiteindelijk aangevuld met screenshots)

## App Structuur (+ details)
------------------------------------------------------------------------------------------------------------------------------------------------------

------------------------------------------------------------------------------------------------------------------------------------------------------
###### Admin / Tabbed
------------------------------------------------------------------------------------------------------------------------------------------------------
**+ Voorpagina**
* navigaties naar pagina's:

  *--> Agenda*

  *--> DataReports*

  *--> Video's*

**+ Agenda**
* nieuwe boekingen
* boekingen wijzigen

**+ Offertes**
* een gedetailleerde offerte aanmaken door de opties te selecteren die de klant wil hebben
* een text wordt geprint in een object die dan gekopieerd kan worden

**+ Video's**
* lijst van video's (filteren)
* detailed page video (aanpasbaar):
  
  *--> upload nieuw video*
  
  *--> verwijder video*

**+ DataReports**
* Winst
* Aantal klanten/ projecten
* Soorten projecten


## Logboek

## Link video
## Bronnen

icons in de app:
https://iconmonstr.com/

## Todo
- create task for loading page https://stackoverflow.com/questions/40857298/populate-listview-when-page-is-loaded-xamarin-forms-using-a-command
- try to use one function for two command Bindings (load and refresh)
- youtube id extractor: https://stackoverflow.com/questions/39777659/extract-the-video-id-from-youtube-url-in-net
- add upcoming projects table
- add booking structure
- sort tables
- use resources in app.xaml
- create proper settingspage
- use gradient colors?
- use linq for joining tables ([indexed] from sqlite does not work for me)
- prevent videoelement (object) from disposing

## rules
- client can have multiple bookings
- client can be added via newbooking but als seperately
- client cannot be deleted via booking

## Problems
- tabbar has no height property. Tried to change it with a custom renderer but no fix.
- You can't put a big logo on the toolbar in toolbaritems. Just icons that have a max of 24dp which is very small. 
- onbackbuttonpressed() true MediaElement.play in ProfilePage.xaml.cs
- can't check if any table exist in firebase. there is no query for that. (snapshot--> java??)
- when updating password, only the props given in the constructors are getting put in firebase. Nickname and userId gets removed. (put them also in update function maybe? but how to get them? Linq?)
- booking table Casting error. casting type error due to wrong type?
- how to change boolean output to string values like corporate or non-corporate before displaying in table?


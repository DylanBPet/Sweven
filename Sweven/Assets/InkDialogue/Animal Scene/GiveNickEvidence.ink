What did you find #speaker: Nick #portrait:nick #layout:right
*[Just a hole] Just a hole full of dismembered animal parts #speaker: Marcus #portrait:marcus #layout:left
->JustAHole

*[Not much] Not much of anything, it would have been hard to see much out there #speaker: Marcus #portrait:marcus #layout:left
->NotMuch

===NotMuch
Tell me its not just a dead end #speaker: Nick #portrait:nick #layout:right
*[Not sure] Im not sure where to go from here #speaker: Marcus #portrait:marcus #layout:left
->NotSure

*[I think...] My gut tells me this is still related to the fire somehow #speaker: Marcus #portrait:marcus #layout:left
->IThink

===JustAHole
Found a coyotes nest maybe? #speaker: Nick #portrait:nick #layout:right
*[No] Not unless the coyotes kill their own #speaker: Marcus #portrait:marcus #layout:left
->NotUnless

*[Definitly human] Only a human can be this cruel #speaker: Marcus #portrait:marcus #layout:left
->DefinitlyHuman

===NotSure
Let me have a look at what you found #speaker: Nick #portrait:nick #layout:right
->GiveEvidence

===IThink
My gut tells me this is still related to the fire somehow #speaker: Nick #portrait:nick #layout:right
->GiveEvidence

===NotUnless
Ive heard they can do that. Let me have a look at what you found #speaker: Nick #portrait:nick #layout:right
->GiveEvidence

===DefinitlyHuman
Youd be surprise. Let me have a look at what you found #speaker: Nick #portrait:nick #layout:right
->GiveEvidence

===GiveEvidence
Give Nick the evidence to study? (this will block the option for others) #speaker: Nick #portrait:nick #layout:right
*[No] No #speaker: Marcus #portrait:marcus #layout:left
->END

*[Yes] Yes #speaker: Marcus #portrait:marcus #layout:left
->Yes

===Yes
My theory? This person is testing the waters of what they can do. #speaker: Nick #portrait:nick #layout:right
*[Serial Killer?] You think we have a new serial killer on the loose? #speaker: Marcus #portrait:marcus #layout:left
->SerialKiller

*[What?] What do you mean? #speaker: Marcus #portrait:marcus #layout:left
->SerialKiller

===SerialKiller
Someone who keeps ramping up the intensity, first a fire, then these animals #speaker: Nick #portrait:nick #layout:right
*[Then human?] Then a human? #speaker: Marcus #portrait:marcus #layout:left
->ThenHuman

*[Then animal?] Then a...Bigger animal? #speaker: Marcus #portrait:marcus #layout:left
->ThenAnimal

===ThenHuman
Lets hope not #speaker: Nick #portrait:nick #layout:right
->END

===ThenAnimal
Lets hope so. #speaker: Nick #portrait:nick #layout:right
->END
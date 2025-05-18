# Process Documentation
## 16 April 2025 - The beginning
***
It all started with a late night rush of desperation to come with ideas to present for a meeting with advisors that prompted me to begin furiously scribbling down the first things in my head.

![initial scribbles](DocumentationImages/InitialScribbles.jpg)

## 17 April 2025 - Brainstorming
***
I was very hung up on the idea of creating a rhythm game for this project as the idea of player actions being controlled by rhythm fits within the idea of outmersion and can be considered a mechanical fourth wall break due to it having the ability to distate the player's physical actions. After a discussion with my first advisor, a rhythm game requires a solid game mechanics that takes a good chunk of time to build and is not particularly easy. A prototype has to be done in a span of at least 1 week or 2 first before considering diving deep into developing the idea.

This sounds rather daunting, but I do enjoy the idea of working on a rhythm game as it has been on my bucket list for awhile and I never got to fulfil it as of yet. But perhaps it would be wiser to start of with an overarching theme and manifesto that I can always refer back to when designing the game so I don't get lost in the chaos of my own mind.

## 21 April 2025 - Then there was light
***
As I was lazing about enjoying the Easter weekend, I came upon a particular game on steam and was mesmerised by the sheer ingenius in implementing the ideas of puppetry within the puzzle game. [A Fisherman's Tale](https://store.steampowered.com/app/559330/A_Fishermans_Tale/) was incredibly intriguing and I adored the way the game looks and plays with its mindbreaking puzzle concepts, reminding me of the Puppetry idea I previously had in my scribbles (but cooler and better). Having a model of the room and character smaller than the player as well as a larger version compared to the player. While simulatneously creating puzzles that requires the usage of those different models to proceed forward in the game.

## 24 April 2025 - Getting down to business
***
The most difficult part is to start, so instead of thinking up the full details of the game plan, I decided to just take the leap and make something for the coming Playtest Evening next Tuesday. 

I decided to try recreating A Fisherman's Tale's and started out with a basic first person perspective animated player controller where you can see your own body. After trying to recreate the large, medium and small version of the player, I realised that it's incredibly tricky to match up the movement for each version and the scaling has to be very accurate in terms of space and movement velocity across the different scales to make it work correcty. No wonder the VR game restricted the player's movement by making them jump from fix positions to another fix position to overcome that movement and placement matchup.

## 1 May 2025 - Developing the prototype
***
I spent the whole day working on the prototype trying to get the core features of the game to work properly. Basically added the function to stop player movement when spacebar is pressed while still being able to look around. Also added the function to drag an interactable object with the player when holding the left mouse button.

## 3 May 2025 - Last push to finish first prototype
***
I wanted to finish the 1st prototype as soon as I can so I could push it out to people to playtest the controls I have made and the get the feedback for the general feel of the game. I managed to have that done and sent it out to both my advisors, hopefully it isn't too janky or jarring to play. There are still many things I have to do to develop the main mechanic but here's a list of what I've done and what I should focus to work on next:

Done:
+ Player movement and base interactions with interactable objects
+ when interactable is in Puppet Zone, player can't take interactable
- Door detects if object is correct before opening
- Player stops moving when spacebar is pressed
- Basic start menu and pause menu functionalities

To Do:
- Fix puppet movement 
- Puppet should squat when spacebar is not pressed so it doesn't move along with player every moment (unless puzzle intends for it to do so)
- Fix physics issue when key is picked up it pushes player back
- Brainstorm level ideas to proceed in the game
- Brainstorm narrative that ties into the puzzles of the game

## 7 May 2025 - Revamp entire prototype
***
Had a meeting with Csongor and got some valuable feedback on the project's control and overall direction its heading. Currently the movement of the puppet is too jarring with the Player's movement and there was confusion how to control the puppet. Had some feedback from others as well voicing similar issues. There was contradicting opinions on the puppet movement, some mentioned that it is incredibly confusing and hard to control, while others mentioned that the challenge is rather fun. While I always enjoy the idea of "its not a bug, its a feature", for this particular scenario I do think it should be reworked to provide a more controlled intended janky-ness instead of an unintended one.

I decided to rework on the core movement systems and scrap the entire prototype due to some render pipeline shenanigans in Unity that causes the project to load incredbily slow during play mode. I opened a completely new project and stuck with URP as the main render pipeline and rebuild all imported assets to fit within it. I've also decided to build the game solely using visual scripting and not C# due to the speed and convenience it offers.

The main player's movement still uses some C# script that I got from the unity's official sample asset, but that is as far as it goes. The scripts are well documented and easy to read and dissect its parts and thus making it easy for me to make changes. Everything else on the other hand would be done in visual scripting from here on out.

Project's technical outline:
+ URP render pipeline
+ Code in visual scripts only

## 8 May 2025 - Update on some brainstorm scribbles
***
![brainstorm scribbles](DocumentationImages/ProjectBrainstorm.jpg)
I added new ideas on the right side of the board with all the yellow stars, highlighting the core mechanics and what I need to do to accomplish it. I decided to focus on the theme of control in this game. I want the players to question who truly has control within the game. Though the player has the ability to manipulate the contents of the game and the characters, are the actions they take really their own? or are they just a mere pawn on the board? 

These are the kind of questions I would like to convey within the game, though I am rather worried of the impending scope creep this might result in trying to achieve it. :'D

## 12 May 2025 - A change of pace
***
I decided to head to the university to work on my project for a change of pace and hoping if I place my brain in a different environment I would be able to get fresher ideas on how to proceed forward with the project. After spending the weekend fully scrapping my prototype and starting anew, I managed to get it towards the same state as the previous prototype, but now with lesser bugs and simplified control systems! I brought it on to Florian for a quick playtest and had some interesting feedback on the game's puzzle and overall concept.

Here's a rough summary from the playtest session:
+ The concept of having different sized keys and different sized keyholes needed to be pushed further visually for players to notice their differences
+ Understanding the need to swap the keys amongst the different scaled versions of yourself was not the easiest thing to pick up on
+ The concept was interesting, due to the antique key and keyholes, the game's theme seem to fit a more fantasy genre instead of sci-fi (eg. portal style, which was my initial idea brought on by the style of the sample assets I was using)
+ Having the player control multiple characters at once with one set of control is not bad, having different ways to control the puppets would be interesting
+ Fourth wall breaking elements like the player looking up and seeing the projection of themselves through the webcam would sell that idea more

After contemplating these feedback, it kind of spurred me to work on the narrative elements of the game. Ideas of the story I needed to tell and how to tell that story rolled in my head for awhile and I came up with a base premise:
> A dollmaker obssessed with perfecting his craft, steals the 'souls' of players who wander into his domain and make them into puppets for his collection. He tricks players with the help of his spider familiar by pretending to help them escape, just for them to be lead into his trap at the end.

Basically the story starts by the player assuming they were turned into a puppet and need to turn themselves back to escape. They are lead by a narrator pretending to be their conscience (think Jiminy Cricket in Pinnochio) who explains their situation and help them proceed through the game.

![story draft](DocumentationImages/StoryDraft.jpg)

I drafted some additional flavour mechanics in the game where the narrator would ask seemingly strange and intrusive questions about the player's original appearance (before they got turned into a puppet). Simple dialogue options are presented to get information on how the player actually looks to customize the look of their puppet at the end.

## 15 May 2025 - Blocking out levels according to storybeats
***
After being invigorated by the narrative for this game, I started getting assets to start blocking out levels following the storybeats. I had a rough idea in mind for the player to start in a storage room, as if they were tossed aside and forgotten.

![storage room blockout](DocumentationImages/NarrativeStartzoneBlockout.jpg)

I continued to work on fixing some bugs that causes discrepancies between the different scaled version of the player. I still have not fully work out all the kinks as there is a problem with matching up the pickup range for the different scaled versions to the player without causing unneccessary interactions.

## 18 May 2025 - Getting low with some beats
***
I added the ability to crouch down to grab objects that the player has dropped on the ground to limit the pickup range for each version so they are not able to interact to anything beyond their realm except for the player. 

Progress has been slow this week as most of my time I was brainstorming on the storybeats of the game and narrowing down the scope to make it more achievable while explaining the narrative in its entirety. 

![storybeats draft](DocumentationImages/Storybeats.jpg)
I narrowed it down to 6 rooms for the entire game. This can be reduced or expanded further with more puzzle rooms but so far my brain was only able to come up with two puzzles.

1. **Storage Room** -- the starting area, where the narrator will explain why they are here and how they must get out before its too late.
2. **Room of Keys** -- a tutorial area to showcase different scaled keys and keyholes and the need to match them to proceed forward.
3. **Room of Scales** -- Two scaled versions of the player (who copies the players movement) and the room exists and the player has to get the correct key to move forward. Exchanging the key from the different scaled version of the player is how to proceed forward.
4. **Mirror Room** -- A mirrored version of the room exists on the other side of a glass pane, but not everything that is within the mirrored room exists in the player's room. The player has to manipulate a puppet within their room to open the door in the mirrored room to unlock their own door.
5. **Corridors of Secrets** -- I picture this as an area between puzzle rooms for dialogues to happen, the narrator would ask strange questions about the player and the player can answer them. There would be a total of 3 corridors:
    + The corridor between the keys and scales room
    + A corridor between the scales and mirror room
    + A corridor between the mirror room and the final area.
6. **Judgement Room** -- This isn't a room and more of a cutscene that reveals the player's true circumstances in the game.
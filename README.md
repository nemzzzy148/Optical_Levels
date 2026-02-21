Making a Level

The level content is stored in a JSON file where minor mistakes can stop the game from loading the level.
All preset vars are examples!

Important Info

If you leave certain values empty, the game will load the default value.

You can do this for:

Colors

Names (For text component it will default to Lux)

Types

Size of level

Vertices and triangles (it will create an empty MeshObject)

Positions (defaults to 0)

Positions

Center:

(0, 0)

Position range on screen:

X: -15 to 15

Y: -25 to 25

Colors

Each color component has 4 parts:

r g b a

r = red

g = green

b = blue

a = transparency

Example:

"r": 1.0,
"g": 1.0,
"b": 1.0,
"a": 1.0
There are 4 crucial in-game components:

Level config

Lights

Receivers

MeshObjects

Level Config

Name

"name": "My new and awesome level!"

Size
The size component scales the receiver object and light object for larger levels.
(Not used right now)

"size": 1.0

Background color

"bgR": 0.05,
"bgG": 0.05,
"bgB": 0.1,
"bgA": 1.0
Lights

Type: Array

"Lights": [
  {
    // Light 1
  },
  {
    // Light 2
  }
]

Position

"x": -5.0,
"y": 0.0

Color

"r": 1.0,
"g": 1.0,
"b": 1.0,
"a": 1.0
Receivers

If all the receivers are turned on, the player wins.

Position

"x": 5.0,
"y": 0.0

The boolean light defines if the receiver needs to receive light to turn on.

"light": true
MeshObjects

Examples: walls, mirrors, places where you can't draw.

Mirror
Defines if it reflects light.

"mirror": true

Collision
Defines if light can go through it.

"collision": true

Draw
Defines if the player can draw on it.

"drawable": false

Color

"r": 1.0,
"g": 1.0,
"b": 1.0,
"a": 1.0

Vertices
This uses Unity's mesh system.
Even if the normal is facing away from the player it will still render.

"vertices": [-0.5, -2.0, 0.5, -2.0, 0.5, 2.0, -0.5, 2.0]

Triangles

"triangles": [0, 2, 1, 0, 3, 2]
Text

Text

"text": "Welcome to my level!"

Position

"x": 5.0,
"y": 0.0

Size

"size": 5.0

(Just font size.)

Color

"r": 1.0,
"g": 1.0,
"b": 1.0,
"a": 1.0

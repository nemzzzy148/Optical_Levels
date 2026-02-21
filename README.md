Making a level:

  The level content is stored in a Json file where minor mistakes can stop the game from loadig the level.
  All preset vars are examples!

  Important info:
    If you leave certain values empty, the game will load the default value.
    You can do this for 
    colors, 
    names (For text component it will default to Lux),
    types,
    size of level
    For vertices and triangles, it wil make an empty meshobject.
    For positions it will just be 0
    
  Positions:
    Center = (0,0)
    Pos in screen:
      X: -15 , 15
      Y: -25 , 25
      
  Each color component will have 4 parts: r g b a(transparency)

  There are 4 crutial ingame componants:
    Level config
    Lights
    Receivers
    MeshObjects

  Level config:
    Name: 
      "name": "My new and awesome level!"
    Size:
      The size component scales the receiver object and light object for larger level's.
      (Not used right now)
        "size": 1.0
    Background color:
        "bgR": 0.05,
        "bgG": 0.05,
        "bgB": 0.1,
        "bgA": 1.0

  Lights:
    Type: array
      "Lights": [
        {
        Light 1
        },
        {
        Light 2
        }
      ]
    Position:
      "x": -5.0,
      "y": 0.0
    Color:
      "r": 1.0,
      "g": 1.0,
      "b": 1.0,
      "a": 1.0
  Receivers:
    If all the receivers are turned on, the player wins.
    Pos:
      "x": 5.0,
      "y": 0.0
    The bool light defines if the receiver needs to receive light to turn on.
    Light:
      "light": true
  MeshObjects:
    Ex: walls, mirrors, places where you can't draw.
    Mirror:
      Defines if it reflects light
      "mirror": true
    Collision:
      Can light go through it.
      "collision": true
    Draw:
      Can the player draw on it:
      "drawable": false
    Color:
      "r": 1.0,
      "g": 1.0,
      "b": 1.0,
      "a": 1.0
    Vertices:
      This uses Unity's mesh system.
      Even if normal is facing away from player it will still render it.
      "vertices": [-0.5, -2.0, 0.5, -2.0, 0.5, 2.0, -0.5, 2.0]
    Triangles:
      "triangles": [0, 2, 1, 0, 3, 2]
    
      
      
    
    

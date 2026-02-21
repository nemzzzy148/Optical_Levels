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
      Type: string
        "name": "My new and awesome level!"
    Size:
      The size component scales the receiver object and light object for larger level's.
      (Not used right now)
      Type: float
      Declaration:
        "size": 1.0
    Background color:
      Type: float 0-1
        "bgR": 0.05,
        "bgG": 0.05,
        "bgB": 0.1,
        "bgA": 1.0

  Lights:
    Position:
      "x": -5.0,
      "y": 0.0,
      
      
    
    

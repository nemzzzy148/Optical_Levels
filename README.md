# GOAL
> Use your finger to draw lines to reflect light onto receivers.
> 
> If all the receivers turn green you beat the level.

![](.level.png)
---

# LEVEL CREATION GUIDE

> The level content is stored in a JSON file.  
> Even small mistakes can stop the game from loading the level.
>
> All preset vars are examples!

---

# IMPORTANT INFO

If you leave certain values empty, the game will load default values.

You can leave empty:

- 🎨 Colors  
- 📝 Names (Text component defaults to **"Lux"**)  
- 🔖 Types  
- 📏 Size of level  
- 🔺 Vertices & Triangles → Creates empty MeshObject  
- 📍 Positions → Defaults to `(0,0)`

---

# POSITIONS

### Center
```
(0, 0)
```

### Position range on screen

| Axis | Min | Max |
|------|------|------|
| X | -15 | 15 |
| Y | -25 | 25 |

---

# COLORS

Each color has **4 parts**:

```
r g b a
```

- `r` = red  
- `g` = green  
- `b` = blue  
- `a` = transparency  

Example:

```json
"r": 1.0,
"g": 1.0,
"b": 1.0,
"a": 1.0
```

---

# 4 CRUCIAL IN-GAME COMPONENTS

```
1. Level config
2. Lights
3. Receivers
4. MeshObjects
```

---

# LEVEL CONFIG

### Name
```json
"name": "My new and awesome level!"
```

### Size
Scales receiver and light objects for larger levels.  
(Not used right now.)

```json
"size": 1.0
```

### Background color
```json
"bgR": 0.05,
"bgG": 0.05,
"bgB": 0.1,
"bgA": 1.0
```

---

# LIGHTS

Type: **Array**

```json
"Lights": [
  {
    // Light 1
  },
  {
    // Light 2
  }
]
```

### Position
```json
"x": -5.0,
"y": 0.0
```

### Color
```json
"r": 1.0,
"g": 1.0,
"b": 1.0,
"a": 1.0
```

---

# RECEIVERS

If all receivers are turned on, the player wins.

### Position
```json
"x": 5.0,
"y": 0.0
```

### Light requirement
Defines if the receiver needs light to turn on.

```json
"light": true
```

---

# MESHOBJECTS

Examples:
- Walls  
- Mirrors  
- Places where you can't draw  

---

### Mirror
Defines if it reflects light.

```json
"mirror": true
```

### Collision
Defines if light can go through it.

```json
"collision": true
```

### Draw
Defines if the player can draw on it.

```json
"drawable": false
```

### Color
```json
"r": 1.0,
"g": 1.0,
"b": 1.0,
"a": 1.0
```

### Vertices
Uses Unity's mesh system.  
Even if the normal faces away from the player, it will still render.

```json
"vertices": [-0.5, -2.0, 0.5, -2.0, 0.5, 2.0, -0.5, 2.0]
```

### Triangles
```json
"triangles": [0, 2, 1, 0, 3, 2]
```

---

# TEXT

### Text
```json
"text": "Welcome to my level!"
```

### Position
```json
"x": 5.0,
"y": 0.0
```

### Size
```json
"size": 5.0
```

(Just font size.)

### Color
```json
"r": 1.0,
"g": 1.0,
"b": 1.0,
"a": 1.0
```

---

### Upload level
In the json table, add your level name that matches with your file name, and upload your level.

---

## Example
```json
{
  "name": "Owners_Level",
  "size": 1.0,
  "bgR": 0.05,
  "bgG": 0.05,
  "bgB": 0.1,
  "bgA": 1.0,

  "lights": [
    {
      "x": -5.0,
      "y": 0.0,
      "r": 1.0,
      "g": 1.0,
      "b": 1.0,
      "a": 1.0
    },
    {
      "x": -8.0,
      "y": 5.0,
      "r": 1.0,
      "g": 0.8,
      "b": 0.6,
      "a": 1.0
    }
  ],

  "receivers": [
    {
      "x": 5.0,
      "y": 0.0,
      "light": true
    },
    {
      "x": 8.0,
      "y": -4.0,
      "light": true
    }
  ],

  "meshObjects": [
    {
      "mirror": true,
      "collision": true,
      "drawable": false,
      "r": 0.8,
      "g": 0.8,
      "b": 1.0,
      "a": 1.0,
      "vertices": [-0.5, -2.0, 0.5, -2.0, 0.5, 2.0, -0.5, 2.0],
      "triangles": [0, 2, 1, 0, 3, 2]
    },
    {
      "mirror": false,
      "collision": true,
      "drawable": false,
      "r": 0.5,
      "g": 0.5,
      "b": 0.5,
      "a": 1.0,
      "vertices": [-3.0, -1.0, 3.0, -1.0, 3.0, -0.5, -3.0, -0.5],
      "triangles": [0, 2, 1, 0, 3, 2]
    }
  ],

  "texts": [
    {
      "text": "Welcome to Online Levels",
      "x": 0.0,
      "y": 3.0,
      "size": 5.0,
      "r": 1.0,
      "g": 1.0,
      "b": 1.0,
      "a": 1.0
    },
    {
      "text": "Activate all receivers to win!",
      "x": 0.0,
      "y": -6.0,
      "size": 4.0,
      "r": 0.7,
      "g": 0.9,
      "b": 1.0,
      "a": 1.0
    }
  ]
}
```

---


If your level does not load:

- Check commas  
- Check brackets `{}` and `[]`  
- Check array formatting  
- Check spelling  


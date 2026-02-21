# 🛠️ LEVEL CREATION GUIDE

> ⚠️ The level content is stored in a JSON file.  
> Even small mistakes can stop the game from loading the level.
>
> All preset vars are examples!

---

# 📌 IMPORTANT INFO

If you leave certain values empty, the game will load default values.

You can leave empty:

- 🎨 Colors  
- 📝 Names (Text component defaults to **"Lux"**)  
- 🔖 Types  
- 📏 Size of level  
- 🔺 Vertices & Triangles → Creates empty MeshObject  
- 📍 Positions → Defaults to `(0,0)`

---

# 📍 POSITIONS

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

# 🎨 COLORS

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

# 🧩 4 CRUCIAL IN-GAME COMPONENTS

```
1. Level config
2. Lights
3. Receivers
4. MeshObjects
```

---

# ⚙️ LEVEL CONFIG

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

# 💡 LIGHTS

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

# 🎯 RECEIVERS

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

# 🧱 MESHOBJECTS

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

# 📝 TEXT

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

# ✅ FINAL TIP

If your level does not load:

- Check commas  
- Check brackets `{}` and `[]`  
- Check array formatting  
- Check spelling  

---

🚀 Happy level building!

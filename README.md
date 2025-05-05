# BK_DT_BoatRunner

🎮 A small **runner-style prototype** made in Unity using C#.  
This project demonstrates **player input handling**, **event-driven communication**, and **basic modular structure** using Unity components.

---

## 💡 About the Project

This was built as a prototype where the player controls a boat moving forward automatically.  
You can click and drag the boat to steer it (PC version), and fire from its weapon head.

The game is simple but showcases my approach to:

- Input handling (mouse & touch logic split into different versions)
- Reusable components (e.g., GunHead logic)
- Encapsulated state control (`isStopped`, `SetShooting`, etc.)
- Smooth forward movement in `FixedUpdate`
- Unity's coordinate math: `ScreenToWorldPoint`, `offset` calculation

---

## 🧠 Why This Exists

I made this to experiment with:
- **Runner mechanics**
- **Input control on different platforms**
- **Basic component-driven architecture**

Some parts are clean and reusable. Others can be improved — especially if the project was scaled up.  
Still, it's a good example of how I write Unity C# scripts.

---

## 🗂️ Where to Look

Check these files if you're interested in how I write code:

- `BoatController.cs` – input, movement, and control logic
- Any other scripts =) inside `Assets/Scripts/`

---

## ⚠️ Notes

- The project is not actively maintained.
- PC input version only (for now).
- No builds included – open in Unity to test.

# Steam Wrapper Launcher

A lightweight, no-console Windows executable that acts as a **Steam-safe launcher wrapper**.  
This tool is perfect for launching modded or custom game executables that would otherwise break when launched through Steam due to unexpected parameters.

---

## 🔧 What It Does

- Swallows any command-line arguments Steam tries to pass (like `%command%`)
- Launches your actual game or modded executable
- Runs silently — no console window or prompts
- Works standalone after publishing — no .NET install required

---

## 🚀 How to Use

1. Download or build the executable (see below).
2. Place the `SteamWrapperLauncher.exe` in your game folder or wherever Steam is configured to launch.
3. Edit the included `launch_path.txt` file and replace the default path with the full path to your real game or mod launcher.

### 📄 Example `launch_path.txt` (included)

```
C:\Games\MyModdedGame\MyRealLauncher.exe
```

4. Either:

   - Replace the original game `.exe` with this one  
     **OR**

   - Point Steam's launch options to this file, e.g.:  

     ```
     "C:\Games\MyModdedGame\SteamWrapperLauncher.exe" %command%
     ```

---

## 🛠 Building It Yourself (Command Line)

You need the [.NET SDK](https://dotnet.microsoft.com/download) installed.

### 💬 One-liner to publish a standalone `.exe`:

```bash
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true
```

This creates a portable `.exe` in:

```
bin\Release\netX.X\win-x64\publish\
```

You can now drop that into any Steam game folder and use the included `launch_path.txt` to point to your actual launcher.

---

## ✅ When to Use

- Steam launches a game with unexpected parameters and it crashes or misbehaves
- You use a mod launcher that can’t accept Steam’s `%command%`
- You want a clean, silent handoff from Steam to your real game launcher

---

## 📝 License

MIT — free to use, modify, and redistribute.
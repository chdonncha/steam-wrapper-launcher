# Steam Wrapper Launcher

A lightweight, no-console Windows executable that acts as a **Steam-safe launcher wrapper**. This tool is ideal for modded or custom game launchers that do not handle Steam’s launch parameters properly.

## 🔧 What It Does

- Swallows any command-line arguments Steam tries to pass
- Launches your custom `.exe` (e.g., mod loader or patched game binary)
- Runs silently — no terminal popup
- Fully self-contained `.exe` after publishing (no .NET install required)

## 📁 How to Use

1. **Download or build** the executable.

2. Place it in your Steam game's folder (or wherever needed).

3. Create a file in the same folder named:  

   ```
   launch_path.txt
   ```

4. Inside `launch_path.txt`, write the full path to the real launcher you want to run.  
   Example:

   ```
   C:\Games\MyCustomGame\MyLauncher.exe
   ```

   Alternatively, copy and rename `launch_path.example.txt`.

5. Replace the original game `.exe` with this one or configure Steam to launch this wrapper.

## ✅ Perfect For

- Games that crash when launched with `Steam.exe %command%`
- Modded games like KeeperFX, OpenMW, etc.
- Any launcher that needs to ignore startup arguments

## 💻 Building It Yourself (Visual Studio)

1. Open the solution in Visual Studio
2. Change the `Output Type` to **Windows Application** to suppress the console
3. Go to **Publish** > **Folder** > set Target Runtime to `win-x64`
4. Enable:
   - Self-contained deployment
   - Produce single file
5. Click **Publish**
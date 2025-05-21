# Steam Wrapper Launcher

A lightweight, no-console Windows executable that acts as a **Steam-safe launcher wrapper**.  
This tool is perfect for launching modded or custom game executables that would otherwise break when launched through Steam due to unexpected parameters.

## ✅ When to Use

Use this wrapper when:

- You're launching a game or mod via Steam and it's failing because:
  - You're passing `%command%` in the Steam Launch Options (which adds the original game .exe path as an argument)
  - You're using a custom `.exe` that cannot handle arguments like paths
  - You've replaced the original game `.exe`, but Steam still tries to run or reference the original path internally

### 💡 Example Use Case: Dungeon Keeper Gold with KeeperFX
If you're using KeeperFX - a fan-made modern launcher for Dungeon Keeper - Steam may break the launch process when trying to run it directly or through a custom shortcut. This wrapper avoids those issues by stripping out any injected parameters before handing off control to KeeperFX.

## 🔧 What It Does

- Ignores all command-line arguments passed by Steam
- Launches any target `.exe` defined in a `launch_path.txt` file
- Silently runs with no terminal window (WinExe mode)
- Fully portable: builds into a single, self-contained `.exe` file
- Drop-in replacement for existing Steam game executables


## 🚀 How It Works

Steam often passes arguments like `%command%` to executables — modded launchers often don’t support these and throw errors. This wrapper acts as a "middleman" that:

1. Ignores all parameters
2. Reads the real game/mod executable path from `launch_path.txt`
3. Launches the target `.exe` silently
4. Waits briefly so Steam doesn't think it crashed

## 🛠️ How to Build and Use

### 🔧 Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

### 📦 Steps

**Step 1: Clone this repository**

```sh
git clone https://github.com/chdonncha/steam-wrapper-launcher.git
cd steam-wrapper-launcher
```

**Step 2: Publish the executable**

```sh
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true
```

This will produce a standalone `.exe` file that includes all dependencies. You’ll find it in:

```
<your project folder>\bin\Release\net8.0\win-x64\publish\
```

If you ran the command from the root of your project, and your project is located at:

```
C:\Users\<yourname>\steam-wrapper-launcher
```

Then your compiled `.exe` will be at:

```
C:\Users\<yourname>\steam-wrapper-launcher\bin\Release\net8.0\win-x64\publish\SteamWrapperLauncher.exe
```

💡 Tip: To quickly open the folder in File Explorer, you can run:

```sh
explorer .\bin\Release\net8.0\win-x64\publish\
```


## 🧩 Setting Up the Wrapper for Steam

Once you’ve published the `.exe`, follow these steps to use it as a Steam-compatible wrapper:

### 1. Create a `launch_path.txt`

Place this in the **same folder** as the compiled `.exe`.

This file should contain the full path to the actual game or mod launcher you want to start. For example:

```
C:\Program Files\keeperfx_1_2_0_complete\keeperfx.exe
```

### 2. Choose How to Launch It via Steam

You can use either of the following methods:

- **Replace the original game `.exe` with the wrapper**  
  Rename your compiled `.exe` to match the original executable Steam expects.

  Example:

  ```
  SteamWrapperLauncher.exe → Dungeon Keeper.exe
  ```

  Then place it in the original game folder:

  ```
  C:\Program Files (x86)\Steam\steamapps\common\Dungeon Keeper\DOSBOX\
  ```

- **Use Steam Launch Options instead**  
  This method avoids modifying original files. In Steam's **Launch Options** field, enter:

  ```
  "C:\Games\MyModdedGame\SteamWrapperLauncher.exe" %command%
  ```

  > 🔎 **Note:** If you include `%command%` in Steam's Launch Options, Steam will append the original game's executable path as an argument.  
  > This wrapper safely ignores any such arguments to prevent crashes or unexpected behavior.

Now, when Steam launches the game, your wrapper will intercept it and start the real mod launcher - without crashing from unexpected parameters.

## ⚠️ Notes

- This wrapper only works on **Windows**
- The target executable **must exist at the path** defined in `launch_path.txt`
- If the file is missing or the path is invalid, a `wrapper_error.log` will be generated
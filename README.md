<div align="center">

  # VSSuite

  <a href="https://github.com/AriesLR/VSSuite/releases"><img src="https://img.shields.io/github/v/release/AriesLR/VSSuite?color=emerald" align="center"></a>
  <a href="docs/version/CHANGELOG.md"><img src="https://img.shields.io/badge/changelog-latest-blue" align="center"></a>
  <a href="LICENSE"><img src="https://img.shields.io/github/license/AriesLR/VSSuite?color=orange" align="center"></a>

  <br/>


  <a href="https://www.patreon.com/c/arieslr/membership"><img src="https://img.shields.io/badge/Patreon-F96854?style=flat&logo=patreon&logoColor=white" align="center"></a>
  <a href="https://www.buymeacoffee.com/arieslr"><img src="https://img.shields.io/badge/Buy%20Me%20a%20Coffee-FFDD00?style=flat&logo=buy-me-a-coffee&logoColor=black" align="center"></a>

</div>

## Table of Contents

- [How It Works](#how-it-works)
- [Requirements](#requirements)
  - [Software](#software)
  - [OS Support](#os-support)
- [Features](#features)
- [Known Issues](#known-issues)
- [Installation](#installation)
  - [How To Use](#how-to-use)
- [Updating](#updating)
- [Screenshots](#infographic)
- [Acknowledgements](#acknowledgements)
- [License](#license)

## How It Works  
When the user launches the app, they are prompted to select their mod folder. The app scans every `modNameHere.zip` in the folder, reading the `modinfo.json` inside each archive to populate the main table with relevant information.  

When the user clicks **"Check for Updates,"** the app queries the Vintage Story Mods API for each mod’s latest version and game compatibility data. Any download links retrieved are cached in a temporary `ModLinks.json` file, indexed by `modId` and overwritten each time updates are checked. The table is then refreshed with the newest version information and a **"Has Update"** indicator.  

If the user selects **"Download All Mods,"** the app fetches the updated mods, replaces the old files, and keeps track of changes. At the end of the process, a summary is displayed showing which mods were updated and the version differences.  


## Requirements

### Software

- [.NET 8.0 Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
  - This is likely already installed on your system.

- [WebView2](https://developer.microsoft.com/en-us/microsoft-edge/webview2/?form=MA13LH#download)
  - If this is missing from your system, the application will automatically prompt you to download it when opening the mod browser.

### OS Support

- Windows 10/11
  - Older versions of windows will likely still work.


## Features
- **Automatic Mod Scanning:** Reads every mod in your selected folder and extracts key details from each `modinfo.json`.

- **Update Checking:** Uses the Vintage Story Mods API to fetch the latest versions and game compatibility data, comparing them against your installed mods.
  - Checks compatibility against a user selected target game version via a dropdown menu.
  - Highlights available updates instantly in the main data table.

- **Version Tracking:** Highlights which mods have updates available in the main table.

- **Batch Updates:** Update and replace all outdated mods at once with the latest versions.

- **Individual Mod Updates:** Update a single mod independently, even if multiple mods have updates available.

- **Embedded Mod Browser:** Browse the official Vintage Story Mod Database natively inside the application, allowing you to discover new mods without switching to an external browser.

- **Mod Search Filter:** Filter your active mod list by name using a responsive search bar built into the application's title bar.

- **User-Friendly Interface:** Shows your mods in a clean, sortable table, making it easy to spot which ones need updating.
  - **Dynamic Status Pills:** Features status badges above the table showing counters for total mods, disabled updates, version mismatches, and pending updates.
  - Provides buttons to open any mod's official Vintage Story Mod Database page instantly.

- **Detailed Update Summary:** Displays a clear summary of all updated mods along with their version changes.
  - Includes a copy to clipboard option formatted perfectly in Discord markdown, making it effortless to post patch notes for your community.

- **Advanced Modlist Tools:** Access a collection of utility tools designed to manage your modlist:
  - **Duplicate Cleaner:** Automatically scans your active folder and removes duplicate mod files.
  - **Flexible Modlist Exporting:** Copy your current modlist to the clipboard using either a standard layout or a pre-formatted Discord markdown style.
  - **Modlist Purge & Reinstall:** Wipe and reinstall your entire active modlist to potentially fix corruption issues.

- **In-App Changelog Viewer:** Read the application's full development and update history directly inside the client.

- **Built-In Information Panel:** Access a context guide that clarifies potentially confusing behaviors.

- **Deep Customization:** Tailor VSSuite to your liking with a application settings menu.
  - **General Preferences:** Set your preferred target game version for startup loading and toggle automatic update checks on application launch.
  - **Safe Mode Filter:** Restricts VSSuite to stable mod releases only, automatically filtering out development and release candidate builds (e.g., `3.2.1-dev.1` or `1.2.3-rc.3`).
  - **Interface Customization:** Toggle specific table columns on or off (such as Ignore, Mod Page, File Name, or Game Version) to hide unnecessary data fields and declutter your view.

## Known Issues

- None at all! Let's keep it that way.

## Installation

Getting started with **VSSuite** is simple, just download the [Latest Release](https://github.com/AriesLR/VSSuite/releases/latest) and run the `VSSuite.exe`. No installation or extraction required, the app is fully portable and can be run from anywhere on your computer.

### How To Use

1. Launch `VSSuite.exe`.

2. Browse for your **Mods** folder when prompted.

3. The app will scan all `modNameHere.zip` files and read their `modinfo.json` files to populate the mod table.

4. Click **Check for Updates** to see which mods have new versions available.

5. Click **Download All Mods** to automatically update any mods with available updates.


## Updating

Updating **VSSuite** is easy. Since the app is fully portable, all you need to do is download the [Latest Release](https://github.com/AriesLR/VSSuite/releases/latest) and replace your existing `VSSuite.exe` with the new one.

 
## Acknowledgements
- [Vintage Story Devs](https://www.vintagestory.at) - For unintentionally inspiring this whole project. If it wasn't for the game this wouldn't exist.


## License

[MIT License](LICENSE)

---

<img src="https://i.imgflip.com/1u2oyu.jpg" alt="I like this doge" width="100">
## [v0.7.0] - 5-22-2026

### Developer Notes & Design Philosophy

#### Why VSSuite remains Windows-Only

While expanding support to Linux is a frequent request, branching out would require a massive overhaul of both the UI layer and the backend architecture as I use a Windows exclusive architecture and a UI framework on top of that. As a solo developer, I simply do not have the storage space to set up, test, and maintain multiple operating systems. More importantly, it is incredibly time consuming. For now, keeping the scope limited to Windows ensures I can maintain VSSuite without burning out. That being said, this doesn't exclude the possibility I decide to move to a different architecture and pick up Linux support in the future.

#### Streamlining Game Version Updates

Historically, compatibility version numbers were hardcoded in the application. This meant that every single time Vintage Story released an update, I had to go through a 12 step update process: updating the version numbers, compiling the new build, zipping packages, running separate VirusTotal scans for the raw executable and zip file, updating cryptographic hashes (SHA-256), and manually syncing releases across both GitHub and the Vintage Story Mod Repo. This process took upwards of 30 minutes per minor patch. 

To solve this, game versions are now fetched from a remote JSON file hosted on the tool's GitHub. Because VSSuite already requires an active internet connection to scan the mod database, this shift changes absolutely nothing about the app's core functionality or performance. However, it completely changes the game for me, cutting my update process down from a 30 minute chore to a 1 minute file push. This ensures the app stays up to date with new game releases without forcing users to download a new update every few weeks.

#### The WebView2 Dependency & Embedded Mod Browser

To maximize convenience, this update introduces an embedded Mod Browser that allows you to explore the official mod database without leaving the app. This feature utilizes Microsoft’s WebView2 runtime. If your system doesn't already have it installed (many modern applications use it under the hood), VSSuite will prompt you to download the tiny ~2MB installer, which takes up roughly 250MB of disk space once unpacked. 

For strict security reasons, the embedded browser is heavily sandboxed. URL navigation is completely locked down, meaning it cannot be used as a regular web browser. Because fully securing a web browser requires infrastructure, limiting navigation ensures you aren't exposed to unnecessary vulnerabilities. Additionally, the login button on the mod site has been intentionally disabled. To guarantee your privacy and data safety, VSSuite is designed to never handle, capture, or even allow the input of your sensitive account credentials.

### Patch Notes:

### Added
- **Sidebar Navigation Menu:** Introduced a sidebar navigation menu to access many of the new features.
- **Mod Browser:** Integrated an embedded browser to browse mods.vintagestory.at directly within the app.
- **App Settings Menu:** Added a dedicated settings panel featuring:
  - Default game version dropdown (sets the game version selected on launch).
  - "Check for updates on startup" toggle.
  - Manual "Check for Updates" button.
  - Custom UI visibility toggles for the Ignore, Mod Page, File Name, and Game Version columns.
  - **Safe Mode Toggle:** Restricts downloads to stable mod releases only. When enabled, the tool automatically filters out development, and release candidate builds (e.g., 3.2.1-dev.1 or 1.2.3-rc.3) to ensure stability.
- **Modlist Tools Menu:** Added a utility menu featuring modlist related tools:
  - Copy modlist with Discord markdown formatting.
  - Copy raw text modlist.
  - Reinstall all mods.
  - Scan and remove duplicate mods.
- **Changelog Viewer:** Added a native Markdown viewer to read VSSuite update history in-app.
- **Tips Menu:** Introduced a tips flyout menu to highlight ways to support me and the tool.
- **Information Panel:** Added an information panel to clarify any confusing application behaviors.
- **Pill Displays:** Added status badges above the mod table to track totals for total mods, updates disabled, version mismatches, and available updates.
- **Search Bar:** Embedded a search filter into the application's title bar to filter your modlist by mod name.
- **App Version Display:** Added the current application build version into the window title bar.
- **Table Sorting:** Enabled column sorting for the download button column.
- **Dependencies:**
  - Added Microsoft.Web.WebView2 as a dependency.
  - Added MdXaml as a dependency to parse Markdown files.
- **Application & Deployment:**
  - Integrated missing assembly and copyright metadata into the executable.
  - Digitally signed the application's executable to improve security.

### Changed
- **The Rebrand:** Rebranded the project from "VS-Mod-Update-Tool" to "VSSuite" for a more memorable name.
- **UI & Layout Overhaul:**
  - Overhauled VSSuite's theme and increased overall default window dimensions by 10%.
  - Consolidated scattered UI actions into a control area located above the main mod table.
  - Integrated folder browser controls into the file path bar.
- **Mod Table Columns:**
  - Merged the Update column and the previously unlabeled Mod Download column into a single column.
  - Updated the Latest Version column to always show the true latest version (even if incompatible with your selected game version), displaying the version in yellow.
  - Enhanced the Latest Version text color to shift to green when an applicable update is available.
- **Game Version Dropdown:** Redesigned the version selector layout to make the currently active target version clearly visible at a glance.
- **Dependencies:** Upgraded NuGet.Versioning from v7.3.0 to v7.6.0.
- **Under the Hood:** Performed light code refactoring across core methods to align with modern C# standards.

### Fixed
- Resolved outstanding compiler nullability warnings throughout the codebase.

---

## [v0.6.4] - 5-15-2026

### Changed
- Added 1.22.1 and 1.22.2 as options for version selection.

---

## [v0.6.3] - 4-19-2026

### Changed
- Added 1.21.7 as an option for version selection.

---

## [v0.6.2] - 4-11-2026

### Changed
- Added 1.22.x and 1.22.0 as an option for version selection.
- Updated Dependencies.

---

## [v0.6.1] - 12-16-2025

### Changed
- Added 1.21.6 as an option for version selection.

### Fixed
- An odd issue with some mods selecting the wrong version for updating -- the mod in question was Terra Prety, but I'm sure the issue went unnoticed with other mods as well.

---

## [v0.6.0] - 10-19-2025

### Added
- Added an Ignore column and matching logic to ignore checking for updates on specific mods in the event a new version of a mod causes issues, but an older version works fine.
- Added 1.21.5 as an option for version selection.

### Changed
- Slightly increased the window size to accomodate the new column.
- Reworded some comments for clarity.
- Possible other changes to code I forgot about, it's been awhile between making these changes and pushing the update.

---

## [v0.5.2] - 10-7-2025

### Added
- Added support for specific game versions ranging from 1.20.0 to 1.21.4.

### Changed
- Improved version selection logic to recognize and handle exact versions such as 1.21.1 and 1.21.2.

---

## [v0.5.1] - 9-21-2025

### Added
- Integrated NuGet.Versioning to improve semantic version sorting.

### Fixed
- Corrected update logic so that stable releases are always preferred (when available) over pre-release versions like -pre.2 or -rc.1.

---

## [v0.5.0] - 9-21-2025

### Added
- Added a button to copy the entire mod list (useful for quickly sharing in places like a Discord server).

### Changed
- Improved the mod update check to run in parallel instead of sequentially, making it roughly 4–5x faster compared to v0.4.0.
- Refactored backend logic related to how/when mod update checks are processed.

---

## [v0.4.0] - 09-18-2025

### Added
- MahApps.Metro.IconPacks.SimpleIcons for better brand icons.  
- Mod Page column to the mods table.  
- Ability to click mod page icons to open the corresponding mod page in a browser.  
- Tooltips added or improved for: Refresh Mods Folder, Browse for Mods Folder, Buy Me a Coffee, Check for Updates, Update column checkmark, and Mod Page icons.  
- Markdown copy output for updated mods, making it easier to paste directly into Discord.  
- App Icon for a more polished look.  
- The app now remembers the last loaded mods folder, so you only need to select it once.  

### Changed
- Discord button replaced with a Buy Me a Coffee button.  
- "Has Update" column renamed to "Update".  
- Update column now displays a checkmark icon instead of a checkbox control.  
- Compiler warnings cleaned up (~20 resolved).  
- Substantial code refactoring, consolidating duplicate functionality into helper methods.  
- Improved error messages, making debugging easier.  
- Updated build settings: SelfContained and EnableCompressionInSingleFile disabled.  
  - .NET 8 is no longer bundled with the app (assumed to be installed separately).  
  - File size reduced from ~70MB → ~10MB.  

### Fixed
- Issue with checking for mod updates after files were removed from the active folder.  
  - The app now refreshes the folder before update checks, preventing file-not-found errors.  

### Removed
- MahApps.Metro.IconPacks.FontAwesome
- Redundant"Update" header above the update button.

---

## [v0.3.0] - 09-17-2025

### Added
- Game version selection dropdown for finding the most recent mod updates by [major.minor](https://semver.org) version (e.g. 1.21.x).  
  - Patch version no longer matters, as long as the update matches the selected [major.minor](https://semver.org) version.  

### Changed
- Updated MahApps.Metro from 2.4.10 → 2.4.11.  
- Updated Newtonsoft.Json from 13.0.3 → 13.0.4.  
- Switched update checking to use the Vintage Story Mods API instead of scraping webpages.  
- Download logic adapted to align with the new update-checking method.  

### Fixed
- General code cleanup.  

### Removed
- HtmlAgilityPack dependency removed.  

---

## [v0.2.2] - 09-16-2025

### Added
- Confirmation prompt before downloading all mods.

### Changed
- Additional UI adjustments.

---

## [v0.2.1] - 09-16-2025

### Added
- New dialog type.

### Changed
- Updated the application theme.
- Changed the assembly name.

---

## [v0.2.0.0] - 09-16-2025

### Added
- Buttons and logic for refreshing the mods folder, browsing for a different mods folder, and joining the Discord server for our Vintage Story server.  
- An update button within the table for updating individual mods without updating all mods at once.  
- Progress bars and completion dialogs for checking for updates and updating mods.  
- Logic to track how many mods were checked and which mods have updates available.  
- Extended error logging to display informative messages for additional actions that may cause errors.  
- A summary screen after updating mods showing which mods were updated (by modId) and their version changes, with a button for copying the text to share the results.  
- Logic for updating a single mod independently of the full update process.

### Changed
- User interface has been cleaned up for improved usability.  
- Code has been refactored and cleaned for maintainability.

### Fixed
- Corrected links required by the app, including the update.json file in the repository and the repository page itself.

---

## [v0.1.0] - 09-14-2025

### Added
- Moved the mods folder textbox to the title bar.
- Enabled click-and-drag of the window via the mods folder textbox.
- "Check for Mod Updates" button with update checking logic.
- "Update All Mods" button with bulk download logic.
- Prompt on launch to select the mods folder.
- HtmlAgilityPack added for scraping mod pages to find versions and download links.
- Single-file publishing enabled.
- Assembly information added to the program.
- MessageService updated with custom dialogs for this app.

### Changed
- Mods table layout updated with a "Latest Version" column.
- Config file location changed to: Documents\AriesLR\VSModUpdateTool.
- modinfo.json parsing updated to handle both uppercase and lowercase field names.
- Empty fields in the Mods table now display as "N/A".

### Removed
- Folder browse textbox and button.

---

## [v0.0.3] - 09-14-2025

### Added
- Added game version dropdown selection.

- Added a check for mod updates button.

### Changed
- Code cleanup.

---

## [v0.0.2] - 09-14-2025

### Added
- Added logic for handling inconsistent json field naming. (e.g. X mod uses "Name" while Y mod uses "name")

- Added versioning to the project file.

### Changed
- Switched from System.Text.Json to Newtonsoft.Json.Linq, this was mainly due to some mod authors leaving a trailing comma at the end of their modinfo.json causing the system.text JSON parser to fail.

- Increased default app window size

---

## [v0.0.1] - 09-13-2025
### Added
- Initial commit of the project, barebones at this point.

# MSM.NET 🚀
### Minecraft Server Maker

**MSM.NET** is a modern, lightweight desktop application designed to simplify the process of creating and managing Minecraft servers in your device.

---

## 🛠 Built With

The project utilizes/employs the power of the latest Microsoft stack to ensure high performance and a modern experience:

* **Framework:** [.NET 9](https://dotnet.microsoft.com/) (The latest, cutting-edge version of .NET)
* **Language:** [C# 13](https://learn.microsoft.com/en-us/dotnet/csharp/)
* **UI Framework:** [WPF (Windows Presentation Foundation)](https://learn.microsoft.com/en-us/dotnet/desktop/wpf/)
* **Architecture:** **MVVM** (Model-View-ViewModel) for clean and maintainable code.
* **System API:** **WMI (Windows Management Instrumentation)** for real-time RAM monitoring.

---

## 🚀 Getting Started

To start your journey as a server owner, you need a server engine file.

1.  **Download the Server Engine:**
    You can get the official clean **Vanilla** server file from the official source:
    👉 [Download Minecraft Server JAR](https://www.minecraft.net/en-us/download/server)

2. **Get Portable Java (JRE):**
   You can use this portable JRE version (just extract the zip):
   * **Source:** Adoptium (Eclipse Temurin)
   * **Version:** Java 21+ (Recommended)
   👉 [Download Portable JRE (.ZIP)](https://adoptium.net/download?link=https%3A%2F%2Fgithub.com%2Fadoptium%2Ftemurin25-binaries%2Freleases%2Fdownload%2Fjdk-25.0.2%252B10%2FOpenJDK25U-jre_x64_windows_hotspot_25.0.2_10.zip&vendor=Adoptium)
3. **Portable Java Setup:**
   To make the application detect Java automatically, extract the downloaded JRE ZIP content into the following directory:
   `{BaseDirectory}/bin/debug/runtime/`

   **Your folder structure should look like this:**
   ```text
    {BaseDirectory}/
    └── bin/
        └── debug/
            └── runtime/
                ├── bin/ (contains java.exe)
                ├── lib/
                └── conf/

4.  **Configuration:**
    * Launch **MSM.NET**.
    * Select your downloaded `server.jar`.
    * Configure the settings according to your preferences.
    
5.  **Run:**
    Hit the **Create Server** button and enjoy your server!

---

## ✨ Features

* **Real-time Memory Monitor:** Prevents assigning more RAM than your PC actually has.
* **Flexible Setup:** Toggle between Localhost and Public mode with one click.
* **Easy Dashboard:** Application have simple dashboard with basic information.

---
## 🖼️ Preview & Interface

<div align="center">

| 🖥️ Dashboard #1 | 📊 Dashboard #2 | ⚙️ Maker Settings | 🔧 Server Configuration |
| :---: | :---: | :---: | :---: |
| <img src="https://github.com/user-attachments/assets/528094ad-9871-491c-b1b8-cffbc84e1a30" width="380" /> | <img src="https://github.com/user-attachments/assets/560cfde7-dc4c-4115-bd60-afe45aeb6e27" width="380" /> | <img src="https://github.com/user-attachments/assets/c720002e-dc5a-477f-9f8e-bad52396f205" width="380" /> | <img src="https://github.com/user-attachments/assets/e42656c4-636f-4d11-b98e-06e6966400f5" width="380" /> |
| *Server status is "Offline"* | *Server status is "Online"* | *Network & Memory Allocation* | *Server Name and Properties* |

</div>



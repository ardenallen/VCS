# Virtual Clinical Simulation (VCS)
VCS is a proof of concept prototype of virtual clinical simulation training software. It is aiming to solve the problem for medical students who do not have the accessibility to the real clinical training centre, especially in developing countries.

The prototype is designed around a specific clinical scenario of a young male patient sustaining a motor vehicle crash suffering with hypotensive shock. In the scenario, the student is expected to do a typical patient assessment; asking the patient how they are, monitoring their vitals and conducting a physical assessment. Upon that, discovering that the patient has suffered trauma to his pelvic region. 

## Getting Started
The project is split into two client ends: **VR end for students** and **PC end for instructors**. These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites
For getting a copy of this project, please access to the master branch and download it as a **ZIP file**. Then find two projects file from **VCS/Unity Project/StudentEnd** and **VCS/Unity Project/InstructorEnd**.

[![](https://www.mdeditor.com/images/logos/markdown.png)](https://www.mdeditor.com/images/logos/markdown.png "markdown")
> Process of Downloading Project

##### Hardware Requirement (student end)
* Oculus Quest
* USB TypeC to USB 3.0 cable (for enabling Oculus Link, available product: https://www.amazon.ca/dp/B01MZIPYPY/)
* A PC that meets the requirement of Oculus Link (https://support.oculus.com/444256562873335/)

##### Software Requirement (student end)
* Oculus App Version 15.0.0.200.456 (15.0.0.200.456) (https://www.oculus.com/setup/#rift-setup)
* Oculus mobile application for changing some settings and getting the device information (https://www.oculus.com/setup/#quest-setup)

##### Development Tool
* Unity 2019.2.19f1

##### Plug-ins
* [Photon PUN 2](https://www.photonengine.com/PUN)
* [Photon Voice](https://www.photonengine.com/Voice)
* [Oculus Unity Integration](https://developer.oculus.com/downloads/package/unity-integration/) (student end only)
* [Peter Koch - VR Canvas Keyboard](http://talesfromtherift.com/vr-canvas-keyboard/) (student end only)

##### Key Unity packages (student end, automatically imported)
* Oculus Android 1.38.6
* Oculus Desktop 1.38.4
* OpenVR (Desktop) 1.0.5

### Photon Sign Up
For getting your own Photon server, please register an account on [Photon official website](https://www.photonengine.com).

In the dashboard, click **CREATE A NEW APP**

[![](https://www.mdeditor.com/images/logos/markdown.png)](https://www.mdeditor.com/images/logos/markdown.png "markdown")

Choose the Photon Type as **Photon PUN**

[![](https://www.mdeditor.com/images/logos/markdown.png)](https://www.mdeditor.com/images/logos/markdown.png "markdown")

Copy the **App ID**

[![](https://www.mdeditor.com/images/logos/markdown.png)](https://www.mdeditor.com/images/logos/markdown.png "markdown")

Paste the App ID to **PhotonServerSettings** in Unity and change the settings based on your need

[![](https://www.mdeditor.com/images/logos/markdown.png)](https://www.mdeditor.com/images/logos/markdown.png "markdown")

### Oculus Development
If you want to release the application on Oculus platform or develop it on Android, please register your Oculus account and create your own application on the developer dashboard. For the details, please visit Oculus Developers.

### Platform
Currently, the project is based on Windows platform, for further development, if you want to run the application without Oculus Link or move to Android platform, please check Preparing for Android Development to get details.


##### For any questions about Photon, OVR and VR Canvas Keyboard, please visit the links below:

Photon:
[Photon PUN 2 Free Edition Unity Package](https://assetstore.unity.com/packages/tools/network/pun-2-free-119922)
[Photon Voice Unity Package](https://assetstore.unity.com/packages/tools/audio/photon-voice-45848)
[Photon](https://www.photonengine.com/)
[Photon PUN 2 Documentation](https://doc.photonengine.com/en-us/pun/current/getting-started/pun-intro)
[Photon Voice Documentation](https://doc.photonengine.com/en-us/voice/current/getting-started/voice-intro)
[Photon Server](https://doc.photonengine.com/en-us/server/current/getting-started/photon-server-intro)

OVR:
[Oculus Integration Unity package](https://assetstore.unity.com/packages/tools/integration/oculus-integration-82022)
[Oculus Unity Integration](https://developer.oculus.com/downloads/package/unity-integration/)
[Oculus Developers Center (Oculus Quest)](https://developer.oculus.com/quest/)
[Oculus Unity Development Documentation](https://developer.oculus.com/documentation/unity/book-unity-gsg/)
[Oculus Unity Utilities Reference Manual 14.0](https://developer.oculus.com/reference/unity/v14/)

[VR Canvas Keyboard](http://talesfromtherift.com/vr-canvas-keyboard/)

## Important Classes
### Student End
##### NetworkLauncher
The script is attached to NetworkManager in Scene Login_Student. 
##### NetworkPlayer

##### TrainingManagement

##### ControlPanelDataTransfer




### Instructor End






## Authors
Emily Yao - Lead Developer @Sakuya0116
Arden Allen - Developer @ardenallen
Leo Chen - 3D Artist @LeoCHCH
Meg Dimma - Project Manager
Ruby Zhang - UX Designer/ Product Manager
Parastou Heidari - UI Designer/ 2D Artist
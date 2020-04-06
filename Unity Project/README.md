# Virtual Clinical Simulation (VCS)
VCS is a proof of concept prototype of virtual clinical simulation training software. It is aiming to solve the problem for medical students who do not have the accessibility to the real clinical training centre, especially in developing countries.

The prototype is designed around a specific clinical scenario of a young male patient sustaining a motor vehicle crash suffering with hypotensive shock. In the scenario, the student is expected to do a typical patient assessment; asking the patient how they are, monitoring their vitals and conducting a physical assessment. Upon that, discovering that the patient has suffered trauma to his pelvic region. 

## Getting Started
The project is split into two client ends: **VR end for students** and **PC end for instructors**. These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites
For getting a copy of this project, please access to the master branch and download it as a **ZIP file**. Then find two projects file from **VCS/Unity Project/StudentEnd** and **VCS/Unity Project/InstructorEnd**.

![](https://github.com/sakuya0116/VCS/blob/master/Documentation/Images~/downloadProject.PNG "downloadProject")
> Process of Downloading Project

##### Hardware Requirement (student end)
* Oculus Quest
* USB TypeC to USB 3.0 cable (for enabling Oculus Link, available product: https://www.amazon.ca/dp/B01MZIPYPY/)
* A PC that meets the requirement of Oculus Link (https://support.oculus.com/444256562873335/)

##### Software Requirement (student end)
* [Oculus App Version 15.0.0.200.456](https://www.oculus.com/setup/#rift-setup)
* [Oculus mobile application](https://www.oculus.com/setup/#quest-setup) for device management

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

![](https://github.com/sakuya0116/VCS/blob/master/Documentation/Images~/PhotonSetUp1.PNG "PhotonSetUp1")

Choose the Photon Type as **Photon PUN**

![](https://github.com/sakuya0116/VCS/blob/master/Documentation/Images~/PhotonSetUp2.PNG "PhotonSetUp2")

Copy the **App ID**

![](https://github.com/sakuya0116/VCS/blob/master/Documentation/Images~/PhotonSetUp3.PNG "PhotonSetUp3")

Paste the App ID to **PhotonServerSettings** in Unity and change the settings based on your need

![](https://github.com/sakuya0116/VCS/blob/master/Documentation/Images~/PhotonSetUp4.PNG "PhotonSetUp4")

### Oculus Development
If you want to release the application on Oculus platform or develop it on Android, please register your Oculus account and create your own application on the developer dashboard. For the details, please visit [Oculus Developers](https://developer.oculus.com/).

### Platform
Currently, the project is based on Windows platform, for further development, if you want to run the application without Oculus Link or move to Android platform, please check [Preparing for Android Development](https://developer.oculus.com/documentation/unity/unity-mobileprep/) to get details.


#### For any questions about Photon, OVR and VR Canvas Keyboard, please visit the links below:

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
* __NetworkLauncher__
The script is attached to **NetworkManager** in the Scene **Login_Student**. It is mainly used for server connection, room creation, and UI management.

* __TrainingManager__
The script is attached to the gameobject **TrainingManager** in the Scene **TrainingRoom**. It will instantiate the user’s character after joining the room.

* __NetworkPlayer__
The script is attached to **LeadDoctor** and **Doctor** prefabs in ** Assets/Photon/PhotonUnityNetworking/Resources**, which is used for instantiating user’s character on their own client and transferring data to the others. It will synchronize the character’s name, position, rotation, character’s hands’ position and rotation, and status of the objects on the character itself, to other users who are in the same training room.

* __ControlPanelDataTransfer__
This script is for transferring and receiving data from other users, it is attached to **LeadDoctor** and **Doctor** prefabs, and requires **PhotonView** component (A class in Photon PUN 2) and **RPC function** (Remote Procedure Calls). In this case, on the student end, it will send the activated status of the objects on characters, like the stethoscope, so that other users are able to see the changes. Meanwhile, it will receive the data from instructors to update vitals, active tools, control patient’s animation, and the volume of voice chat.

* Note: There are various other scripts present in **VCS/Unity Project/StudentEnd/Assets/Script** that are attached to the stethoscope X-ray and blood result. 

### Instructor End
* __NetworkLauncher__
The script is attached to **NetworkManager** in the Scene **Login_Instructor**. It is mainly used for server connection, room creation, and UI management. It also is responsible for the transitions from the login page to the dashboard.

* __TrainingManager__
The script is attached to the game object **TrainingManager** in the Scene **TrainingRoom**. It will instantiate the instructor upon joining the room

* __ControlPanelManagement__
The script is attached to the gameobject **TrainingManager** in the Scene **TrainingRoom**. This script attaches callbacks to the different UI elements of the control panel and tracks when the user makes changes to the control panel, including adjusting the vitals and making objects appear/disappear in the scene. This script tracks these changes so that the **ControlPanelDataTransfer** script can synchronize the changes to the student via **RPC function**.

* __ControlPanelDataTransfer__
This script is for transferring and receiving data from other users, it is attached to Instructor prefab, and requires a **PhotonView** component (A class in Photon PUN 2) and **RPC function** (Remote Procedure Calls). In this case, it will check the flags in the **ControlPanelManagement** component of the **TrainingManager** to see if the values in the control panel have changed, and then will use the RPC functions to send the corresponding new values to the student. The script contains RPC callbacks for changing the vitals, changing the visibility of objects, as well as activating the animation to talk as the patient. The script also makes RPC calls to send these values to the student.

* Note: There are various other scripts present in **VCS/Unity Project/InstructorEnd/Assets/Script** that are attached to the various UI elements of the Control Panel and Login/Dashboard. 

## Authors
Emily Yao - Lead Developer [@sakuya0116](https://github.com/sakuya0116)

Arden Allen - Developer [@ardenallen](https://github.com/ardenallen)

Leo Chen - 3D Artist [@LeoCHCH](https://github.com/LeoCHCH)

Meg Dimma - Project Manager

Ruby Zhang - UX Designer/ Product Manager

Parastou Heidari - UI Designer/ 2D Artist

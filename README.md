# Virtual Clinical Simulation (VCS)
VCS is a proof of concept prototype of virtual clinical simulation training software. It is aiming to solve the problem for medical students who do not have the accessibility to the real clinical training centre, especially in developing countries.

The prototype is designed around a specific clinical scenario of a young male patient sustaining a motor vehicle crash suffering with hypotensive shock. In the scenario, the student is expected to do a typical patient assessment; asking the patient how they are, monitoring their vitals and conducting a physical assessment. Upon that, discovering that the patient has suffered trauma to his pelvic region. 

## Getting Started
The project is split into two client ends: VR end for students and PC end for instructors. These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Folder Structure
+ Unity project 
	+ InstructorEnd
	+ StudentEnd
	+ Specific readme
+ Application
	+ InstructorEnd_Windows
	+ InstructorEnd_Mac
	+ StudentEnd
+ 3D Assets 
	+ Mannequin
	+ Objects
+ Design
	+ Colour & Font
	+ Final Files
	+ Hand Instruction
	+ Logo
	+ Story Board
	+ User Test
	+ UX Research
	+ UX Wireframe
+ Documentation
+ General readme

### Hardware Requirements
For running the student end, the Oculus Quest is required, you can buy the device through this link: https://www.oculus.com/quest/where-to-buy/

Due to the calculation power of Oculus Quest and 3D assets quality in the prototype, it needs to run by PC. Please access here for purchasing a USB cable which can enable Oculus Link function.

##### Recommended PC configuration
Componets	|	Recommended Configuration	|
------------- | -------------
CPU  | Intel i5-4590 / AMD Ryzen 5 1500X or upper level
GPU  | Please check the list below
RAM  | 8GB
System	|	Windows 10
USB	|USB 3.0

##### Recommended GPU
NVIDIA GPU	|	Support or not
------------- | :----:
NVIDIA Titan Z |X
NVIDIA Titan X |✓
NVIDIA GeForce GTX 970|✓
NVIDIA GeForce GTX 1060（desktop）|✓
NVIDIA GeForce GTX 1060M|X
NVIDIA GeForce GTX 1070（all）|✓
NVIDIA GeForce GTX 1080（all）|✓
NVIDIA GeForce GTX 1650|X
NVIDIA GeForce GTX 1650 Super|✓
NVIDIA GeForce GTX 1660|✓
NVIDIA GeForce GTX 1660 TI|✓
NVIDIA GeForce RTX 20 series（all）|✓

AMD GPU|Support or not
------------- | :----:
AMD 200 series|X
AMD 300 series|X
AMD 400 series|✓
AMD 500 series|✓
AMD 5000 series|✓
AMD Vega series|✓

If your GPU is not on the list, the compatibility cannot be guaranteed. For further information, please click [here](https://support.oculus.com/444256562873335/).

### Prerequisites
For using Oculus Link, please download **[Oculus software](https://www.oculus.com/setup/#rift-setup)** to set up on PC. Also, you can download the **[Oculus Quest application](https://www.oculus.com/setup/#quest-setup)** on your mobile devices for device management. If you have any problem with setting up Oculus Link, please check the webpage [here](https://support.oculus.com/525406631321134/#setup).

To get more information, please visit **[Oculus Support Centre](https://support.oculus.com/quest/)**.

For getting a copy of this project, please access the **master branch** and download it as a **ZIP file**.

[!(https://github.com/sakuya0116/VCS/blob/master/Documentation/Images~/downloadProject.PNG "downloadProject")
> Process of Downloading Project

## Running the Tests
### Student End
For running the application on the VR headset, please connect the Oculus Quest to your PC with cable and running the Oculus application, then enable the Oculus Link function after you put it on.

Find the **VCS_Student.exe** file in **VCS/Application/StudentEnd** and run. 

Important: make sure all the files in VCS/Application/StudentEnd are always put together (at the same location or folder), otherwise, the application cannot run successfully. 

When you log into the training, please **input 1234 as the passcode**, to make sure the student and instructor can enter the same room.

[!(https://github.com/sakuya0116/VCS/blob/master/Documentation/Images~/VRPasscode.jpg "VRPasscode")
> Input Passcode on Student End

### Instructor End
For the Windows system, please open the VCS_Instructor.exe file in **VCS/Application/InstructorEnd_Windows**.

***Important: make sure all the files in VCS/Application/InstructorEnd_Windows are always put together (at the same location or folder)***_, otherwise, the application cannot run successfully._

For MacOS, please copy **VCS/Application/InstructorEnd_Mac/InstructorEnd_Mac.app** to your Mac.

Since it does not connect to the database, the username and password will not influence the training simulation, you can skip login and directly go to the dashboard.

The training passcode is **1234** (you don’t need to input).

## Built With
Unity 2019.2.19f1

[Oculus Unity Integration](https://developer.oculus.com/downloads/package/unity-integration/)

[Photon PUN 2](https://www.photonengine.com/PUN)

[Photon Voice](https://www.photonengine.com/Voice)

[Peter Koch - VR Canvas Keyboard](http://talesfromtherift.com/vr-canvas-keyboard/)

## Authors
Meg Dimma - Project Manager

Ruby Zhang - UX Designer/ Product Manager

Parastou Heidari - UI Designer/ 2D Artist

Emily Yao - Lead Developer [@sakuya0116](https://github.com/sakuya0116)

Arden Allen - Developer [@ardenallen](https://github.com/ardenallen)

Leo Chen - 3D Artist [@LeoCHCH](https://github.com/LeoCHCH)

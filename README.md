#### UIS (User Interface System)
##### Plug-in to automate the transition between windows in the application. All that remains is to write the logic inside the interface windows themselves.
[Download Last Version UnityPackage](https://gitlab.com/ilnprj/interfacesystem/blob/release/UIS_v1.1.0.unitypackage)

##### Features:
- **WindowAgregator**:
  - Controls the display and sorting of WindowsAssets.
  - Supports 2 types of loading windows into memory (Resources.Load or Load from inspector's public values)
- **Base Class Window**:
  - Allows you to create on the basis of any other window.
- **ButtonTransition**: 
  - Sends id the desired window to the WindowAgregator.
- **Close**:
  - Automaticly add event "Close Window" to parent Window Button.
- **PanelsWindow**:
  - Modular extension for the Window component. You can enter the prefab of the panel or any other interface object in it. 
  - The general idea is that elements that are repeated in windows can be stored in a pool and transferred from one window to another.

##### Extensions:
- **Drag'n'Drop Module**:
  - Simle Drag Drop methods for UI components.
  - Ready system slots for drag drop.
- **Swipe Module**.
- **Animations for UI components**.
  - Position, Rotation, Transform, Scale and Alpha Animations. 


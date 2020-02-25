# Installing the package

> * Level: Beginner
>
> * Reading Time: 2 minutes
>
> * Checked with: Unity 2018.3.14f1

## Introduction

The package contains two distinct sub packages and these prefabs can be included in a [Unity] software project via the [Unity Package Manager].

### Interactors

The `Interactors/Interactions.Interactor` prefab provides a mechanism for determining when an interactable object has been touched and can have an action injected to determine when to send the _grab_ signal, which simply passes over this state to the interactable object being touched. Upon the interactable object receiving this state, it will execute the appropriate action such as following the interactor (to represent grabbing).

The `Interactors/Interactions.ActionPublisher` prefab provides a mechanism for sending action data from the interactor over to a `Interactors/Interactions.ActionReceiver` prefab in the form of boolean, float or vector2 actions. This can be useful for sending custom controller button data to be used within the interactable object.

### Interactables

The `Interactables/Interactions.Interactable` prefab provides a structure to determine a Unity GameObject as an interactable object within the spatial scene. It receives data from the appropriate interactor to inform the interactable when it is being touched or should be manipulated.

The `Interactors/Interactions.ActionReceiver` prefab provides a mechanism for receiving action data from the valid `Interactors/Interactions.ActionPublisher` prefab in the form of boolean, float or vector2 actions. This received data can then be tied specifically to an individual or multiple interactable objects to provide custom controls.

## Let's Start

### Step 1: Creating a Unity project

> You may skip this step if you already have a Unity project to import the package into.

* Create a new project in the Unity software version `2018.3.10f1` (or above) using `3D Template` or open an existing project.

### Step 2: Configuring the Unity project

* Ensure the project `Scripting Runtime Version` is set to `.NET 4.x Equivalent`:
  * In the Unity software select `Main Menu -> Edit -> Project Settings` to open the `Project Settings` inspector.
  * Select `Player` from the left hand menu in the `Project Settings` window.
  * In the `Player` settings panel expand `Other Settings`.
  * Ensure the `Scripting Runtime Version` is set to `.NET 4.x Equivalent`.

### Step 3: Adding the package to the Unity project manifest

* Navigate to the `Packages` directory of your project.
* Adjust the [project manifest file][Project-Manifest] `manifest.json` in a text editor.
  * Ensure `https://registry.npmjs.org/` is part of `scopedRegistries`.
    * Ensure `io.extendreality` is part of `scopes`.
  * Add `io.extendreality.tilia.interactions.interactables.unity` to `dependencies`, stating the latest version.

  A minimal example ends up looking like this. Please note that the version `X.Y.Z` stated here is to be replaced with [the latest released version][Latest-Release] which is currently [![Release][Version-Release]][Releases].
  ```json
  {
    "scopedRegistries": [
      {
        "name": "npmjs",
        "url": "https://registry.npmjs.org/",
        "scopes": [
          "io.extendreality"
        ]
      }
    ],
    "dependencies": {
      "io.extendreality.tilia.interactions.interactables.unity": "X.Y.Z",
      ...
    }
  }
  ```
* Switch back to the Unity software and wait for it to finish importing the added package.

### Done

The `Tilia Interactions Interactables Unity` package will now be available in your Unity project `Packages` directory ready for use in your project.

The package will now also show up in the Unity Package Manager UI. From then on the package can be updated by selecting the package in the Unity Package Manager and clicking on the `Update` button or using the version selection UI.

[Unity]: https://unity3d.com/
[Unity Package Manager]: https://docs.unity3d.com/Manual/upm-ui.html
[Project-Manifest]: https://docs.unity3d.com/Manual/upm-manifestPrj.html
[Version-Release]: https://img.shields.io/github/release/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity.svg
[Releases]: ../../releases
[Latest-Release]: ../../releases/latest
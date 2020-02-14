# Changelog

## [1.4.0](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.3.0...v1.4.0) (2020-02-14)

#### Features

* **HowToGuides:** add guide for passing float value ([e05913d](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/e05913d602529fbd47706ddd23acb7e859a794ce))
  > guide shows how to use Action Publisher and Action Receiver to pass float values.

## [1.3.0](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.2.0...v1.3.0) (2020-01-17)

#### Features

* **Interactables:** ability to convert GameObject to interactable ([ddb2831](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/ddb2831ea6dd5e2e9e9864de5f27ea387fb1628d))
  > The new Interactable Creator inspector panel provides a simple button for selecting a GameObject in the hierarchy and then clicking the button to wrap the GameObject within a newly created Interactable prefab.
* **Interactor:** ability to modify interactor settings dynamically ([7f733c7](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/7f733c7f9264d5a93944aab868a036adc67d8871))
  > The InteractorFacadeSettingsModifier provides a way of specifying setting modifiers for a collection of interactors and then apply the settings dynamically.
  > 
  > This can be used for updating the grab action on an interactor to be something different from the default based on the interactable being touched. For example, the default grab could be grip press but on touch of an interactable it could change the interactor grab action to be trigger press, and then on untouch resort to the original cached action.

#### Bug Fixes

* **Prefabs:** set interactor grab anchor position to 0,0,0 ([fcf422c](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/fcf422c6c030e0702d6a5e7fc1d3ee5e2e4fa108))
  > The Grab anchor on the interactor prefab had a z offset meaning it didn't grab to the point of collision when using precision grab.
  > 
  > It's best to default the grab anchor to 0,0,0 and let users override it if they want.

## [1.2.0](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.1.0...v1.2.0) (2020-01-15)

#### Features

* **HowToGuides:** adding documentation for using the interactables. ([a85611a](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/a85611ade49c01283a40ea14784ed0be41fc02a9))
  > Added documentation on how to use the interactables prefab.

## [1.1.0](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.0.0...v1.1.0) (2020-01-14)

#### Features

* **HowToGuides:** add guide for adding an interactor ([36e7d63](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/36e7d634207e9f247cc77e1021fedc901d6fc456))
  > adding initial guide for adding an interactor.

## 1.0.0 (2020-01-02)

#### Features

* **structure:** create initial prefab and user guides ([2643da3](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/2643da3ab277e9c3d08b6e85b5c57dcf83f1fb2f))
  > The structure of the repository has been created with all the required files for the package, the prefab and the documentation.

# Changelog

## [1.7.0](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.6.1...v1.7.0) (2020-04-14)

#### Features

* **Extraction:** update Extractors to use new Zinnia generic types ([b564002](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/b564002de8c40edb44fecbd24172f9024821dd90))
  > Zinnia version 1.15.0 has new generic Extractor types that offer a consistent Extractor API.
  > 
  > The Interactable and Interactor extractors have been updated so they extend these new generic types so they also offer a consistent API.
  > 
  > The InteractorExtractor has had the `ExtractAttachPoint` method deprecated in place of a new InteractorAttachPoint extractor, which does the same job but is responsible for this specific action.
  > 
  > The extractors have also been moved to a sub directory named: `Operation/Extraction` to follow the convention used in Zinnia.
  > 
  > Also, the proxy emitter has been moved to `Event/Proxy` to follow the same Zinnia convention.
  > 
  > The prefabs that used the old `ExtractAttachPoint` have been updated to now use the `InteractorAttachPoint` extractor and any 3rd party calling the `ExtractAttachPoint` method will get a log warning of the obsolete usage of this method.

### [1.6.1](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.6.0...v1.6.1) (2020-04-08)

#### Bug Fixes

* **Interactions:** fix spelling error on InteractableFacade editor ([7e29690](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/7e29690d93415099b7b5479c85f7190e16f1b67b))
  > There was a small spelling error on the custom InteractableFacade editor, which has now been corrected.

## [1.6.0](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.5.1...v1.6.0) (2020-04-07)

#### Features

* **Interactions:** add option to choose grab provider for interactable ([873d237](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/873d237abe7c40a72cb092f63adbe304ca6429f6))
  > The Interactable now has both the Stack and Set GrabProvider embedded within the prefab and an option on the InteractableFacade allows this GrabProvider to be changed at edit or runtime.

### [1.5.1](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.5.0...v1.5.1) (2020-04-03)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 1.14.0 to 1.14.1 ([dc37fab](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/dc37fabeadfe5fae0cbeb663b397a5d4c4947464))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 1.14.0 to 1.14.1. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v1.14.0...v1.14.1)
  > 
  > Signed-off-by: dependabot-preview[bot] <support@dependabot.com>

## [1.5.0](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.4.4...v1.5.0) (2020-03-09)

#### Features

* **HowToGuides:** add guide for orientation handles ([66f8112](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/66f811290b7fa645b8b55a6d63c3737d827b7da1))
  > added guide to show how to use orientation handles when grabbing an interactable.

### [1.4.4](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.4.3...v1.4.4) (2020-03-05)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 1.12.0 to 1.14.0 ([bf011e2](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/bf011e225afd0ec42baca384c0d332acee86f354))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 1.12.0 to 1.14.0. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v1.12.0...v1.14.0)
  > 
  > Signed-off-by: dependabot-preview[bot] <support@dependabot.com>

### [1.4.3](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.4.2...v1.4.3) (2020-02-25)

#### Bug Fixes

* **HowToGuides:** provide better grammatical sentences ([5e38dc7](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/5e38dc74e0b7b3cd965d73e9bb3a9f059e76358a))
  > A number of the guides have been slightly updated to provide better grammar in the sentences and one of the images has been fixed where the wrong event action box was highlighted.
* **HowToGuides:** provide correct package name in installation guide ([ab2ebb0](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/ab2ebb027ee413b45a23412d720c2b8feb292de6))
  > The package name at the bottom of the installation guide was incorrect and referenced the wrong package. This has now been updated to reflect the correct package name.

### [1.4.2](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.4.1...v1.4.2) (2020-02-24)

#### Bug Fixes

* **Interactions:** allow for multiple grab orientation handles ([814998e](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/814998eefc0b36e1bc676e53a6144a2e074a5b36))
  > There was an issue with the interactable when using multiple grab orientation handles as it was always set up by default to get the first GameObject relation, which meant when multiple orientation handles were required then the nested prefab logic would also need changing.
  > 
  > It's now possible to do all of the logic required in the event flow due to a new event on the GameObjectRelations component.
  > 
  > The new functionality is to attempt to match the Interactor GameObject as the key in the GameObjectRelations and if it's not found then the new event will simply attempt to look up the first relation as this is what happened previously.
* **Interactions:** instantiate a prefab instead of gameobject in helper ([0eeffc9](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/0eeffc9921179019aab049463a6003476eee9764))
  > The InteractableFacadeEditor helper now will instantiate a copy of the grab action prefab instead of an actual GameObject. This means that the Interactable prefab in the scene still contains nested prefabs which should auto update with any changes to the internal nested grab action prefab.

### [1.4.1](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.4.0...v1.4.1) (2020-02-24)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 1.11.0 to 1.12.0 ([5ae4a06](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/5ae4a0689eabeb91005a9c8511b77efad5f2aee7))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 1.11.0 to 1.12.0. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v1.11.0...v1.12.0)
  > 
  > Signed-off-by: dependabot-preview[bot] <support@dependabot.com>

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

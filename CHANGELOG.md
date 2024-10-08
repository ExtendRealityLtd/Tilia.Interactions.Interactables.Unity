# Changelog

### [2.18.1](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v2.18.0...v2.18.1) (2024-09-28)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 2.16.1 to 2.16.2 ([f41ef0d](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/f41ef0d1f10615d552f02988b0009014ebeb045b))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 2.16.1 to 2.16.2. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v2.16.1...v2.16.2)

## [2.18.0](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v2.17.2...v2.18.0) (2024-09-28)

#### Features

* **Facade:** allow multiple rules for disallowed touch/grab types ([7a4c1d8](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/7a4c1d8d49da502855a84b49f5b7af1549482cde))
  > The disallowed touch and grab interactors used to only work on a ListContainsRule and this was hard coded into the facade editor. This meant that no other rule could be replaced as it would throw an error due to the custom editor.
  > 
  > This feature introduces a new AnyRule at the heart of both the touch/grab disallowed logic with the first rule being the existing ListContainsRule, so all of the existing logic still works and that ListContainsRule must be at the zero index of the AnyRule list.
  > 
  > But now the AnyRule can also contain any other rule that is required to disallow touch or grab interactors.

### [2.17.2](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v2.17.1...v2.17.2) (2024-06-15)

#### Bug Fixes

* **Prefabs:** disallow collision consumers for invalid interactor ([d40583c](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/d40583c1bef17de117758daf853363f9e992009b))
  > The DisallowedGrabInteractors rule was causing an issue when using precision grab due to the collision consumer still being published for an invalid interactor which was causing the precision point container to be created for an invalid interactor. This meant that any other valid interactor was not becoming a precision point grab as the detached precision point for the invalid interactor still existed.
  > 
  > The solution is to modify the GrabReceiver prefab so it turns off the OutputActiveCollisionConsumer logic if the interactor is disallowed and then the precision point cannot be created prior to a grab event.

### [2.17.1](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v2.17.0...v2.17.1) (2024-05-11)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 2.16.0 to 2.16.1 ([eb92c11](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/eb92c115f609904ed957d9707b62cfa5213fd1bd))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 2.16.0 to 2.16.1. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v2.16.0...v2.16.1)

## [2.17.0](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v2.16.7...v2.17.0) (2024-05-11)

#### Features

* **Facade:** control rigidbody kinematic state from IsVisible ([e89ba29](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/e89ba299746954fc198fe6c4828c2ddd5127133e))
  > The IsVisible property also now controls the rigidbody kinematic state otherwise an invisible object will just fall through all other colliders in the scene.
  > 
  > A helper component of InteractableVisibilityStatusTag has also been added to the top level of the Interactable prefab that is enabled when the Interactable is visible and disabled when the Interactable is hidden.
  > 
  > This can be used in rules to ignore hidden Interactables if needed.

#### Bug Fixes

* **Editor:** disable custom inspector if ignore custom editor is set ([59bd286](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/59bd286655ccfc812b7357e6d09acf8bcf9d1a36))
  > If the ZINNIA_IGNORE_CUSTOM_INSPECTOR_EDITOR ifdef is set then the custom editor must also be disabled otherwise an error will occur.

### [2.16.7](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v2.16.6...v2.16.7) (2024-04-17)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 2.15.0 to 2.16.0 ([ae29f31](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/ae29f31edf4cee7735ec6ad305fdd706b9584cfa))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 2.15.0 to 2.16.0. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v2.15.0...v2.16.0)

### [2.16.6](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v2.16.5...v2.16.6) (2023-07-10)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 2.14.0 to 2.15.0 ([d8efc5f](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/d8efc5f33092d9ff7fb7006dfe3ed411821b24d6))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 2.14.0 to 2.15.0. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v2.14.0...v2.15.0)

### [2.16.5](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v2.16.4...v2.16.5) (2023-07-08)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 2.13.0 to 2.14.0 ([341c968](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/341c9684039ffbc134c2c9731a192970f0f76376))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 2.13.0 to 2.14.0. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v2.13.0...v2.14.0)

### [2.16.4](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v2.16.3...v2.16.4) (2023-07-05)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 2.12.1 to 2.13.0 ([b1b2eb4](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/b1b2eb4818d7f7eeb652ced31a20fdbf09597813))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 2.12.1 to 2.13.0. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v2.12.1...v2.13.0)

### [2.16.3](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v2.16.2...v2.16.3) (2023-06-06)

#### Bug Fixes

* **Grab:** prevent infinite loop in grab drop restrictor ([87450b5](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/87450b5c153fab699a643ccc75b067f0c18b8ff6))
  > When calling `DoEnableDrop` it would go into an infinite loop as the main method was being called rather than the sub method.

### [2.16.2](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v2.16.1...v2.16.2) (2023-05-06)

#### Bug Fixes

* **Interactors:** prevent grab on disabled game object ([7023269](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/7023269f8291194e39b9ed061f3005554ccfffb7))
  > The Grab method on the GrabInteractorConfigurator was able to be run even when the GameObject was disabled, which is not in keeping with Zinnia patterns. This has now been fixed.

### [2.16.1](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v2.16.0...v2.16.1) (2023-05-06)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 2.12.0 to 2.12.1 ([249193e](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/249193e548121ad8f548e6e65e8cbeef9737683f))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 2.12.0 to 2.12.1. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v2.12.0...v2.12.1)

## [2.16.0](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v2.15.1...v2.16.0) (2023-05-02)

#### Features

* **Editor:** add restriction options for scale action ([a983813](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/a9838134ad29da76bf86b1bfde1e85178b8f99ab))
  > The Scale action now has restrictions for scale axis and min/max scale values which are now present on the custom inspector window.

#### Bug Fixes

* **Interactables:** ensure reference properties are public ([86f092a](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/86f092a2d31bfa4955765da483837bf4ac4bdc70))
  > There is no point in having reference properties as protected as this just makes it harder to set these elements via code and they should be available to do so.

### [2.15.1](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v2.15.0...v2.15.1) (2023-05-02)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 2.11.0 to 2.12.0 ([63396e7](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/63396e74607d1322899162ecbadfe464e319b135))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 2.11.0 to 2.12.0. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v2.11.0...v2.12.0)

## [2.15.0](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v2.14.0...v2.15.0) (2023-04-23)

#### Features

* **prefabs:** add rules matcher for touched colliders ([ea05f16](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/ea05f16224044102dd6b5eaf905a9ef8d1019860))
  > A new Rules Matcher has been added that can be used to process the touched collider of the interactable in a similar way to how the grabbed collider matcher works. This makes it possible to know which collider has been touched on the interactable and do something with this information before the rest of the touch logic is run.
  > 
  > The touch (and now the grab) collider logic only runs if the interactor is not in the disallowed interactors list for the interaction type.

## [2.14.0](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v2.13.1...v2.14.0) (2023-04-16)

#### Features

* **Prefabs:** match rules to the grabbed interactable collider ([94425b7](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/94425b78235daa1e84f19bd2f0f03a41318becfa))
  > A new path has been added that when an interactable is grabbed, the specific collider on the interactable is emitted to a Rules Matcher so custom logic can be applied before the grab mechanics execute.

### [2.13.1](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v2.13.0...v2.13.1) (2023-04-16)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 2.10.0 to 2.11.0 ([15d1106](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/15d110672fc3b930a7ba2ed988456b6dc07fbae6))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 2.10.0 to 2.11.0. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v2.10.0...v2.11.0)

## [2.13.0](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v2.12.0...v2.13.0) (2023-04-16)

#### Features

* **Editor:** add embed interactable into gameobject option ([28bde5c](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/28bde5c1e9ccdd3f5531683c765c1ded57791ecf))
  > The InteractableCreatorEditorWindow now has an extra button that instead of nesting the selected GameObject inside an interactable prefab it will instead embed the newly created interactable prefab as a child of the selected GameObject.

## [2.12.0](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v2.11.8...v2.12.0) (2023-04-04)

#### Features

* **Resources:** add multiple render pipeline materials ([aec0fa2](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/aec0fa2b30a8027d30abd0cca776294565c4a8d3))
  > The prefab now uses the Pipeline Material Applier to provide multiple material types for the main render pipelines to improve compatibility.

### [2.11.8](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v2.11.7...v2.11.8) (2023-04-03)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 2.9.0 to 2.10.0 ([37bcdc0](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/37bcdc0ff064389ed49d6a20ae2fa0e573d1ab40))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 2.9.0 to 2.10.0. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v2.9.0...v2.10.0)

### [2.11.7](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v2.11.6...v2.11.7) (2023-03-28)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 2.8.0 to 2.9.0 ([8bed011](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/8bed011621ef19a55c6c5964b6f0ce6d0182e237))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 2.8.0 to 2.9.0. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v2.8.0...v2.9.0)

### [2.11.6](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v2.11.5...v2.11.6) (2023-03-22)

#### Bug Fixes

* **Configurator:** catch error on destroy nested prefabs ([eb42364](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/eb423642736fe1b4f4ee9a1188908526dd382b1f))
  > Older versions of Unity cannot destroy a nested prefab, so as the Controllables for example nest the Interactable prefab, if the Interactable prefab is attempted to change the grab action then this tries to delete the nested grab action but will raise an InvalidOperationException because this nested prefab cannot be deleted.
  > 
  > The fix for this is to just disable the hard wired prefab and then create a new temporary prefab that can be continually updated.

### [2.11.5](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v2.11.4...v2.11.5) (2023-03-21)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 2.7.2 to 2.8.0 ([268c641](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/268c641478414bccd3881ddb928ce82639d81271))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 2.7.2 to 2.8.0. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v2.7.2...v2.8.0)

### [2.11.4](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v2.11.3...v2.11.4) (2023-03-18)

#### Bug Fixes

* **Grab:** remove hard requirement for rigidbody ([a615465](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/a6154652e4be193fb32fe2a949b501e2331aa9e8))
  > There is no definitive requirement for a rigidbody on an Interactable but the previous changes that prepared rigidbody for kinematic changes has meant that a Rigidbody is required to set up the state to prepare for any kinematic change.
  > 
  > This fix just makes sure these state preparations are only done if a rigidbody is provided, so it no longer needs a rigidbody if not required.

### [2.11.3](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v2.11.2...v2.11.3) (2023-03-16)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 2.7.1 to 2.7.2 ([57242db](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/57242db6f7155d15c98aceb5e93c70474eb9956c))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 2.7.1 to 2.7.2. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v2.7.1...v2.7.2)

### [2.11.2](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v2.11.1...v2.11.2) (2023-03-13)

#### Bug Fixes

* **Prefabs:** reset default mesh collider scale to 1,1,1 ([e146052](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/e146052bfd581e6b35e5d4baca4df610423729b9))
  > The collider scale on the interactable default mesh was set to 2,2,2 which meant the collider was twice as big as the mesh.
  > 
  > This has now been fixed.

### [2.11.1](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v2.11.0...v2.11.1) (2023-03-13)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 2.7.0 to 2.7.1 ([64e22ce](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/64e22cea8b22c385b2a558ad82604b29263c3fe9))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 2.7.0 to 2.7.1. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v2.7.0...v2.7.1)

## [2.11.0](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v2.10.1...v2.11.0) (2023-03-11)

#### Features

* **Editor:** add inspector options for control direction ([e73ea3b](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/e73ea3b26e2ccca8a33f9d7a613b3d27702adfdf))
  > The Interactable inspector now draws additional options if the Control Direction action is selected.
* **Grab:** add option to attempt swap grab options ([4b89b6c](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/4b89b6c54b6ff4736a896da26690ed7ac3c991ef))
  > A new option that provides the ability to attempt to swap the secondary grab action to the primary grab action when the secondary grab is still active when the primary action ungrabs.
  > 
  > This also fixes an issue where using Primary:Follow and Secondary:ControlDirection causes the rotation upon release of the secondary interactor to not stay in the correct rotation when precision grab is used because the precision grab container rotation wasn't being updated with the control direction pivot.

### [2.10.1](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v2.10.0...v2.10.1) (2023-03-11)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 2.6.0 to 2.7.0 ([975c8ed](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/975c8ed8fdd788981a72059fd7195d74bc3371dc))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 2.6.0 to 2.7.0. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v2.6.0...v2.7.0)

## [2.10.0](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v2.9.3...v2.10.0) (2023-02-26)

#### Features

* **Interactions:** add IsVisible property to interactable ([a77cb65](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/a77cb6595e210f55f90077a11bf16367073df5e2))
  > The IsVisible property on the getter will return whether the interactable object is in its `visible` state which is the renderers are active and the colliders working.
  > 
  > When the IsVisible property is set to `false` then all of the renderers are disabled and all of the colliders are set to trigger colliders to mimmic the GameObject becoming invisible but still active within the scene.

### [2.9.3](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v2.9.2...v2.9.3) (2023-02-22)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 2.5.0 to 2.6.0 ([b51a4f5](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/b51a4f5a0cc0bc77d7ff140afcf4a3517bb5fb1b))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 2.5.0 to 2.6.0. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v2.5.0...v2.6.0)

### [2.9.2](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v2.9.1...v2.9.2) (2023-02-19)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 2.4.0 to 2.5.0 ([2acc1c7](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/2acc1c7864a7b3e1acb3b2b4cb72caafcc983419))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 2.4.0 to 2.5.0. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v2.4.0...v2.5.0)

### [2.9.1](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v2.9.0...v2.9.1) (2023-02-16)

#### Bug Fixes

* **Editor:** replace missing icon in newer unity versions ([3aa147a](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/3aa147a23706c56c5c211ef5126ea702e6ea545c))
  > The icon was available in Unity 2018 but does not seem to be available in 2022 so it has been replaced with something that is similar and seems to be available in all current versions.

## [2.9.0](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v2.8.2...v2.9.0) (2023-02-16)

#### Features

* **Editor:** add sub options for action types ([ce452a5](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/ce452a521b96f545a4b0677378760fb284ccd55a))
  > A new sub option has been added for the `None` action and the `Scale` action that bubbles up useful internal settings.
  > 
  > The primary/secondary action drop downs also now have a button next to them that pings the action gameobject within the interactable hierarchy to make it easier to navigate to.
  > 
  > Also, the entire editor script has been refactored to make it tidier and more concise to read.

### [2.8.2](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v2.8.1...v2.8.2) (2023-02-15)

#### Bug Fixes

* **InteractableConfigurator:** set action instantiation correctly ([510184a](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/510184a5eeff27f60dd86c6ac8ddeac67ce97b5e))
  > There was an issue when instantiating a new action it was not possible to update the position, rotation or scale of any child object in the action GameObject. This has now been fixed by making the action object match the world orientation/scale of the interactable facade so when it is childed it resets to the correct zero origin.
  > 
  > The Instantiate method is also always called if the app is playing and not the PrefabUtility method as this is only now used at edit time in the editor.

### [2.8.1](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v2.8.0...v2.8.1) (2023-02-15)

#### Bug Fixes

* **InteractableConfigurator:** reset instantiated action orientation ([70c43da](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/70c43dab6cfcfa78c0afaa49a22a1d7efa7f97eb))
  > When the interactable action is instantiated it was not having the position, rotation and scale reset so if the original converted object was not at the zero orientation then the action was being offset.
  > 
  > This fix ensures the position, rotation and scale is reset to the identity when the action is childed to the interactable.

## [2.8.0](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v2.7.1...v2.8.0) (2023-02-13)

#### Features

* **Editor:** add button to link to selected follow tracking container ([0729640](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/0729640a5f408eb8c049d7e9a383764a32c420d0))
  > The new Show Follow Tracking Container button will ping the GameObject in the Interactable hierarchy that contains the currently selected follow tracking logic, making it easier to traverse to the logic to customise settings further.
* **Utility:** add streamline way to generate interactables via code ([51c6025](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/51c602527913b0bb8e5861f3ed6749b5994fff9e))
  > The new InteractableCreator prefab makes it much easier to create an Interactable Object via code by simply calling the `Convert` method passing in the GameObject to convert (and wrap) to an Interactable.
  > 
  > The core generation code has now been moved into a factory that the Interactable Creator Editor Window now also uses. The ability to set the primary and secondary actions has also been moved to the InteractableConfigurator as it already holds all of the relevant prefab references to be able to set an action.

### [2.7.1](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v2.7.0...v2.7.1) (2023-02-08)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 2.3.0 to 2.4.0 ([154cd52](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/154cd52dca59039e07921bdbcd77a6948a2aa894))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 2.3.0 to 2.4.0. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v2.3.0...v2.4.0)

## [2.7.0](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v2.6.1...v2.7.0) (2022-07-05)

#### Features

* **Action:** add property for precision collision point ([565e786](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/565e786b6c22411188f96c0c3991316e06b79c3a))
  > The GrabInteractableFollowAction now has a property that allows the retrieval of the current precision grab collision point GameObject in case this runtime generated object is required for any reason.
* **Action:** provide rule based orientation handle option ([0704996](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/070499640f1904f1e8e89f4f43a3865b4faa9297))
  > The GrabInteractableFollowAction and the GrabAction.Follow prefab have now been updated to also allow for the orientation handle to be set via a rule.
  > 
  > This makes it possible to determine orientation handles by a rule at runtime, so an interactable can be instantiated and does not need any custom code to hook up the GameObject Relation.

#### Bug Fixes

* **GrabActions:** rotate around angular velocity in target space ([13c343c](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/13c343c8df1a41631e5027c5880dbfbf4231a95a))
  > The Rotate Around Angular Velocity component now has the In Target Space option checked so it operates in local space fo the target.
  > 
  > This enables any Interactable using the Follow action set to Follow Rotate Around Angular Velocity to be able to rotate correctly even if the object is rotated in the world space.

### [2.6.1](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v2.6.0...v2.6.1) (2022-06-25)

#### Bug Fixes

* **Interactor:** prevent double touch on force grab ([0f7e32e](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/0f7e32ed4e3074ca35c6ea4502ff14bb89b78f9a))
  > When the Interactor Force `Grab()` method was being called it would first do a simulate touch (to ensure the events were in the right order). Then it would do the grab, which would make the interactable physically touch the interactor, which would call the touch logic again, therefore breaking the untouch logic and meaning the untouched event would not fire as it thought it was still being touched with the second touch that had happened.
  > 
  > This fix resolves that by when a simulate touch occurs, the Interactor then turns off the Interactable CollisionNotifier for a fixed update frame so the second touch cannot occur after the simulated touch.

## [2.6.0](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v2.5.1...v2.6.0) (2022-06-16)

#### Features

* **ActionReceiver:** add notify events when receiver is received ([6f9ce20](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/6f9ce20f753dd48357b33fed8187028cae58ee64))
  > The ActionReceiver now has a notify activated and deactivated when a publisher activates or deactivates a receiver.
* **Editor:** use string constants for labels ([ed571f1](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/ed571f1a07fc5c72783a8a6288f08ff4ffe9a5af))
  > The Interactable Creator Editor Window now uses string constants for labels rather than inline strings.

### [2.5.1](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v2.5.0...v2.5.1) (2022-06-16)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 2.2.0 to 2.3.0 ([4e71548](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/4e71548947ac582543e49278a88b4c15c010f0bd))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 2.2.0 to 2.3.0. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v2.2.0...v2.3.0)

## [2.5.0](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v2.4.1...v2.5.0) (2022-05-28)

#### Features

* **Action:** allow null grab action to force grab/ungrab events ([3ca710e](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/3ca710e888e5fa330f42a6420b1ef0e65d9c9214))
  > The GrabInteractableNullAction did not emit any events when the grab or ungrab action occurred, which was technically correct because nothing has happened, but there may be occasions where you'd want the events to occur. This change allows the null action to be set to force the events if required, but by default it still doesn't force the events so no breaking changes will occur.

### [2.4.1](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v2.4.0...v2.4.1) (2022-05-20)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 2.1.0 to 2.2.0 ([56299e7](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/56299e71c4b91ddbb527ab2c281d322c9fdfffab))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 2.1.0 to 2.2.0. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v2.1.0...v2.2.0)

## [2.4.0](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v2.3.0...v2.4.0) (2022-05-16)

#### Features

* **ActionPublisher:** remove need for string identifier ([26e2a6a](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/26e2a6a181932b518063df0503319a2788302be4))
  > The ActionPublisher no longer needs a string for the publisher identifier as this was just being used intenally in the rules. But this has now been replaced with a List Contains Rule and it just uses the actual ActionPublishers that are linked onto the ActionReceiver to make the internal rule work.
  > 
  > The FirstTouched logic was also broken so that has been fixed as part of this commit.
* **Editor:** move velocity multipler settings into foldout ([4b8ed8f](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/4b8ed8fbff1a4c853575eeee188161e5ac262e87))
  > The Velocity Multiplier settings are now in a foldout just above the Advanced Follow settings as it's a bit neater to just show them when necessary as they are somewhat optional.

## [2.3.0](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v2.2.0...v2.3.0) (2022-05-13)

#### Features

* **Interactions:** multiply velocity on interactor and interactable ([e9bcff3](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/e9bcff381c3afe2e5f44a5db683c5d0a9ac578be))
  > The Interactor and Interactable now has a VelocityMultiplier on them so the throw velocity can be multiplied on either the Interactor or the Interactable (or both).
  > 
  > The Interactable Editor has also been tidied up a bit with some horizontal lines added and a bit more indentation to make it easier to follow the flow of data.
  > 
  > A number of enum properties have also had set methods added for them as well.

## [2.2.0](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v2.1.1...v2.2.0) (2022-05-09)

#### Features

* **prefabs:** add selection base component to facade ([5aaebd9](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/5aaebd9e4e698ce68b66e902e66e2670de162e93))
  > The new Zinnia BaseGameObjectSelector when added to a GameObject will cause the GameObject to be selected when the mesh is clicked in the Unity scene view. This has been added to the facade to ensure the facade is selected when the mesh is clicked.

### [2.1.1](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v2.1.0...v2.1.1) (2022-05-09)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 2.0.0 to 2.1.0 ([e703969](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/e703969dbd808ec7fc82c36c60e2b06b80a47e1c))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 2.0.0 to 2.1.0. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v2.0.0...v2.1.0)

## [2.1.0](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v2.0.1...v2.1.0) (2022-05-05)

#### Features

* **Grab:** emit event when kinematic state will change ([e7e7bbe](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/e7e7bbea6e7026e5216c5bbd032ddb60a4bcd073))
  > Due to the changes in PhysX, the change of a Rigidbody kinematic state will cause the collider to call the exit, then enter events even though the collider has not stopped intersecting.
  > 
  > This was fixed in the Zinnia Collision Tracker and in turn the Interactable and Interactor connection, but anywhere else that relies on the interactable kinematic state will not have a clear point to know when this happens.
  > 
  > So a new event has been added to the GrabInteractableConfigurator that emits the rigidbody that the kinematic state is about to change on.
  > 
  > Other dependents can now listen to this event to prepare any colliding rigidbody for the impending exit/enter.
  > 
  > The GrabInteractableFollowAction emits this event when it changes the kinematic state upon grab and ungrab.
  > 
  > The InteractableGrabStateRegistrar has also been updated to have two new events that are connected to the kinematic state change on grab and on ungrab, so they can be listened to when the grab or ungrab occurs so any rigidbody can be prepared accordingly.

### [2.0.1](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v2.0.0...v2.0.1) (2022-04-28)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 1.47.1 to 2.0.0 ([e65b689](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/e65b68917f8d4da973a4cdd2397b4932512963d2))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 1.47.1 to 2.0.0. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v1.47.1...v2.0.0)

## [2.0.0](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.24.2...v2.0.0) (2022-04-28)

#### :warning: BREAKING CHANGES :warning:

* **Malimbe:** This removes the last remaining elements of Malimbe and whilst it does not cause any breaking changes within this package, it removes Malimbe as a dependency which other projects that rely on this package may piggy back off this Malimbe dependency so it will break any project like that.

All of the previous functionality from Malimbe has been replicated in standard code without the need for it to be weaved by the Malimbe helper tags. ([b6d0240](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/b6d0240d1980421ed7b11c3c3adc84a232de7a17))

#### Features

* **Malimbe:** remove malimbe dependency ([b6d0240](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/b6d0240d1980421ed7b11c3c3adc84a232de7a17))

### [1.24.2](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.24.1...v1.24.2) (2022-03-15)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 1.47.0 to 1.47.1 ([9356fd2](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/9356fd20653e4dfe3b598720265ebfa2757dc095))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 1.47.0 to 1.47.1. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v1.47.0...v1.47.1)

### [1.24.1](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.24.0...v1.24.1) (2022-03-15)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 1.46.0 to 1.47.0 ([339c503](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/339c503e4956c12584e7f778011c82ccc7832640))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 1.46.0 to 1.47.0. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v1.46.0...v1.47.0)

## [1.24.0](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.23.0...v1.24.0) (2022-03-03)

#### Features

* **Grab:** add interactable drop restrictor ([1eeef73](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/1eeef73264065c4f4a31e1cf7b92aa2d2c66a893))
  > The InteractableGrabDropRestrictor component makes it possible to disable dropping an interactable once it is grabbed.

## [1.23.0](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.22.9...v1.23.0) (2022-03-02)

#### Features

* **package.json:** add information urls to package ([c3d2b6c](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/c3d2b6c9e1879f151920cae360e5794285e352a2))
  > The changelog, documentation and license url has been added to the package.json as these are used within the Unity package manager.

### [1.22.9](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.22.8...v1.22.9) (2022-02-14)

#### Bug Fixes

* **Touching:** only call touch consumers if touch has changed ([e4b5666](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/e4b5666c682fbb6dad952930369f15abfc6e76e6))
  > The Slicer component now provides a mechanism to determine if the sliced list contents have changed so this makes it more efficient when needing to call the interactable collision consumers.
  > 
  > Previously, they were being called every OnStay even if the current touched object hadn't changed and this was very inefficeint and could lead to a drop in framerate if touching many objects.

### [1.22.8](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.22.7...v1.22.8) (2022-02-14)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 1.45.0 to 1.46.0 ([4f797d1](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/4f797d1be2c82cf7bb1e588594109c2c64e05cd0))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 1.45.0 to 1.46.0. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v1.45.0...v1.46.0)

### [1.22.7](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.22.6...v1.22.7) (2022-02-05)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 1.44.0 to 1.45.0 ([d4173ff](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/d4173fff33293626a30455dbf2414e6bef86d007))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 1.44.0 to 1.45.0. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v1.44.0...v1.45.0)

### [1.22.6](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.22.5...v1.22.6) (2022-01-17)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 1.43.0 to 1.44.0 ([c6deac5](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/c6deac5f0661d173bac40710c876b02f2295330d))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 1.43.0 to 1.44.0. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v1.43.0...v1.44.0)

### [1.22.5](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.22.4...v1.22.5) (2022-01-13)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 1.42.0 to 1.43.0 ([7372648](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/73726487408df014630c473f5afffef5c9d5b178))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 1.42.0 to 1.43.0. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v1.42.0...v1.43.0)

### [1.22.4](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.22.3...v1.22.4) (2022-01-13)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 1.41.0 to 1.42.0 ([35e2160](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/35e21600311bdc23ae1c86f3ec84bfca4e7115d6))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 1.41.0 to 1.42.0. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v1.41.0...v1.42.0)

### [1.22.3](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.22.2...v1.22.3) (2022-01-12)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 1.40.0 to 1.41.0 ([3ab2e60](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/3ab2e60173444c23bf7d129567d4daf0a4b2052d))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 1.40.0 to 1.41.0. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v1.40.0...v1.41.0)

### [1.22.2](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.22.1...v1.22.2) (2022-01-03)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 1.39.0 to 1.40.0 ([fa95992](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/fa95992941dd3c23e8759e263ebf885e67426892))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 1.39.0 to 1.40.0. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v1.39.0...v1.40.0)

### [1.22.1](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.22.0...v1.22.1) (2021-12-03)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 1.38.1 to 1.39.0 ([fb8f6ab](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/fb8f6ab423a1bdfaed75bc0ecc3114d95f427cc4))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 1.38.1 to 1.39.0. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v1.38.1...v1.39.0)

## [1.22.0](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.21.1...v1.22.0) (2021-07-23)

#### Features

* **Extraction:** add interactor facade extractor ([06e9701](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/06e97010d7c0ea95acb2b39e639b8a4b240c71df))
  > The InteractorFacadeExtractor component will extract an InteractorFacade component from the given GameObject and can also search for the InteractorFacade component on ancestor or descendant GameObejcts.
* **Interactables:** implement interactable grabber ([c9fb3c8](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/c9fb3c8f0f89482d5f0a10b29d19c05cd847d967))
  > The InteractableGrabber component actually existed in the PointerInteractors package but it is far more general purpose than just being used for pointer interactions. So the component has been included in this repo where it can serve a wider use and it can then be used to supersede the one in the PointerInteractors package.

### [1.21.1](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.21.0...v1.21.1) (2021-07-21)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 1.38.0 to 1.38.1 ([18befa6](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/18befa679786f2b01df0fd9c17222a69960b0fab))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 1.38.0 to 1.38.1. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v1.38.0...v1.38.1)

## [1.21.0](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.20.2...v1.21.0) (2021-07-19)

#### Features

* **Action:** provide pivot offset from target offset first found child ([eefc409](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/eefc4090afbb7cd3d25edd48d4acbac8ceae5b6d))
  > The DirectionModifier now supports a PivotOffset which is now set by the first child GameObject found within the TargetOffset GameObject.

### [1.20.2](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.20.1...v1.20.2) (2021-07-19)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 1.37.0 to 1.38.0 ([c5fef15](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/c5fef15b22cf299a5902f517e010c991c84abce1))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 1.37.0 to 1.38.0. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v1.37.0...v1.38.0)

### [1.20.1](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.20.0...v1.20.1) (2021-06-24)

#### Bug Fixes

* **Interactor:** make touch before force grab optional ([243bdf1](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/243bdf19ee55e2f24750992214215acee8663ec6))
  > There is an issue with the newly added touch before force grab where it may not always be desirable to have that functionality and as the functionality has changed then it should be an option so it can be disabled and provide the original functionality if need be.

## [1.20.0](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.19.4...v1.20.0) (2021-06-24)

#### Features

* **Interactor:** add ability to simulate a touch with no collision ([ee83176](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/ee83176cd5134b94f569dcd39e7987442e941ffd))
  > The new SimulateTouch and SimulateUntouch method on the InteractorFacade allow for the Interactor to effectively touch an Interactable without needing to physically collide with it in the spatial world.
  > 
  > The Grab() method has also been updated so it uses this SimulateTouch before grabbing so all of the correct events are triggered.

### [1.19.4](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.19.3...v1.19.4) (2021-06-24)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 1.36.2 to 1.37.0 ([c4e89e9](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/c4e89e9e70856dda135b08ab4f20fd42f104ab88))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 1.36.2 to 1.37.0. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v1.36.2...v1.37.0)

### [1.19.3](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.19.2...v1.19.3) (2021-06-19)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 1.36.1 to 1.36.2 ([2f6e12a](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/2f6e12abbe1dc1c6572e9b73093f8ca1b06fbf65))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 1.36.1 to 1.36.2. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v1.36.1...v1.36.2)

### [1.19.2](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.19.1...v1.19.2) (2021-06-10)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 1.36.0 to 1.36.1 ([082b6fe](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/082b6fe150fa6bae58c64d5298f5d44de378e025))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 1.36.0 to 1.36.1. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v1.36.0...v1.36.1)

### [1.19.1](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.19.0...v1.19.1) (2021-05-31)

#### Bug Fixes

* **Documentation:** add missing auto generated API docs ([c524efd](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/c524efdc3f942231eb369fd749b093691556a559))
  > The API docs had not been updated to the latest to match the code, this has been fixed by auto generating the new docs.

## [1.19.0](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.18.0...v1.19.0) (2021-05-14)

#### Features

* **Rule:** add rules for interactor touch and grab state ([26700d9](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/26700d9b1f26e968a2c6bb4b81ecede804eec6db))
  > The new rules will be able to determine if a given GameObject has an InteractorFacade on it and if it does then whether the given Interactor is either currently touching or grabbing something.

#### Miscellaneous Chores

* **README.md:** update title logo to related-media repo ([f3556b4](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/f3556b439b19549b960eb2415c12eca8071ab193))
  > The title logo is now located on the related-media repo.

## [1.18.0](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.17.2...v1.18.0) (2021-05-10)

#### Features

* **Interactors:** add ability to ignore colliders based on tag ([3f4938e](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/3f4938e9b2e4de60bd1260d735320213b95609cf))
  > A recent update to the Collision Tracker means it is now possible to ignore specific colliders based on a rule. This is now being used in the Interactor to ignore any collider with the IgnoreInteractorOnColliderTag component on it. This can now be added to any collider on an interactable to make the interactor ignore the collider on the interactable.
  > 
  > This can be useful for example to ignore the blade of a sword so it can only be grabbed by the handle.

### [1.17.2](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.17.1...v1.17.2) (2021-05-09)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 1.35.0 to 1.36.0 ([8dcfe86](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/8dcfe86663e84097d307a179640bd4913bfae520))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 1.35.0 to 1.36.0. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v1.35.0...v1.36.0)
  > 
  > Signed-off-by: dependabot[bot] <support@github.com>

### [1.17.1](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.17.0...v1.17.1) (2021-05-03)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 1.34.1 to 1.35.0 ([60dcb4f](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/60dcb4fad5bf286316cb95e2cbdd8fbbe11f0c50))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 1.34.1 to 1.35.0. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v1.34.1...v1.35.0)
  > 
  > Signed-off-by: dependabot[bot] <support@github.com>

## [1.17.0](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.16.2...v1.17.0) (2021-04-07)

#### Features

* **Utility:** add prefab creator ([15bee59](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/15bee59e6908025b1d874e5eb87b33bdb7c4e774))
  > The latest version of Zinnia has the basis of a prefab creator that can be used to enable easy adding of prefabs to a scene without needing to drag and drop from directories. Instead a new menu item is added for quickly adding prefabs. The guide has been updated to accommodate this and the FodyWeavers.xml is now located in the root to serve both the Runtime and Editor scripts.

### [1.16.2](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.16.1...v1.16.2) (2021-04-01)

#### Bug Fixes

* **Proxy:** prevent null exception in event proxies ([6577a60](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/6577a60a3b8deb3bc3e6c34e2f068a1c11fefef8))
  > There was an issue where an event proxy could be called but the Payload was null causing a null exception to occur. This has now been guarded against.

### [1.16.1](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.16.0...v1.16.1) (2021-03-29)

#### Bug Fixes

* **API:** add missing API documentation ([74d3998](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/74d3998e1b1a41e11617cda97d93f8f0d5052704))
  > The API documentation wasn't auto generated for the last set of changes so this documentation has now been auto generated and added.

## [1.16.0](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.15.11...v1.16.0) (2021-03-29)

#### Features

* **prefabs:** update ControlDirection to implement follow TargetOffset ([95ed5dd](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/95ed5ddc56787e8b3fbfbf0fdb9813c1bc725bf9))
  > The latest version of the DirectionModifier now allows for a TargetOffset to be provided, which can be provided from any Follow action as they also consider a TargetOffset. The first found TargetOffset of a complimentary follow action on an interactable will be used as the TargetOffset on the ControlDirection Directionmodifier.

### [1.15.11](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.15.10...v1.15.11) (2021-03-29)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 1.31.1 to 1.33.0 ([065970b](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/065970b96bf68eedcb5999db4a52f32ae4a1912c))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 1.31.1 to 1.33.0. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v1.31.1...v1.33.0)
  > 
  > Signed-off-by: dependabot[bot] <support@github.com>

### [1.15.10](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.15.9...v1.15.10) (2021-03-04)

#### Bug Fixes

* **Interactions:** prepare kinematic state changes on collision tracker ([fb69869](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/fb698694d096aa5971d626955268d7eb1b5ec992))
  > The CollisionTracker on the Interactor is now pre-warned of kinematic state changes of any trigger collider that the Interactor is touching and this then works inline with the new CollisionTracker changes that allow the TriggerExit/Enter to be ignored in Unity 2019.3 and above when kinematic changes are made to a rigidbody.
  > 
  > This is to ensure the changes introduced by Unity 2019.3 do not break the events on the Interactable because now changing the kinematic state on a Rigidbody will now cause a collsiion exit and collision enter to occur, even though the colliding objects have not stopped colliding. This is due to a change in the PhysX 4.11 system and Unity did not counter this change and introduced a non-documented breaking change.

### [1.15.9](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.15.8...v1.15.9) (2021-03-03)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 1.31.0 to 1.31.1 ([7d95950](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/7d959506871a7712cf9788dc6be26d032d0b8389))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 1.31.0 to 1.31.1. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v1.31.0...v1.31.1)
  > 
  > Signed-off-by: dependabot[bot] <support@github.com>

### [1.15.8](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.15.7...v1.15.8) (2021-02-27)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 1.30.0 to 1.31.0 ([e7b8762](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/e7b87621bbdb01b1a4a819e8e72d668b466c47bf))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 1.30.0 to 1.31.0. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v1.30.0...v1.31.0)
  > 
  > Signed-off-by: dependabot[bot] <support@github.com>

### [1.15.7](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.15.6...v1.15.7) (2021-02-04)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 1.29.0 to 1.30.0 ([bb0eea6](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/bb0eea6ebe0c141e1e0127fa75a03e3c0aebe9fc))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 1.29.0 to 1.30.0. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v1.29.0...v1.30.0)
  > 
  > Signed-off-by: dependabot-preview[bot] <support@dependabot.com>

### [1.15.6](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.15.5...v1.15.6) (2021-01-07)

#### Bug Fixes

* **Interactions:** remove erroneous xml doc from editor ([837efd7](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/837efd7d49a42c0f59d30c2adca3198fcdb19471))
  > The InteractableFacadeEditor had an empty XML doc at the top of the class which isn't needed.

### [1.15.5](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.15.4...v1.15.5) (2021-01-07)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 1.28.1 to 1.29.0 ([3182c1b](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/3182c1bbc45484d0db849c8dd91b2732bbdb77dc))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 1.28.1 to 1.29.0. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v1.28.1...v1.29.0)
  > 
  > Signed-off-by: dependabot-preview[bot] <support@dependabot.com>

### [1.15.4](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.15.3...v1.15.4) (2021-01-04)

#### Bug Fixes

* **Interactions:** use VelocityTracker on Interactor ([c73e8d5](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/c73e8d5fe8eec7a2cbff9304834378c62a7d119a))
  > The Interactor would require a VelocityTrackerProcessor but this limited the usage and as it just extends the VelocityTracker then it makes sense for the Interactor to just take a VelocityTracker and this shouldn't break any prefab links either.

### [1.15.3](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.15.2...v1.15.3) (2020-12-26)

#### Bug Fixes

* **Interactions:** add interactor example avatar to IgnoreRaycast layer ([1ec9766](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/1ec9766327f549de22f7f7ca330d3ddf49a6ccca))
  > The ExampleAvatar included in the Interactor is now on the IgnoreRaycast layer to prevent any pointers following the interactor from clipping with the avatar and terminating the pointer RayCast too early.
* **Interactions:** prevent attach point with precision grab ([12c991a](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/12c991acb330e815ba79c8e4112bf69308d51b3e))
  > The Grab Attach Point on the Interactor is no longer used when an Interactable is set to precision grab because if the Grab Attach Point has a Transform offset then it means the precision grab is offset too.
  > 
  > Instead, a new Precision Attach Point has been added to the Interactor that has a Vector3.zero position so this is used as the follow Source for precision grab so the offset is always zero.
  > 
  > It is still possible to offset this new Precision Attach Point if required, but the effects will be the precision grab is also offset.

### [1.15.2](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.15.1...v1.15.2) (2020-12-21)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 1.28.0 to 1.28.1 ([ff3e3b8](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/ff3e3b82551227a7879d1fd1082d15ead83370ff))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 1.28.0 to 1.28.1. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v1.28.0...v1.28.1)
  > 
  > Signed-off-by: dependabot-preview[bot] <support@dependabot.com>

### [1.15.1](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.15.0...v1.15.1) (2020-12-17)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 1.27.0 to 1.28.0 ([844170f](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/844170fbd4c788ca5993722d02fdf3a388dc10ad))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 1.27.0 to 1.28.0. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v1.27.0...v1.28.0)
  > 
  > Signed-off-by: dependabot-preview[bot] <support@dependabot.com>

## [1.15.0](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.14.4...v1.15.0) (2020-12-13)

#### Features

* **Interactions:** add ability to choose valid interaction types ([941fa68](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/941fa68c311966ecec57f14271ab6747bf37208c))
  > The new ValidInteractionTypes enum property makes it possible to pre-determine what interaction types the Interactable will respond to.
  > 
  > Note: A grab can still occur if the Interactable does not respond to a touch because the touch on the Interactor side is still valid. This is useful for disabling touch events but still wanting to grab.
  > 
  > An UngrabAll method has been added too that is just a shortcut to `Ungrab(0)` for easier understanding in the facade.
* **Interactions:** deprecate end of frame methods ([ac2c59f](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/ac2c59f0dd0b33b6dfada5c312fee5e756c954e8))
  > The InteractableFacade EndOfFrame methods have now all been deprecated as the WaitForEndOfFrameYieldEmitter component should be used if a method needs calling at the end of a frame.

### [1.14.4](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.14.3...v1.14.4) (2020-12-12)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 1.25.1 to 1.27.0 ([74a2a85](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/74a2a857914eab94c3753fd173d0a12fdc8b02fe))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 1.25.1 to 1.27.0. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v1.25.1...v1.27.0)
  > 
  > Signed-off-by: dependabot-preview[bot] <support@dependabot.com>

### [1.14.3](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.14.2...v1.14.3) (2020-12-11)

#### Bug Fixes

* **HowToGuides:** apply document styling guidelines ([63763a9](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/63763a9d7db7db642ebd947ca4fb578235a4144e))
  > The document style guidelines have been updated and now have been applied to the guides in this repo.

### [1.14.2](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.14.1...v1.14.2) (2020-11-21)

#### Bug Fixes

* **Interactions:** add missing API documentation ([978af58](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/978af5895de55c1c24bd5c61629908a1dc2c4d8f))
  > The API had changed but the documentation hadn't been auto generated so this commit just adds in the auto generated documentation.

### [1.14.1](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.14.0...v1.14.1) (2020-11-01)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 1.25.0 to 1.25.1 ([4ee896b](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/4ee896bc5e9d3b59ecaed0a43179f284781c2d15))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 1.25.0 to 1.25.1. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v1.25.0...v1.25.1)
  > 
  > Signed-off-by: dependabot-preview[bot] <support@dependabot.com>

## [1.14.0](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.13.4...v1.14.0) (2020-11-01)

#### Features

* **Interactions:** allow follow as standard secondary action ([d7d2b7e](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/d7d2b7e1aa48dd6b67900bd2524425bd8189c005))
  > The secondary action can now also be set to follow, which allows the primary action to be set to none so the primary action does nothing whereas the secondary action will then grab the item to mimic two hand grabbing.
  > 
  > The None action now has its own null action rather than just using the base action so it can be easily identified as a nothing action.

### [1.13.4](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.13.3...v1.13.4) (2020-10-02)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 1.24.0 to 1.25.0 ([28c578e](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/28c578eb50d15807aa4440c0e83c8e74ff50ba31))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 1.24.0 to 1.25.0. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v1.24.0...v1.25.0)
  > 
  > Signed-off-by: dependabot-preview[bot] <support@dependabot.com>

### [1.13.3](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.13.2...v1.13.3) (2020-08-29)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 1.23.0 to 1.24.0 ([7b3faed](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/7b3faeddac7ca0def5279b9ae622f7035bf1cdb3))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 1.23.0 to 1.24.0. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v1.23.0...v1.24.0)
  > 
  > Signed-off-by: dependabot-preview[bot] <support@dependabot.com>

### [1.13.2](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.13.1...v1.13.2) (2020-08-26)

#### Bug Fixes

* **Interactions:** ensure correct consumer container is unregistered ([149bc72](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/149bc72c71710fb99dbf4ad1e6349091b34c7894))
  > The Ungrab in the Interactor shouldn't just attempt to unregister the consumers associated with the interactable but instead should attempt to unregister with the interactable's consumer container as that is the actual thing the consumers return as the registered container.

### [1.13.1](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.13.0...v1.13.1) (2020-08-15)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 1.22.0 to 1.23.0 ([71454e3](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/71454e3948fe453f9a7ec37b44b313890f68d336))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 1.22.0 to 1.23.0. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v1.22.0...v1.23.0)
  > 
  > Signed-off-by: dependabot-preview[bot] <support@dependabot.com>

## [1.13.0](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.12.2...v1.13.0) (2020-08-14)

#### Features

* **Interactions:** force snap interactable orientation to interactor ([82f4775](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/82f4775094bbe12c3cad9ea9f8db76e3587430ec))
  > There is now a mechanism on the Interactable that will force it to snap to the orientation of the grabbing Interactor regardless of the follow type being used. This is useful particularly with the Follow Rigidbody follow mechanic for ensuring if it gets too far away from a natural follow then it can be immediately snapped back to the correct orientation.
  > 
  > This mechanism can also be called from the Interactor and applied to any or all grabbed Interactables.

#### Bug Fixes

* **Interactions:** allow toggle grab to work when no longer touching ([26d632e](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/26d632e106d554f9e75a60e68a3fb554ca69ff2d))
  > The Toggle Grab mechanism would not work if the first toggle would grab and then the interactor would stop touching the interactable as the second toggle would no longer release the grab.
  > 
  > This was due to the grab publishers were always populated based on what was being touched and if the interactor stopped touching the grabbed interactable then the start grab publisher would not have anyway of knowing which interactable to publish to.
  > 
  > The latest version of Zinnia (1.22.0) has a mechanism for registering successful consumers of published events and this is now being used to keep a copy of all consumers that have successfully been published to by the interactor and then even if the interactor stops touching the interactable, the interactor still knows which consumers it can publish to (the grabbed consumers) because of this registry.
  > 
  > The ActionPublisher has also been updated to utilise this new Zinnia consumer registry to ensure the same concept of a grabbed interactable can still pass through 3rd party button data even if it is not being touched by additionally registering to the interactor start grab publisher.
* **Interactions:** force action grab setup to occur immediately ([e78969b](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/e78969bed8223adb559d8bb5693214e93378497c))
  > There is an issue where instantiating an Interactable prefab and then immediately calling an Interactor.Grab on it will cause a null exception because for some reason Unity hasn't fully set up the instantiated GameObject by the time the event process has run and therefore the `action.GrabSetUp` won't be set until the `action` GameObject is enabled in the scene.
  > 
  > The simplest solution to this is to force set the `action.GrabSetUp` immediately and then still do the wait to set it when the GameObject is enabled and then this way it will exist to do the preliminary setup and any additional setup that requires an active action will still occur.

### [1.12.2](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.12.1...v1.12.2) (2020-07-28)

#### Bug Fixes

* **interactions:** clear divergence states on ungrab ([59d9ecf](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/59d9ecf7cb1e9e03a4953afd30a1144f8dcbbb1e))
  > The divergence states found within the divergable property modifiers needs to be cleared when the ungrab occurs otherwise the convergence of the source/target objects cannot occur.

### [1.12.1](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.12.0...v1.12.1) (2020-07-28)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 1.20.0 to 1.21.0 ([255bc93](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/255bc931c756964ed96419b96ebe87563b10b557))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 1.20.0 to 1.21.0. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v1.20.0...v1.21.0)
  > 
  > Signed-off-by: dependabot-preview[bot] <support@dependabot.com>

## [1.12.0](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.11.1...v1.12.0) (2020-07-22)

#### Features

* **Interactables:** provide helper methods for common tasks ([755188d](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/755188d5f82b2371fb2750187b75af998d2d1be9))
  > The InteractableFacade now has some common helper methods for tasks like enabling/disabling the touch and grab configurations in case of toggling the interactable behaviour.
  > 
  > It is also possible to get access to common sub components from the facade such as the Rigidbody, MeshContainer, a collection of MeshRenderers and a collection of Colliders.
  > 
  > The Interactable.TouchReceiver prefab has also been updated to contain additional useful references.

### [1.11.1](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.11.0...v1.11.1) (2020-07-11)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 1.19.0 to 1.20.0 ([b3e1683](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/b3e168326b222f6885d37afd77ea2bf8be895ab4))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 1.19.0 to 1.20.0. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v1.19.0...v1.20.0)
  > 
  > Signed-off-by: dependabot-preview[bot] <support@dependabot.com>

## [1.11.0](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.10.1...v1.11.0) (2020-07-07)

#### Features

* **Interactions:** provide new methods for auto grabbing interactable ([a333827](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/a333827b723b940c74f65d748d9ba31a1938cfc6))
  > The Interactable can now be grabbed automatically with a collection of new methods like:
  > 
  > * GrabAtEndOfFrame (delays the grab until the end of frame) * GrabIgnoreUngrab (attempts a grab but doesn't call ungrab on the   interactor)
  > 
  > There is also a `UngrabAtEndOfFrame` which delays the ungrab until the end of the frame.
  > 
  > These new methods allow for finer control when wanting to perform automatic grabs and ungrabs and allow for more advanced features such as psuedo multi grabbing.

#### Bug Fixes

* **dependabot:** remove bddckr from default reviewer ([a0c27da](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/a0c27da96d75da722bf2f69082aae972b6feb688))
  > Only need one reviewer in the dependabot config.

### [1.10.1](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.10.0...v1.10.1) (2020-07-05)

#### Bug Fixes

* **Documentation:** apply style guidelines ([251ec26](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/251ec263a7ae891a46aeec422c225e092209f982))
  > The guide has had the style guidelines applied to it to make it more consistent.

## [1.10.0](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.9.0...v1.10.0) (2020-07-03)

#### Features

* **API:** add auto-generated API documentation ([1358b98](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/1358b98c976af5f42162fd9e12a590fde7cc9ea1))
  > The API documentation is auto generated with docfx and converted to markdown via turndown in a custom nodejs script.

#### Bug Fixes

* **package.json:** add docfx.json file ([fdd9e4c](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/fdd9e4c5104063dfaf7df306eed34c97403e0c63))
  > The docfx.json file was missing from the package.json causing the build process to fail. It has now been added.

## [1.9.0](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.8.1...v1.9.0) (2020-06-27)

#### Features

* **Interactables:** apply more specific namespace to interactables ([0f8b8d5](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/0f8b8d5a229bc2ddd04af164ad535245cd9689d7))
  > Previously, the Interactables were in a namespace that was at a higher level of the Interactors whereas Interactables should be at the same level.
  > 
  > There is already an Interactables namespace used by both interactors and interactables so the best solution is to just have a double Interactables.Interactables namespace. Whilst this looks a bit strange it at least buckets the code at the correct level.

### [1.8.1](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.8.0...v1.8.1) (2020-06-08)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 1.18.0 to 1.19.0 ([129a220](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/129a220883c9536b268a8b021f2ef090df311483))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 1.18.0 to 1.19.0. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v1.18.0...v1.19.0)
  > 
  > Signed-off-by: dependabot-preview[bot] <support@dependabot.com>

## [1.8.0](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.7.4...v1.8.0) (2020-05-31)

#### Features

* **Interactions:** add rotate around angular velocity follow type ([968c19b](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/968c19b8517adeb23281944798733574d89f7fdc))
  > The new Rotate Around Angular Velocity follow type allows the interactable to follow the rotation of the interactor's angular velocity and can be useful for interactions such as turning something with wrist motion rather than controller positional changes.

### [1.7.4](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.7.3...v1.7.4) (2020-05-31)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 1.17.1 to 1.18.0 ([6b39040](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/6b39040af05583c4121156942314cde1e5dcff14))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 1.17.1 to 1.18.0. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v1.17.1...v1.18.0)
  > 
  > Signed-off-by: dependabot-preview[bot] <support@dependabot.com>

### [1.7.3](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.7.2...v1.7.3) (2020-05-22)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 1.17.0 to 1.17.1 ([7092992](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/709299209ee9800cffa0e660a15de58e60d67027))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 1.17.0 to 1.17.1. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v1.17.0...v1.17.1)
  > 
  > Signed-off-by: dependabot-preview[bot] <support@dependabot.com>

### [1.7.2](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.7.1...v1.7.2) (2020-05-22)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 1.16.0 to 1.17.0 ([986c90f](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/986c90f889ef03647df58c054a8dd82c1b6ce6ac))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 1.16.0 to 1.17.0. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v1.16.0...v1.17.0)
  > 
  > Signed-off-by: dependabot-preview[bot] <support@dependabot.com>

### [1.7.1](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.7.0...v1.7.1) (2020-04-21)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 1.15.0 to 1.16.0 ([0c6a415](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/commit/0c6a4150f5fef13bd1d835abb5de6d2f9f318b6f))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 1.15.0 to 1.16.0. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v1.15.0...v1.16.0)
  > 
  > Signed-off-by: dependabot-preview[bot] <support@dependabot.com>

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

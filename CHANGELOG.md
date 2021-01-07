# Changelog

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

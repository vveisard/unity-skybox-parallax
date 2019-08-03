SkyboxEX
- Alpha (transparency)
- (Apparent) Scale
- (Apparent) Position

Setup
Project Settings
- `System_Skybox_LocalPosition_Factor`
- `System_Skybox_LocalRotation_Inverse`
- `System_Skybox_LocalRotation_Delta`
- `System_Skybox_ApplyProperties`

Use
Assets
- create a new material for your skybox, with the SkyboxEX shader
Scene / GameObjects
- instantiate a `-skybox` prefab as a child of the Camera that will be rendering the Skyboxes
- to each `-skybox` instance, attach the corresponding `Component_Skybox_Render` for the properties you want   
- to an empty GameObject, attach a single corresponding `System_Skybox_Rotation` for each `Component_Skybox_Render` in the previous step
- to an empty GameObject, attach a `Component_Skybox_Entities` for each `-skybox` instance
Scene / Inspector
- on the `-skybox` prefab instance, set the Material of the MeshRender Component to the Material you created in Project Setup

SkyboxEX

RotationInverse
- `_Rotation` of the Skybox will be set to the inverse of the rotation of `EntityTarget`
- use this if you want your skybox to be "fixed"
- the reason this works is because, as a child of the Camera, the Skybox will rotate with it

RotationDelta
- `_Rotation` of the Skybox will track ONLY the changes in the rotation of the `EntityTarget` 

# Use Cases #

 "Fixed" Rotation Skybox
- attach a `Component_Skybox_Entities`
- attach a `Component_Skybox_Properties`
- attach a `Component_Skybox_LocalRotation_Inverse`

"Parallax" Rotation Skybox
- attach a `Component_Skybox_Entities`
- attach a `Component_Skybox_Properties`
- attach a `Component_Skybox_LocalRotation_Inverse`
- attach a `Component_Skybox_LocalRotation_Delta` (this will stack)
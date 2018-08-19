##Usage

Will upload a demo eventually

Attach a SkeletonSkin component to each skinned mesh renderer you want to move to another matching skeleton.
Click the "Precache" button, this will build the list of bones used for lookup later.

Attach a Skeleton component to the skeleton (rig) you want to attach to.  
Assign the root bone, and click the "Precache" button.

Call skeleton.EquipSkin(skin), this will move the skin to be a child of skeleton, and remap the skin to use the skeletons matched bones.

Uses Odin Inspector to make dictionaries visible in inspector, and for the inspector buttons.  If you're not using Odin, remove the includes, change SerializedMonoBehaviour to MonoBehaviour, comment out the [Button] attributes and precach using the right click menu on the components in the inspector.


## Usage

I'm using this to attach equipment (shirts, like this BOX) to character bodies.

![screenshot](https://i.imgur.com/Lgd9DFd.gif)

Attach a SkeletonSkin component to each skinned mesh renderer you want to move to another matching skeleton.
Click the "Precache" button, this will build the list of bones used for lookup later.

Attach a Skeleton component to the skeleton (rig) you want to attach to.  
Assign the root bone, and click the "Precache" button.

Call skeleton.EquipSkin(skin), this will move the skin to be a child of skeleton, and remap the skin to use the skeletons matched bones.

Uses Odin Inspector to make dictionaries visible and serializable in the inspector, and for the inspector buttons.  If you're not using Odin you'll have to do a bit of editing. Remove the includes, change SerializedMonoBehaviour to MonoBehaviour, comment out the [Button] attributes and precach using the right click menu on the components in the inspector.  The precaches will also need to be saved to something other than a dictionary (as unity seems to clear any dicts on play that were set in the editor??). Will also need a way to index the bones by string (or just iterate through the entirel list of bones to find the one you're looking for or something).

Hopefully this is a good starting point for someone looking to do the same thing, and save them the few days of headache I had :)


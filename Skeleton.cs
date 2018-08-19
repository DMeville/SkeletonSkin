using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Skeleton : SerializedMonoBehaviour {

    public Dictionary<string, BoneDefintiion> rigDefinition = new Dictionary<string, BoneDefintiion>();
    public Transform rootBone;

    [Button(Name = "Precache Rig")]
    public void PrecacheRig() {
        rigDefinition = new Dictionary<string, BoneDefintiion>();
        Transform[] children = rootBone.GetComponentsInChildren<Transform>();
        for(int i = 0;  i < children.Length; i++) {
            rigDefinition.Add(children[i].name, new BoneDefintiion() { index = i, gameObject = children[i] });
        }
    }

    [ContextMenu("Precache Rig")]
    public void PrecacheRigCM() {
        PrecacheRig();
    }
    
    //Call this to move a skinned mesh renderer from one skeleton to another
    //Skeletons must match!
    public void EquipSkin(SkeletonSkin skin) {
        List<Transform> b = new List<Transform>();
        foreach(var bone in skin.skeleton) {
            b.Add(rigDefinition[bone.Key].gameObject.transform);
        }

        skin.smr.bones = b.ToArray();
        skin.smr.rootBone = rootBone;
        skin.smr.transform.parent = rootBone.parent.parent;
    }
}

[System.Serializable]
public class BoneDefintiion {
    public int index;
    public Transform gameObject;
}

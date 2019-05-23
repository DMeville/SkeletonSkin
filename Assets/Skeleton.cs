using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Sirenix;
//using Sirenix.OdinInspector;

public class Skeleton : MonoBehaviour {

    //public Dictionary<string, BoneDefintiion> rigDefinition = new Dictionary<string, BoneDefintiion>();
    public List<BoneDefintion> rigDefinition = new List<BoneDefintion>();
    public Transform rootBone;

    //replace dictionary with List<BoneDefinition>.
    //but we need to be able

    //[Button(Name = "Precache Rig")]
    //[ContextMenu("")]
    [Button]
    public void PrecacheRig() {
        rigDefinition = new List<BoneDefintion>();
        Transform[] children = rootBone.GetComponentsInChildren<Transform>();
        for(int i = 0; i < children.Length; i++) {
            BoneDefintion bd = new BoneDefintion() { index = i, name = children[i].name, gameObject = children[i] };
            rigDefinition.Add(bd);
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
            //we need a list (b) that has all the bones that these two share?   
            //for every bone precached in the skin
            //we need to find that corresponding bone in our rigDef and add it to a list

            //find bone with name bone (string value)
            BoneDefintion bd = rigDefinition.Find((d) => bone == d.name);

            b.Add(rigDefinition[bd.index].gameObject.transform);
        }

        skin.smr.bones = b.ToArray();
        skin.smr.rootBone = rootBone;
        skin.smr.transform.parent = rootBone.parent;
    }

    //If we have a shirt that's already on one player, we can't just use the Equip method because it places it in the wrong spot?
    //Use this instead I guess
    public void ReassignSkin(SkeletonSkin equip, Skeleton skel) {
        List<Transform> b = new List<Transform>();
        foreach(var e in equip.skeleton) {
            BoneDefintion bd = skel.rigDefinition.Find((d) => e == d.name);
            b.Add(skel.rigDefinition[bd.index].gameObject.transform);
        }

        SkinnedMeshRenderer s = equip.GetComponent<SkinnedMeshRenderer>();
        s.bones = b.ToArray();
        s.rootBone = skel.rootBone;
        s.transform.parent = skel.rootBone.parent.parent;

    }

    [ContextMenu("LogRigDef")]
    public void LogRigDef() {
        Debug.Log("Skeleton Rigdef: " + rigDefinition.Count);
    }
}

[System.Serializable]
public class BoneDefintion {
    public int index;
    public string name;
    public Transform gameObject;
}

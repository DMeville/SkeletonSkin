using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class SkeletonSkin : SerializedMonoBehaviour {
//public class SkeletonSkin : MonoBehaviour {

    [SerializeField]
    public Dictionary<string, int> skeleton = new Dictionary<string, int>();
    public SkinnedMeshRenderer smr;

    [Button(Name = "Precache Bones")]
    public void PrecacheBones() {
        skeleton = new Dictionary<string, int>();
        smr = this.GetComponent<SkinnedMeshRenderer>();
        Transform[] ts = smr.bones;
        for(int i = 0; i < ts.Length; i++) {
            skeleton.Add(ts[i].name, i);
        }
    }


    [ContextMenu("PrecacheBones")]
    public void PrecacheBonesCM() {
        PrecacheBones();
    }
}

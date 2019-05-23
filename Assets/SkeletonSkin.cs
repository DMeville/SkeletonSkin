using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Sirenix.OdinInspector;

public class SkeletonSkin : MonoBehaviour {

    [SerializeField]
    //public Dictionary<string, int> skeleton = new Dictionary<string, int>();
    public List<string> skeleton = new List<string>();
    public SkinnedMeshRenderer smr;


    //[Button(Name = "Precache Bones")]
    [Button]
    public void PrecacheBones() {
        skeleton = new List<string>();
        Transform[] ts = smr.GetComponent<SkinnedMeshRenderer>().bones;
        for(int i = 0; i < ts.Length; i++) {
            skeleton.Add(ts[i].name);
        }

        smr = this.GetComponent<SkinnedMeshRenderer>();
    }

    [ContextMenu("PrecacheBones")]
    public void PrecacheBonesCM() {
        PrecacheBones();
    }

    [ContextMenu("LogRigDef")]
    public void LogRigDef() {
        Debug.Log("SkeletonSkin skeleton: " + skeleton.Count);
    }
}

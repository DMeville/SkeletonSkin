using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipOnStart : MonoBehaviour {

    public SkeletonSkin skin;

    void Start () {
        //Transform skinRoot = skin.transform.root;
        this.GetComponent<Skeleton>().EquipSkin(skin);
        //GameObject.Destroy(skinRoot.gameObject);
	}
}

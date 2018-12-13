using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour {

    public Material[] materials;
    public MeshRenderer rend;

	// Use this for initialization
	void Start () {

        //rend = GetComponent<Renderer>();
        //rend.enabled = true;
        rend.sharedMaterial = materials[0];

	} // End Start()
	
    public void changeSkin()
    {

        rend.sharedMaterial = materials[1];

    } // End changeSkin()


}

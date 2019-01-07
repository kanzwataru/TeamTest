using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuillAnimation : MonoBehaviour {
    public int frameRate = 12;

    private GameObject[] layers;
    private int frame = 0;

	// Use this for initialization
	void Start () {
        QuillAnimSystem.instance.RequestFPSCounter(frameRate);

        layers = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            layers[i] = transform.GetChild(i).gameObject;
            layers[i].SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if(QuillAnimSystem.instance.ShouldUpdate(frameRate)) {
            layers[frame].SetActive(false);

            if (++frame == layers.Length) {
                frame = 0;
            }

            layers[frame].SetActive(true);
        }
	}
}

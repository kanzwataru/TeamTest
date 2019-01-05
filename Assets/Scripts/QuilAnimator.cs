using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuilAnimator : MonoBehaviour {

    private List<GameObject> layers = new List<GameObject>();
    public int frameSkip;
    private int frameCounter = 0;
    private int frame = 0;

	// Use this for initialization
	void Start () {
        
        for (int i = 0; i < transform.childCount; i++)
        {
            layers.Add(transform.GetChild(i).gameObject);
            layers[i].SetActive(false);
        }

	}
	
	// Update is called once per frame
	void Update () {

        if (frameCounter > frameSkip)
        {
            frameCounter = 0;
            layers[frame].SetActive(false);

            if (++frame == layers.Count) //up frames
            {
                frame = 0;
            }

            layers[frame].SetActive(true);
        }
        frameCounter++;

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuillAnimation : MonoBehaviour {
    public float frameRate = 12;

    private List<GameObject> layers = new List<GameObject>();
    private float frameTimeCounter = 0.0f;
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
        Benchmarker.instance.BenchCall("QuillAnimation Update", () => {
            frameTimeCounter += (Time.deltaTime * 1000);
            if(frameTimeCounter >= 1000 / frameRate) {
                layers[frame].SetActive(false);

                if (++frame == layers.Count) //up frames
                {
                    frame = 0;
                }

                layers[frame].SetActive(true);

                frameTimeCounter = 0.0f;
            }
        });
	}
}

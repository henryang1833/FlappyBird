using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipeline : MonoBehaviour {

    public float speed = 3;
    public float minRange;
    public float maxRange;
    private float t = 0;
	// Use this for initialization
	void Start ()
    {
        this.Init();
	}

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(-1, 0) * speed * Time.deltaTime;
        t += Time.deltaTime;
        if (t >= 6f)
        {
            t = 0;
            this.Init();
        }
	}

    public void Init()
    {
        float y = Random.Range(minRange, maxRange);
        this.transform.localPosition = new Vector3(0, y, 0);
    }
}

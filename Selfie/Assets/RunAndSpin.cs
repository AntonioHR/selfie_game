using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAndSpin : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(MoveAndSpinForever());	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator MoveAndSpinForever()
    {
        while(true)
        {
            var move = Random.insideUnitSphere;
            move.y = 0;
            move.Normalize();
            yield return RunTo(transform.position + move * Random.Range(3, 10), 1);
            yield return Spin(Random.insideUnitSphere, 360, Random.Range(.5f, 1.5f));
        }
    }

    IEnumerator Spin(Vector3 axis, float angle, float time)
    {
        Debug.Log("Started Spinning");
        var startRot = transform.rotation;
        float startTime = Time.time;

        bool reached = false;
        while (!reached)
        {
            float lerp = Mathf.InverseLerp(startTime, startTime + time, Time.time);

            if (lerp >= 1)
            {
                lerp = 1;
                reached = true;
            }

            transform.rotation = Quaternion.AngleAxis(angle * lerp, axis) * startRot;
            yield return null;
        }
    }

    IEnumerator RunTo(Vector3 targetPos, float time)
    {
        Vector3 startPos = transform.position;
        float startTime = Time.time;

        bool reached = false;
        while(!reached)
        {
            float lerp = Mathf.InverseLerp(startTime, startTime + time, Time.time);

            if(lerp >= 1)
            {
                lerp = 1;
                reached = true;
            }

            transform.position = Vector3.Lerp(startPos, targetPos, lerp);
            yield return null;
        }
    }
}

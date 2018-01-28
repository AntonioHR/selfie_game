using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DGPunchScale : MonoBehaviour {

	public Vector3 punch;
	public float duration;
	public int vibrato;
	[Range(0,1)]
	public float elasticity;

	public bool canTween = true;

	public void PlayTween(){

		if(canTween){
			transform.DOComplete();
			transform.DOPunchScale(punch,duration,vibrato, elasticity);
		}

	}


}

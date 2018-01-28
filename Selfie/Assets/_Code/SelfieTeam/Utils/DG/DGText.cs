using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class DGText : MonoBehaviour {

	public float duration;

	// Use this for initialization
	void Start () {

		string txt = GetComponent<Text>().text;
		GetComponent<Text>().DOText(txt, duration, true, ScrambleMode.Custom, " ");
		
	}
}

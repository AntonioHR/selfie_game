using SelfieTeam.Selfie;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class QuestUpdateDisplay : MonoBehaviour {
    public Slider slider;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        var quest = SceneManager.Instance.CurrentQuest;
        if(quest != null)
        {
            slider.value = quest.Progress;
        }
    }
}

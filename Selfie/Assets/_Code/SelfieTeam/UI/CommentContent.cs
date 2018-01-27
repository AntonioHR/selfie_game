using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class CommentContent : MonoBehaviour {

    public Image avatar;
    public TextMeshProUGUI txtmesh;

    private void Start()
    {
        transform.DOPunchScale(new Vector3(-0.2f,-0.2f,-0.2f),0.2f,10,1).SetEase(Ease.OutBack);
    }

    public void SetText(string txt){
        txtmesh.text = txt;
    }

    public void SetAvatar(Sprite sprite){
        avatar.sprite = sprite;
    }
}

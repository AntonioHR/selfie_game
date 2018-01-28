using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using System;

public class InterfaceManager : MonoBehaviour {

    public static InterfaceManager Instance { get; private set;}

    public Image batteryImage;
    public ScrollRect scroll;
    public Transform commentsContent;
    public TextMeshProUGUI viewersText;
    public GameObject commentPrefab;

    public void SetViewers (int amount){
        viewersText.transform.DOComplete();
        viewersText.transform.parent.DOComplete();
        viewersText.transform.parent.DOPunchScale(new Vector3(-0.2f, -0.2f, -0.2f), 0.2f, 10, 1).SetEase((Ease.OutBack));
        viewersText.transform.DOPunchScale(new Vector3(-1,-1,-1),0.2f,10,1);
        viewersText.text = amount.ToString();
    }

    //percent is float from 0 to 1
    public void SetBattery(float percent, float duration){
        batteryImage.DOFillAmount(percent, duration);
    }

    internal void SetBatteryNow(float val)
    {
        batteryImage.fillAmount = val;
    }

    public void AddComent(string text, Sprite portrait){
        GameObject obj = Instantiate(commentPrefab,transform.position, transform.rotation,commentsContent);
        var content = obj.GetComponent<CommentContent>();
        content.SetText(text);
        content.SetAvatar(portrait);
        scroll.DOVerticalNormalizedPos(0, 1);
        //obj.GetComponent<CommentContent>().set
    }
    private void Awake()
    {
        Instance = this;
    }

    //private void Update()
    //{
    //    if(Input.GetKeyDown(KeyCode.Alpha1)){
    //        SetBattery(0.2f,0.2f);
    //        SetViewers(999);
    //    }

    //    if (Input.GetKeyDown(KeyCode.Alpha2))
    //    {
    //        SetBattery(0.4f, 0.2f);
    //        SetViewers(300);
    //    }
    //    if (Input.GetKeyDown(KeyCode.Alpha9))
    //    {
    //        SetBattery(0.9f, 0.2f);
    //        SetViewers(20);
    //    }

    //    if (Input.GetKeyDown(KeyCode.P))
    //    {
    //        AddComent("tu é <b>GOSTOSO</b>");
    //    }

    //    if (Input.GetKeyDown(KeyCode.O))
    //    {
    //        AddComent("que <b>DELI</b>");
    //    }

    //}



}

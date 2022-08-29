using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public static int point;
    public static Transform[] points;
    public GameObject noRetreat;
    public GameObject noAttack;
    public Text pointsText;

    private void Start() {
        point = 1;
        pointsText.text = "Points: " + point.ToString();
    }

    private void Awake() {
        points = new Transform[transform.childCount];
        for(int i = 0; i < points.Length; i++) {
            points[i] = transform.GetChild(i);
        }
    }

    private void Update() {
        pointsText.text = "Points: " + point.ToString();
    }

    public void Retreat() {
        if(point >= points.Length - 2) {
            point = points.Length - 1;
            noAttack.SetActive(true);
        }
        else point++;
    }
    public void Attack() {
        if(point <= 0) {
            point = Convert.ToInt32(points[0]) - 1;
            noRetreat.SetActive(true);
        }
        else point--;
    }
}

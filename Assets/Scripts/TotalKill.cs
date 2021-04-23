using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TotalKill : MonoBehaviour
{
    public static int totalKill;
    Text text;

    void Awake()
    {
        totalKill = 0;
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = "ENEMY : " + totalKill;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class oyunSkor : MonoBehaviour
{
    Text skorTxt;
    int skor;
    public int Skor
    {
        get { return this.skor; }
        set { this.skor = value; UpdateSkorTxt(); }

    }
    // Start is called before the first frame update
    void Start()
    {
        skorTxt = GetComponent<Text>();
    }
    void UpdateSkorTxt()
    {
        string skorFormat = string.Format("{0:000000}",skor);
        skorTxt.text = skorFormat;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time_out : MonoBehaviour {

    public int _timeOut;
    static public int _Time_in;

    // Use this for initialization
    void Start ()
    {
        _Time_in = _timeOut;

        //----------------Count-Time----------------
        InvokeRepeating("_countDown", 1, 1);
        //------------------------------------------

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMesh>().text = "Time : " + _Time_in; //Show time
    }

    public void _countDown()
    {
        _Time_in -= 1; // time -1
    }
}

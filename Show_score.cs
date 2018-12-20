using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Show_score : MonoBehaviour {

    static public int _score;

	//// Use this for initialization
	//void Start () {
		
	//}
	
	// Update is called once per frame
	void Update ()
    {
        GetComponent<TextMesh>().text = "Score: " + _score;  //Show Text Score

        if (Time_out._Time_in == 0)
        {
            Time.timeScale = 0; //Pause
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _score = 0;
            Time.timeScale = 1; //Play
            Time_out._Time_in = 5; //Reset time
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_move : MonoBehaviour {

    public int _speed = -10; // Variable Start speed
    public AudioClip _HitSFX; // Variable Audio

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(0, 0, _speed * Time.deltaTime); // Move object axis Z

        if (transform.position.z < -8) // Stop object axis Z = -8
        {
            _newPos(); // Run function
        }

    }

    //===================Random Start object axis Z =================//
    public void _newPos()
    {
        float _random = Random.Range(-10.0f, 10.0f); //-5, 6
        transform.position = new Vector3(_random, -0.8f, 6);
        _speed = 0;

        Invoke("_newSpeed", 0); // Time Start object >> function _newSpeed

    }
    //=========================================================//

    //===================Random speed object====================//
    public void _newSpeed()
    {
        _speed = Random.Range(-20, -10);
    }
    //=========================================================//

    //==============Collision detection=======================//
    private void OnCollisionEnter(Collision _Chonh)
    {
        if (_Chonh.collider.name == "Cylinder_P") // object name Cylinder_P
        {
            GetComponent<AudioSource>().PlayOneShot(_HitSFX); // Play sound
            //_parPoint_2 = (Transform)Instantiate(_parFX, transform.position, transform.rotation);
            //_speed = -1;
            //Destroy(_Chonh.gameObject); //ทำลายตัวอื่น
            //Destroy(gameObject); //ทำลายตัวเอง
            print("OK!!"); // print console
            _newPos(); // start function, restart object
        }
    }
    //=========================================================//
}

using UnityEngine;
using System.Collections;

public class WhiteKey : DefaultKey {

  void OnCollisionEnter2D(Collision2D col) 
  {
    if (col.gameObject.tag == "Character") 
    {
      GotKey = true;
      Destroy(gameObject);
    }
  }

	// Use this for initialization
	void Start () {
    GotKey = false;
	}
	
	// Update is called once per frame
	void Update () {

	}
}

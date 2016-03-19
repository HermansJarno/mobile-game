using UnityEngine;
using System.Collections;

public class PlatformDestroyer : MonoBehaviour {

  GameObject platformDestructionPoint;

	// Use this for initialization
	void Start () {
    platformDestructionPoint = GameObject.Find("PlatformDestructionPoint");
	}
	
	// Update is called once per frame
	void Update () {
    if (transform.position.z < platformDestructionPoint.transform.position.z)
    {
      //Destroy(gameObject);
      gameObject.SetActive(false);
    }
	}
}

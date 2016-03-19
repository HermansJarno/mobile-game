using UnityEngine;
using System.Collections;


public class WhiteDoor : MonoBehaviour {

  private bool openDoor;
  private WhiteKey gotWhiteKey;
  public GameObject whiteKey;
  Animator anim;
  public Collider2D colNewLevel;

  public bool OpenDoor
  {
    get { return openDoor; }
    set { openDoor = value; }
  }

	// Use this for initialization
	void Start () {
    anim = GetComponent<Animator>();
    gotWhiteKey = whiteKey.GetComponent<WhiteKey>();
    openDoor = false;
    colNewLevel.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

    if (gotWhiteKey.GotKey) 
    {
      anim.SetBool("OpenDoor", true);
      anim.SetBool("StayOpen", true);
      OpenDoor = true;
    }

    if (OpenDoor) 
    {
      colNewLevel.enabled = true;
    }
	}
}

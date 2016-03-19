using UnityEngine;
using System.Collections;

public class IdleScript : MonoBehaviour {

  Animator anim;

	// Use this for initialization
	void Awake () {
    anim = GetComponent<Animator>();
    anim.SetFloat("Speed", 0f);
    
  }
}

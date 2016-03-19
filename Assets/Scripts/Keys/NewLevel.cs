using UnityEngine;
using System.Collections;

public class NewLevel : MonoBehaviour {

  void OnTriggerEnter2D (Collider2D col) 
  {
    if (col.gameObject.tag == "Door") 
    {
      Debug.Log("new level loading");
    }
  }
}

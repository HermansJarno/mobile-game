using UnityEngine;
using System.Collections;

public class CherryPoints : MonoBehaviour {


  void OnTriggerEnter2D(Collider2D col) 
  {
    if (col.gameObject.name == "Cherry") 
    {
      Destroy(col.gameObject);
    }
  }

}

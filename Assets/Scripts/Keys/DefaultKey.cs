using UnityEngine;
using System.Collections;

public class DefaultKey : MonoBehaviour {

  private bool gotKey;

  public bool GotKey 
  {
    get { return gotKey; }
    set { gotKey = value; }
  }
  
}

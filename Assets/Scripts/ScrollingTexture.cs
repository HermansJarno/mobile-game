using UnityEngine;
using System.Collections;

public class ScrollingTexture : MonoBehaviour {

  public float scrollSpeed = 0.90f;
  public float scrollSpeed2 = 0.90f;
  public SpriteRenderer spriteR;

  void FixedUpdate()
  {

    float offset = Time.time * scrollSpeed;
    float offset2 = Time.time * scrollSpeed2;
    //GetComponent<Renderer>().material.mainTextureOffset = new Vector2(offset2, -offset);
    spriteR.material.mainTextureOffset = new Vector2(offset2, -offset);
  }
}
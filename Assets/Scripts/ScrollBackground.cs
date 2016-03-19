using UnityEngine;
using System.Collections;

public class ScrollBackground : MonoBehaviour {

  [SerializeField] float parralax = 2f;
  //[SerializeField] Transform character;
  //public float distance = -10, goDepth = -1;
  //Vector3 viewPort;
  //Vector3 BottemLeft;
  //Vector3 TopRight;

  void Start()
  {
    //distance = Camera.main.transform.position.z - transform.position.z;
    //distance -= (goDepth * 0.5f);
    //viewPort.Set(0, 0, distance);
    //BottemLeft = Camera.main.ViewportToWorldPoint(viewPort);
    //viewPort.Set(1, 1, distance);
    //TopRight = Camera.main.ViewportToWorldPoint(viewPort);
    //transform.localScale = new Vector3(BottemLeft.x - TopRight.x, -(BottemLeft.y - TopRight.y), goDepth);
  }

	// Update is called once per frame
	void Update () {
    MeshRenderer mr = GetComponent<MeshRenderer>();
    Material mat = mr.material;
    Vector2 offset = mat.mainTextureOffset;
    offset.x = transform.position.x / transform.localScale.x / parralax;
    //offset.y = transform.position.y / transform.localScale.y;

    mat.mainTextureOffset = offset;
	}
}

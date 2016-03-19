using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour {

  public GameObject thePlatform;
  public Transform generationPoint;
  public float distanceBetween;

  private float platformWidth;
  float[] platformWidths;

  public float DistanceBetweenMin, DistanceBetweenMax;
  public float xOffsetMin, xOffsetMax;
  float xMiddleValue, xRandomOffset;
  private float minHeight, maxHeight;
  public Transform maxHeightPoint;
  public float maxHeightChange;
  private float heightChange;

  public GameObject[] thePlatforms;
  int platformSelector;
  public ObjectPooling[] theObjectPools;



  // Use this for initialization
  void Start () {
    //platformWidth = thePlatform.GetComponent<BoxCollider>().size.z;

    xMiddleValue = generationPoint.position.x;
    xOffsetMin = xMiddleValue - xOffsetMin;
    xOffsetMax = xMiddleValue + xOffsetMax;

    minHeight = transform.position.y;
    maxHeight = maxHeightPoint.position.y;

    platformWidths = new float[theObjectPools.Length];
    for (int i = 0; i < theObjectPools.Length; i++)
    {
      platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider>().size.x;
    }
	}
	
	// Update is called once per frame
	void Update () {
    if (transform.position.z < generationPoint.position.z)
    {
      distanceBetween = Random.Range(DistanceBetweenMin, DistanceBetweenMax);
      xRandomOffset = Random.Range(xOffsetMin, xOffsetMax);

      platformSelector = Random.Range(0, theObjectPools.Length);

      heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

      if (heightChange > maxHeight)
      {
        heightChange = maxHeight;
      } else if (heightChange < maxHeight)
      {
        heightChange = minHeight;
      }

      transform.position = new Vector3(xRandomOffset, heightChange, transform.position.z + (platformWidths[platformSelector]/2) + distanceBetween);

      GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();

      newPlatform.transform.position = transform.position;
      newPlatform.transform.rotation = transform.rotation;
      newPlatform.SetActive(true);

      transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (platformWidths[platformSelector] / 2));
      //Instantiate(thePlatform, transform.position, transform.rotation);
    }
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour {

  public RectTransform healthTransform;
  private float cachedY;
  private float minXValue;
  private float maxXValue;
  private float currentEnergy = 40.0f;
  private float maxEnergy = 40.0f;

  public Image visualHealth, frame1, frame2;







  void OnTriggerEnter2D(Collider2D col)
  {
    if (col.gameObject.name == "Energy")
    {
      currentEnergy = 40.0f;
      Destroy(col.gameObject);
    }
  }

	// Use this for initialization
	void Start () {

    cachedY = healthTransform.position.y;
    maxXValue = healthTransform.position.x;
    minXValue = healthTransform.position.x - healthTransform.rect.width;
    currentEnergy = maxEnergy;
    //Timer = maxEnergy;

	}
	
	// Update is called once per frame
	void Update () {

    handleHealth();
    currentEnergy -= Time.deltaTime;

    
	}

  private void handleHealth() 
  {
    float currentXValue = mapValues(currentEnergy, 0, maxEnergy, minXValue, maxXValue);
    healthTransform.position = new Vector3(currentXValue, cachedY);

    if (currentEnergy > maxEnergy / 2)//more than 50procent
    {
      visualHealth.color = new Color32((byte)mapValues(currentEnergy,maxEnergy/2,maxEnergy,255,0), 255, 0, 255);
    }
    else
    {
      visualHealth.color = new Color32(255, (byte)mapValues(currentEnergy, 0, maxEnergy / 2, 0, 255), 0, 255);
    }
  }

  private float mapValues(float x, float inMin, float inMax, float outMin, float outMax) 
  {
    return (x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
  }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(WolfControllerScript))]
public class Thunderhealth : MonoBehaviour
{

  public RectTransform healthTransform;
  private float cachedX;
  private float minYValue;
  private float maxYValue;
  private float currentEnergy = 40.0f;
  private float maxEnergy = 40.0f;
  public Image visualHealth;






  void OnTriggerEnter2D(Collider2D col)
  {
    if (col.gameObject.name == "Energy")
    {
      currentEnergy = 40.0f;
      Destroy(col.gameObject);
    }
  }

  // Use this for initialization
  void Start()
  {

    cachedX = healthTransform.position.x;
    maxYValue = healthTransform.position.y;
    minYValue = healthTransform.position.y - healthTransform.rect.height;
    currentEnergy = maxEnergy;
    //Timer = maxEnergy;

  }

  // Update is called once per frame
  void Update()
  {


    handleHealth();
    if (currentEnergy >= 0)
    {
      currentEnergy -= (Time.deltaTime/1.8f);
    
    }


  }

  private void handleHealth()
  {
    float currentYValue = mapValues(currentEnergy, 0, maxEnergy, minYValue, maxYValue);
    healthTransform.position = new Vector3( cachedX, currentYValue);

    if (currentEnergy > maxEnergy / 2)//more than 50procent
    {
      visualHealth.color = new Color32((byte)mapValues(currentEnergy, maxEnergy / 2, maxEnergy, 255, 0), 255, 0, 255);
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

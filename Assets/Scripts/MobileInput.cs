using UnityEngine;
using System.Collections;

[RequireComponent(typeof(WolfControllerScript))]
public class MobileInput : MonoBehaviour
{

  private WolfControllerScript character;
  private bool jump = false , roll = false;
  float timer = 5.0f;

  void Awake() 
  {
    character = GetComponent<WolfControllerScript>();
  }

  //MOBILE VARS


  public float minSwipeDistY;

  public float minSwipeDistX;

  private Vector2 startPos;


  void FixedUpdate()
  {
    jump = false;
  }


  void Update()
  {


    if (Input.GetButtonDown("Jump"))
    {
      roll = true;
    }

    //#if UNITY_ANDROID
    if (Input.touchCount > 0)
    {

      Touch touch = Input.touches[0];



      switch (touch.phase)
      {

        case TouchPhase.Began:

          startPos = touch.position;

          break;



        case TouchPhase.Ended:



          float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;

          if (swipeDistVertical > minSwipeDistY)
          {

            float swipeVertValue = Mathf.Sign(touch.position.y - startPos.y);

            if (swipeVertValue > 0)//Up SWIPE
            {
              jump = true;
            }
            else if (swipeVertValue < 0)//down swipe
            {
              roll = true;
              StartCoroutine( deactivateRollingAfterTime(2f));
            }
          }

          float swipeDistHorizontal = (new Vector3(touch.position.x, 0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;

          if (swipeDistHorizontal > minSwipeDistX)
          {

            float swipeHValue = Mathf.Sign(touch.position.x - startPos.x);

            if (swipeHValue > 0)//right swipe
            {
              if (character.move < 0)
              {
                //
              }
              
            }

            else if (swipeHValue < 0)//left swipe
            {
              if (character.move > 0)
              {
                //
              }
              
            }
          }
          break;
      }
    }
  }

  IEnumerator deactivateRollingAfterTime(float seconds)
  {
    yield return new WaitForSeconds(seconds);
    roll = false;
  }
}
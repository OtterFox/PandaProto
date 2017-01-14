using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TouchPatterns : MonoBehaviour {

    public enum TouchPattern
    {
        Tap = 0,
        DoubleTap = 1,
        Up = 2,
        Down = 3,
        Left = 4,
        Right = 5,
        TapUp = 6,
        TapDown = 7,
        TapLeft = 8,
        TapRight = 9,
    }
    public TouchPattern tPat = TouchPattern.Tap;

    ObjectFallProto objFall;

    int tapCount;
    float tapTimer;

    bool isTap;
    bool isDoubleTap;
    bool isSwipeR;
    bool isSwipeL;
    bool isSwipeUp;
    bool isSwipeDown;
    bool isTouchDisabled;

    bool isMissed;  //did player miss pattern

	void Start ()
    {
        isMissed = true;
        GameObject ObjectSpawner = GameObject.Find("ObjectSpawner");
        objFall = ObjectSpawner.GetComponent<ObjectFallProto>();
        Text missed = objFall.missText;
        Text great = objFall.PerfectText;
        objFall.PerfectText.enabled = false;
    }
		
	void Update ()
    {
        Taps();
        Swipe();
        PatternTest();

        //print(" " + Input.touchCount);

    }

    void Taps()
    {
       if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            tapCount++;
        }
       if(tapCount > 0)
        {
            tapTimer += Time.deltaTime;   //start timer to count tap or double tap     
        }
       if (tapCount == 2)
        {
            tapTimer = 0.0f;
            tapCount = 0;
            isDoubleTap = true;
            DoubleTap();
        }
       if(tapTimer > .2f)     //timer to call if single tap
        {
            tapTimer = 0f;
            tapCount = 0;
            isTap = true;
            SingleTap();
            
        }
    }

    void SingleTap()
    {
        if (!isTouchDisabled && tPat == TouchPattern.Tap)
        {
            print("tap ");
            objFall.canFall = true;
            isMissed = false;
            objFall.PerfectText.enabled = true;
        }
       
    }

    void DoubleTap()
    {
        if (!isTouchDisabled && tPat == TouchPattern.DoubleTap)
        {
            print("double tap ");
            objFall.canFall = true;
            isMissed = false;
            objFall.PerfectText.enabled = true;
        }
      
    }
    

    void Swipe()
    {
        if (Input.touches.Length > .3f && !isTouchDisabled )
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && Input.GetTouch(0).deltaPosition.x > 0)
            {
                isSwipeR = true;
                SwipeRight();
            }
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && Input.GetTouch(0).deltaPosition.x < 0)
            {
                isSwipeL = true;
                SwipeLeft();
            }
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && Input.GetTouch(0).deltaPosition.y > 0)
            {
                isSwipeUp = true;
                SwipeUp();
            }
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && Input.GetTouch(0).deltaPosition.y < 0)
            {
                isSwipeDown = true;
                SwipeDown();
                
            }
        }

    }

    //for testing
    public void SwipeRight()
    {
        isSwipeR = false;
        print("Right swipe ");
    }

    public void SwipeLeft()
    {
        
        print("Left swipe " );
    }

    public void SwipeUp()
    {
        if (!isTouchDisabled && tPat == TouchPattern.Up)
        {
            print("Up swipe ");
            objFall.canFall = true;
            isMissed = false;
            objFall.PerfectText.enabled = true;
        }
        isSwipeUp = false;
    }

    public void SwipeDown()
    {
        if (!isTouchDisabled && tPat == TouchPattern.Down)
        {
            print("Down swipe ");
            objFall.canFall = true;
            isMissed = false;
            objFall.PerfectText.enabled = true;
        }
        isSwipeDown = false;
    }

    void PatternTest()
    {
        //Was there a tap then swipe? Test the pattern if so
        if(isDoubleTap && isSwipeL)
        {
            print("tap + left swipe worked");
            isDoubleTap = false;
            isSwipeL = false;
            isTouchDisabled = true;
            StartCoroutine("TouchPause");
        }
    }

    IEnumerator TouchPause()
    {
       
        yield return new WaitForSeconds(2f);    // 2f needs to be its own float var to decrese when objects instantiate speed increases
       
        isTouchDisabled = false;
    }

    
    //replace later with when obj collides it becomes deactivated
    void OnCollisionEnter(Collision col)
    {//if obj touches anything && should only be obj count == 1
        if (col.gameObject.tag == "Cube" && !isMissed) 
        {
            print("Collided");
            objFall.ObjectFall();
            enabled = false;
            objFall.CountText.text = objFall.fallpieces.ToString();
            objFall.PerfectText.enabled = false;
        }
        else if (isMissed)
        {

            print("Missed!");
            StartCoroutine("MissedHit");
        }
    }

    IEnumerator MissedHit()
    {
        objFall.missText.enabled = true;
        yield return new WaitForSeconds(3f);
        objFall.missText.enabled = false;
        SceneManager.LoadScene(0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyLibrary
{
    public class MyTouch
    {
        //2D Collider를 이용한 touch 객체 얻기
        //http://am-kwon.blogspot.com/2014/08/unity3d-2d-touch-sprite.html
        public static GameObject[] TouchObject()
        {
            List<GameObject> touchObj = new List<GameObject>();

            for (int i = 0; i < Input.touchCount; i++)
            {
                if (Input.GetTouch(i).phase == TouchPhase.Began)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position), Vector2.zero);
                    if (hit)
                    {
                        touchObj.Add(hit.collider.gameObject);
                    }
                }
            }

            return touchObj.ToArray();
        }
    }
}
 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
 public class ButtonPressed : MonoBehaviour
 {
    public int offsetX, offsetY;
    public RectTransform[] textRect;
    Vector3[] pos;
    
    void Start()
    {
        pos = new Vector3[textRect.Length];
        for(int i = 0; i < pos.Length; i++){
            pos[i] = textRect[i].localPosition;
        }
        
    }
     public void Down()
     {
        for(int i = 0; i < pos.Length; i++){
            textRect[i].localPosition = new Vector3(pos[i].x + (float)offsetX, pos[i].y - (float)offsetY, pos[i].z);
        }
    }
 
    public void Up()
    {
        for(int i = 0; i < pos.Length; i++){
            textRect[i].localPosition = pos[i];
        }
    }
 }
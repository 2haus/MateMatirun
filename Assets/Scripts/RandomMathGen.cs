using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomMathGen : MonoBehaviour
{
    int a;
    int b;
    int[] extra = new int[9];
    public Text[] text;
    int[] answers;
    int operation;
    int result;
    int randomAns;
    // Start is called before the first frame update
    void Start()
    {
        a = Random.Range(0, 10);
        b = Random.Range(0, 10);
        result = Random.Range(1, 3);
        operation = Random.Range(1, 3);
        randomAns = Random.Range(1, 4);

        for(int j = 0; j < 2; j++){
            for(int i = 0; i < extra.Length; i++){
                extra[i] = Random.Range(1, 10);
            }
            for(int x = 0; x < extra.Length; x++){
                extra[x] = Random.Range(1, 10);
            }
            for(int y = 0; y < extra.Length; y++){
                extra[y] = Random.Range(1, 10);
            }

        
            if(result == 1){
                text[0].text = (a).ToString()+ "+" +(b).ToString();
                Addition();
            }
            else if(result == 2){
                text[0].text = (a).ToString()+ "-" +(b).ToString();
                Minus();
            }
            else if(result == 3){
                text[0].text = (a).ToString()+ "*" +(b).ToString();
                Multiplication();
            }
        }
    }

    void Addition(){
        if(result == 1){
            if(randomAns == 1){
                text[1].text = (a+b).ToString();
                text[2].text = (a+b+extra[0]).ToString();
                text[3].text = (a+b+extra[1]).ToString();
                text[4].text = (a+b+extra[2]).ToString();
            }
            else if(randomAns == 2){
                text[1].text = (a+b+extra[0]).ToString();
                text[2].text = (a+b).ToString();
                text[3].text = (a+b+extra[1]).ToString();
                text[4].text = (a+b+extra[2]).ToString();
            }
            else if(randomAns == 3){
                text[1].text = (a+b+extra[0]).ToString();
                text[2].text = (a+b+extra[1]).ToString();
                text[3].text = (a+b).ToString();
                text[4].text = (a+b+extra[2]).ToString();
            }
            else if(randomAns == 4){
                text[1].text = (a+b+extra[0]).ToString();
                text[2].text = (a+b+extra[1]).ToString();
                text[3].text = (a+b+extra[2]).ToString();
                text[4].text = (a+b).ToString();
            }
        }
    }

    void Minus(){
        if(result == 2){
            if(randomAns == 1){
                text[1].text = (a-b).ToString();
                text[2].text = (a-b-extra[0]).ToString();
                text[3].text = (a-b-extra[1]).ToString();
                text[4].text = (a-b-extra[2]).ToString();
            }
            else if(randomAns == 2){
                text[1].text = (a-b-extra[0]).ToString();
                text[2].text = (a-b).ToString();
                text[3].text = (a-b-extra[1]).ToString();
                text[4].text = (a-b-extra[2]).ToString();
            }
            else if(randomAns == 3){
                text[1].text = (a-b-extra[0]).ToString();
                text[2].text = (a-b-extra[1]).ToString();
                text[3].text = (a-b).ToString();
                text[4].text = (a-b-extra[2]).ToString();
            }
            else if(randomAns == 4){
                text[1].text = (a-b-extra[0]).ToString();
                text[2].text = (a-b-extra[1]).ToString();
                text[3].text = (a-b-extra[2]).ToString();
                text[4].text = (a-b).ToString();
            }
        }
    }

    void Multiplication(){
        if(result == 3){
            if(randomAns == 1){
                text[1].text = (a*b).ToString();
                text[2].text = (a*b+extra[0]).ToString();
                text[3].text = (a*b+extra[1]).ToString();
                text[4].text = (a*b+extra[2]).ToString();
            }
            else if(randomAns == 2){
                text[1].text = (a*b+extra[0]).ToString();
                text[2].text = (a*b).ToString();
                text[3].text = (a*b+extra[1]).ToString();
                text[4].text = (a*b+extra[2]).ToString();
            }
            else if(randomAns == 3){
                text[1].text = (a*b+extra[0]).ToString();
                text[2].text = (a*b+extra[1]).ToString();
                text[3].text = (a*b).ToString();
                text[4].text = (a*b+extra[2]).ToString();
            }
            else if(randomAns == 4){
                text[1].text = (a*b+extra[0]).ToString();
                text[2].text = (a*b+extra[1]).ToString();
                text[3].text = (a*b+extra[2]).ToString();
                text[4].text = (a*b).ToString();
            }
        }
    }
}

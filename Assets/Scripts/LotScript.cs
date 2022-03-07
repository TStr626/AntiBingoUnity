using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LotScript : MonoBehaviour
{
    private int[] lot;
    private int turn;
    
    private int lotCount = 75;
    // Start is called before the first frame update
    void Start()
    {
        lotInit();
    }

    void lotInit(){
        lot = new int[lotCount];
        for(int i=0; i<lotCount; i++){
            lot[i] = i+1;
        }
        lotShuffle();
    }
    void lotShuffle(){
        int temp;
        int rand;
        for(int i=0; i<lotCount; i++){
            temp = lot[i];
            rand = UnityEngine.Random.Range(0,lotCount);
            lot[i] = lot[rand];
            lot[rand] = temp;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public int lotGet(int turn){
        return lot[turn-1];
    }
}

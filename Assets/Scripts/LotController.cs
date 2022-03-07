using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LotController : MonoBehaviour
{
    public GameObject lot;
    private int lotCur;
    // Start is called before the first frame update
    void Start()
    {
        lot = GameObject.Find("Lot");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int lotGet(int turn){
        if(turn<=75){
            lotCur = lot.GetComponent<LotScript>().lotGet(turn);
        }
        return lotCur;
    }
}

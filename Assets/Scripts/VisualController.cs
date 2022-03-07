using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualController : MonoBehaviour
{
    public GameObject CurNumber;
    public GameObject CurScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetCurNumber(int num){
        CurNumber.GetComponent<CurNumberScript>().SetCurNumber(num);
    }
    public void SetCurScore(int turn, int score){
        CurScore.GetComponent<CurScoreScript>().SetCurScore(turn, score);
    }
}

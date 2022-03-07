using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurScoreScript : MonoBehaviour
{
    public GameObject CurScore;
    private int score;
    private int turn;
    public Text TextTurn;
    public Text TextScore;

    // Start is called before the first frame update
    void Start()
    {
        turn = 0;
        score = 1;
        TextTurn.text = turn.ToString();
        TextScore.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetCurScore(int curturn,int curscore){
        turn = curturn;
        score = curscore;
        TextTurn.text = turn.ToString();
        TextScore.text = score.ToString();
    }
}

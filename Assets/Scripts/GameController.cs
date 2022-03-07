using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    enum GameState{
        ACTIVE,
        STOP,
        OUT
    }
    public GameObject Card;
    public GameObject Lot;
    public GameObject CurScore;
    public int turn;
    public int num;
    public int score;
    GameState gameState;
    bool isBingo;
    bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        turn = 0;
        Lot = GameObject.Find("Lot");
        Card = GameObject.Find("CardPrefab");
        gameState = GameState.ACTIVE;
    }

    // Update is called once per frame
    void Update()
    {
        isActive = this.GetComponent<CardController>().cardActiveCheck();
        isBingo = this.GetComponent<CardController>().cardBingoCheck();
        if(gameState == GameState.ACTIVE){
            if(isBingo == true){
                score = 0;
                gameState = GameState.OUT;
                this.GetComponent<VisualController>().SetCurScore(turn, score);
                GameEndOUT();
            }else{
              score = this.GetComponent<CardController>().cardGetScore();
              this.GetComponent<VisualController>().SetCurScore(turn, score);
            }
        }
    }
    public void OnClickGo(){
        if(isActive == true || isBingo == true || turn>=75){
            // button inactive
            return;
        }
        turn++;
        num = this.GetComponent<LotController>().lotGet(turn);
        this.GetComponent<CardController>().cardActivate(num);
        this.GetComponent<VisualController>().SetCurNumber(num);
        this.GetComponent<VisualController>().SetCurScore(turn ,score);
    }
    public void OnClickStop(){
        if(gameState != GameState.ACTIVE){
            SceneManager.LoadScene("TitleScene");
            return;
        }
        if(isActive == false){
            gameState = GameState.STOP;
            GameEndSTOP();
        }else{
            // There is an CLOSE_ACTIVE cell
        }
    }
    void GameEndOUT(){
        CurScore.GetComponent<Image>().color = new Color(1.0f, 0.8f, 0.8f, 1.0f);
    }
    void GameEndSTOP(){
        CurScore.GetComponent<Image>().color = new Color(0.8f, 0.8f, 1.0f, 1.0f);
    }
}

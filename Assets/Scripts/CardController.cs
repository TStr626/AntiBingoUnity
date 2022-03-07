using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{   
    public GameObject cardPrefab;
    private GameObject canvas;
    private GameObject card;
    private Vector3 pos = new Vector3(0f,0f,0f);
    private int cellCount = 25;
    private int[] cardLine;
    public int cardScore;
    void Start()
    {  
        canvas = GameObject.Find("Canvas");
        pos.x=-170;
        card = new GameObject();
        card = Instantiate(cardPrefab, pos, Quaternion.identity);
        card.transform.SetParent(canvas.transform,false);
        cardLine = new int[5];
        cardScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        cardScore = cardScoreCheck();
        cardBingoCheck();
    }
    public int cardScoreCheck(){
        int openCount = 0;
        for(int i=0; i<cellCount; i++){
            CellState cellState;
            cellState = card.transform.GetChild(i).GetComponent<CellScript>().cellGetState();
            if(CellState.IS_OPEN.HasFlag(cellState)){
                openCount++;
            }
        }
        return openCount;
    }

    public void cardActivate(int num){
        int cellNum;
        for(int i=0; i<cellCount; i++){
            cellNum = card.transform.GetChild(i).GetComponent<CellScript>().cellGetNum();
            if(cellNum==num){
                CellState cellState;
                cellState = card.transform.GetChild(i).GetComponent<CellScript>().cellGetState();
                if(cellState == CellState.CLOSE){
                    cellState = CellState.CLOSE_ACTIVE;
                }else{
                    cellState = CellState.CLOSE_ACTIVE_BOMB;
                }
                card.transform.GetChild(i).GetComponent<CellScript>().cellSetState(cellState);
            }
        }
    }
    public bool cardActiveCheck(){
        CellState cellState;
        for(int i=0; i<cellCount; i++){
            cellState = card.transform.GetChild(i).GetComponent<CellScript>().cellGetState();
            if(CellState.IS_ACTIVE.HasFlag(cellState)){
                return true;
            }
        }
        return false;
    }
    public bool cardBingoCheck(){
        bool isBingo = false;
        // column
        for(int i=0; i<5; i++){
            for(int j=0; j<5; j++){
                cardLine[j]=i*5+j;
            }
            isBingo |= cardBingoCheckLine(cardLine);
        }
        // row
        for(int i=0; i<5; i++){
            for(int j=0; j<5; j++){
                cardLine[j]=j*5+i;
            }
            isBingo |= cardBingoCheckLine(cardLine);
        }
        // diagonal
        for(int i=0; i<5; i++){
            cardLine[i]=6*i;
        }
        isBingo |= cardBingoCheckLine(cardLine);
        for(int i=0; i<5; i++){
            cardLine[i]=4+4*i;
        }
        isBingo |= cardBingoCheckLine(cardLine);
        return isBingo;
    }
    bool cardBingoCheckLine(int[] cardLine){
        int openCount = 0;
        CellState cellState;
        for(int i=0; i<5; i++){
            cellState=card.transform.GetChild(cardLine[i]).GetComponent<CellScript>().cellGetState();
            if(CellState.IS_OPEN.HasFlag(cellState)){
                openCount++;
            }
        }
        if(openCount==5){
            // BINGO
            for(int i=0; i<5; i++){
                card.transform.GetChild(cardLine[i]).GetComponent<CellScript>().cellSetState(CellState.OPEN_BINGO);
            }
            return true;
        }else if(openCount==4){
            // Reach
            for(int i=0; i<5; i++){
                cellState=card.transform.GetChild(cardLine[i]).GetComponent<CellScript>().cellGetState();
                if(cellState==CellState.CLOSE){
                    card.transform.GetChild(cardLine[i]).GetComponent<CellScript>().cellSetState(CellState.CLOSE_BOMB);
                }else if(cellState==CellState.CLOSE_ACTIVE){
                    card.transform.GetChild(cardLine[i]).GetComponent<CellScript>().cellSetState(CellState.CLOSE_ACTIVE_BOMB);
                }
            }
            return false;
        }else{
            return false;
        }
    }

    public int cardGetScore(){
        return cardScore;
    }

}



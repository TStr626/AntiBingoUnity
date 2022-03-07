using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Flags] public enum CellState
{
    CLOSE = 1,
    CLOSE_BOMB = 2,
    CLOSE_ACTIVE = 4,
    CLOSE_ACTIVE_BOMB = 8,
    OPEN = 16,
    OPEN_CUR = 32,
    OPEN_BINGO = 64,
    IS_CLOSE = CLOSE | CLOSE_BOMB | CLOSE_ACTIVE | CLOSE_ACTIVE_BOMB,
    IS_OPEN = OPEN | OPEN_CUR | OPEN_BINGO,
    IS_ACTIVE = CLOSE_ACTIVE | CLOSE_ACTIVE_BOMB,
    IS_BOMB = CLOSE_BOMB | CLOSE_ACTIVE_BOMB
}
public class CellScript : MonoBehaviour
{
    public GameObject cell;
    private Image cellImage;
    private Sprite[] cellSprites;
    private int cellNum = 0; // [0,75],0 means FREE
    private CellState cellState = CellState.CLOSE;
    public Text cellText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void cellInit(int num){
        cellImage = cell.GetComponent<Image>();
        cellSprites = Resources.LoadAll<Sprite>("CellSprites");
        cellSetNum(num);
        if(num==0){
            // FREE
            cellState = CellState.OPEN;
        }else{
            cellState = CellState.CLOSE;
        }
    }

    // Update is called once per frame
    void Update()
    {
        cellSetText();
        cellSetSprite();
    }

    private void cellSetText(){
        if(CellState.IS_CLOSE.HasFlag(cellState)){
            cellText.text = cellNum.ToString();
        }else{
            cellText.text = "";
        }
    }
    private void cellSetSprite(){
        int num = 0;
        switch(cellState){
            case CellState.CLOSE : num = 0; break;
            case CellState.CLOSE_BOMB : num = 1; break;
            case CellState.CLOSE_ACTIVE : num = 2; break;
            case CellState.CLOSE_ACTIVE_BOMB : num = 3; break;
            case CellState.OPEN : num = 4; break;
            case CellState.OPEN_CUR : num = 5; break;
            case CellState.OPEN_BINGO :num = 6; break;
        }
        cellImage.sprite=cellSprites[num];
    }
    public void cellOnClick(){
        if(CellState.IS_ACTIVE.HasFlag(cellState)){
            cellSetState(CellState.OPEN);
        }
    }
    public void cellSetState(CellState st){
        cellState = st;
    }
    public CellState cellGetState(){
        return cellState;
    }
    public void cellSetNum(int num){
        cellNum = num;
    }
    public int cellGetNum(){
        return cellNum;
    }
}

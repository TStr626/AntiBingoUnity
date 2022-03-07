using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellController : MonoBehaviour
{   
    public GameObject cellPrefab;
    public GameObject card;
    private Vector3 pos = new Vector3(0f,0f,0f);
    private GameObject[] cell;
    private int cellCol = 5;
    private int cellRow = 5;
    private int cellCount = 25;
    private int cellColCount = 15;
    private int[] cellNum;

    void Start()
    {   
        cell = new GameObject[cellCount];
        cellNum = new int[cellColCount];
        for(int i=0; i<cellCount; i++){
            pos.x=-120+60*(i/cellRow);
            pos.y=90-60*(i%cellRow);
            cell[i] = Instantiate(cellPrefab, pos, Quaternion.identity);
            cell[i].transform.SetParent(card.transform, false);   
        }
        cellShuffle();
    }

    void cellShuffle()
    {
        for(int i=0; i<cellCol; i++){
            for(int j=0; j<cellColCount; j++){
                cellNum[j]=(i*cellColCount)+(j+1);
            }
            cellColShuffle();
            for(int j=0; j<cellRow; j++){
                cell[i*cellRow+j].GetComponent<CellScript>().cellInit(cellNum[j]);
            }
        }
        // Center is Free
        cell[12].GetComponent<CellScript>().cellInit(0);
    }
    void cellColShuffle()
    {
        int temp;
        int rand;
        for(int i=0; i<cellColCount; i++){
            temp = cellNum[i];
            rand = UnityEngine.Random.Range(0,cellColCount);
            cellNum[i] = cellNum[rand];
            cellNum[rand] = temp;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClick()
    {
        //cell[0].GetComponent<CellScript>().cellStateChange(CellState.OPEN);
    }
    

}



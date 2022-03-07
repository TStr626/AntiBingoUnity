using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurNumberScript : MonoBehaviour
{
    public GameObject CurNumber;
    private string[] colName = {"B","I","N","G","O"};
    private int num;
    public Text TextCol;
    public Text TextNum;

    // Start is called before the first frame update
    void Start()
    {
        TextCol.text="";
        TextNum.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetCurNumber(int num){
        if(num<=0 || num>75){
            return;
        }
        
        TextCol.text = colName[(num-1)/15];
        TextNum.text = num.ToString();
    }

}

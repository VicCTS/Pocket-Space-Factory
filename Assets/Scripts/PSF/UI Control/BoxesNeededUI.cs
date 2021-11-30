using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxesNeededUI : MonoBehaviour
{

    public GameManager gameManager;
    public Image boxNeededIcon1;
    public Image boxNeededIcon2;
    public Image boxNeededIcon3;
    public Text position1;
    public Text position2;
    public Text position3;

    public int listPosition = 0;

    private void Awake() {
        boxNeededIcon1.GetComponent<Image>();
        boxNeededIcon2.GetComponent<Image>();
        boxNeededIcon3.GetComponent<Image>();
    }

    private void Start() {
        //Omplim les tres caselles per primer cop
        for(int i = 0; i < 3; i++){
            FillNeededBoxesLayout(i);
        }

    }

    private void FillNeededBoxesLayout(int i){
        //Selecciona la imatge necessaria depenent de laposicio en la llista de cada nivell
        if(i==0){
            boxNeededIcon1.sprite = SelectBox(listPosition);
            position1.text = listPosition+1 +"";
            if(gameManager.actualBox > listPosition){
                var tempColor = boxNeededIcon1.color;
                tempColor.a = 1;
                boxNeededIcon1.color = tempColor;
            }
        }else if(i==1){
            boxNeededIcon2.sprite = SelectBox(listPosition + 1);
            position2.text = listPosition+1 + 1 +"";
           if(gameManager.actualBox > listPosition){
                var tempColor = boxNeededIcon2.color;
                tempColor.a = 1;
                boxNeededIcon2.color = tempColor;
            }
        }else if(i==2){
            boxNeededIcon3.sprite = SelectBox(listPosition + 2);
            position3.text = listPosition+1 + 2 +"";
            if(gameManager.actualBox > listPosition){
                var tempColor = boxNeededIcon3.color;
                tempColor.a = 1;
                boxNeededIcon3.color = tempColor;
            }
        }

    }

    //Retorna la imatge necessaria per a cada box de la llista
    private Sprite SelectBox(int listPosition){
        if(Global.requestBox[listPosition] == 1){
            return gameManager.box1;
        }else if(Global.requestBox[listPosition] == 2){
            return gameManager.box2;
        }else if(Global.requestBox[listPosition] == 3){
            return gameManager.box3;
        }
        return null;
    }

    //funcionament dels botons per a passar les box de la llista
    public void SlideRight(){
        if(listPosition < Global.requestBox.Count - 3){
            listPosition++;
        }
        for(int i = 0; i < 3; i++){
            FillNeededBoxesLayout(i);
        }
    }

    public void SlideLeft(){
        if(listPosition > 0){
            listPosition--;
        }
        for(int i = 0; i < 3; i++){
            FillNeededBoxesLayout(i);
        }
    }

    


}

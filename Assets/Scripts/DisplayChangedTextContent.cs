using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayChangedTextContent : MonoBehaviour
{
    [SerializeField] TMP_InputField playerName;
    ResultsKeeper2 rK;
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    void Awake() {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        rK = FindObjectOfType<ResultsKeeper2>();
    }

    void Start() {
        scoreText.text = "You Scored:\n" + scoreKeeper.GetScore(); 
    } 

    public void PrintNewValue (){
        string msg = "new content = '" + playerName.text + "'";
        print (msg);
        if(rK != null){
            string s = playerName.text + " scored " + scoreKeeper.GetScore().ToString() + " points.\n";
            rK.addToList(s);
        }
        print(rK.GetAllResults());
    }
}

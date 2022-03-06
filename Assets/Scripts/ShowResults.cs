using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowResults : MonoBehaviour
{
    ResultsKeeper2 rK;
    [SerializeField] TextMeshProUGUI resultsText;


    void Awake() {  
        rK = FindObjectOfType<ResultsKeeper2>();
    }
    void Start()
    {
        Debug.Log(rK.GetAllResults());
        resultsText.text = rK.GetAllResults();
    }

    
}

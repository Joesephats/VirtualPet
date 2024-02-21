using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //[SerializeField] TMP_Text nameInput;
    [SerializeField] TMP_InputField nameInput;
    [SerializeField] GameObject nameButton;

    [SerializeField] TMP_Text hungerBar;
    //zzz
    //[SerializeField] TMP_Text 

    VirtualPet playerPet;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        nameButton.GetComponent<Button>().interactable = !isInputEmpty();
    }

    bool isInputEmpty()
    {
        string inputFieldContents = nameInput.text;
        if (string.IsNullOrWhiteSpace(inputFieldContents))
        {
            return true;
        }
        return false;
    }

    void AdoptPet()
    {
        playerPet = new VirtualPet(nameInput.text);
    }

}

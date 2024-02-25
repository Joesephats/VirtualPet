//////////////////////////////////////////////
//Assignment/Lab/Project: VirtualPet
//Name: Tristin Gatt
//Section: SGD.213.2172
//Instructor: Brian Sowers
//Date: 02/25/2024
/////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGameButton()
    {
        SceneManager.LoadScene("VirtualPet");
    }
}

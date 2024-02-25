//////////////////////////////////////////////
//Assignment/Lab/Project: VirtualPet
//Name: Tristin Gatt
//Section: SGD.213.2172
//Instructor: Brian Sowers
//Date: 02/25/2024
/////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //adoption UI
    [SerializeField] TMP_InputField nameInput;
    [SerializeField] GameObject nameButton;
    [SerializeField] GameObject petMessage;

    //pet info UI
    [SerializeField] TMP_Text hungerUI;
    [SerializeField] TMP_Text energyUI;
    [SerializeField] TMP_Text happinessUI;
    [SerializeField] TMP_Text petNameUI;

    //pet action buttons
    [SerializeField] Button feedPetButton;
    [SerializeField] Button playWithPetButton;
    [SerializeField] Button putPetSleepButton;

    //pet
    VirtualPet playerPet;

    //gameplay vars. petAdopted controls timer
    bool petAdopted = false;
    [SerializeField] float timerMax = 10;
    [SerializeField] float timerCurrent = 10;



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //enables button if pet name input has data. disables if empty
        nameButton.GetComponent<Button>().interactable = !isInputEmpty();

        //decrements pet stats on timer and updates ui.
        if (petAdopted)
        {
            timerCurrent -= Time.deltaTime;
            if (timerCurrent <= 0)
            {
                timerCurrent = timerMax;

                DecrementPetStats(playerPet);
            }

            //checks if any of the pet stats have hit zero
            CheckPetDead();
        }

        
    }

    //checks if pet name input field is empty
    bool isInputEmpty()
    {
        string inputFieldContents = nameInput.text;
        if (string.IsNullOrWhiteSpace(inputFieldContents))
        {
            return true;
        }
        return false;
    }

    //adopt pet button
    public void AdoptPet()
    {
        //constructs new pet with pet name and sets pet name ui
        playerPet = new VirtualPet(nameInput.text);
        petNameUI.text = playerPet.Name;

        //disables adoption ui
        nameButton.SetActive(false);
        nameInput.gameObject.SetActive(false);
        petMessage.SetActive(false);

        //sets ui for pet stats
        UpdatePetStatsUI(playerPet);

        //enables pet action buttons and sets their methods
        feedPetButton.gameObject.SetActive(true);
        playWithPetButton.gameObject.SetActive(true);
        putPetSleepButton.gameObject.SetActive(true);
        AddPetButtonListeners(playerPet);

        //has pet is now true
        petAdopted = true;
    }

    //call decrement methods in VirtualPet and update ui
    void DecrementPetStats(VirtualPet pet)
    {
        pet.StarvePet();
        pet.BorePet();
        pet.TirePet();

        UpdatePetStatsUI(playerPet);
    }

    //feed pet action button. see Eat in VirtualPet Class
    public void FeedPet(VirtualPet pet)
    {
        pet.Eat();
        UpdatePetStatsUI(pet);
    }

    //rest pet action button. see Eat in VirtualPet Class
    public void PetToSleep(VirtualPet pet)
    {
        pet.Rest();
        UpdatePetStatsUI(pet);
    }

    //play with pet action button. see Eat in VirtualPet Class
    public void PlayWithPet(VirtualPet pet)
    {
        pet.Play();
        UpdatePetStatsUI(pet);
    }

    //update pet stats ui
    void UpdatePetStatsUI(VirtualPet pet)
    {
        hungerUI.text = $"Hunger: {pet.Hunger.ToString()}";
        energyUI.text = $"Energy: {pet.Energy.ToString()}";
        happinessUI.text = $"Happiness: {pet.Happiness.ToString()}";
    }

    //adds methods to virtual pet buttons
    void AddPetButtonListeners(VirtualPet pet)
    {
        feedPetButton.onClick.AddListener(() => FeedPet(pet));
        playWithPetButton.onClick.AddListener(() => PlayWithPet(pet));
        putPetSleepButton.onClick.AddListener(() => PetToSleep(pet));
    }

    //game logic when a pet stat reaches zero
    void HandlePetDead()
    {
        //pet no longer adopted
        petAdopted = false;

        //empty pet stats ui and clear name
        petNameUI.text = "";
        hungerUI.text = "Hunger:";
        energyUI.text = "Energy:";
        happinessUI.text = "Happiness:";

        //disable pet action buttons
        feedPetButton.gameObject.SetActive(false);
        playWithPetButton.gameObject.SetActive(false);
        putPetSleepButton.gameObject.SetActive(false);

        //display adoption message
        petMessage.SetActive(true);
        petMessage.GetComponentInChildren<TMP_Text>().text = $"{nameInput.text} died horribly. Maybe you will take better care of the next one.";

        //clear pet input field and display field and adopt button
        nameInput.text = null;
        nameInput.gameObject.SetActive(true);
        nameButton.gameObject.SetActive(true);
    }

    //checks if any pet stats have hit zero
    void CheckPetDead()
    {
        if (playerPet.Hunger <= 0 || playerPet.Energy <= 0 || playerPet.Happiness <= 0)
        {
            HandlePetDead();
        }
    }
}

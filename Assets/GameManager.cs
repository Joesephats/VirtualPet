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

    [SerializeField] TMP_Text hungerUI;
    [SerializeField] TMP_Text energyUI;
    [SerializeField] TMP_Text happinessUI;

    [SerializeField] TMP_Text petNameUI;

    [SerializeField] Button feedPetButton;
    [SerializeField] Button playWithPetButton;
    [SerializeField] Button putPetSleepButton;

    VirtualPet playerPet;

    bool petAdopted = false;
    [SerializeField] float timerMax = 10;
    [SerializeField] float timerCurrent = 10;



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        nameButton.GetComponent<Button>().interactable = !isInputEmpty();

        if (petAdopted)
        {
            timerCurrent -= Time.deltaTime;
            if (timerCurrent <= 0)
            {
                timerCurrent = timerMax;

                DecrementPetStats(playerPet);

                UpdatePetUI(playerPet);
            }
        }
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

    public void AdoptPet()
    {
        playerPet = new VirtualPet(nameInput.text);
        petNameUI.text = playerPet.Name;

        nameButton.SetActive(false);
        nameInput.gameObject.SetActive(false);

        UpdatePetUI(playerPet);

        feedPetButton.gameObject.SetActive(true);
        playWithPetButton.gameObject.SetActive(true);
        putPetSleepButton.gameObject.SetActive(true);
        AddPetButtonListeners(playerPet);

        petAdopted = true;
    }

    void DecrementPetStats(VirtualPet pet)
    {
        pet.StarvePet();
        pet.BorePet();
        pet.TirePet();

        UpdatePetUI(playerPet);
    }

    public void FeedPet(VirtualPet pet)
    {
        pet.Eat();
        UpdatePetUI(pet);
    }

    public void PetToSleep(VirtualPet pet)
    {
        pet.Rest();
        UpdatePetUI(pet);
    }

    public void PlayWithPet(VirtualPet pet)
    {
        pet.Play();
        UpdatePetUI(pet);
    }

    void UpdatePetUI(VirtualPet pet)
    {
        hungerUI.text = $"Hunger {pet.Hunger.ToString()}";
        energyUI.text = $"Energy {pet.Energy.ToString()}";
        happinessUI.text = $"Happiness {pet.Happiness.ToString()}";
    }

    void AddPetButtonListeners(VirtualPet pet)
    {
        feedPetButton.onClick.AddListener(() => FeedPet(pet));
        playWithPetButton.onClick.AddListener(() => PlayWithPet(pet));
        putPetSleepButton.onClick.AddListener(() => PetToSleep(pet));
    }
}

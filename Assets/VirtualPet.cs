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

public class VirtualPet
{
    //Pet Stats and name
    private string name;
    //range from 1 - 10
    private int hungerLevel;
    private int happinessLevel;
    private int energyLevel;

    //properties for pet stats
    public string Name 
    {
        get { return name; }
        set { name = value; }
    }

    public int Hunger
    {
        get { return hungerLevel; }
        set { hungerLevel = value; }
    }

    public int Happiness
    {
        get { return happinessLevel; }
        set { happinessLevel = value; }
    }

    public int Energy
    {
        get { return energyLevel; }
        set { energyLevel = value; }
    }

    //constructor with name and default starting stats
    public VirtualPet(string newName)
    {
        name = newName;
        hungerLevel = 8;
        happinessLevel = 10;
        energyLevel = 5;
    }

    //constructor for setting custom starting stats
    public VirtualPet(string newName, int startingHunger, int startingHappiness, int startingEnergy)
    {
        name = newName;
        hungerLevel = startingHunger;
        happinessLevel = startingHappiness;
        energyLevel = startingEnergy;
    }

    //give pet rest. uses hunger to reset energy
    public void Rest()
    {
        if (energyLevel <= 4)
        {
            energyLevel = 10;
            hungerLevel -= 4;
            if (hungerLevel < 1)
            {
                hungerLevel = 1;
            }
        }
    }

    //give pet food. gives pet 5 hunger
    public void Eat()
    {
        hungerLevel += 5;
        if (hungerLevel > 10)
        {
            hungerLevel = 10;
        }
    }

    //play with pet. uses hunger and energy to reset happiness
    public void Play()
    {
        happinessLevel += 3;
        if (happinessLevel > 10)
        {
            happinessLevel = 10;
        }

        TirePet();
        StarvePet();
    }

    //decrement each stat. called on timer
    public void StarvePet()
    {
        hungerLevel -= 1;
    }
    public void BorePet()
    {
        happinessLevel -= 1;
    }
    public void TirePet()
    {
        energyLevel -= 1;
    }
}

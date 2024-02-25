using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualPet
{
    private string name;
    private int hungerLevel;
    private int happinessLevel;
    private int energyLevel;

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

    public VirtualPet(string newName)
    {
        name = newName;
        hungerLevel = 8;
        happinessLevel = 10;
        energyLevel = 5;
    }

    public VirtualPet(string newName, int startingHunger, int startingHappiness, int startingEnergy)
    {
        name = newName;
        hungerLevel = startingHunger;
        happinessLevel = startingHappiness;
        energyLevel = startingEnergy;
    }

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

    public void Eat()
    {
        hungerLevel += 5;
        if (hungerLevel > 10)
        {
            hungerLevel = 10;
        }
    }

    public void Play()
    {
        happinessLevel += 3;
        if (happinessLevel > 10)
        {
            happinessLevel = 10;
        }

        energyLevel -= 1;
        hungerLevel -= 1;
    }

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

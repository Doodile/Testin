using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorTest_Nick : PuzzleBase_Nick
{
    public int RequiredFuel = 2;
    int currentFuel = 0;
    ParticleSystem Exhaust;
    Light ActiveLight;
    public ParticleSystem[] activateParticles;

    bool generatorOn = false;
    //bool breakerOn = false;

    public GeneratorPuzzle_Nick puzzle;
    ToolTipSpawner_Nick toolTip;

    PlayerInteract_Nick Inventory;
    void Awake()
    {
        Inventory = GameObject.Find("PlayerFab").GetComponent<PlayerInteract_Nick>();
        Exhaust = gameObject.GetComponentInChildren<ParticleSystem>();
        ActiveLight = gameObject.GetComponentInChildren<Light>();
        toolTip = GetComponent<ToolTipSpawner_Nick>();
    }

    void Start()
    {
        Exhaust.Stop();
        ActiveLight.enabled = false;
    }

    public override void Interact()
    {
        if(!generatorOn)
        {
            if (currentFuel == RequiredFuel)
            {
                StartGenerator();
                if(toolTip)
                {
                    toolTip.UpdateToolTipText(" ");
                }
            }
            else if(Inventory.IsInInventory(EInventoryItems.FUEL))
            {
                SetProgress(EPuzzleProgress.IN_PROGRESS);
                Inventory.RemoveFromInventory(EInventoryItems.FUEL);
                ++currentFuel;
                if(currentFuel == RequiredFuel && toolTip)
                {
                    toolTip.UpdateToolTipText("Press 'Use' to Turn On Generator");
                }
            }
            
        }
    }

    void StartGenerator()
    {
        generatorOn = true;
        Exhaust.Play();
        ActiveLight.enabled = true;
        CompletePuzzle();

        foreach (var item in activateParticles)
        {
            item.Play();
        }
    }

}

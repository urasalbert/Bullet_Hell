using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private GameObject Buttons;
    [SerializeField] private GameObject Upgrades;
    [SerializeField] private GameObject CharacterScreen;

    public void OpenUpgrades()
    {
        Buttons.SetActive(false);
        Upgrades.SetActive(true);
    }
    public void CloseUpgrades()
    {
        Buttons.SetActive(true);
        Upgrades.SetActive(false);
    }
    public void OpenCharChoose()
    {
        CharacterScreen.SetActive(true);
        Buttons.SetActive(false);
    }


}

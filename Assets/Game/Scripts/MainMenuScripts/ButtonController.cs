using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private GameObject Buttons;
    [SerializeField] private GameObject Upgrades;

    void OpenUpgrades()
    {
        Buttons.SetActive(false);
        Upgrades.SetActive(true);
    }
}

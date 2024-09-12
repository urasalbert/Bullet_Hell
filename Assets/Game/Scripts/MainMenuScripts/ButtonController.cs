using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private GameObject Buttons;
    [SerializeField] private GameObject Upgrades;
    [SerializeField] private GameObject CharacterScreen;
    [SerializeField] private GameObject ConfirmQuitPanel;
    [SerializeField] private GameObject Settings;

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
    public void CloseCharChoose()
    {
        CharacterScreen.SetActive(false);
        Buttons.SetActive(true);
    }
    public void QuitButton()
    {
        ConfirmQuitPanel.SetActive(true);
    }
    public void ConfirmQuitButton()
    {
        Application.Quit();
    }
    public void DeclineQuitButton()
    {
        ConfirmQuitPanel.SetActive(false);
    }
    public void SettingsBackButton()
    {
        Settings.SetActive(false);
        Buttons.SetActive(true);
    }
    public void OpenSettings()
    {
        Settings.SetActive(true);
        Buttons.SetActive(false);
    }
}

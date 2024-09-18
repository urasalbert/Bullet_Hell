using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    // Very basic code for play button

    public void playButton()
    {
        if (CharChooseButton.Instance.isLevisSelected)
        {
            SceneManager.LoadScene("Level1Game");
            Time.timeScale = 1.0f;
        }
    }

}

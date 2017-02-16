﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DebugLevelSwitcher : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneManager.LoadScene("MainMenu");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SceneManager.LoadScene("Lobby_01");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SceneManager.LoadScene("Lobby_02");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            SceneManager.LoadScene("Lobby_03");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            SceneManager.LoadScene("DiningRoom");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            SceneManager.LoadScene("BowlingRoom");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            SceneManager.LoadScene("KaminsBoss");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SceneManager.LoadScene("BallroomBlitz");
        }
        else if (Input.GetKeyDown(KeyCode.Minus))
        {
            SceneManager.LoadScene("BreakToTheBeat");
        }
        else if (Input.GetKeyDown(KeyCode.Equals))
        {
            SceneManager.LoadScene("DanceFloorRumble");
        }
		else if (Input.GetKeyDown(KeyCode.F1))
		{
			SceneManager.LoadScene("DiningRoom02");
		}
    }

}

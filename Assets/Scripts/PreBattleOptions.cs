using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreBattleOptions : MonoBehaviour
{
    public FlipAllCoins FlipAllCoins;
    public List<GameObject> coins = new List<GameObject>();

    public List<GameObject> players = new List<GameObject>();

    public GameObject SkillPanel;

    public Button reOrderButton;
    public Button StartButton;
    public Button SkillButton;

    public bool dragEnabled;
    public bool skillSelectionEnabled;

    public void EnablePlacement()
    {
        dragEnabled = !dragEnabled;
        if (dragEnabled)
        {
            foreach (GameObject p in players)
            {
                p.GetComponent<Drag>().canDrag = true;
                p.GetComponent<Drag>().highlight.SetActive(true);
            }

            //Disable Other Pre-BattleMenu Buttons while draggable is on
            StartButton.interactable = false;
            SkillButton.interactable = false;
        }
        else
        {
            foreach (GameObject p in players)
            {
                p.GetComponent<Drag>().canDrag = false;
                p.GetComponent<Drag>().highlight.SetActive(false);
            }

            //Enable Other Pre-BattleMenu Buttons while draggable is off
            StartButton.interactable = true;
            SkillButton.interactable = true;
        }

    }
    public void EnableSkillAssignment()
    {
        skillSelectionEnabled = !skillSelectionEnabled;
        if (skillSelectionEnabled)
        {
            foreach (GameObject p in players)
            {
                p.GetComponent<Drag>().skillPanel = SkillPanel;
                p.GetComponent<Drag>().canPlace = true;
            }
            //Disable Other Pre-BattleMenu Buttons while selection is on
            reOrderButton.interactable = false;
            StartButton.interactable = false;
        }
        else
        {
            //Sets the x and y of the Camera
            GameObject.Find("Main Camera").transform.position = Vector2.zero;
            GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize = 5f;
            foreach (GameObject p in players)
            {
                SkillPanel.SetActive(false);
                p.GetComponent<Drag>().canPlace = false;
            }
            //Enable Other Pre-BattleMenu Buttons while selection is off
            reOrderButton.interactable = true;
            StartButton.interactable = true;
        }

    }
    public void StartGame()
    {
        //Removes all buttons
        reOrderButton.gameObject.SetActive(false);
        StartButton.gameObject.SetActive(false);
        SkillButton.gameObject.SetActive(false);

        //Enable Battle Menu
        FlipAllCoins.enabled = true;
        foreach (GameObject coin in coins)
        {
            coin.SetActive(true);
        }
    }
    public void EnablePreBattleMenu()
    {
        reOrderButton.gameObject.SetActive(true);
        StartButton.gameObject.SetActive(true);
        SkillButton.gameObject.SetActive(true);

        //Diables Battle Menu
        FlipAllCoins.enabled = true;
        foreach (GameObject coin in coins)
        {
            coin.SetActive(false);
        }
    }
}

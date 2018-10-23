using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    private MenuManager menuManager;            //reference to MenuManager script

    public GameObject[] otherEps;               //contains all the other episode buttons
    public Sprite backgroundImage;
    public Sprite[] images;                     //sprite images

    public Image background;
    private Image img;                          //image component
    public int state;                           //current state of button

    public bool interactable = true;            //is it interactable

    void Start()
    {
        menuManager = FindObjectOfType<MenuManager>();              //find the gameobject holding the MenuManager component

        img = GetComponent<Image>();                                //get image component
        img.sprite = images[state];                                     //set to the first sprite image
    }

    //every time gameobject is clicked on
    private void OnMouseDown()
    {
        //if it is interactable
        if (interactable)
        {
            //if in certain state, either set of button states, or moving to the next scene
            switch (state)
            {
                case 0:
                    //set all buttons to idle, except current button
                    for (int i = 0; i < otherEps.Length; i++)
                    {
                        otherEps[i].GetComponent<ButtonManager>().state = 0;
                    }
                    background.sprite = backgroundImage;
                    state = 1;
                    break;
                case 1:
                    //double-click on button to go to next episode
                    if (gameObject.name == "Episode 1")
                    {
                        menuManager.GoToScene("360");
                    }
                    if (gameObject.name == "Episode 2")
                    {
                        menuManager.GoToScene("EP2");
                    }
                    if (gameObject.name == "Episode 3")
                    {
                        menuManager.GoToScene("EP3");
                    }
                    break;
                default:
                    print("Not a state!");
                    break;
            }
        }
    }

    private void Update()
    {
        //every frame, check state to change image sprite
        switch (state)
        {
            case 0:
                img.sprite = images[0];
                break;
            case 1:
                img.sprite = images[1];
                break;
        }
    }
}

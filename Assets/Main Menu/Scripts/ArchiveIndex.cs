using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArchiveIndex : MonoBehaviour
{
    public GameObject pageIndex;

    public Sprite[] images;                     //sprite images
    private SpriteRenderer img;                          //image component

    public int state = 0;

    void Start()
    {
        pageIndex.SetActive(false);

        img = GetComponent<SpriteRenderer>();                                //get image component
        img.sprite = images[state];                                     //set to the first sprite image
    }

    //every time gameobject is clicked on
    private void OnMouseDown()
    {
        ArchiveIndex[] otherIndexes = FindObjectsOfType<ArchiveIndex>();
        //if in certain state, either set of button states, or moving to the next scene
        switch (state)
        {
            case 0:
                for (int i = 0; i < otherIndexes.Length; i++)
                {
                    otherIndexes[i].state = 0;
                    otherIndexes[i].ChangeState();
                    otherIndexes[i].pageIndex.SetActive(false);
                }

                pageIndex.SetActive(true);
                state = 1;
                break;
            case 1:
                pageIndex.SetActive(false);
                state = 0;
                break;
            default:
                print("Not a state!");
                break;
        }

        ChangeState();
    }

    private void ChangeState()
    {
        //every frame, check state to change image sprite
        img.sprite = images[state];
    }
}

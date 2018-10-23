using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveImages : MonoBehaviour {

    public Sprite[] images;                     //sprite images
    private SpriteRenderer img;                          //image component

    void Start()
    {
        img = GetComponent<SpriteRenderer>();                                //get image component
        img.sprite = images[0];                                     //set to the first sprite image
    }

    private void OnMouseOver()
    {
        img.sprite = images[1];
    }

    private void OnMouseExit()
    {
        img.sprite = images[0];
    }
}

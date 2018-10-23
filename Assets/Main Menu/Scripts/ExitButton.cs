using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour {

    private MenuManager menu;
    private SpriteRenderer spriteRend;
    public Sprite[] images;

    private void Start()
    {
        menu = FindObjectOfType<MenuManager>();
        spriteRend = GetComponent<SpriteRenderer>();
        spriteRend.sprite = images[0];
    }

    private void OnMouseEnter()
    {
        spriteRend.sprite = images[1];
    }

    private void OnMouseDown()
    {
        menu.Archive(false);
    }

    private void OnMouseExit()
    {
        spriteRend.sprite = images[0];
    }
}

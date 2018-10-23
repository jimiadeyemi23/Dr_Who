using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArchiveController : MonoBehaviour
{

    public GameObject archiveMenu;

    public Sprite[] images;
    private Image activeImage;
    private BoxCollider2D boxCollider;

    private Animator archiveAnimator;
    private Button archiveButton;

    private bool stayAsSpin = false;
    private IEnumerator coroutine;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        activeImage = GetComponent<Image>();
        archiveAnimator = GetComponent<Animator>();
        archiveButton = GetComponent<Button>();

        activeImage.sprite = images[0];

        coroutine = AnimateBook(1.5f);
    }

    void OnMouseDown()
    {
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("Episode");

        for (int i = 0; i < buttons.Length; i++)
            buttons[i].GetComponent<Button>().interactable = false;

        activeImage.sprite = images[2];
        stayAsSpin = true;

        archiveAnimator.SetFloat("speedValue", 0.5f);
        StartCoroutine(coroutine);
    }

    private void OnMouseOver()
    {
        if (!stayAsSpin)
            activeImage.sprite = images[1];
    }

    private void OnMouseExit()
    {
        if (!stayAsSpin)
            activeImage.sprite = images[0];
    }

    IEnumerator AnimateBook(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        activeImage.sprite = images[0];
        archiveMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}

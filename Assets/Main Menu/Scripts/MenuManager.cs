using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    private MusicPlayer musicPlayer;            //reference to musicPlayer
    public GameObject[] menus;
    public Sprite[] archiveImages;

    private float timer;
    private bool startTimer = false;

    private Animator archiveAnimator;

    private void Start()
    {
        musicPlayer = FindObjectOfType<MusicPlayer>();

        for (int i = 0; i < menus.Length; i++)
        {
            menus[i].SetActive(false);
        }

        if (musicPlayer.skipSplash)
        {
            menus[1].SetActive(true);
        }
        else
        {
            menus[0].SetActive(true);
        }

        archiveAnimator = GameObject.FindGameObjectWithTag("Archive").GetComponent<Animator>();
    }

    public void ClickButton(int num)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            menus[i].gameObject.SetActive(false);
        }

        menus[num].gameObject.SetActive(true);
    }

    public void Settings(bool active)
    {
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("Episode");

        if (active)
        {
            for (int i = 0; i < buttons.Length; i++)
                buttons[i].GetComponent<ButtonManager>().interactable = false;
            menus[3].SetActive(true);
        }
        else
        {
            for (int i = 0; i < buttons.Length; i++)
                buttons[i].GetComponent<ButtonManager>().interactable = true;
            menus[3].SetActive(false);
        }
    }

    public void Archive(bool active)
    {
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("Episode");
        GameObject archive = GameObject.FindGameObjectWithTag("Archive");

        if (active)
        {
            for (int i = 0; i < buttons.Length; i++)
                buttons[i].GetComponent<ButtonManager>().interactable = false;

            archive.GetComponent<Button>().enabled = false;
            archive.GetComponent<Image>().sprite = archiveImages[1];

            archiveAnimator.SetFloat("speedValue", 0.5f);
            archiveAnimator.Play("Archive01", -1, 0f);
            startTimer = true;
        }
        else
        {
            for (int i = 0; i < buttons.Length; i++)
                buttons[i].GetComponent<ButtonManager>().interactable = true;

            archive.GetComponent<Button>().enabled = true;
            archive.GetComponent<Image>().sprite = archiveImages[0];

            startTimer = false;

            archiveAnimator.Play("Archive01", -1, 0f);
            archiveAnimator.SetFloat("speedValue", 0f);

            menus[2].SetActive(false);
        }
    }

    private void Update()
    {
        if (startTimer)
        {
            timer += 1 * Time.deltaTime;
            if (timer >= 1.5f)
                menus[2].SetActive(true);
        }
        else
            timer = 0;
    }

    public void GoToScene(string newScene)
    {
        AudioSource music = musicPlayer.gameObject.GetComponent<AudioSource>();
        music.Stop();
        SceneManager.LoadScene(newScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

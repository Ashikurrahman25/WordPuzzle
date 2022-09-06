using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseDialog : Dialog {

    public bool gotHint;
    public GameObject winPanel;
    public GameObject lostPanel;
    public GameObject quizPanel;
    public Text reasoningText;

    protected override void Start()
    {
        base.Start();
    }

    public void OnContinueClick()
    {
        Sound.instance.PlayButton();
        Close();
    }

    public void OnQuitClick()
    {
        Application.Quit();
    }

    public void OnMenuClick()
    {
        CUtils.LoadScene(0, true);
        Sound.instance.PlayButton();
        Close();
    }

    public void OnShareClick()
    {
        Sound.instance.PlayButton();
        Close();
    }

    public void OnHowToPlayClick()
    {
        Sound.instance.PlayButton();
        DialogController.instance.ShowDialog(DialogType.HowtoPlay);
    }

    public void CheckAnswer(bool isCorrect)
    {
        if (isCorrect)
        {
            if (MainController.instance.gameLevel.quizes[MainController.instance.currentHint].isCorrect)
            {
                gotHint = true;
                winPanel.SetActive(true);
                quizPanel.SetActive(false);
            }
            else
            {
                gotHint = false;
                lostPanel.SetActive(true);
                quizPanel.SetActive(false);
                reasoningText.text = MainController.instance.gameLevel.quizes[MainController.instance.currentHint].reasoning;
            }
        }
        else
        {
            if (MainController.instance.gameLevel.quizes[MainController.instance.currentHint].isCorrect)
            {
                gotHint = false;
                lostPanel.SetActive(true);
                quizPanel.SetActive(false);
                reasoningText.text = MainController.instance.gameLevel.quizes[MainController.instance.currentHint].reasoning;
            }
            else
            {
                gotHint = true;
                winPanel.SetActive(true);
                quizPanel.SetActive(false);
            }
        }

        MainController.instance.currentHint++;
    }

    public void CloseHint()
    {
        if (gotHint)
            WordRegion.instance.ShowHint();

        Close();
    }
}

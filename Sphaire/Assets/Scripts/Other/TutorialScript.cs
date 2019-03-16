using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class TutorialScript : MonoBehaviour
{

    public GuideDialogue dialogue;
    public TextMeshProUGUI tutorialText;
    private string sentence;

    private Queue<string> sentences;

    private void Start() {
        sentences = new Queue<string>();
        sentences.Clear();

        foreach(string sentenceToQueue in dialogue.sentences)
        {
            sentences.Enqueue(sentenceToQueue);
        }

//Call each dialogue for each touch.
        sentence = sentences.Dequeue();
        NextSentence();
        while(sentences.Count != 0)
        {
            if(Input.touchCount > 0)
            {
                sentence = sentences.Dequeue();
                NextSentence();
            }
        }
    }

//Print Next Sentence.
    private void NextSentence()
    {
        tutorialText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            tutorialText.text += letter;
        }
    }
}

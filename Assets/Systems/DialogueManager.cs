using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> _sentences;

    public GameObject _dialogueBox;

    public TMP_Text _nameText;
    public TMP_Text _dialogueText;

    public float _charPerSec;

    public bool _isInDialogue;
    public bool _finishedDialogue;

    private void Start()
    {
        _sentences = new Queue<string>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            DisplayNextSentence();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        _isInDialogue = true;

        _dialogueBox.SetActive(true);
        
        _sentences.Clear();

        _nameText.text = dialogue._name;

        foreach (string sentence in dialogue._sentences)
        {
            _sentences.Enqueue(sentence);
        }
    }

    public void DisplayNextSentence()
    {
        if (_sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = _sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        float waitTime = 1 / _charPerSec;
        _dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            _dialogueText.text += letter;
            yield return new WaitForSeconds(waitTime);
        }
    }

    private void EndDialogue()
    {
        _isInDialogue = false;
        _finishedDialogue = true;
        
        _dialogueBox.SetActive(false);
        Debug.Log("End of conversation");
    }
}

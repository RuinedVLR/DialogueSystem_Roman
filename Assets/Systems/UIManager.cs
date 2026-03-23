using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class UIManager : MonoBehaviour
{
    [SerializeField] bool debugEnabled = false;

    [Header("Interact Prompt")]
    [SerializeField] private TMP_Text promptText;
    [SerializeField] private string prompt;

    [Header("Interact Message")]
    [SerializeField] float messageDuration = 3.0f;
    [SerializeField] float fadeOutTime = 0.5f;

    [SerializeField] private TMP_Text messageText;
    private Coroutine messageFadeCoroutine;

    [Header("Dialoge")]
    // reference TMP IMage
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;





    private void Awake()
    {
        DisplayMessage("");
        HidePrompt();

        HideDialoguePanel();
    }



    #region Prompt

    public void ShowPrompt()
    {
        promptText.text = prompt;
        ClearMessage();
    }

    public void HidePrompt()
    {
        promptText.text = "";
    }

    #endregion

    #region Message

    public void DisplayMessage(string message)
    {

        // currentMessage = message;
        if (messageFadeCoroutine != null)
        {
            StopCoroutine(messageFadeCoroutine);
        }

        messageFadeCoroutine = StartCoroutine(DisplayMessageAndFade(message));
    }

    public void ClearMessage()
    {
        if (messageFadeCoroutine != null)
        {
            StopCoroutine(messageFadeCoroutine);
        }

        messageText.text = "";
    }

    private IEnumerator DisplayMessageAndFade(string message)
    {
        messageText.text = message;
        messageText.alpha = 1;

        float elapsedTime = 0f;

        yield return new WaitForSeconds(messageDuration); // Wait before fading out

        Color originalColor = messageText.color;

        while (elapsedTime < messageDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeOutTime);

            messageText.alpha = alpha;

            yield return null;
        }
        messageText.text = "";
    }

    #endregion

    #region Dialogue

    public void ShowDialoguePanel()
    {
        dialoguePanel.SetActive(true);
    }

    public void HideDialoguePanel()
    {
        dialoguePanel.SetActive(false);
    }


    #endregion

}

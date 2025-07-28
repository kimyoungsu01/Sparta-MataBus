using UnityEngine;
using UnityEngine.UI;

public class NPCDialogue : MonoBehaviour
{
    public GameObject dialoguePanel;        // ��ȭâ UI
    public Text dialogueText;               // ��ȭ ���� �ؽ�Ʈ
    public string[] dialogueLines;          // ��ȭ ����
    private int currentLine = 0;
    private bool playerInRange = false;
    private bool isDialogueActive = false;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!isDialogueActive)
            {
                StartDialogue();
            }
            
            else
            {
                NextLine();
            }
        Debug.Log(playerInRange);
        }
    }

    void StartDialogue()
    {
        isDialogueActive = true;
        dialoguePanel.SetActive(true);
        currentLine = 0;
        dialogueText.text = dialogueLines[currentLine];
    }

    void NextLine()
    {
        currentLine++;
        Debug.Log("DKDKDKDKDKDKD");
        if (currentLine < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLine];
            Debug.Log(currentLine);
            
        }
        else
        {
            EndDialogue();
            Debug.Log("asasasasasas");
        }

        
    }

    void EndDialogue()
    {
        isDialogueActive = false;
        dialoguePanel.SetActive(false);
    }

    // �÷��̾ ���� ������ ���Դ��� ����
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            EndDialogue(); // ������ �ڵ� ����
        }
    }
}

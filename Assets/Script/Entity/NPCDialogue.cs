using UnityEngine;
using UnityEngine.UI;

public class NPCDialogue : MonoBehaviour
{
    public GameObject dialoguePanel;        // 대화창 UI
    public Text dialogueText;               // 대화 문장 텍스트
    public string[] dialogueLines;          // 대화 내용
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

    // 플레이어가 범위 안으로 들어왔는지 감지
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
            EndDialogue(); // 나가면 자동 종료
        }
    }
}

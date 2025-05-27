using UnityEngine;
using UnityEngine.UI; // O usar TMPro si prefieres
using TMPro;

public class Oracle : MonoBehaviour
{
    public GameObject dialogPanel;
    public TextMeshProUGUI dialogText;
    private string[] dialogLines;
    private int currentLine = 0;
    private bool playerInRange = false;
    private bool dialogActive = false;

    private void Start()
    {
        dialogLines = new string[] {
            "Hola Candidato", 
            "Esta parte de tu aventura..." 
        };



    }
    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!dialogActive)
            {
                StartDialog();
            }
            else
            {
                NextLine();
            }
        }
    }

    void StartDialog()
    {
        dialogActive = true;
        currentLine = 0;
        dialogPanel.SetActive(true);
        dialogText.text = dialogLines[currentLine];
    }

    void NextLine()
    {
        currentLine++;
        if (currentLine < dialogLines.Length)
        {
            dialogText.text = dialogLines[currentLine];
        }
        else
        {
            dialogPanel.SetActive(false);
            dialogActive = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            if (dialogActive)
            {
                dialogPanel.SetActive(false);
                dialogActive = false;
            }
        }
    }
}


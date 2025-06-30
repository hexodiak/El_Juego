using UnityEngine;
using UnityEngine.UI; // O usar TMPro si prefieres
using TMPro;
using System.Collections;

public class Oracle : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Playermovement movementScript;

    public GameObject dialogPanel;
    public TextMeshProUGUI dialogText;
    public float typingSpeed = 0.04f;
    public string[] dialogLines;
    private int currentLine = 0;
    private bool playerInRange = false;
    private bool dialogActive = false;
    private bool isTyping = false;

    private void Start()
    {
        if (player != null)
        {
            movementScript = player.GetComponent<Playermovement>();
            
        }

        dialogLines = new string[] {
        "Hola Candidato",
        "Esta parte de tu aventura...sdsddsdsadsdsdasdsdsdsdsdas sadasd sd ad adsad sdsa dasd s dasdsd"
        };
        dialogPanel.SetActive(false);
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!dialogActive)
            {
                StartDialog();
            }
            else if (!isTyping)
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

        if (movementScript != null)
            movementScript.enabled = false; // ← bloqueo de acciones
        

        StartCoroutine(TypeLine(dialogLines[currentLine]));
    }

    void NextLine()
    {
        currentLine++;
        if (currentLine < dialogLines.Length)
        {
            StartCoroutine(TypeLine(dialogLines[currentLine]));
        }
        else
        {
            dialogPanel.SetActive(false);
            dialogActive = false;

            if (movementScript != null)
                movementScript.enabled = true; // ← Desbloqueo de acciones 
            
        }
    }

    IEnumerator TypeLine(string line)
    {
        isTyping = true;
        dialogText.text = "";
        foreach (char c in line)
        {
            dialogText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) playerInRange = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            dialogPanel.SetActive(false);
            dialogActive = false;
            StopAllCoroutines();
        }
    }
}


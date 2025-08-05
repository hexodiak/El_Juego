using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class RebindGamepad : MonoBehaviour
{
    [Header("Referencias de entrada")]
    public InputActionReference actionRef;
    public int bindingIndex = 0;

    [Header("UI")]
    public TMP_Text keyDisplayText;       // Si es teclado
    public Image gamepadIconImage;        // Si es gamepad
    public Button rebindButton;

    [Header("Íconos por botón de Gamepad")]
    public List<IconMapping> iconMappings;

    [System.Serializable]
    public struct IconMapping
    {
        public string controlPath;  // Ej: "<Gamepad>/buttonSouth"
        public Sprite iconSprite;   // Sprite correspondiente
    }

    private void Start()
    {
        UpdateBindingDisplay();
        rebindButton.onClick.AddListener(() => StartRebinding());
    }

    void UpdateBindingDisplay()
    {
        string path = actionRef.action.bindings[bindingIndex].effectivePath;

        // Mostrar ícono si es un control
        if (path.Contains("Gamepad"))
        {
            keyDisplayText.gameObject.SetActive(false);
            gamepadIconImage.gameObject.SetActive(true);

            // Buscar el sprite correspondiente
            foreach (var icon in iconMappings)
            {
                if (path == icon.controlPath)
                {
                    gamepadIconImage.sprite = icon.iconSprite;
                    return;
                }
            }

            // Si no hay icono encontrado, lo desactiva
            gamepadIconImage.enabled = false;
        }
        else
        {
            // Mostrar texto si es teclado
            gamepadIconImage.gameObject.SetActive(false);
            keyDisplayText.gameObject.SetActive(true);
            keyDisplayText.text = actionRef.action.GetBindingDisplayString(bindingIndex);
        }
    }

    void StartRebinding()
    {
        keyDisplayText.text = "...";

        actionRef.action.Disable();

        var rebindOperation = actionRef.action.PerformInteractiveRebinding(bindingIndex)
            .WithControlsExcluding("Mouse")
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation =>
            {
                actionRef.action.Enable();
                operation.Dispose();
                UpdateBindingDisplay();

                PlayerPrefs.SetString(actionRef.action.name + "_rebind", actionRef.action.bindings[bindingIndex].effectivePath);
                PlayerPrefs.Save();
            })
            .Start();
    }
}

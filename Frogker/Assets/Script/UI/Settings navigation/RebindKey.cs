using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class RebindKey : MonoBehaviour
{
    public InputActionReference actionRef; // La acción (ej. salto)
    public int bindingIndex = 0; // Si tiene varias (teclado/joystick)
    public TMP_Text keyDisplayText; // Muestra la tecla actual
    public Button rebindButton; // Botón para reconfigurar

    private void Start()
    {
        // Mostrar la tecla actual
        UpdateBindingDisplay();

        // Al hacer clic, iniciar el proceso de reconfiguración
        rebindButton.onClick.AddListener(() => StartRebinding());
    }

    void UpdateBindingDisplay()
    {
        string displayString = actionRef.action.GetBindingDisplayString(bindingIndex);
        keyDisplayText.text = displayString;
    }

    void StartRebinding()
    {
        keyDisplayText.text = "..."; // Mostrar que está esperando

        actionRef.action.Disable();

        var rebindOperation = actionRef.action.PerformInteractiveRebinding(bindingIndex)
            .WithControlsExcluding("Mouse") // Excluye mouse si quieres
            .OnMatchWaitForAnother(0.1f) // Espera breve para confirmar
            .OnComplete(operation =>
            {
                actionRef.action.Enable();
                operation.Dispose();
                UpdateBindingDisplay();

                // Opcional: guardar la nueva tecla
                PlayerPrefs.SetString(actionRef.action.name + "_rebind", actionRef.action.bindings[bindingIndex].effectivePath);
                PlayerPrefs.Save();
            })
            .Start();
    }

}


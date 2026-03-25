using System;
using UnityEngine;

public class Interactable_Dialogue : MonoBehaviour, IInteractable
{
    public Dialogue _dialogue;

    private DialogueManager _dialogueManager;

    [SerializeField] bool _isRainbow;
    [SerializeField] float _rainbowSpeed;

    private float _hue;
    private float _sat;
    private float _bri;
    private SpriteRenderer _meshRenderer;

    public void Awake()
    {
        _dialogueManager = ServiceHub.Instance.DialogueManager;
        _meshRenderer = GetComponentInChildren<SpriteRenderer>();

        if (_dialogueManager == null) Debug.LogError("DialogManager not found in ServiceHub. Please ensure it is properly set up.");
    }

    public void Interact()
    {
        if(!_dialogueManager._isInDialogue)
            _dialogueManager.StartDialogue(_dialogue);
    }

    public void Update()
    {
        if (_isRainbow && _dialogueManager._finishedDialogue)
        {
            Color.RGBToHSV(_meshRenderer.material.color, out _hue, out _sat, out _bri);
            _hue += _rainbowSpeed / 10000;
            if (_hue >= 1)
            {
                _hue = 0;
            }
            _sat = 1;
            _bri = 1;
            _meshRenderer.material.color = Color.HSVToRGB(_hue, _sat, _bri);
        }
    }
}

using Assets.Scripts.Infastructure;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppView : MonoBehaviour
{
    #region Editor

    [SerializeField]
    private RectTransform _toggleRectTransformHandle;

    [Header("Data")]
    [SerializeField]
    private Text _nameText;

    [SerializeField]
    private InputField _textArea;

    [SerializeField]
    private Image _image;

    [SerializeField]
    private Image _colorImage;

    [SerializeField]
    private Button _toggleButton;

    [SerializeField]
    private bool _enable;

    [SerializeField]
    private Button _getCatButton;

    #endregion

    #region Fields

    private Vector2 _handleTogglePosition;

    #endregion

    #region Methods

    private void Start()
    {
        SubscribeEvents();
        _handleTogglePosition = _toggleRectTransformHandle.anchoredPosition;
        Preview();
    }

    private void OnDestroy()
    {
        UnSubscribeEvents();
    }

    private void SubscribeEvents()
    {
        PlayerModelProvider.Instance.Get.NameChange += OnNameChanged;
        PlayerModelProvider.Instance.Get.DescriptionChange += OnDescriptionChanged;
        PlayerModelProvider.Instance.Get.ImageChange += OnImageChanged;
        PlayerModelProvider.Instance.Get.ColorChange += OnColorChanged;
        PlayerModelProvider.Instance.Get.EnableChange += OnEnableChanged;
    }
    private void UnSubscribeEvents()
    {
        PlayerModelProvider.Instance.Get.NameChange -= OnNameChanged;
        PlayerModelProvider.Instance.Get.DescriptionChange -= OnDescriptionChanged;
    }
    private void OnNameChanged(string name)
    {
        _nameText.text = name;
    }

    private void OnDescriptionChanged(string description)
    {
        _textArea.text = description;
    }

    private void OnImageChanged(Sprite image)
    {
        _image.sprite = image;
    }

    private void OnColorChanged(Color color)
    {
        _colorImage.color = color;
    }

    private void OnEnableChanged(bool enable)
    {
        _enable = enable;
        ToggleSwitch(_enable);
    }

    private void Preview()
    {
        _nameText.text = PlayerModelProvider.Instance.Get.CatName;
        _textArea.text = PlayerModelProvider.Instance.Get.Description;
        _image.sprite = PlayerModelProvider.Instance.Get.Qr_code;
        _colorImage.color = PlayerModelProvider.Instance.Get.Color;
        _enable = PlayerModelProvider.Instance.Get.Enable;
    }

    public void OnGetCatButtonClick()
    {
        StartCoroutine(NetWorkManager.Instance.PostDataCoroutine());
    }

    private void ToggleSwitch(bool on)
    {
        if (!on)
        {
            _toggleRectTransformHandle.anchoredPosition = _handleTogglePosition * -1;
            _toggleButton.interactable = on;
        }
        else
        {
            _toggleRectTransformHandle.anchoredPosition = _handleTogglePosition;
            _toggleButton.interactable = on;
        }
    }

    #endregion
}

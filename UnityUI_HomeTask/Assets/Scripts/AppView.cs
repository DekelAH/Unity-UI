using Assets.Scripts.Infastructure;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    private TMP_InputField _textArea;

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
        PlayerModelProvider.Instance.Get.DataChange += OnDataChanged;
    }
    private void UnSubscribeEvents()
    {
        PlayerModelProvider.Instance.Get.DataChange -= OnDataChanged;
    }
    private void OnDataChanged(string name, string description, Sprite image, Color color, bool enable)
    {
        _nameText.text = name; 
        _textArea.text = description; 
        _image.sprite = image; 
        _colorImage.color = color;
        _enable = enable;

        ToggleSwitch(_enable);
    }

    private void Preview()
    {
        _nameText.text = PlayerModelProvider.Instance.Get.CatName;
        _textArea.text = PlayerModelProvider.Instance.Get.Description;
        _image.sprite = PlayerModelProvider.Instance.Get.Image;
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

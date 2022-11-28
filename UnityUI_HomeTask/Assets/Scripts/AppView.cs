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
    private Text _nameText;

    [SerializeField]
    private InputField _textArea;

    [SerializeField]
    private Image _image;

    [SerializeField]
    private Image _colorImage;

    [SerializeField]
    private bool _enable;

    #endregion

    #region Methods

    private void Start()
    {
        SubscribeEvents();
        Preview();
    }

    private void OnDestroy()
    {
        UnSubscribeEvents();
    }

    private void SubscribeEvents()
    {
        PlayerModelProvider.Instance.Get.ImageChange += OnImageChange;
        PlayerModelProvider.Instance.Get.ColorChange += OnColorChange;
    }
    private void UnSubscribeEvents()
    {
        PlayerModelProvider.Instance.Get.ImageChange -= OnImageChange;
        PlayerModelProvider.Instance.Get.ColorChange -= OnColorChange;
    }

    private void OnColorChange(Color color)
    {
        _colorImage.color = color;
    }

    private void OnImageChange(Sprite image)
    {
        _image.sprite = image;
    }


    private void Preview()
    {
        _nameText.text = PlayerModelProvider.Instance.Get.CatName;
        _textArea.text = PlayerModelProvider.Instance.Get.Description;
        _image.sprite = PlayerModelProvider.Instance.Get.Image;
        _colorImage.color = PlayerModelProvider.Instance.Get.Color;
        _enable = PlayerModelProvider.Instance.Get.Enable;
    }

    #endregion
}

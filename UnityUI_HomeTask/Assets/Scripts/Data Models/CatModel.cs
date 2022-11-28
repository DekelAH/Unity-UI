using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Data_Models
{
    [CreateAssetMenu(menuName = "Models/Data Models/Player Model", fileName = "Player Model")]
    public class CatModel : ScriptableObject
    {
        #region Events

        public event Action<string> NameChange;
        public event Action<string> DescriptionChange;
        public event Action<Sprite> ImageChange;
        public event Action<Color> ColorChange;
        public event Action<bool> EnableChange;

        #endregion

        #region Editor

        [SerializeField]
        private string _catName;

        [SerializeField]
        private string _description;

        [SerializeField]
        private Sprite _image;

        [SerializeField]
        private Color _color;

        [SerializeField]
        private bool _enable;

        #endregion

        #region Methods

        public void SetName(string catName)
        {
            _catName = catName;
            NameChange?.Invoke(_catName);
        }

        public void SetInputArea(string description)
        {
            _description = description;
            DescriptionChange?.Invoke(_description);
        }

        public void SetImage(Sprite image)
        {
            _image = image;
            ImageChange?.Invoke(_image);
        }

        public void SetColor(Color color)
        {
            _color = color;
            ColorChange?.Invoke(_color);
        }

        public void SetEnable(bool enable)
        {
            _enable = enable;
            EnableChange?.Invoke(enable);
        }

        #endregion

        #region Properties

        public string CatName => _catName;
        public string Description => _description;
        public Sprite Image => _image;
        public Color Color => _color;
        public bool Enable => _enable;


        #endregion
    }
}

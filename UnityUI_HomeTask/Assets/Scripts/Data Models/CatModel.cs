using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Data_Models
{
    [CreateAssetMenu(menuName = "Models/Data Models/Player Model", fileName = "Player Model")]
    public class CatModel : ScriptableObject
    {
        #region Events

        public event Action<string, string, Sprite, Color, bool> DataChange;

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

        public void SetData(string nameToChange, string descriptionToChange, Sprite imageTochange, Color color, bool enable)
        {
            _catName = nameToChange;
            _description = descriptionToChange;
            _image = imageTochange;
            _color = color;
            _enable = enable;
            DataChange?.Invoke(_catName, _description, _image, _color, _enable);
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

using Assets.Scripts.Infastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Data_Models
{
    public class MockDataConverter
    {
        #region Properties

        public string name;
        public string description;
        public string color;
        public bool enable;
        public string qr_code;

        #endregion

        #region Methods

        public void SetMockData()
        {
            PlayerModelProvider.Instance.Get.SetData(name, description, ImageConverter(qr_code), SetRGBAColor(color), enable);
        }

        private Color SetRGBAColor(string hex)
        {
            hex = hex.Replace("#", "");
            byte a = 255;
            byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
            
            if (hex.Length == 8)
            {
                a = byte.Parse(hex.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
            }

            return new Color32(r, g, b, a);
        }

        private Sprite ImageConverter(string image)
        {
            byte[] imageBytes = Convert.FromBase64String(image);

            Texture2D tex = new Texture2D(2, 2);
            tex.LoadImage(imageBytes);

            Sprite sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
            return sprite;
        }

        #endregion
    }
}

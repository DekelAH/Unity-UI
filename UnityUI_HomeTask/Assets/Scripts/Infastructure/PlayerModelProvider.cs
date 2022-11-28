using Assets.Scripts.Data_Models;
using UnityEngine;

namespace Assets.Scripts.Infastructure
{
    public class PlayerModelProvider
    {
        #region Consts

        private const string RESOURCE_NAME = "Player Model";

        #endregion

        #region Fields

        private static PlayerModelProvider _instance;
        private readonly CatModel _playerModel;

        #endregion

        #region Construtors

        private PlayerModelProvider(string resourceName)
        {
            _playerModel = Resources.Load<CatModel>(resourceName);
        }

        #endregion

        #region Properties

        public static PlayerModelProvider Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PlayerModelProvider(RESOURCE_NAME);
                }

                return _instance;
            }
        }

        public CatModel Get => _playerModel;

        #endregion

    }
}

using UnityEngine;

namespace Assets.Scripts.Infastructure
{
    public class NetWorkManager
    {
        #region Consts

        private const string ÜRL = "https://pusbkbbia3.execute-api.us-east-1.amazonaws.com/default/get_cat";
        private const string DEVELOPER_NAME = "dekel";

        #endregion

        #region Methods



        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void SetNetWorkManager()
        {
            Instance = new NetWorkManager();
        }

        #endregion

        #region Properties

        public static NetWorkManager Instance { get; private set; }

        #endregion

    }
}

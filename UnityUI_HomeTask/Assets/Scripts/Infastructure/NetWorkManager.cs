using Assets.Scripts.Data_Models;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts.Infastructure
{
    public class NetWorkManager
    {
        #region Consts

        private const string URL = "https://pusbkbbia3.execute-api.us-east-1.amazonaws.com/default/get_cat";
        private const string DEVELOPER_NAME = "dekel";

        #endregion

        #region Methods

        public IEnumerator PostDataCoroutine()
        {
            MockDataConverter objToPost = new MockDataConverter()
            {
                name = DEVELOPER_NAME
            };

            var jsonToPost = JsonUtility.ToJson(objToPost);

            using (UnityWebRequest request = UnityWebRequest.Post(URL, jsonToPost))
            {
                request.SetRequestHeader("Content-Type", "application/json");

                var dataRaw = Encoding.UTF8.GetBytes(jsonToPost);
                request.uploadHandler = new UploadHandlerRaw(dataRaw);

                yield return request.SendWebRequest();

                if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                {
                    Debug.LogWarning(request.error);
                }
                else
                {
                    var mockData = new MockDataConverter();
                    JsonUtility.FromJsonOverwrite(request.downloadHandler.text, mockData);
                    mockData.SetMockData();
                    Debug.Log(request.downloadHandler.text);
                }
            }
        }

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

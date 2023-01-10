using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
public class Database : MonoBehaviour
{
    public struct DataScore
    {
        public string id { get; set; }
        public int score { get; set; }
    }
    private void Start()
    {
        StartCoroutine(AddScoreCoroutine("ksd1234", 5000));
        //StartCoroutine(GetScoreCoroutine());

    }
    private IEnumerator AddScoreCoroutine(string _id, int _score)
    {
        WWWForm form = new WWWForm();
        form.AddField("id", _id); // dictionary ���� "key", value
        form.AddField("score", _score);
        // Post: ������.
        // .php ; �Է��� �����ּ��� php���ٰ� ������.
        // ������ ��� ���� ������ �ڷ�ƾ ������ ��.
        using (UnityWebRequest WWW = UnityWebRequest.Post("http://127.0.0.1:3308/addscore.php", form))
        {
            yield return WWW.SendWebRequest();

            if (WWW.isNetworkError || WWW.isHttpError)
            {
                Debug.Log(WWW.error);
            }
        }
        Debug.Log("AddScore Success : " + _id + "(" + _score + ")");
    } // end of AddScoreCoroutine()

    //private IEnumerator GetScoreCoroutine()
    //{
    //    using (UnityWebRequest www = UnityWebRequest.Post("http://127.0.0.1:3308/getscore.php", ""))
    //    {
    //        yield return www.SendWebRequest();

    //        if (www.isNetworkError || www.isHttpError)
    //        {
    //            Debug.Log(www.error);
    //        }
    //        else
    //        {
    //            Debug.Log(www.downloadHandler.text);
    //            string data = www.downloadHandler.text;

    //            List<DataScore> dataScores = JsonConvert.DeserializeObject<List<DataScore>>(data);

    //            foreach (DataScore dataScore in dataScores)
    //            {
    //                Debug.Log(dataScore.id + " : " + dataScore.score);
    //            }
    //        }

    //    }
    //} // end of GetScoreCoroutine()
} // end of class

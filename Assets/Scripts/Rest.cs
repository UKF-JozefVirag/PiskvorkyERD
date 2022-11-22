using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Rendering;

public class Rest : MonoBehaviour {

    private static string HOST = "https://mirzi.cc/piskvorky/";

    public static IEnumerator CreateLobby() {
        string uri = HOST + "create.php";

        using(UnityWebRequest request = UnityWebRequest.Get(uri)) {

            yield return request.SendWebRequest();

            switch(request.result) {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.Log("Error: " + request.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError("HTTP Error: " + request.error);
                    break;
                case UnityWebRequest.Result.Success:
                    // Get data from response and process it (convert the data into ResponseCreate class)
                    ResponseCreate response = JsonUtility.FromJson<ResponseCreate>(request.downloadHandler.text);
                    // Do the response logic
                    response.logic();
                    break;
            }
        }
    }

    class ResponseCreate {

        public string status;
        public int id;

        public void logic() {
            GameScript.instance.setLobbyId(id);
            Debug.Log($"{this.GetType().Name} -> status: {status}, id: {id}");
        }
    }

    public static IEnumerator ConnectToLobby(int lobbyId) {
        string uri = HOST + "connect.php?id=" + lobbyId;
        WWWForm form = new WWWForm();
        form.AddField("id", lobbyId);

        using(UnityWebRequest request = UnityWebRequest.Get(uri)) {

            yield return request.SendWebRequest();

            switch(request.result) {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                Debug.Log("Error: " + request.error);
                break;
                case UnityWebRequest.Result.ProtocolError:
                Debug.LogError("HTTP Error: " + request.error);
                break;
                case UnityWebRequest.Result.Success:
                // Get data from response and process it (convert the data into ResponseConnect class)
                ResponseConnect response = JsonUtility.FromJson<ResponseConnect>(request.downloadHandler.text);
                // Do the response logic
                response.logic();
                break;
            }
        }
    }

    class ResponseConnect {

        public string status;
        public int id;
        public int p1x, p1y;
        public int p2x, p2y;
        public string timestamp;
        public int firstplayer;

        public void logic() {
            GameScript.instance.setLobbyId(id);
            Debug.Log($"{this.GetType().Name} -> status: {status}, id: {id}, p1x: {p1x}, p1y: {p1y}, p2x: {p2x}, p2y: {p2y}, firstplayer: {firstplayer}, timestamp: {timestamp}");
        }

    }

    public static IEnumerator Get(int lobbyId) {
        string uri = HOST + "get.php?id="+lobbyId;
        WWWForm form = new WWWForm();
        form.AddField("id", lobbyId);

        using(UnityWebRequest request = UnityWebRequest.Get(uri)) {

            yield return request.SendWebRequest();

            switch(request.result) {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                Debug.Log("Error: " + request.error);
                break;
                case UnityWebRequest.Result.ProtocolError:
                Debug.LogError("HTTP Error: " + request.error);
                break;
                case UnityWebRequest.Result.Success:
                // Get data from response and process it (convert the data into ResponseGet class)
                ResponseGet response = JsonUtility.FromJson<ResponseGet>(request.downloadHandler.text);
                // Do the response logic
                response.logic();
                break;
            }
        }
    }

    class ResponseGet {

        public string status;
        public int id;
        public int p1x, p1y;
        public int p2x, p2y;
        public string timestamp;
        public int firstplayer;

        

        public void logic() {
            int p1predoslyStavX = PlayerPrefs.GetInt("p1x");
            int p1predoslyStavY = PlayerPrefs.GetInt("p1y");
            int p2predoslyStavX = PlayerPrefs.GetInt("p2x");
            int p2predoslyStavY = PlayerPrefs.GetInt("p2y");

            if (GameScript.instance.getIsHost())
            {
                if (p2x != p2predoslyStavX || p2y != p2predoslyStavY)
                {
                    GameScript.instance.setCanClick(true);
                    TurnScript.RenderItem(p2x, p2y);
                }
            }
            else
            {
                if (p1x != p1predoslyStavX || p1y != p1predoslyStavY )
                {
                    GameScript.instance.setCanClick(true);
                    TurnScript.RenderItem(p1x, p1y);
                }
            }


            PlayerPrefs.SetInt("p1x", p1x);
            PlayerPrefs.SetInt("p1y", p1y);
            PlayerPrefs.SetInt("p2x", p2x);
            PlayerPrefs.SetInt("p2y", p2y);
            //Debug.Log($"{this.GetType().Name} -> status: {status}, id: {id}, p1x: {p1x}, p1y: {p1y}, p2x: {p2x}, p2y: {p2y}, firstplayer: {firstplayer}, timestamp: {timestamp}");
        }


    }

    public static IEnumerator Post(int lobbyId, int player, int x, int y) {
        string uri = HOST + "post.php";
        WWWForm form = new WWWForm();
        form.AddField("id", lobbyId);
        form.AddField("player", player);
        form.AddField("x", x);
        form.AddField("y", y);

        Debug.Log($"{lobbyId} - {player} - {x} - {y}");

        using(UnityWebRequest request = UnityWebRequest.Post(uri, form)) {

            yield return request.SendWebRequest();

            switch(request.result) {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                Debug.Log("Error: " + request.error);
                break;
                case UnityWebRequest.Result.ProtocolError:
                Debug.LogError("HTTP Error: " + request.error);
                break;
                case UnityWebRequest.Result.Success:
                // Get data from response and process it (convert the data into ResponsePost class)
                ResponsePost response = JsonUtility.FromJson<ResponsePost>(request.downloadHandler.text);
                // Do the response logic
                response.logic();
                break;
            }
        }
    }

    class ResponsePost {

        public string status;
        public int id;
        public int player;
        public int x, y;

        public void logic() {

            Debug.Log($"{this.GetType().Name} -> status: {status} -> id: {id} -> player: {player} -> x:{x} -> y:{y}");
        }

    }

}

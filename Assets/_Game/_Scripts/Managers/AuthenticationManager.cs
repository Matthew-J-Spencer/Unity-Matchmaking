using UnityEngine;
using UnityEngine.SceneManagement;

public class AuthenticationManager : MonoBehaviour {

    public async void LoginAnonymously() {
        using (new Load("Logging you in...")) {
            await Authentication.Login();
            SceneManager.LoadSceneAsync("Lobby");
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoreLoader : MonoBehaviour {
    // Start is called before the first frame update
    void Awake() {
        if (CoreManager.instance == null) {
            SceneManager.LoadScene("Core", LoadSceneMode.Additive);
        }

        Destroy(this.gameObject);
    }
}

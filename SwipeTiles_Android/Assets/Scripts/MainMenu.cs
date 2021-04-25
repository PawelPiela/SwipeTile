using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play(){
        StartCoroutine(PlayLevel());
    }
    
    private IEnumerator PlayLevel() {
        yield return new WaitForSeconds(1F);
        SceneManager.LoadScene("LoadingData");
    }
    

}

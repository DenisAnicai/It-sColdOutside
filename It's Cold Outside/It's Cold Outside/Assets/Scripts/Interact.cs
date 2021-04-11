using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Interact : MonoBehaviour
{
    private GameObject dialogue, sceneBoss;
    public GameObject PromptToInteract, border1, border2;
    private bool CheckForInteraction = false;
    private bool[] interacted = new bool[200]; 
    private bool[] reinteractable = new bool[200];
    private int scene;
    // Start is called before the first frame update
    void Start()
    {
        #region reinteractable
        reinteractable[1] = true;
        reinteractable[2] = true;
        reinteractable[3] = true;
        reinteractable[4] = false;
        reinteractable[5] = false;
        reinteractable[6] = false;
        reinteractable[7] = true;
        reinteractable[8] = true;
        reinteractable[9] = false;
        reinteractable[10] = false;
        reinteractable[11] = false;
        reinteractable[12] = false;
        #endregion


        sceneBoss = GameObject.Find("sceneBoss");
        dialogue = GameObject.Find("DialogManager");
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "5")
        {
            if (dialogue.GetComponent<dialog>().GetInDialogue())
            {
                border1.SetActive(true);
                border2.SetActive(true);
            }
            else
            {
                border1.SetActive(false);
                border2.SetActive(false);
            }
        }
        if(CheckForInteraction)
        {
            if (Input.GetKeyDown("space"))
            {
                CheckForInteraction = false;
                interacted[scene] = true;
                if (scene == 4)
                {

                    StartCoroutine(LoadNextScene("2"));
                }
                else if (scene == 5)
                {
                    StartCoroutine(LoadNextScene("3"));
                }
                else if (scene == 9)
                {
                    StartCoroutine(LoadNextScene("4"));
                }
                else if (scene == 11)
                {
                    StartCoroutine(LoadNextScene("5"));
                }
                else if (scene == 14)
                {
                    StartCoroutine(LoadNextScene("8"));
                }
                else if (scene == 15)
                {
                    StartCoroutine(LoadNextScene("9"));
                }
                else if (scene == 17)
                {
                    StartCoroutine(LoadNextScene("10"));
                }
                else if (scene == 18)
                {
                    StartCoroutine(LoadNextScene("11"));
                }
                else if (scene == 19)
                {
                    StartCoroutine(LoadNextScene("12"));
                }
                else if (scene == 21)
                {
                    StartCoroutine(LoadNextScene("13"));
                }
                else if (scene == 22)
                {
                    StartCoroutine(LoadNextScene("14"));
                }
                else if(scene == 23)
                {
                    StartCoroutine(LoadNextScene("15"));
                }
                else
                {
                    dialogue.GetComponent<dialog>().StartDialogueInteraction(scene);
                }
                
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("In range of interactable object");
        scene = int.Parse(collision.gameObject.tag);
        if(scene == 12) StartCoroutine(LoadNextScene("6"));
        else if (scene >= 100)
        {
            if(!interacted[scene])
            {
                interacted[scene] = true;
                dialogue.GetComponent<dialog>().StartThinkingInteraction(scene);
            }
            
        }
        else
        {
            if ((interacted[scene] && reinteractable[scene]) || (!interacted[scene]))
            {
                PromptToInteract.SetActive(true);
                CheckForInteraction = true;
            }
        }
        
        
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PromptToInteract.SetActive(false);
        Debug.Log("Out of range");
        CheckForInteraction = false;
    }

    public IEnumerator LoadNextScene(string scene)
    {
        sceneBoss.GetComponent<sceneManager>().StartCoroutine(sceneBoss.GetComponent<sceneManager>().FadeOut(1.5f));
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(scene);
    }
}

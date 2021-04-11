using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class moveCharacter : MonoBehaviour
{
    
    private Rigidbody2D rb;
    public float speed = 1f;
    public Animator animator;
    private Vector2 moveVelocity;
    GameObject dialogue, sceneBoss;
    // Start is called before the first frame update
    void Start()
    {
        sceneBoss = GameObject.Find("sceneBoss");
        dialogue = GameObject.Find("DialogManager");
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogue.GetComponent<dialog>().GetPermissionToMove())
        {
            if(dialogue.GetComponent<dialog>().previousScene == 24)
            {
                StartCoroutine(LoadNextScene("16"));
            }
            animator.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal"));
            if (animator.GetFloat("Horizontal") != 0) animator.SetBool("WalkSide", true);
            else animator.SetBool("WalkSide", false);
            animator.SetFloat("Vertical", Input.GetAxisRaw("Vertical"));
            Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            moveVelocity = moveInput.normalized * speed;
        }
    }
    public IEnumerator LoadNextScene(string scene)
    {
        sceneBoss.GetComponent<sceneManager>().StartCoroutine(sceneBoss.GetComponent<sceneManager>().FadeOut(1.5f));
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(scene);
    }
    private void FixedUpdate()
    {
        if (dialogue.GetComponent<dialog>().GetPermissionToMove())
            rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
}

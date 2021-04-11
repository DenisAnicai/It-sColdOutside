using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;
public class dialog : MonoBehaviour
{
    private bool InDialogue;
    public int previousScene;
    private GameObject sceneBoss;
    public GameObject PromptToInteract, mainCharacter, mainCharacterHead;
    bool ALLOW_MOVEMENT = true;
    private string[,] sentences = new string[200, 50];
    public TextMeshProUGUI textDisplay;
    public Sprite[,] portrait = new Sprite[200, 50];
    private int index;
    public float typingSpeed;
    public GameObject Continue, DialogueWindow;
    public Image DialogueHead;
    public Sprite[] Portraits;
    private AudioSource source;
    public AudioClip[] sound;
    private int[] sceneLength = new int[200];
    private int scene;
    private int playSound = 0;
    private int soundIndex;
    bool insanity = false;
    [HideInInspector] public int ConversationNumber;
    public bool GetPermissionToMove()
    {
        return ALLOW_MOVEMENT;
    }
    public bool GetInDialogue()
    {
        return InDialogue;
    }
    IEnumerator Type()
    {
    
        DialogueHead.sprite = portrait[scene, index];
        if (scene == 101 && index == 6) insanity = true;
        if (scene == 24 && index == 0) insanity = true;
        if(scene == 24 && index == 8)
        {
            insanity = false;
        }
        if(scene == 101 && index == 7)
        {
            insanity = false;
        }
        foreach (char letter in sentences[scene, index].ToCharArray())
        {
            if (insanity) source.pitch = Random.Range(0.3f, 1.7f);
            else source.pitch = 1f;
            textDisplay.text += letter;
            if (playSound % 10 == 0)
            {
                playSound = 1;
                soundIndex = Random.Range(0, 7);
                source.clip = sound[soundIndex];
                source.Play();
            }
            else
                playSound++;
            yield return new WaitForSeconds(typingSpeed);
            
        }
    }
    // Start is called before the first frame update
    void Start()
    {

        #region portrait
        portrait[0, 0] = Portraits[0];
        portrait[0, 1] = Portraits[0];
        portrait[0, 2] = Portraits[0];
        portrait[0, 3] = Portraits[0];
        portrait[0, 4] = Portraits[0];

        portrait[1, 0] = Portraits[0];
        portrait[1, 1] = Portraits[0];
        portrait[1, 2] = Portraits[0];

        portrait[2, 0] = Portraits[0];
        portrait[2, 1] = Portraits[0];
        portrait[2, 2] = Portraits[0];

        portrait[3, 0] = Portraits[0];

        portrait[6, 0] = Portraits[1];
        portrait[6, 1] = Portraits[2];
        portrait[6, 2] = Portraits[1];
        portrait[6, 3] = Portraits[2];
        portrait[6, 4] = Portraits[1];
        portrait[6, 5] = Portraits[1];

        portrait[7, 0] = Portraits[0];
        portrait[7, 1] = Portraits[0];

        portrait[8, 0] = Portraits[0];

        portrait[10, 0] = Portraits[0];
        portrait[10, 1] = Portraits[0];
        portrait[10, 2] = Portraits[0];
        portrait[10, 3] = Portraits[0];
        portrait[10, 4] = Portraits[0];

        portrait[11, 0] = Portraits[0];
        portrait[11, 1] = Portraits[0];
        portrait[11, 2] = Portraits[0];
        portrait[11, 3] = Portraits[0];

        portrait[13, 0] = Portraits[2];
        portrait[13, 1] = Portraits[1];
        portrait[13, 2] = Portraits[3];
        portrait[13, 3] = Portraits[1];
        portrait[13, 4] = Portraits[0];

        portrait[16, 0] = Portraits[0];

        portrait[20, 0] = Portraits[0];

        portrait[24, 0] = Portraits[0];
        portrait[24, 1] = Portraits[0];
        portrait[24, 2] = Portraits[0];
        portrait[24, 3] = Portraits[0];
        portrait[24, 4] = Portraits[0];
        portrait[24, 5] = Portraits[0];
        portrait[24, 6] = Portraits[0];
        portrait[24, 7] = Portraits[0];
        portrait[24, 8] = Portraits[0];

        portrait[25, 0] = Portraits[0];

        portrait[100, 0] = Portraits[0];
        portrait[100, 1] = Portraits[0];
        portrait[100, 2] = Portraits[0];
        portrait[100, 3] = Portraits[0];
        portrait[100, 4] = Portraits[0];
        portrait[100, 5] = Portraits[0];

        portrait[101, 0] = Portraits[0];
        portrait[101, 1] = Portraits[0];
        portrait[101, 2] = Portraits[0];
        portrait[101, 3] = Portraits[0];
        portrait[101, 4] = Portraits[0];
        portrait[101, 5] = Portraits[0];
        portrait[101, 6] = Portraits[0];
        portrait[101, 7] = Portraits[0];
        #endregion    

        #region dialogue
        sentences[0, 0] = "I love it when it's raining.";
        sentences[0, 1] = "It's as if the whole world comes to a halt, and the only sound remaining is the water slowly splashing onto the wet soil.";
        sentences[0, 2] = "You can feel the rain seep into the atmosphere, undermining every little problem you've ever had.";
        sentences[0, 3] = "It makes me feel closer to my origins, as if I have a greater purpose in life.";
        sentences[0, 4] = "Just like that, all my worries disappear. . .";
        sceneLength[0] = 5;

        sentences[1, 0] = "It's my bookshelf.";
        sentences[1, 1] = "I used to really enjoy reading books, living through the extraordinary lives of the characters.";
        sentences[1, 2] = "Thinking about it. . . I haven't read anything in quite some time. . .";
        sceneLength[1] = 3;

        sentences[2, 0] = "This is the kind of weather I love most.";
        sentences[2, 1] = "The air is a lot cleaner and the world feels a lot more pure.";
        sentences[2, 2] = "The rain droplets slowly bash against the window.";
        sceneLength[2] = 3;

        sentences[3, 0] = "I can't get back in bed, I have to go to school.";
        sceneLength[3] = 1;


        sentences[6, 0] = "It's such a sorrowful morning, it doesn't look like the rain will let up anytime soon...";
        sentences[6, 1] = "Yeah, it makes my bones shiver just thinking about going outside in this cold weather!";
        sentences[6, 2] = "Think the dog's doing alright? It's quite the storm out there..";
        sentences[6, 3] = "He should be fine, he has that thick layer of fur unlike us!";
        sentences[6, 4] = "Haha, that's true...";
        sentences[6, 5] = "He has been getting kind of old lately though...";
        sceneLength[6] = 6;

        sentences[7, 0] = "I really don't have an appetite in the mornings.";
        sentences[7, 1] = "No reason to eat right now.";
        sceneLength[7] = 2;

        sentences[8, 0] = "It's the family table.";
        sceneLength[8] = 1;

        sentences[10, 0] = "It's the family dog.";
        sentences[10, 1] = "This is where he lived for the last 10 years.";
        sentences[10, 2] = "He barks at cars and people, making us aware of their presence...";
        sentences[10, 3] = "He's a good dog.";
        sentences[10, 4] = "...He looks kind of cold.";
        sceneLength[10] = 5;

        sentences[11, 0] = "Classes have begun.";
        sentences[11, 1] = "School has always been a place full of social interaction for most, boredom for a few and loneliness for many.";
        sentences[11, 2] = "You sit absent-minded.";
        sentences[11, 3] = "You decide to hang out with your friends after school.";
        sceneLength[11] = 4;

        sentences[13, 0] = "Soo, have you guys heard about that new kid who got transferred to our school?";
        sentences[13, 1] = "Yeah, I saw him walk into school today, what do you think about him?";
        sentences[13, 2] = "You can't seem to concentrate on the conversation, you feel dizzy...";
        sentences[13, 3] = "Hey, you've been kind of quiet, are you in a bad mood? Or maybe you're feeling under the weather?";
        sentences[13, 4] = "Nah, I'm feeling great! I have something to do at home though so I'll have to go, see you!";
        sceneLength[13] = 5;

        sentences[16, 0] = "He seems tired.";
        sceneLength[16] = 1;

        sentences[20, 0] = "I have to find out what that sound was...";
        sceneLength[20] = 1;

        sentences[24, 0] = "It's not breathing.";
        sentences[24, 1] = "What is this that I feel?";
        sentences[24, 2] = "Sorrow, numbness, relief, confusion?";
        sentences[24, 3] = "I feel s1ck.";
        sentences[24, 4] = "My head is $pinning, the air is he4vy, why is it so hot@#$*)($?";
        sentences[24, 5] = "Where can I hide and never c0me b4ck ag41n?";
        sentences[24, 6] = "A dark warm secluded place.";
        sentences[24, 7] = "It's all my fault isn't itTt?";
        sentences[24, 8] = "Born free, wilted chained.";
        sceneLength[24] = 9;

        sentences[25, 0] = "It looks cold outside.";
        sceneLength[25] = 1;
        sentences[100, 0] = "It all feels clunky.";
        sentences[100, 1] = "Moving my left leg forward, right arm back, right leg forward, left arm back..";
        sentences[100, 2] = "Or was it the other way around?";
        sentences[100, 3] = "Keep your head at a steady level, not too low, not too high.";
        sentences[100, 4] = "Do i look normal, like everybody else?";
        sentences[100, 5] = "Thankfully there's no one else around...";
        sceneLength[100] = 6;

        sentences[101, 0] = "Walking is always bothersome to me";
        sentences[101, 1] = "It's too much free time to think.";
        sentences[101, 2] = "I look around me, examining each and every thing and it all makes me slowly go mad.";
        sentences[101, 3] = "Why am I even here? Am I really living life the best I ever could?";
        sentences[101, 4] = "What if I'm not doing enough, what if what awaits me is nothing but failure?!";
        sentences[101, 5] = "Other people are doing much better, why can't I?";
        sentences[101, 6] = "AM I GOING TO ACCOMPLISH MY GOALS OR WILL I BE A FAILURE LIKE I ALWAYS PROVE TO BE?";
        sentences[101, 7] = "I fear failure... I fear wasting my life away without making a difference...";
        sceneLength[101] = 8;
        #endregion
        if (!mainCharacter) mainCharacter = GameObject.Find("mainCharacter");
        sceneBoss = GameObject.Find("sceneBoss");
        source = GetComponent<AudioSource>();
    }
    public void StartThinkingInteraction(int sceneNumber)
    {
        InDialogue = true;
        DialogueWindow.SetActive(true);
        scene = sceneNumber;
        PromptToInteract.SetActive(false);
        StartCoroutine(Type());
    }
    public void StartDialogueInteraction(int sceneNumber)
    {
        InDialogue = true;
        DialogueWindow.SetActive(true);
        ALLOW_MOVEMENT = false;
        scene = sceneNumber;
        PromptToInteract.SetActive(false);
        StartCoroutine(Type());
    }
    // Update is called once per frame
    void Update()
    {
        if (insanity)
            typingSpeed = 0.0180f;
        else typingSpeed = 0.02f;
        if(textDisplay.text == sentences[scene,index])
        {

                Continue.SetActive(true);
                if (Input.GetKeyDown("space"))
                {
                    NextSentence();
                }
            
        }
        
    }
    void NextSentence()
    {
        if (index <  sceneLength[scene] - 1)
        {

            if(scene == 24)
            {
                mainCharacter.GetComponent<Light2D>().intensity -= 0.1f;
            }
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
            Continue.SetActive(false);
        }
        else
        {
            if(scene == 0)
            {
                StartCoroutine(set());
                
            }
            if(SceneManager.GetActiveScene().name == "6")
            {
                SceneManager.LoadScene("7");
            }
            previousScene = scene;
            textDisplay.text = "";
            index = 0;
            DialogueWindow.SetActive(false);
            ALLOW_MOVEMENT = true;
            InDialogue = false;
        }
    }

    IEnumerator set()
    {
        sceneBoss.GetComponent<sceneManager>().StartCoroutine(sceneBoss.GetComponent<sceneManager>().Fade(2f, 2f));
        yield return new WaitForSeconds(1.80f);
        mainCharacterHead.SetActive(false);
        mainCharacter.SetActive(true);
        yield return new WaitForSeconds(1f);
        
    }
}

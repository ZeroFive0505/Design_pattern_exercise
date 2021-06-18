using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public GameObject actor;
    public float inputTime = 0.0f;
    public bool comboStart = false;
    private Animator anim;
    Command keyP, keyK;
    Command combo;
    List<Command> commands = new List<Command>();
    Dictionary<Command, int> moveSet = new Dictionary<Command, int>();

    const int COMBO = 2;

    // Start is called before the first frame update
    void Start()
    {
        keyP = new Punch();
        keyK = new Kick();
        combo = new Combo();
        anim = actor.GetComponent<Animator>();
        Camera.main.GetComponent<CameraController>().player = actor.transform;
        moveSet[keyP] = 0;
        moveSet[keyK] = 1;
    }

    // Update is called once per frame
    void Update()
    {
        HandleCommands();
        if (comboStart && inputTime > 1.0f)
        {
            commands.Clear();
            comboStart = false;
            inputTime = 0.0f;
        }
        if(comboStart)
            inputTime += Time.deltaTime * 0.2f;
    }

    void HandleCommands()
    {
        if(commands.Count >= 2)
        {
            if(Input.GetKeyDown(KeyCode.P))
            {
                int c = 0;
                for(int i = 0; i < commands.Count; i++)
                {
                    if (moveSet.ContainsKey(commands[i]) && moveSet[commands[i]] == c)
                        c++;
                }

                if(c == COMBO)
                {
                    combo.Execute(anim);
                    commands.Clear();
                    inputTime = 0.0f;
                    comboStart = false;
                    return;
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            keyP.Execute(anim);
            commands.Add(keyP);
            comboStart = true;
        }
        else if(Input.GetKeyDown(KeyCode.K))
        {
            keyK.Execute(anim);
            commands.Add(keyK);
            comboStart = true;
        }
    }
}

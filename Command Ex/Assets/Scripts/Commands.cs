using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    public abstract void Execute(Animator anim);
}

public class Punch : Command
{
    public override void Execute(Animator anim)
    {
        anim.SetTrigger("isPunching");
    }
}

public class Kick : Command
{
    public override void Execute(Animator anim)
    {
        anim.SetTrigger("isKicking");
    }
}

public class Combo : Command
{
    public override void Execute(Animator anim)
    {
        anim.SetTrigger("Combo");
    }
}
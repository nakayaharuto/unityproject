using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SameObjGimmick : MonoBehaviour
{
    public Frame[] frames;
    public ItemBox palyeritembox;

    public SwitchDoorScript SwitchDoorScript;

    public void UseItemFrame(int frameIndex, Item.Type itemtype)
    {
        if(frameIndex < 0 || frameIndex >= frames.Length) return;

        frames[frameIndex].TryInsertItem(itemtype, palyeritembox);
        
        if(CheckAllFramesFilled())
        {
            OnAllFramesCompledted();
        }
    }

    bool CheckAllFramesFilled()
    {
        foreach(var frame in frames)
        {
          
            if (!frame.IsFilled())
                return false;
        }
        return true;
    }

    void OnAllFramesCompledted()
    {
        SwitchDoorScript.isOpen = true;
    }
}


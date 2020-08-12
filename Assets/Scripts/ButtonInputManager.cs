using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInputManager : SteamVR_TrackedController
{
    
    GameObject collidingObject;

    public override void OnTriggerClicked(ClickedEventArgs e)
    {
        print("Trigger Clicked");
    }
    public override void OnTriggerUnclicked(ClickedEventArgs e)
    {
        print("Trigger Unclicked");
    }
    public override void OnMenuClicked(ClickedEventArgs e)
    {
        print("Menu Clicked");
    }
    public override void OnMenuUnclicked(ClickedEventArgs e)
    {
        print("Menu Unclicked");
    }
    public override void OnSteamClicked(ClickedEventArgs e)
    {
    }
    public override void OnPadClicked(ClickedEventArgs e)
    {
        print("Pad Clicked");
    }
    public override void OnPadUnclicked(ClickedEventArgs e)
    {
        print("Pad Unclicked");
    }
    public override void OnPadTouched(ClickedEventArgs e)
    {
        print("Pad Touched");
    }
    public override void OnPadUntouched(ClickedEventArgs e)
    {
        print("Pad Untouched");
    }
    public override void OnGripped(ClickedEventArgs e)
    {
        print("Gripped");
    }
    public override void OnUngripped(ClickedEventArgs e)
    {
        print("Ungripped");
    }

    
}

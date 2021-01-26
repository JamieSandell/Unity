using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

    public Text text;

    private enum States { Keys0, KeyTray0, Bedroom0, UpstairsLanding0, DownstairsLanding0, FrontRoom0, PartnerLook0, PartnerTalk0, PCLook0, PCUse0, FrontDoor0, Outside0,
                            FrontDoor1, PartnerLook1, PartnerTalk1, FrontRoom1, DownstairsLanding1, UpstairsLanding1, Bedroom1, KeyTray1, PCLook1, PCUse1, Keys1, Outside1,
                            FrontDoor2, PartnerLook2, PartnerTalk2, FrontRoom2, DownstairsLanding2, UpstairsLanding2, Bedroom2, KeyTray2, PCLook2, PCUse2, Keys2, Outside2,
                            FrontDoor3, PartnerLook3, PartnerTalk3, FrontRoom3, DownstairsLanding3, UpstairsLanding3, Bedroom3, KeyTray3, PCLook3, PCUse3, Outside3,
                            FrontDoor4, FrontDoorOutside4, Car4, PartnerLook4, PartnerTalk4, FrontRoom4, DownstairsLanding4, UpstairsLanding4, Bedroom4, KeyTray4, PCLook4, PCUse4, Outside4,
                            GameWon};
    private States myState;

	// Use this for initialization
	void Start () {
        myState = States.Bedroom0;		
	}
	
	// Update is called once per frame
	void Update () {
        switch (myState)
        {
            case States.Keys0:
                Keys0();
                break;
            case States.KeyTray0:
                KeyTray0();
                break;
            case States.Bedroom0:
                Bedroom0();
                break;
            case States.UpstairsLanding0:
                UpstairsLanding0();
                break;
            case States.DownstairsLanding0:
                DownstairsLanding0();
                break;
            case States.FrontRoom0:
                FrontRoom0();
                break;
            case States.PartnerLook0:
                PartnerLook0();
                break;
            case States.PartnerTalk0:
                PartnerTalk0();
                break;
            case States.PCLook0:
                PCLook0();
                break;
            case States.PCUse0:
                PCUse0();
                break;
            case States.FrontDoor0:
                FrontDoor0();
                break;
            case States.Outside0:
                Outside0();
                break;
            case States.FrontDoor1:
                FrontDoor1();
                break;
            case States.PartnerLook1:
                PartnerLook1();
                break;
            case States.PartnerTalk1:
                PartnerTalk1();
                break;
            case States.FrontRoom1:
                FrontRoom1();
                break;
            case States.DownstairsLanding1:
                DownstairsLanding1();
                break;
            case States.UpstairsLanding1:
                UpstairsLanding1();
                break;
            case States.Bedroom1:
                Bedroom1();
                break;
            case States.KeyTray1:
                KeyTray1();
                break;
            case States.PCLook1:
                PCLook1();
                break;
            case States.PCUse1:
                PCUse1();
                break;
            case States.Keys1:
                Keys1();
                break;
            case States.Outside1:
                Outside1();
                break;
            case States.FrontDoor2:
                FrontDoor2();
                break;
            case States.PartnerLook2:
                PartnerLook2();
                break;
            case States.PartnerTalk2:
                PartnerTalk2();
                break;
            case States.FrontRoom2:
                FrontRoom2();
                break;
            case States.DownstairsLanding2:
                DownstairsLanding2();
                break;
            case States.UpstairsLanding2:
                UpstairsLanding2();
                break;
            case States.Bedroom2:
                Bedroom2();
                break;
            case States.KeyTray2:
                KeyTray2();
                break;
            case States.PCLook2:
                PCLook2();
                break;
            case States.PCUse2:
                PCUse2();
                break;
            case States.Keys2:
                Keys2();
                break;
            case States.Outside2:
                Outside2();
                break;
            case States.FrontDoor3:
                FrontDoor3();
                break;
            case States.PartnerLook3:
                PartnerLook3();
                break;
            case States.PartnerTalk3:
                PartnerTalk3();
                break;
            case States.FrontRoom3:
                FrontRoom3();
                break;
            case States.DownstairsLanding3:
                DownstairsLanding3();
                break;
            case States.UpstairsLanding3:
                UpstairsLanding3();
                break;
            case States.Bedroom3:
                Bedroom3();
                break;
            case States.KeyTray3:
                KeyTray3();
                break;
            case States.PCLook3:
                PCLook3();
                break;
            case States.PCUse3:
                PCUse3();
                break;
            case States.Outside3:
                Outside3();
                break;
            case States.FrontDoor4:
                FrontDoor4();
                break;
            case States.FrontDoorOutside4:
                FrontDoorOutside4();
                break;
            case States.Car4:
                Car4();
                break;
            case States.PartnerLook4:
                PartnerLook4();
                break;
            case States.PartnerTalk4:
                PartnerTalk4();
                break;
            case States.FrontRoom4:
                FrontRoom4();
                break;
            case States.DownstairsLanding4:
                DownstairsLanding4();
                break;
            case States.UpstairsLanding4:
                UpstairsLanding4();
                break;
            case States.Bedroom4:
                Bedroom4();
                break;
            case States.KeyTray4:
                KeyTray4();
                break;
            case States.PCLook4:
                PCLook4();
                break;
            case States.PCUse4:
                PCUse4();
                break;
            case States.Outside4:
                Outside4();
                break;
            case States.GameWon:
                GameWon();
                break;
        }
    }

    void Keys0 ()
    {
        text.text = "Your house and car keys each on a keychain hoop connected to one master keychain hoop." +
                    "\n" +
                    "\n" +
                    "Press S to stop looking at the keys.";
        if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.KeyTray0;
        }
    }

    void KeyTray0 ()
    {
        text.text = "Your heavy looking (but surprisingly light...and cheap) brown wooden key tray." +
                    "\n" +
                    "You see your house and car keys." +
                    "\n" +
                    "\n" +
                    "Press S to stop looking at the key tray, press L to look at the keys.";
        if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.DownstairsLanding0;
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            myState = States.Keys0;
        }
    }

    void Bedroom0 ()
    {
        text.text = "You're in your bedroom which is nice and warm, it's Winter so the heating is on." +
                    "\n" +
                    "You've recently heard that there is a surprise Bruce Springsteen concert tonight, you must get tickets!" +
                    "\n" +
                    "\n" +
                    "Press W to walk to the upstairs landing, press L to look at your PC.";
        if (Input.GetKeyDown(KeyCode.W))
        {
            myState = States.UpstairsLanding0;
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            myState = States.PCLook0;
        }
    }

    void UpstairsLanding0 ()
    {
        text.text = "You stand on your ugly beige carpet on your upstairs landing." +
                    "\n" +
                    "It could do with a quick hoover, though now really isn't the time." +
                    "\n" +
                    "\n" +
                    "Press B to walk to the bedroom, press D to go down the stairs to the downstairs landing.";
        if (Input.GetKeyDown(KeyCode.B))
        {
            myState = States.Bedroom0;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            myState = States.DownstairsLanding0;
        }
    }

    void DownstairsLanding0 ()
    {
        text.text = "You stand in your unremarkable downstairs landing." +
                    "\n" +
                    "The upstairs landing directly behind you, the front room to your left, key tray to your right and your white front door directly ahead." +
                    "\n" +
                    "\n" +
                    "Press U to walk up stairs to the upstairs landing, press L to look at the key tray, press F to enter the front room and D to look at front door.";
        if (Input.GetKeyDown(KeyCode.U))
        {
            myState = States.UpstairsLanding0;
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            myState = States.KeyTray0;
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            myState = States.FrontRoom0;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            myState = States.FrontDoor0;
        }
    }

    void FrontRoom0 ()
    {
        text.text = "You're in your front room, you find the shabby chic look of it's decor comforting and visually appealing." +
                    "\n" +
                    "Your partner is sat on the couch (which you hate and can't wait to replace) and on her phone, she acknowledges you with a loving look." +
                    "\n" +
                    "\n" +
                    "Press L to look at your partner, T to talk to your partner and press E to exit back to the downstairs landing.";
        if (Input.GetKeyDown(KeyCode.L))
        {
            myState = States.PartnerLook0;
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            myState = States.PartnerTalk0;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            myState = States.DownstairsLanding0;
        }
    }

    void PartnerLook0 ()
    {
        text.text = "Long blonde hair, smart and funny - she's your dream girl." +
                    "\n" +
                    "\n" +
                    "Press S to stop looking at your partner, press T to talk to your partner.";
        if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.FrontRoom0;
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            myState = States.PartnerTalk0;
        }
    }

    void PartnerTalk0 ()
    {
        text.text = "You tell you're partner excitedly about the Bruce Springsteen tickets and that you're going to book them." +
                    "\n" +
                    "She's agreeable and says \"Go for it, but count me out babe.\"" +
                    "\n" +
                    "\n" +
                    "Press S to stop talking to your partner.";
        if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.FrontRoom1;
        }
    }

    void PCLook0 ()
    {
        text.text = "Your PC, your solice, your hobby and friend." +
                    "\n" +
                    "You try to imagine what it would be like to be playing a PC within a video game, and then shake your head at the absurdity." +
                    "\n" +
                    "\n" +
                    "Press S to stop looking at your PC.";
        if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.Bedroom0;
        }
    }

    void PCUse0 ()
    {

    }

    void FrontDoor0 ()
    {
        text.text = "Your white front door, recently glossed by yourself and your partner." +
                    "\n" +
                    "\n" +
                    "Press S to stop looking at your front door.";
        if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.DownstairsLanding0;
        }
    }

    void Outside0 ()
    {

    }

    void Keys1()
    {
        text.text = "Your house and car keys each on a keychain hoop connected to one master keychain hoop." +
                    "\n" +
                    "\n" +
                    "Press S to stop looking at the keys.";
        if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.KeyTray1;
        }
    }

    void FrontDoor1 ()
    {
        text.text = "Your white front door, recently glossed by yourself and your partner." +
                    "\n" +
                    "\n" +
                    "Press S to stop looking at your front door.";
        if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.DownstairsLanding1;
        }
    }

    void PartnerLook1 ()
    {
        text.text = "Long blonde hair, smart and funny - she's your dream girl." +
                    "\n" +
                    "\n" +
                    "Press S to stop looking at your partner, press T to talk to your partner.";
        if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.FrontRoom1;
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            myState = States.PartnerTalk1;
        }
    }

    void PartnerTalk1 ()
    {
        text.text = "You go to speak when your partner asks \"Aren't you going to get the tickets before they sell out?\"" +
                    "\n" +
                    "\n" +
                    "Press S to stop talking to your partner.";
        if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.FrontRoom1;
        }
    }

    void FrontRoom1 ()
    {
        text.text = "You're in your front room, you find the shabby chic look of it's decor comforting and visually appealing." +
                    "\n" +
                    "Your partner is sat on the couch (which you hate and can't wait to replace) and on her phone, she acknowledges you with a loving look." +
                    "\n" +
                    "\n" +
                    "Press L to look at your partner, T to talk to your partner and press E to exit back to the downstairs landing.";
        if (Input.GetKeyDown(KeyCode.L))
        {
            myState = States.PartnerLook1;
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            myState = States.PartnerTalk1;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            myState = States.DownstairsLanding1;
        }
    }

    void DownstairsLanding1 ()
    {
        text.text = "You stand in your unremarkable downstairs landing." +
                    "\n" +
                    "The upstairs landing directly behind you, the front room to your left, key tray to your right and your white front door directly ahead." +
                    "\n" +
                    "\n" +
                    "Press U to walk up stairs to the upstairs landing, press L to look at the key tray, press F to enter the front room and D to look at front door.";
        if (Input.GetKeyDown(KeyCode.U))
        {
            myState = States.UpstairsLanding1;
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            myState = States.KeyTray1;
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            myState = States.FrontRoom1;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            myState = States.FrontDoor1;
        }
    }

    void UpstairsLanding1 ()
    {
        text.text = "You stand on your ugly beige carpet on your upstairs landing." +
                    "\n" +
                    "It could do with a quick hoover, though now really isn't the time." +
                    "\n" +
                    "\n" +
                    "Press B to walk to the bedroom, press D to go down the stairs to the downstairs landing.";
        if (Input.GetKeyDown(KeyCode.B))
        {
            myState = States.Bedroom1;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            myState = States.DownstairsLanding1;
        }
    }

    void Bedroom1 ()
    {
        text.text = "Your're in your bedroom which is nice and warm, it's Winter so the heating is on." +
                    "\n" +
                    "You think now would be a good time to book those Springsteen tickets." +
                    "\n" +
                    "\n" +
                    "Press W to walk to the upstairs landing, press L to look at your PC, press P to book the tickets on your PC.";
        if (Input.GetKeyDown(KeyCode.W))
        {
            myState = States.UpstairsLanding1;
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            myState = States.PCLook1;
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            myState = States.PCUse1;
        }
    }

    void KeyTray1 ()
    {
        text.text = "Your heavy looking (but surprisingly light...and cheap) brown wooden key tray." +
                    "\n" +
                    "You see your house and car keys." +
                    "\n" +
                    "\n" +
                    "Press S to stop looking at the key tray, press L to look at the keys.";
        if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.DownstairsLanding1;
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            myState = States.Keys1;
        }
    }

    void PCLook1 ()
    {
        text.text = "Your PC, your solice, your hobby and friend." +
                    "\n" +
                    "A more than adequate tool for booking concert tickets." +
                    "\n" +
                    "\n" +
                    "Press S to stop looking at your PC.";
        if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.Bedroom1;
        }
    }

    void PCUse1 ()
    {
        text.text = "You turn your PC on and log on, booking your tickets with a deft grace perhaps only seen on the Serengeti." +
                    "\n" +
                    "\n" +
                    "Press S to shut your PC down.";
        if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.Bedroom2;
        }
    }

    void Outside1 ()
    {

    }

    void FrontDoor2 ()
    {
        text.text = "Your white front door, recently glossed by yourself and your partner." +
                    "\n" +
                    "\n" +
                    "Press S to stop looking at your front door.";
        if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.DownstairsLanding2;
        }
    }

    void PartnerLook2 ()
    {
        text.text = "Long blonde hair, smart and funny - she's your dream girl." +
                    "\n" +
                    "\n" +
                    "Press S to stop looking at your partner, press T to talk to your partner.";
        if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.FrontRoom2;
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            myState = States.PartnerTalk2;
        }
    }

    void PartnerTalk2 ()
    {
        text.text = "\"You've booked your tickets?\"" +
                    "\n" +
                    "She smiles and says \"Very good.\"" +
                    "\n" +
                    "\n" +
                    "Press S to stop talking to your partner.";
        if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.FrontRoom2;
        }
    }

    void FrontRoom2 ()
    {
        text.text = "You're in your front room, you find the shabby chic look of it's decor comforting and visually appealing." +
                    "\n" +
                    "Your partner is sat on the couch (which you hate and can't wait to replace) and on her phone, she acknowledges you with a loving look." +
                    "\n" +
                    "\n" +
                    "Press L to look at your partner, T to talk to your partner and press E to exit back to the downstairs landing.";
        if (Input.GetKeyDown(KeyCode.L))
        {
            myState = States.PartnerLook2;
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            myState = States.PartnerTalk2;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            myState = States.DownstairsLanding2;
        }
    }

    void DownstairsLanding2 ()
    {
        text.text = "You stand in your unremarkable downstairs landing." +
                    "\n" +
                    "The upstairs landing directly behind you, the front room to your left, key tray to your right and your white front door directly ahead." +
                    "\n" +
                    "\n" +
                    "Press U to walk up stairs to the upstairs landing, press L to look at the key tray, press F to enter the front room and D to look at front door.";
        if (Input.GetKeyDown(KeyCode.U))
        {
            myState = States.UpstairsLanding2;
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            myState = States.KeyTray2;
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            myState = States.FrontRoom2;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            myState = States.FrontDoor2;
        }
    }

    void UpstairsLanding2 ()
    {
        text.text = "You stand on your ugly beige carpet on your upstairs landing." +
                    "\n" +
                    "It could do with a quick hoover, though now really isn't the time." +
                    "\n" +
                    "\n" +
                    "Press B to walk to the bedroom, press D to go down the stairs to the downstairs landing.";
        if (Input.GetKeyDown(KeyCode.B))
        {
            myState = States.Bedroom2;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            myState = States.DownstairsLanding2;
        }
    }

    void Bedroom2 ()
    {
        text.text = "Your're in your bedroom which is nice and warm, it's Winter so the heating is on." +
                    "\n" +
                    "You're very excited that you've booked the Springsteen tickets, you almost jump for joy." +
                    "\n" +
                    "\n" +
                    "Press W to walk to the upstairs landing, press L to look at your PC.";
        if (Input.GetKeyDown(KeyCode.W))
        {
            myState = States.UpstairsLanding2;
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            myState = States.PCLook2;
        }
    }

    void KeyTray2 ()
    {
        text.text = "Your heavy looking (but surprisingly light...and cheap) brown wooden key tray." +
                    "\n" +
                    "You see your house and car keys." +
                    "\n" +
                    "\n" +
                    "Press S to stop looking at the key tray, press L to look at the keys, press T to take the keys.";
        if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.DownstairsLanding2;
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            myState = States.Keys2;
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            myState = States.KeyTray3;
        }
    }

    void PCLook2 ()
    {
        text.text = "Your PC, your solice, your hobby and friend." +
                    "\n" +
                    "You try to imagine what it would be like to be playing a PC within a video game, and then shake your head at the absurdity." +
                    "\n" +
                    "\n" +
                    "Press S to stop looking at your PC.";
        if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.Bedroom2;
        }
    }

    void PCUse2 ()
    {

    }

    void Keys2 ()
    {
        text.text = "Your house and car keys each on a keychain hoop connected to one master keychain hoop." +
                    "\n" +
                    "\n" +
                    "Press S to stop looking at the keys.";
        if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.KeyTray2;
        }
    }

    void Outside2 ()
    {

    }

    void FrontDoor3 ()
    {
        text.text = "Your white front door, recently glossed by yourself and your partner." +
                    "\n" +
                    "\n" +
                    "Press S to stop looking at your front door.";
        if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.DownstairsLanding3;
        }
    }

    void PartnerLook3 ()
    {
        text.text = "Long blonde hair, smart and funny - she's your dream girl." +
                    "\n" +
                    "\n" +
                    "Press S to stop looking at your partner, press T to talk to your partner.";
        if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.FrontRoom3;
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            myState = States.PartnerTalk3;
        }
    }

    void PartnerTalk3 ()
    {
        text.text = "\"You've booked your tickets?\"" +
                    "\n" +
                    "She smiles and says \"Very good.\"" +
                    "\n" +
                    "\n" +
                    "Press S to stop talking to your partner.";
        if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.FrontRoom3;
        }
    }

    void FrontRoom3 ()
    {
        text.text = "You're in your front room, you find the shabby chic look of it's decor comforting and visually appealing." +
                    "\n" +
                    "Your partner is sat on the couch (which you hate and can't wait to replace) and on her phone, she acknowledges you with a loving look." +
                    "\n" +
                    "\n" +
                    "Press L to look at your partner, T to talk to your partner and press E to exit back to the downstairs landing.";
        if (Input.GetKeyDown(KeyCode.L))
        {
            myState = States.PartnerLook3;
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            myState = States.PartnerTalk3;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            myState = States.DownstairsLanding3;
        }
    }

    void DownstairsLanding3 ()
    {
        text.text = "You stand in your unremarkable downstairs landing." +
                    "\n" +
                    "The upstairs landing directly behind you, the front room to your left, key tray to your right and your white front door directly ahead." +
                    "\n" +
                    "\n" +
                    "Press U to walk up stairs to the upstairs landing, press L to look at the key tray, press F to enter the front room," + 
                    "\n" +
                    "press D to look at front door, press O to unlock your front door and go outside.";
        if (Input.GetKeyDown(KeyCode.U))
        {
            myState = States.UpstairsLanding3;
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            myState = States.KeyTray3;
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            myState = States.FrontRoom3;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            myState = States.FrontDoor3;
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            myState = States.Outside4;
        }
    }

    void UpstairsLanding3 ()
    {
        text.text = "You stand on your ugly beige carpet on your upstairs landing." +
                    "\n" +
                    "It could do with a quick hoover, though now really isn't the time." +
                    "\n" +
                    "\n" +
                    "Press B to walk to the bedroom, press D to go down the stairs to the downstairs landing.";
        if (Input.GetKeyDown(KeyCode.B))
        {
            myState = States.Bedroom3;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            myState = States.DownstairsLanding3;
        }
    }

    void Bedroom3 ()
    {
        text.text = "Your're in your bedroom which is nice and warm, it's Winter so the heating is on." +
                    "\n" +
                    "You're very excited that you've booked the Springsteen tickets, you almost jump for joy." +
                    "\n" +
                    "\n" +
                    "Press W to walk to the upstairs landing, press L to look at your PC.";
        if (Input.GetKeyDown(KeyCode.W))
        {
            myState = States.UpstairsLanding3;
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            myState = States.PCLook3;
        }
    }

    void KeyTray3 ()
    {
        text.text = "Your empty, heavy looking (but surprisingly light...and cheap) brown wooden key tray." +
                    "\n" +
                    "\n" +
                    "Press S to stop looking at the key tray.";
        if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.DownstairsLanding3;
        }
    }

    void PCLook3()
    {
        text.text = "Your PC, your solice, your hobby and friend." +
                    "\n" +
                    "You try to imagine what it would be like to be playing a PC within a video game, and then shake your head at the absurdity." +
                    "\n" +
                    "\n" +
                    "Press S to stop looking at your PC.";
        if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.Bedroom3;
        }
    }

    void PCUse3()
    {

    }

    void Outside3()
    {

    }

    void FrontDoor4 ()
    {
        text.text = "Your white front door, recently glossed by yourself and your partner." +
                    "\n" +
                    "\n" +
                    "Press S to stop looking at your front door.";
        if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.DownstairsLanding4;
        }
    }

    void FrontDoorOutside4()
    {
        text.text = "Your front door, blue from this side." +
                    "\n" +
                    "\n" +
                    "Press S to stop looking at your front door";
        if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.Outside4;
        }
    }

    void Car4 ()
    {
        text.text = "Your black Suzuki Swift, always seems to need a wash this time of year." +
                    "\n" +
                    "\n" +
                    "Press S to stop looking at your car and press D to drive your car to the concert.";
        if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.Outside4;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            myState = States.GameWon;
        }
    }

    void PartnerLook4 ()
    {
        text.text = "She looks at you perplexingly, as if to say \"Why did you leave and then come back inside?\"" +
                    "\n" +
                    "\n" +
                    "Press S to stop looking at your partner, press T to talk to your partner.";
        if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.FrontRoom4;
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            myState = States.PartnerTalk4;
        }
    }

    void PartnerTalk4 ()
    {
        text.text = "\"Have you forgotten something?\" asks your partner." +
                    "\n" +
                    "\n" +
                    "Press S to stop talking to your partner.";
        if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.FrontRoom4;
        }
    }

    void FrontRoom4 ()
    {
        text.text = "You're in your front room, you find the shabby chic look of it's decor comforting and visually appealing." +
                    "\n" +
                    "Your partner is sat on the couch (which you hate and can't wait to replace) and on her phone, she acknowledges you with a loving look." +
                    "\n" +
                    "\n" +
                    "Press L to look at your partner, T to talk to your partner and press E to exit back to the downstairs landing.";
        if (Input.GetKeyDown(KeyCode.L))
        {
            myState = States.PartnerLook4;
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            myState = States.PartnerTalk4;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            myState = States.DownstairsLanding4;
        }
    }

    void DownstairsLanding4 ()
    {
        text.text = "You stand in your unremarkable downstairs landing." +
                    "\n" +
                    "The upstairs landing directly behind you, the front room to your left, key tray to your right and your white front door directly ahead." +
                    "\n" +
                    "\n" +
                    "Press U to walk up stairs to the upstairs landing, press L to look at the key tray, press F to enter the front room," +
                    "\n" +
                    "press D to look at front door, press O to unlock your front door and go outside.";
        if (Input.GetKeyDown(KeyCode.U))
        {
            myState = States.UpstairsLanding4;
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            myState = States.KeyTray4;
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            myState = States.FrontRoom4;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            myState = States.FrontDoor4;
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            myState = States.Outside4;
        }
    }

    void UpstairsLanding4 ()
    {
        text.text = "You stand on your ugly beige carpet on your upstairs landing." +
                    "\n" +
                    "It could do with a quick hoover, though now really isn't the time." +
                    "\n" +
                    "\n" +
                    "Press B to walk to the bedroom, press D to go down the stairs to the downstairs landing.";
        if (Input.GetKeyDown(KeyCode.B))
        {
            myState = States.Bedroom4;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            myState = States.DownstairsLanding4;
        }
    }

    void Bedroom4 ()
    {
        text.text = "Your're in your bedroom which is nice and warm, it's Winter so the heating is on." +
                    "\n" +
                    "You're very excited that you've booked the Springsteen tickets, you almost jump for joy." +
                    "\n" +
                    "\n" +
                    "Press W to walk to the upstairs landing, press L to look at your PC.";
        if (Input.GetKeyDown(KeyCode.W))
        {
            myState = States.UpstairsLanding4;
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            myState = States.PCLook4;
        }
    }

    void KeyTray4 ()
    {
        text.text = "Your empty, heavy looking (but surprisingly light...and cheap) brown wooden key tray." +
                    "\n" +
                    "\n" +
                    "Press S to stop looking at the key tray.";
        if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.DownstairsLanding4;
        }
    }

    void PCLook4 ()
    {
        text.text = "Your PC, your solice, your hobby and friend." +
                    "\n" +
                    "You try to imagine what it would be like to be playing a PC within a video game, and then shake your head at the absurdity." +
                    "\n" +
                    "\n" +
                    "Press S to stop looking at your PC.";
        if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.Bedroom4;
        }
    }

    void PCUse4 ()
    {

    }

    void Outside4 ()
    {
        text.text = "You stand outside, your front door locked behind you. Your black Suzuki Swift to your left." +
                    "\n" +
                    "\n" +
                    "Press L to look at the front door, O to unlock your front door and go inside, press C to look at your car, and press D to drive your car to the concert.";
        if (Input.GetKeyDown(KeyCode.L))
        {
            myState = States.FrontDoorOutside4;
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            myState = States.DownstairsLanding4;
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            myState = States.Car4;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            myState = States.GameWon;
        }
    }

    void GameWon ()
    {
        text.text = "You drive to the concert and have an amazing time rocking out to Bruce." +
                    "\n" +
                    "\n" +
                    "Press P to play again.";
        if (Input.GetKeyDown(KeyCode.P))
        {
            myState = States.Bedroom0;
        }
    }
}

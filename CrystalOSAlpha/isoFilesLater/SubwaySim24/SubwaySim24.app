#Define Window_Main
{
    this.Title = "SubwaySim 24";
    this.X = 0;
    this.Y = 0;
    this.Width = 1920;
    this.Height = 1005;
    this.Titlebar = true;
    this.RGB = 60, 60, 60;
    this.Icon = "1:\SubwaySim24\Assets\icon.bmp";
    PictureBox Interior = new PictureBox(0, 0, "1:\SubwaySim24\Assets\Interior.bmp", true);
    //PictureBox Tunnel = new PictureBox(0, 0, "1:\SubwaySim24\Assets\Tunnel1.bmp", true);
    PictureBox Tunnel = new PictureBox(0, 0, 1920, 1080, true);

    //Points
    //Rails

    //Rail1
    //Left side
    Point p1 = new Point(770, 720);
    Point p2 = new Point(954, 463);
    Point p3 = new Point(1023, 368);
    Point p4 = new Point(1038, 346);
    Point p40 = new Point(1047, 333);
    
    //Right side
    Point p11 = new Point(1051, 333);
    Point p21 = new Point(1045, 344);
    Point p31 = new Point(1030, 368);
    Point p41 = new Point(962, 467);
    Point p42 = new Point(788, 720);

    //Rail2
    //Left side
    Point q1 = new Point(1097, 697);
    Point q2 = new Point(1081, 463);
    Point q3 = new Point(1080, 368);
    Point q4 = new Point(1078, 346);
    Point q40 = new Point(1077, 333);
    
    //Right side
    Point q11 = new Point(1082, 333);
    Point q21 = new Point(1083, 344);
    Point q31 = new Point(1086, 368);
    Point q41 = new Point(1096, 467);
    Point q42 = new Point(1116, 697);

    //Ground
    Point Ground1 = new Point(231, 574);
    Point Ground2 = new Point(973, 332);
    Point Ground3 = new Point(1089, 334);
    Point Ground4 = new Point(1287, 720);
    Point Ground5 = new Point(230, 720, 720);

    //Tunnel
    //Left Side
    Point T1 = new Point(1, 505);
    Point T2 = new Point(2, 1);
    Point T3 = new Point(987, 1);
    Point T4 = new Point(986, 185);
    Point T5 = new Point(947, 220);
    Point T6 = new Point(935, 278);
    Point T7 = new Point(970, 332);
    Point T8 = new Point(619, 452);
    Point T9 = new Point(507, 505);
    //Right Side
    Point T11 = new Point(985, 1);
    Point T12 = new Point(1920, 1);
    Point T13 = new Point(1919, 505);
    Point T15 = new Point(1412, 505);
    Point T16 = new Point(1140, 435);
    Point T17 = new Point(1090, 333);
    Point T18 = new Point(1114, 273);
    Point T19 = new Point(1098, 216);
    Point T20 = new Point(1055, 185);
    Point T21 = new Point(986, 185);

    //Start of station
    Point S1 = new Point(1098, 213);
    Point S2 = new Point(1920, 213);
    Point S3 = new Point(1920, 457);
    Point S4 = new Point(1178, 434);
    Point S5 = new Point(1098, 310);

    Point S6 = new Point(1098, 310);
    Point S7 = new Point(1293, 309);
    Point S8 = new Point(1920, 457);
    Point S9 = new Point(1178, 434);
    //End of station

    //Background
    Tunnel.Clear(42, 42, 42);
    //Ground
    Tunnel.FilledPollygon(25, 25, 25, Ground1, Ground2, Ground3, Ground4, Ground5);
    //Rails
    Tunnel.FilledPollygon(64, 63, 60, p1, p2, p3, p4, p40, p11, p21, p31, p41, p42);
    Tunnel.FilledPollygon(64, 63, 60, q1, q2, q3, q4, q40, q11, q21, q31, q41, q42);
    //Tunnel
    Tunnel.FilledPollygon(30, 30, 30, T1, T2, T3, T4, T5, T6, T7, T8, T9);
    Tunnel.FilledPollygon(30, 30, 30, T11, T12, T13, T15, T16, T17, T18, T19, T20, T21);
    //Station
    Tunnel.FilledPollygon(255, 168, 0, S1, S2, S3, S4, S5);
    Tunnel.FilledPollygon(255, 255, 255, S6, S7, S8, S9);

    //Game Graphics
    Interior.MergeOnto(Tunnel);
    
    Label VehicleName = new Label(125, 853, VehicleBrand, 255, 255, 255);
    Label VehicleL = new Label(125, 880, VehicleLength, 255, 255, 255);
    Label VehicleW = new Label(125, 907, VehicleWeight, 255, 255, 255);
    Label VehicleMaxS = new Label(125, 934, VehicleMaxSpeed, 255, 255, 255);

    Label VehicleS = new Label(345, 853, VehicleSpeed, 255, 255, 255);
    Label VehicleT = new Label(345, 880, VehicleThrotle, 255, 255, 255);
    Label VehicleB = new Label(345, 907, VehicleBrake, 255, 255, 255);

    Label Time = new Label(1480, 25, Seconds, 255, 162, 0);
    Label WaitTime = new Label(1480, 50, WaitInStation, 255, 162, 0);
    Label Travelled = new Label(1480, 75, TravelledDistance, 255, 162, 0);
    Label Score = new Label(672, 824, Points, 255, 255, 255);
    Label LDoorState = new Label(672, 844, "Left door: Closed", 255, 255, 255);
    Label RDoorState = new Label(672, 864, "Right door: Closed", 255, 255, 255);
    Label NextStop = new Label(672, 884, "Next stop: ", 255, 255, 255);

    //GPS
    Label SpeedL = new Label(533, 588, SpeedLimit, 1, 1, 1);

    //Control UI
    //Throtle
    Button ThrotleUp = new Button(1660, 540, 104, 60, "Throtle Up", 1, 1, 1);
    Button ThrotleDown = new Button(1660, 620, 104, 60, "Throtle Down", 1, 1, 1);

    //Brake
    Button BrakeUp = new Button(1781, 540, 104, 60, "Brake Up", 1, 1, 1);
    Button BrakeDown = new Button(1781, 620, 104, 60, "Brake Down", 1, 1, 1);

    //Index
    Button IndexL = new Button(1660, 463, 104, 60, "Index Left", 1, 1, 1);
    Button IndexR = new Button(1781, 463, 104, 60, "Index Right", 1, 1, 1);

    //Door handling
    Button DoorL = new Button(1660, 385, 104, 60, "Door Left", 1, 1, 1);
    Button DoorR = new Button(1781, 385, 104, 60, "Door Right", 1, 1, 1);

    //Horn
    Button Horn = new Button(1660, 308, 225, 60, "Horn", 1, 1, 1);
}
#Define Variables
{
    //Vehicle status
    string VehicleBrand = "Test subway";
    string VehicleLength = "25 Meter";
    string VehicleWeight = "34 Tonn";
    string VehicleMaxSpeed = "120 KM/H";

    int VehicleThrotle = 0;
    int VehicleBrake = 0;
    int VehicleGear = 0;
    int VehicleSpeed = 0;
    bool Horn = false;
    bool LDoorOpened = false;
    bool RDoorOpened = false;

    //Game mechanics
    int Seconds = 0;
    int Now = DateTime.UtcNow.Second;
    int WaitInStation = 8;
    int TravelledDistance = 0;

    //Player status
    int pts = 0;
    bool givepts = true;

    //Stations
    string Station1 = "Silverline Square";
    string Station2 = "Azure Abyss";
    string Station3 = "Golden Gateway";
    string Station4 = "Amethyst Arcade";
    string Station5 = "Lunar Labirinth";
    string Station6 = "Pearl Plaza";

    //GPS
    Point Location = new Point(298, 626);
    bool UpdatePos = false;
    int SpeedLimit = 0;
}
#void Looping
{
    //Gametic
    int CurrentSecond = DateTime.UtcNow.Second;
    if(CurrentSecond != Now)
    {
        //Adjust vehicle speed
        InjectCode("1:\SubwaySim24\GameLogic\SpeedControl.ins");
        InjectCode("1:\SubwaySim24\GameLogic\BreakingSystem.ins");

        //Time spent in-game
        Seconds += 1;
        Now = CurrentSecond;
        string temp = "Ellapsed time: " + Seconds + "s";
        Time.Content = temp;

        //Time spent waiting in station
        if(WaitInStation > 0)
        {
            WaitInStation -= 1;
            string countBack = "You can leave the station after " + WaitInStation + " seconds.";
            WaitTime.Content = countBack;
            WaitTime.Color = 255, 162, 0;
        }
        else
        {
            string countBack = "You can now leave the station! Drive safe!";
            WaitTime.Content = countBack;
            WaitTime.Color = 0, 255, 0;
        }
        //Measure distance in meter
        if(VehicleSpeed != 0)
        {
            int Dist = VehicleSpeed * 0.277778;
            TravelledDistance += Dist;
            string TravelledDist = "Distance travelled: " + TravelledDistance + " meter(s)";
            Travelled.Content = TravelledDist;        
        }
        
        //Rendering railway
        InjectCode("1:\SubwaySim24\Maps\Map1.ins");
        //End of rendering railway

        string pnts = "Player score: " + pts + "pts";
		Score.Content = pnts;

        Tunnel.Clear(42, 42, 42);
        Tunnel.FilledPollygon(25, 25, 25, Ground1, Ground2, Ground3, Ground4, Ground5);
        Tunnel.FilledPollygon(64, 63, 60, p1, p2, p3, p4, p40, p11, p21, p31, p41, p42);
        Tunnel.FilledPollygon(64, 63, 60, q1, q2, q3, q4, q40, q11, q21, q31, q41, q42);

        Tunnel.FilledPollygon(30, 30, 30, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10);
        Tunnel.FilledPollygon(30, 30, 30, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21);
        //Station
        InjectCode("1:\SubwaySim24\GameLogic\Stations.ins");

        Interior.MergeOnto(Tunnel);
        //GPS
        InjectCode("1:\SubwaySim24\Maps\GPS.ins");
    }
    //End of Gametic
}
#OnClick ThrotleUp
{
    InjectCode("1:\SubwaySim24\GameLogic\ThrotleUp.ins");
}
#OnClick ThrotleDown
{
    InjectCode("1:\SubwaySim24\GameLogic\ThrotleBack.ins");
}
#OnClick BrakeUp
{
    if(VehicleBrake < 5)
    {
        VehicleBrake += 1;
        VehicleB.Content = VehicleBrake;
    }
    if(VehicleBrake != 0)
    {
        VehicleThrotle = 0;
        string ModifyType = VehicleThrotle + " ";
        VehicleT.Content = ModifyType;
    }
}
#OnClick BrakeDown
{
    if(VehicleBrake > 0)
    {
        VehicleBrake -= 1;
        VehicleB.Content = VehicleBrake;
    }
    if(VehicleBrake != 0)
    {
        VehicleThrotle = 0;
        string ModifyType = VehicleThrotle + " ";
        VehicleT.Content = ModifyType;
    }
}
#OnClick Horn
{
    PCSpeaker.Beep(350, 1200);
}
#OnClick DoorL
{
    if(LDoorOpened == true)
    {
        LDoorOpened = false;
        LDoorState.Content = "Left door: Closed";
    }
    else
    {
        LDoorOpened = true;
        LDoorState.Content = "Left door: Opened";
    }
}
#OnClick DoorR
{
    if(RDoorOpened == true)
    {
        RDoorState.Content = "Right door: Closed";
        RDoorOpened = false;
    }
    else
    {
        RDoorState.Content = "Right door: Opened";
        RDoorOpened = true;
    }
}
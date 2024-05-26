﻿using Cosmos.System.Graphics;
using CrystalOSAlpha.Applications;
using CrystalOSAlpha.Applications.CarbonIDE;
using CrystalOSAlpha.Graphics.Engine;
using CrystalOSAlpha.Graphics;
using CrystalOSAlpha.UI_Elements;
using System.Drawing;
using System;
using System.Collections.Generic;
using Cosmos.System;
using System.Net.Http.Headers;
using CrystalOSAlpha.Graphics.TaskBar;

namespace CrystalOSAlpha.System32.Installer
{
    class Layout : App
    {
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }
        public int width { get; set; }
        public int height { get; set; }

        public int desk_ID { get; set; }

        public int AppID { get; set; }
        public string name { get; set; }
        public bool minimised { get; set; }
        public bool movable { get; set; }
        public bool once { get; set; }
        public Bitmap icon { get; set; }
        public Bitmap window { get; set; }
        public Bitmap canvas;
        public Bitmap back_canvas;

        public bool initial = true;
        public bool temp = true;
        public int CurrentColor = ImprovedVBE.colourToNumber(GlobalValues.R, GlobalValues.G, GlobalValues.B);
        public int memory = 0;

        public List<UIElementHandler> Elements = new List<UIElementHandler>();
        public Layout(int X, int Y, int Z, int Width, int Height, string Title, Bitmap Icon)
        {
            x = X;
            y = Y;
            z = Z;
            width = Width;
            height = Height;
            name = Title;
            icon = Icon;
        }

        public void App()
        {
            if (initial == true)
            {
                #region Wallpapers
                Elements.Add(new PictureBox(40, 160, "Default", true, ImprovedVBE.ScaleImageStock(ImprovedVBE.Temp, 250, 140)));

                //All these color presets were evacuated from CrystalOS 1.0. Rest In Peace my friend...
                Elements.Add(new Button(40, 332, 24, 24, "", Color.Green.ToArgb(), "CrystalGreen"));
                Elements.Add(new Button(85, 332, 24, 24, "", Color.Blue.ToArgb(), "CrystalBlue"));
                Elements.Add(new Button(130, 332, 24, 24, "", Color.Yellow.ToArgb(), "CrystalYellow"));
                Elements.Add(new Button(175, 332, 24, 24, "", Color.Red.ToArgb(), "CrystalRed"));
                Elements.Add(new Button(220, 332, 24, 24, "", Color.Orange.ToArgb(), "CrystalOrange"));
                Elements.Add(new Button(265, 332, 24, 24, "", 2, "CrystalBlack"));

                Elements.Add(new Button(40, 380, 24, 24, "", Color.Pink.ToArgb(), "CrystalPink"));
                Elements.Add(new Button(85, 380, 24, 24, "", Color.Purple.ToArgb(), "CrystalPurple"));
                Elements.Add(new Button(130, 380, 24, 24, "", Color.Aqua.ToArgb(), "CrystalAqua"));
                Elements.Add(new Button(175, 380, 24, 24, "", Color.White.ToArgb(), "CrystalWhite"));

                //New color palett
                //Generated by non other than ChatGPT
                Elements.Add(new Button(220, 380, 24, 24, "", ImprovedVBE.colourToNumber(255, 215, 0), "GoldenSunshine"));
                Elements.Add(new Button(265, 380, 24, 24, "", ImprovedVBE.colourToNumber(255, 127, 80), "CoralOrange"));

                Elements.Add(new Button(40, 429, 24, 24, "", ImprovedVBE.colourToNumber(255, 204, 104), "PeachPink"));
                Elements.Add(new Button(85, 429, 24, 24, "", Color.SkyBlue.ToArgb(), "SkyBlue"));
                Elements.Add(new Button(130, 429, 24, 24, "", ImprovedVBE.colourToNumber(30, 144, 255), "OceanBlue"));
                Elements.Add(new Button(175, 429, 24, 24, "", ImprovedVBE.colourToNumber(64, 224, 208), "TurquoiseTeal"));
                Elements.Add(new Button(220, 429, 24, 24, "", ImprovedVBE.colourToNumber(0, 128, 0), "EmeraldGreen"));
                Elements.Add(new Button(265, 429, 24, 24, "", ImprovedVBE.colourToNumber(152, 255, 152), "MintGreen"));

                Elements.Add(new Button(40, 477, 24, 24, "", ImprovedVBE.colourToNumber(204, 204, 255), "LavenderPurple"));
                Elements.Add(new Button(85, 477, 24, 24, "", ImprovedVBE.colourToNumber(192, 192, 192), "SoothingGray"));
                #endregion Wallpaper

                #region Menubars
                Elements.Add(new Button(40, 586, 130, 25, "Nostalgia", 1, "Nostalgia"));
                Elements.Add(new Button(185, 586, 130, 25, "Float-up", 1, "FloatUp"));
                #endregion Menubars

                #region Sliders
                Elements.Add(new Slider(392, 176, 290, 1, 255, GlobalValues.R, "WindowRed"));
                Elements.Add(new Slider(392, 200, 290, 1, 255, GlobalValues.G, "WindowGreen"));
                Elements.Add(new Slider(392, 224, 290, 1, 255, GlobalValues.B, "WindowBlue"));

                Elements.Add(new Slider(392, 277, 290, 1, 255, GlobalValues.TaskBarR, "TaskbarRed"));
                Elements.Add(new Slider(392, 301, 290, 1, 255, GlobalValues.TaskBarG, "TaskbarGreen"));
                Elements.Add(new Slider(392, 325, 290, 1, 255, GlobalValues.TaskBarB, "TaskbarBlue"));

                Elements.Add(new Slider(392, 383, 290, 1, 255, GlobalValues.StartColor.R, "SatrtRed"));
                Elements.Add(new Slider(392, 407, 290, 1, 255, GlobalValues.StartColor.G, "StartGreen"));
                Elements.Add(new Slider(392, 431, 290, 1, 255, GlobalValues.StartColor.B, "StartBlue"));

                Elements.Add(new Slider(392, 480, 290, 1, 255, GlobalValues.EndColor.R, "EndRed"));
                Elements.Add(new Slider(392, 504, 290, 1, 255, GlobalValues.EndColor.G, "EndGreen"));
                Elements.Add(new Slider(392, 528, 290, 1, 255, GlobalValues.EndColor.B, "EndBlue"));

                Elements.Add(new Slider(392, 583, 290, 0, 100, GlobalValues.LevelOfTransparency, "Transparency"));

                Elements.Add(new Slider(392, 632, 290, 0, 255, GlobalValues.IconR, "IconR"));
                Elements.Add(new Slider(392, 656, 290, 0, 255, GlobalValues.IconG, "IconG"));
                Elements.Add(new Slider(392, 680, 290, 0, 255, GlobalValues.IconB, "IconB"));
                #endregion Sliders

                #region Dropdown
                Elements.Add(new Dropdown(841, 164, 410, 35, "KeyboardLayout",
                    new List<values>
                    {
                        new values(true, "US/English", "KeyboardLayout"),
                        new values(false, "HU/Hungarian", "KeyboardLayout")
                    }));
                #endregion Dropdown

                Elements.Add(new Button(width - 215, height - 98, 192, 58, "Next", 1, "Next"));
                once = true;
                initial = false;
            }
            if (once == true)
            {
                (canvas, back_canvas, window) = WindowGenerator.Generate(x, y, width, height, CurrentColor, name);

                BitFont.DrawBitFontString(canvas, "VerdanaCustomCharset32", Color.White, "Preferences", 30, 52);
                BitFont.DrawBitFontString(canvas, "VerdanaCustomCharset24", Color.White, "Wallpapers", 40, 122);
                BitFont.DrawBitFontString(canvas, "VerdanaCustomCharset24", Color.White, "Menubar options", 40, 574);
                BitFont.DrawBitFontString(canvas, "VerdanaCustomCharset24", Color.White, "Global colors", 390, 122);
                BitFont.DrawBitFontString(canvas, "VerdanaCustomCharset24", Color.White, "Keyboard settings", 841, 122);
                BitFont.DrawBitFontString(canvas, "VerdanaCustomCharset24", Color.White, "Mouse settings", 841, 240);

                //Slider text
                BitFont.DrawBitFontString(canvas, "ArialCustomCharset16", Color.White, "Window color", 390, 164);
                BitFont.DrawBitFontString(canvas, "ArialCustomCharset16", Color.White, "Taskbar color", 390, 269);
                BitFont.DrawBitFontString(canvas, "ArialCustomCharset16", Color.White, "Start color(titlebar)", 390, 375);
                BitFont.DrawBitFontString(canvas, "ArialCustomCharset16", Color.White, "End color(titlebar)", 390, 472);
                BitFont.DrawBitFontString(canvas, "ArialCustomCharset16", Color.White, "Transparency", 390, 574);
                BitFont.DrawBitFontString(canvas, "ArialCustomCharset16", Color.White, "Icon background", 390, 624);
                BitFont.DrawBitFontString(canvas, "ArialCustomCharset16", Color.Gray, "Not yet supported!", 851, 277);

                Array.Copy(canvas.RawData, 0, window.RawData, 0, canvas.RawData.Length);
                once = false;
                temp = true;
            }

            if(temp == true)
            {
                Array.Copy(canvas.RawData, 0, window.RawData, 0, canvas.RawData.Length);
                BitFont.DrawBitFontString(window, "ArialCustomCharset16", Color.White, "Red: " + Elements.Find(d => d.ID == "WindowRed").Value, 692, 192);
                BitFont.DrawBitFontString(window, "ArialCustomCharset16", Color.White, "Green: " + Elements.Find(d => d.ID == "WindowGreen").Value, 692, 216);
                BitFont.DrawBitFontString(window, "ArialCustomCharset16", Color.White, "Blue: " + Elements.Find(d => d.ID == "WindowBlue").Value, 692, 240);

                BitFont.DrawBitFontString(window, "ArialCustomCharset16", Color.White, "Red: " + Elements.Find(d => d.ID == "TaskbarRed").Value, 692, 293);
                BitFont.DrawBitFontString(window, "ArialCustomCharset16", Color.White, "Green: " + Elements.Find(d => d.ID == "TaskbarGreen").Value, 692, 317);
                BitFont.DrawBitFontString(window, "ArialCustomCharset16", Color.White, "Blue: " + Elements.Find(d => d.ID == "TaskbarBlue").Value, 692, 341);

                BitFont.DrawBitFontString(window, "ArialCustomCharset16", Color.White, "Red: " + Elements.Find(d => d.ID == "SatrtRed").Value, 692, 399);
                BitFont.DrawBitFontString(window, "ArialCustomCharset16", Color.White, "Green: " + Elements.Find(d => d.ID == "StartGreen").Value, 692, 423);
                BitFont.DrawBitFontString(window, "ArialCustomCharset16", Color.White, "Blue: " + Elements.Find(d => d.ID == "StartBlue").Value, 692, 447);

                BitFont.DrawBitFontString(window, "ArialCustomCharset16", Color.White, "Red: " + Elements.Find(d => d.ID == "EndRed").Value, 692, 496);
                BitFont.DrawBitFontString(window, "ArialCustomCharset16", Color.White, "Green: " + Elements.Find(d => d.ID == "EndGreen").Value, 692, 520);
                BitFont.DrawBitFontString(window, "ArialCustomCharset16", Color.White, "Blue: " + Elements.Find(d => d.ID == "EndBlue").Value, 692, 544);

                BitFont.DrawBitFontString(window, "ArialCustomCharset16", Color.White, "Level: " + (100 - Elements.Find(d => d.ID == "Transparency").Value) / 100.0f, 692, 599);

                BitFont.DrawBitFontString(window, "ArialCustomCharset16", Color.White, "Red: " + Elements.Find(d => d.ID == "IconR").Value, 692, 648);
                BitFont.DrawBitFontString(window, "ArialCustomCharset16", Color.White, "Green: " + Elements.Find(d => d.ID == "IconG").Value, 692, 672);
                BitFont.DrawBitFontString(window, "ArialCustomCharset16", Color.White, "Blue: " + Elements.Find(d => d.ID == "IconB").Value, 692, 696);
                temp = false;
            }

            foreach(var element in Elements)
            {
                if(element.Clicked == true && element.TypeOfElement == TypeOfElement.PictureBox)
                {
                    ImprovedVBE.DrawFilledRectangle(window, ImprovedVBE.colourToNumber(69, 99, 255), element.X - 3, element.Y + 19, element.Width + 6, element.Height + 6);
                }
                if(element.TypeOfElement == TypeOfElement.Slider)
                {
                    if (element.CheckClick(x, y))
                    {
                        switch (element.ID)
                        {
                            case "WindowRed":
                                GlobalValues.R = element.Value;
                                break;
                            case "WindowGreen":
                                GlobalValues.G = element.Value;
                                break;
                            case "WindowBlue":
                                GlobalValues.B = element.Value;
                                break;
                            case "TaskbarRed":
                                GlobalValues.TaskBarR = element.Value;
                                TaskManager.resize = true;
                                break;
                            case "TaskbarGreen":
                                GlobalValues.TaskBarG = element.Value;
                                TaskManager.resize = true;
                                break;
                            case "TaskbarBlue":
                                GlobalValues.TaskBarB = element.Value;
                                TaskManager.resize = true;
                                break;
                            case "SatrtRed":
                                Color StartR = Color.FromArgb(element.Value, GlobalValues.StartColor.G, GlobalValues.StartColor.B);
                                GlobalValues.StartColor = StartR;
                                break;
                            case "StartGreen":
                                Color StartG = Color.FromArgb(GlobalValues.StartColor.R, element.Value, GlobalValues.StartColor.B);
                                GlobalValues.StartColor = StartG;
                                break;
                            case "StartBlue":
                                Color StartB = Color.FromArgb(GlobalValues.StartColor.R, GlobalValues.StartColor.G, element.Value);
                                GlobalValues.StartColor = StartB;
                                break;
                            case "EndRed":
                                Color EndR = Color.FromArgb(element.Value, GlobalValues.EndColor.G, GlobalValues.EndColor.B);
                                GlobalValues.EndColor = EndR;
                                break;
                            case "EndGreen":
                                Color EndG = Color.FromArgb(GlobalValues.EndColor.R, element.Value, GlobalValues.EndColor.B);
                                GlobalValues.EndColor = EndG;
                                break;
                            case "EndBlue":
                                Color EndB = Color.FromArgb(GlobalValues.EndColor.R, GlobalValues.EndColor.G, element.Value);
                                GlobalValues.EndColor = EndB;
                                break;
                            case "IconR":
                                GlobalValues.IconR = element.Value;
                                break;
                            case "IconG":
                                GlobalValues.IconG = element.Value;
                                break;
                            case "IconB":
                                GlobalValues.IconB = element.Value;
                                break;
                            case "Transparency":
                                if (element.Value > 40)
                                {
                                    TaskManager.update = true;
                                    TaskManager.resize = true;
                                    SideNav.Get_Back = true;
                                    GlobalValues.LevelOfTransparency = element.Value;
                                }
                                break;
                        }
                        temp = true;
                    }
                }
                else if(element.TypeOfElement == TypeOfElement.DropDown)
                {
                    bool StoreClick = element.Clicked;
                    element.CheckClick(x, y);
                    if (StoreClick != element.Clicked)
                    {
                        temp = true;
                    }

                    if (element.Text == "US/English")
                    {
                        GlobalValues.KeyboardLayout = KeyboardLayout.EN_US;
                    }
                    else if (element.Text == "HU/Hungarian")
                    {
                        GlobalValues.KeyboardLayout = KeyboardLayout.HUngarian;
                    }
                }
                element.Render(window);
                if(MouseManager.MouseState == MouseState.Left)
                {
                    if(MouseManager.X > x + element.X && MouseManager.X < x + element.X + element.Width)
                    {
                        if(MouseManager.Y > y + element.Y && MouseManager.Y < y + element.Y + element.Height)
                        {
                            switch(element.TypeOfElement)
                            {
                                case TypeOfElement.Button:
                                    int Col = element.Color;
                                    element.Color = ComplimentaryColor.Generate(Col).ToArgb();
                                    foreach (var e in Elements)
                                    {
                                        if (e.TypeOfElement == element.TypeOfElement && element.Text.Length <= 1 && e.Text.Length <= 1)
                                        {
                                            e.Text = "";
                                        }
                                        else if (e.TypeOfElement == TypeOfElement.PictureBox && element.Text.Length <= 1)
                                        {
                                            e.Clicked = false;
                                        }
                                    }
                                    switch (element.ID)
                                    {
                                        case "CrystalGreen":
                                            GlobalValues.Background_type = "Monocolor";
                                            GlobalValues.Background_color = element.ID;
                                            TaskManager.resize = true;
                                            TaskManager.Time = 99;
                                            element.Text = "x";
                                            break;
                                        case "CrystalBlue":
                                            GlobalValues.Background_type = "Monocolor";
                                            GlobalValues.Background_color = element.ID;
                                            TaskManager.resize = true;
                                            TaskManager.Time = 99;
                                            element.Text = "x";
                                            break;
                                        case "CrystalYellow":
                                            GlobalValues.Background_type = "Monocolor";
                                            GlobalValues.Background_color = element.ID;
                                            TaskManager.resize = true;
                                            TaskManager.Time = 99;
                                            element.Text = "x";
                                            break;
                                        case "CrystalOrange":
                                            GlobalValues.Background_type = "Monocolor";
                                            GlobalValues.Background_color = element.ID;
                                            TaskManager.resize = true;
                                            TaskManager.Time = 99;
                                            element.Text = "x";
                                            break;
                                        case "CrystalRed":
                                            GlobalValues.Background_type = "Monocolor";
                                            GlobalValues.Background_color = element.ID;
                                            TaskManager.resize = true;
                                            TaskManager.Time = 99;
                                            element.Text = "x";
                                            break;
                                        case "CrystalBlack":
                                            GlobalValues.Background_type = "Monocolor";
                                            GlobalValues.Background_color = element.ID;
                                            TaskManager.resize = true;
                                            TaskManager.Time = 99;
                                            element.Text = "x";
                                            break;
                                        case "CrystalPink":
                                            GlobalValues.Background_type = "Monocolor";
                                            GlobalValues.Background_color = element.ID;
                                            TaskManager.resize = true;
                                            TaskManager.Time = 99;
                                            element.Text = "x";
                                            break;
                                        case "CrystalPurple":
                                            GlobalValues.Background_type = "Monocolor";
                                            GlobalValues.Background_color = element.ID;
                                            TaskManager.resize = true;
                                            TaskManager.Time = 99;
                                            element.Text = "x";
                                            break;
                                        case "CrystalAqua":
                                            GlobalValues.Background_type = "Monocolor";
                                            GlobalValues.Background_color = element.ID;
                                            TaskManager.resize = true;
                                            TaskManager.Time = 99;
                                            element.Text = "x";
                                            break;
                                        case "CrystalWhite":
                                            GlobalValues.Background_type = "Monocolor";
                                            GlobalValues.Background_color = element.ID;
                                            TaskManager.resize = true;
                                            TaskManager.Time = 99;
                                            element.Text = "x";
                                            break;

                                        case "GoldenSunshine":
                                            GlobalValues.Background_type = "Monocolor";
                                            GlobalValues.Background_color = element.ID;
                                            TaskManager.resize = true;
                                            TaskManager.Time = 99;
                                            element.Text = "x";
                                            break;
                                        case "CoralOrange":
                                            GlobalValues.Background_type = "Monocolor";
                                            GlobalValues.Background_color = element.ID;
                                            TaskManager.resize = true;
                                            TaskManager.Time = 99;
                                            element.Text = "x";
                                            break;
                                        case "PeachPink":
                                            GlobalValues.Background_type = "Monocolor";
                                            GlobalValues.Background_color = element.ID;
                                            TaskManager.resize = true;
                                            TaskManager.Time = 99;
                                            element.Text = "x";
                                            break;
                                        case "SkyBlue":
                                            GlobalValues.Background_type = "Monocolor";
                                            GlobalValues.Background_color = element.ID;
                                            TaskManager.resize = true;
                                            TaskManager.Time = 99;
                                            element.Text = "x";
                                            break;
                                        case "OceanBlue":
                                            GlobalValues.Background_type = "Monocolor";
                                            GlobalValues.Background_color = element.ID;
                                            TaskManager.resize = true;
                                            TaskManager.Time = 99;
                                            element.Text = "x";
                                            break;
                                        case "TurquoiseTeal":
                                            GlobalValues.Background_type = "Monocolor";
                                            GlobalValues.Background_color = element.ID;
                                            TaskManager.resize = true;
                                            TaskManager.Time = 99;
                                            element.Text = "x";
                                            break;
                                        case "EmeraldGreen":
                                            GlobalValues.Background_type = "Monocolor";
                                            GlobalValues.Background_color = element.ID;
                                            TaskManager.resize = true;
                                            TaskManager.Time = 99;
                                            element.Text = "x";
                                            break;
                                        case "MintGreen":
                                            GlobalValues.Background_type = "Monocolor";
                                            GlobalValues.Background_color = element.ID;
                                            TaskManager.resize = true;
                                            TaskManager.Time = 99;
                                            element.Text = "x";
                                            break;
                                        case "LavenderPurple":
                                            GlobalValues.Background_type = "Monocolor";
                                            GlobalValues.Background_color = element.ID;
                                            TaskManager.resize = true;
                                            TaskManager.Time = 99;
                                            element.Text = "x";
                                            break;
                                        case "SoothingGray":
                                            GlobalValues.Background_type = "Monocolor";
                                            GlobalValues.Background_color = element.ID;
                                            TaskManager.resize = true;
                                            TaskManager.Time = 99;
                                            element.Text = "x";
                                            break;

                                        case "Next":
                                            TaskScheduler.Apps.Remove(this);
                                            break;
                                    }
                                    element.Render(window);
                                    element.Color = Col;
                                    break;
                                case TypeOfElement.PictureBox:
                                    foreach(var e in Elements)
                                    {
                                        if(e.TypeOfElement == TypeOfElement.Button && e.Text == "x")
                                        {
                                            e.Text = "";
                                        }
                                    }
                                    GlobalValues.Background_type = "Default";
                                    TaskManager.resize = true;
                                    TaskManager.Time = 99;
                                    TaskManager.update = true;
                                    TaskManager.Back_Buffer = null;
                                    element.Clicked = true;
                                    break;
                                case TypeOfElement.DropDown:
                                    element.CheckClick(x, y);
                                    break;
                            }
                            temp = true;
                        }
                    }
                }
            }

            ImprovedVBE.DrawImageAlpha(window, x, y, ImprovedVBE.cover);
        }

        public void RightClick()
        {
            
        }
    }
}

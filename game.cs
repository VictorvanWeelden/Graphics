﻿using System;
//using System.IO;
using OpenTK.Graphics.OpenGL;
using template;

namespace Template {

public class Game
{
	    // member variables
	    public Surface screen;
        public Raytracer raytracer;
        public Scene scene = new Scene();
        public int size = 256;
        int xpositieDebug;
        int ypositieDebug;
        double hoek;
        float r;

        public int CreateColor(int red, int green, int blue)
        {
            return (red << 16) + (green << 8) + blue;
        }

        int CreateColorf(float R, float B, float G)
        {
            return ((int)(R * 255) << 16) + ((int)(B * 255) << 8) + ((int)G * 255);
        }

        // initialize
        public void Init()
	    {
            screen = new Surface(2 * size, size);
            raytracer = new Raytracer(screen, scene, size, size);
	    }

	// tick: renders one frame
	    public void Tick()
	    {
            screen.Clear(CreateColor(0, 0, 0));
            Debug();
            raytracer.Render();            
        }

        public void Debug()
        {                     
            for (int i = 0; i < raytracer.eindpunten.Length; i++)
            {
                screen.Line(((int)Xtrans(raytracer.cameraPosition.X)), ((int)Ytrans(raytracer.cameraPosition.Z)), ((int)Xtrans(raytracer.eindpunten[i].X)), ((int)Ytrans((raytracer.eindpunten[i].Y))), 0xff00ff);// tekent de ray van de camera naar een intersectie
                //screen.Line(((int)Xtrans(raytracer.eindpunten[i].X)), ((int)Ytrans(raytracer.eindpunten[i].Y)), ((int)Xtrans(scene.lightPositie.X)), ((int)Ytrans(scene.lightPositie.Z)),0x00ffff);// tekent de rays van een intersectie naar de lichtbron
            }
            r = scene.radius * (screen.height/10);
            for(double i = 0.0; i < 360.0; i += 0.1)
            {
                hoek = i * Math.PI / 180;
                xpositieDebug = (int)(Xtrans((int)scene.sphere1Positie.X) + r * Math.Cos(hoek));
                ypositieDebug = (int)(Ytrans((int)scene.sphere1Positie.Z) + r * Math.Sin(hoek));
                screen.Plot(xpositieDebug, ypositieDebug, CreateColorf(scene.kleur1.X, scene.kleur1.Y, scene.kleur1.Z));
            }
            for (double i = 0.0; i < 360.0; i += 0.1)
            {
                hoek = i * Math.PI / 180;
                xpositieDebug = (int)(Xtrans((int)scene.sphere2Positie.X) + r * Math.Cos(hoek));
                ypositieDebug = (int)(Ytrans((int)scene.sphere2Positie.Z) + r * Math.Sin(hoek));
                screen.Plot(xpositieDebug, ypositieDebug, CreateColorf(scene.kleur2.X, scene.kleur2.Y, scene.kleur2.Z));
            }
            for (double i = 0.0; i < 360.0; i += 0.1)
            {
                hoek = i * Math.PI / 180;
                xpositieDebug = (int)(Xtrans((int)scene.sphere3Positie.X) + r * Math.Cos(hoek));
                ypositieDebug = (int)(Ytrans((int)scene.sphere3Positie.Z) + r * Math.Sin(hoek));
                screen.Plot(xpositieDebug, ypositieDebug, CreateColorf(scene.kleur3.X, scene.kleur3.Y, scene.kleur3.Z));
            }
            screen.Plot(((int)Xtrans(raytracer.cameraPosition.X)), ((int)Ytrans(raytracer.cameraPosition.Z)), 0xffffff); // geeft de camera positie
            screen.Plot(((int)Xtrans(scene.lightPositie.X)), ((int)Ytrans(scene.lightPositie.Z)), 0x0fffff); // geeft de licht positie
        }

        public float Xtrans(float x)
        {
            return x * (screen.width/20) + (screen.width * 3/4);
        }

        public float Ytrans(float y)
        {
            return screen.height - (y * (screen.height / 10));
        }
    }

}

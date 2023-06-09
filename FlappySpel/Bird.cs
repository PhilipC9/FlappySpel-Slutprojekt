﻿using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using Raylib_cs;
using FlappySpel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace FlappySpel
{
    class Player
    {
        // Spelar variabler
        public const int size = 25;                        // Spelar storlek
        public const int posX = 100;                 // S
        public int jumpHeight = 450;                 // hopphöjd
        private float gravity = 20f;                 // gravitation
        private float ySpeed;                        // fall hastighet
        public bool hasJetpack = false;              // Boolean för jetpack



        // Generisk Dictionary med spelar färger
        Dictionary<int, Color> colorDict = new Dictionary<int, Color>()
    {
        {0, Color.WHITE},
        {1, Color.GREEN},
        {2, Color.BLUE},
        {3, Color.YELLOW},
        {4, Color.ORANGE},
        {5, Color.PURPLE},
        {6, Color.GOLD},
        {7, Color.VIOLET},
        {8, Color.GRAY},
        {9, Color.BROWN}
    };


        // Använder random för att slumpa färg
        private Random random = new Random();
        private Color color;

        public Player()
        {
            SetRandomColor();
        }

        // Väljer en slumpad färg utifrån Dictionary
        public void SetRandomColor()
        {
            int index = random.Next(colorDict.Count);
            color = colorDict[index];
        }


        // Poäng
        public int score { get; private set; }

        // Spelarens position
        public int posY { get; private set; }

        // Boolean som hanterar när spelaren har startat spelet
        public bool fall { get; set; }

        // Återställer alla variabler när spelaren förlorar
        public void InitPlayer()
        {
            posY = (Game.height / 2) - (size / 2);
            score = 0;
            ySpeed = 0f;
            fall = false;
        }

        // Ökar poäng
        public void IncreaseScore()
        {
            score += 1;
        }

        // Funktion för när spelaren hoppar
        public void Jump()
        {
            // När spelaren hoppar för första gången kommer fågeln att börja falla
            if (!fall)          
            {
                fall = true;
            }
            ySpeed = -jumpHeight;
        }

        // Uppdaterar fågelns position
        public void Update(float deltaT)
        {
            // Om spelaren faller
            if (fall)
            {
                // Sätter den nya positionen efter hastighet och gravitation
                posY += (int)(deltaT * ySpeed);
                ySpeed += gravity;
            }
        }
        
        // Ritar ut "fågeln" som just nu är en rektangel
        public void Render()
        {

            DrawRectangle(100, posY, size, size, color);
        }

    }
}

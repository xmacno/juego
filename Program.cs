﻿using System.Collections;
using System.Configuration.Assemblies;
using System.Data;
using System.Diagnostics;
using System.Formats.Asn1;
using System.Reflection.Metadata;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using Spectre.Console;
using System.Media;
using System.Runtime.InteropServices;
using NAudio.Wave;
public class Laberinto
{
    public static int n = 50;
    public static int m = 50;
    public static string[,] matriz = new string[n, m];
    public static int puntos1 = 0;
    public static int puntos2 = 0;
    public static int habilidad1 = 1;
    public static int habilidad2 = 1;
    public static bool turnos = true;
    public static int enfriamiento1 = 0;
    public static int enfriamiento2 = 0;
    public static int cantpaso1 = 0;
    public static int cantpaso2 = 0;

    public static void Menu()
    {


        int k = 0;
        int kk = 0;
        int op = 1;
        while (k == 0)
        {

            while (kk == 0)
            {
                if (op == 1)
                {


                    Console.Clear();
                    Console.WriteLine(" ");
                    AnsiConsole.MarkupLine("[blue]▄█████░██████▄░░░█████▄░██░░░██░▄██████░▄█████░▄████▄░░░██████▄░▄█████░░░██░░░░░▄████▄░▄██████░░░▄██████░▄█████░▄██▄▄██▄░▄████▄░▄██████[/]");
                    AnsiConsole.MarkupLine("[blue]██░░░░░██░░░██░░░██░░██░██░░░██░██░░░░░░██░░░░░██░░██░░░██░░░██░██░░░░░░░██░░░░░██░░██░██░░░░░░░░██░░░░░░██░░░░░██░██░██░██░░██░██░░░░░[/]");
                    AnsiConsole.MarkupLine("[blue]█████░░██░░░██░░░█████░░██░░░██░▀█████▄░██░░░░░██░░██░░░██░░░██░█████░░░░██░░░░░██░░██░▀█████▄░░░██░░███░█████░░██░██░██░██░░██░▀█████▄[/]");
                    AnsiConsole.MarkupLine("[blue]██░░░░░██░░░██░░░██░░██░██░░░██░░░░░░██░██░░░░░██████░░░██░░░██░██░░░░░░░██░░░░░██████░░░░░░██░░░██░░░██░██░░░░░██░██░██░██████░░░░░░██[/]");
                    AnsiConsole.MarkupLine("[blue]▀█████░██░░░██░░░█████▀░▀█████▀░██████▀░▀█████░██░░██░░░██████▀░▀█████░░░██████░██░░██░██████▀░░░▀█████▀░▀█████░██░██░██░██░░██░██████▀[/]");
                    AnsiConsole.MarkupLine("[blue]░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░[/]");
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    AnsiConsole.MarkupLine("> [blue]Jugar[/]");
                    Console.WriteLine("  Controles");
                    Console.WriteLine("  Salir");
                }
                if (op == 2)
                {
                    Console.Clear();
                    Console.WriteLine(" ");
                    AnsiConsole.MarkupLine("[blue]▄█████░██████▄░░░█████▄░██░░░██░▄██████░▄█████░▄████▄░░░██████▄░▄█████░░░██░░░░░▄████▄░▄██████░░░▄██████░▄█████░▄██▄▄██▄░▄████▄░▄██████[/]");
                    AnsiConsole.MarkupLine("[blue]██░░░░░██░░░██░░░██░░██░██░░░██░██░░░░░░██░░░░░██░░██░░░██░░░██░██░░░░░░░██░░░░░██░░██░██░░░░░░░░██░░░░░░██░░░░░██░██░██░██░░██░██░░░░░[/]");
                    AnsiConsole.MarkupLine("[blue]█████░░██░░░██░░░█████░░██░░░██░▀█████▄░██░░░░░██░░██░░░██░░░██░█████░░░░██░░░░░██░░██░▀█████▄░░░██░░███░█████░░██░██░██░██░░██░▀█████▄[/]");
                    AnsiConsole.MarkupLine("[blue]██░░░░░██░░░██░░░██░░██░██░░░██░░░░░░██░██░░░░░██████░░░██░░░██░██░░░░░░░██░░░░░██████░░░░░░██░░░██░░░██░██░░░░░██░██░██░██████░░░░░░██[/]");
                    AnsiConsole.MarkupLine("[blue]▀█████░██░░░██░░░█████▀░▀█████▀░██████▀░▀█████░██░░██░░░██████▀░▀█████░░░██████░██░░██░██████▀░░░▀█████▀░▀█████░██░██░██░██░░██░██████▀[/]");
                    AnsiConsole.MarkupLine("[blue]░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░[/]");
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    Console.WriteLine("  Jugar");
                    AnsiConsole.MarkupLine("> [blue]Controles[/]");
                    Console.WriteLine("  Salir");
                }
                if (op == 3)
                {
                    Console.Clear();
                    Console.WriteLine(" ");
                    AnsiConsole.MarkupLine("[blue]▄█████░██████▄░░░█████▄░██░░░██░▄██████░▄█████░▄████▄░░░██████▄░▄█████░░░██░░░░░▄████▄░▄██████░░░▄██████░▄█████░▄██▄▄██▄░▄████▄░▄██████[/]");
                    AnsiConsole.MarkupLine("[blue]██░░░░░██░░░██░░░██░░██░██░░░██░██░░░░░░██░░░░░██░░██░░░██░░░██░██░░░░░░░██░░░░░██░░██░██░░░░░░░░██░░░░░░██░░░░░██░██░██░██░░██░██░░░░░[/]");
                    AnsiConsole.MarkupLine("[blue]█████░░██░░░██░░░█████░░██░░░██░▀█████▄░██░░░░░██░░██░░░██░░░██░█████░░░░██░░░░░██░░██░▀█████▄░░░██░░███░█████░░██░██░██░██░░██░▀█████▄[/]");
                    AnsiConsole.MarkupLine("[blue]██░░░░░██░░░██░░░██░░██░██░░░██░░░░░░██░██░░░░░██████░░░██░░░██░██░░░░░░░██░░░░░██████░░░░░░██░░░██░░░██░██░░░░░██░██░██░██████░░░░░░██[/]");
                    AnsiConsole.MarkupLine("[blue]▀█████░██░░░██░░░█████▀░▀█████▀░██████▀░▀█████░██░░██░░░██████▀░▀█████░░░██████░██░░██░██████▀░░░▀█████▀░▀█████░██░██░██░██░░██░██████▀[/]");
                    AnsiConsole.MarkupLine("[blue]░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░[/]");
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    Console.WriteLine("  Jugar");
                    Console.WriteLine("  Controles");
                    AnsiConsole.MarkupLine("> [blue]Salir[/]");
                }
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (op < 3) op = op + 1;
                        break;
                    case ConsoleKey.UpArrow:
                        if (op > 1) op = op - 1;
                        break;
                    case ConsoleKey.Enter:
                        Musc.Sonidos(1);
                        if (op != 2) kk = 1;
                        if (op == 2)
                        { Controles(); }
                        break;
                }
            }
            if (op == 1)
            {
                n = TamDelLab();
                m = n;
                Camino();
                Tranpas();
                Points();
                Benef();
                Jugadores();
                MovJug();
                break;
            }
            else if (op == 3)
            {
                Musc.Sonidos(1);
                Console.Clear();
                Environment.Exit(0);
                break;
            }
        }
    }
    // para los controles
    public static void Controles()
    {
        for (int t = 0; t < 1;)
        {
            Console.Clear();
            AnsiConsole.MarkupLine("[blue]CONTROLES:[/]");
            AnsiConsole.MarkupLine("ARRIBA:                ↑");
            AnsiConsole.MarkupLine("ABAJO:                 ↓");
            AnsiConsole.MarkupLine("IZQUIERDA:            <--");
            AnsiConsole.MarkupLine("DERECHA:              -->");
            AnsiConsole.MarkupLine("HABILIDAD ESPECIAL:    X");
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.DownArrow:
                    Console.Clear();
                    AnsiConsole.MarkupLine("[blue]CONTROLES:[/]");
                    AnsiConsole.MarkupLine("ARRIBA:                ↑");
                    AnsiConsole.MarkupLine("ABAJO:                 [blue]↓[/]");
                    AnsiConsole.MarkupLine("IZQUIERDA:            <--");
                    AnsiConsole.MarkupLine("DERECHA:              -->");
                    AnsiConsole.MarkupLine("HABILIDAD ESPECIAL:    X");
                    Thread.Sleep(250);
                    break;
                case ConsoleKey.UpArrow:
                    Console.Clear();
                    AnsiConsole.MarkupLine("[blue]CONTROLES:[/]");
                    AnsiConsole.MarkupLine("ARRIBA:                [blue]↑[/]");
                    AnsiConsole.MarkupLine("ABAJO:                 ↓");
                    AnsiConsole.MarkupLine("IZQUIERDA:            <--");
                    AnsiConsole.MarkupLine("DERECHA:              -->");
                    AnsiConsole.MarkupLine("HABILIDAD ESPECIAL:    X");
                    Thread.Sleep(250);
                    break;
                case ConsoleKey.LeftArrow:
                    Console.Clear();
                    AnsiConsole.MarkupLine("[blue]CONTROLES:[/]");
                    AnsiConsole.MarkupLine("ARRIBA:                ↑");
                    AnsiConsole.MarkupLine("ABAJO:                 ↓");
                    AnsiConsole.MarkupLine("IZQUIERDA:           [blue]<--[/]");
                    AnsiConsole.MarkupLine("DERECHA:              -->");
                    AnsiConsole.MarkupLine("HABILIDAD ESPECIAL:    X");
                    Thread.Sleep(250);
                    break;
                case ConsoleKey.RightArrow:
                    Console.Clear();
                    AnsiConsole.MarkupLine("[blue]CONTROLES:[/]");
                    AnsiConsole.MarkupLine("ARRIBA:                ↑");
                    AnsiConsole.MarkupLine("ABAJO:                 ↓");
                    AnsiConsole.MarkupLine("IZQUIERDA:            <--");
                    AnsiConsole.MarkupLine("DERECHA:             [blue]-->[/]");
                    AnsiConsole.MarkupLine("HABILIDAD ESPECIAL:    X");
                    Thread.Sleep(250);
                    break;
                case ConsoleKey.X:
                    Console.Clear();
                    AnsiConsole.MarkupLine("[blue]CONTROLES:[/]");
                    AnsiConsole.MarkupLine("ARRIBA:                ↑");
                    AnsiConsole.MarkupLine("ABAJO:                 ↓");
                    AnsiConsole.MarkupLine("IZQUIERDA:            <--");
                    AnsiConsole.MarkupLine("DERECHA:              -->");
                    AnsiConsole.MarkupLine("HABILIDAD ESPECIAL:    [blue]X[/]");
                    Thread.Sleep(250);
                    break;
                case ConsoleKey.Escape:
                    t = 2;
                    break;

            }
        }
    }
    //para elegir un tamaño del laberinto
    public static int TamDelLab()
    {
        Random random = new Random();
        for (int i = 1; i > 0;)
        {
            int kk = 0;
            int tam = 0;
            while (kk == 0)
            {
                Console.Clear();
                if (tam == 0)
                {
                    Console.WriteLine("Elija una dimension (N x N) aproximada del mapa en el que desea jugar");
                    AnsiConsole.MarkupLine("> [blue]18-20[/]");
                    Console.WriteLine("  20-25");
                    Console.WriteLine("  25-30");
                    Console.WriteLine("  30-35");
                }
                if (tam == 1)
                {
                    Console.WriteLine("Elija una dimension (N x N) aproximada del mapa en el que desea jugar");
                    Console.WriteLine("  18-20");
                    AnsiConsole.MarkupLine("> [blue]20-25[/]");
                    Console.WriteLine("  25-30");
                    Console.WriteLine("  30-35");
                }
                if (tam == 2)
                {
                    Console.WriteLine("Elija una dimension (N x N) aproximada del mapa en el que desea jugar");
                    Console.WriteLine("  18-20");
                    Console.WriteLine("  20-25");
                    AnsiConsole.MarkupLine("> [blue]25-30[/]");
                    Console.WriteLine("  30-35");
                }
                if (tam == 3)
                {
                    Console.WriteLine("Elija una dimension (N x N) aproximada del mapa en el que desea jugar");
                    Console.WriteLine("  18-20");
                    Console.WriteLine("  20-25");
                    Console.WriteLine("  25-30");
                    AnsiConsole.MarkupLine("> [blue]30-35[/]");
                }
                DescTamDelLab(tam);
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (tam != 3) tam = tam + 1;
                        break;
                    case ConsoleKey.UpArrow:
                        if (tam != 0) tam = tam - 1;
                        break;
                    case ConsoleKey.Enter:
                        Musc.Sonidos(1);
                        kk = 1;
                        break;
                    case ConsoleKey.Escape:
                        kk = 1;
                        Menu();
                        break;
                }
            }

            if (tam == 0)
            {
                int ran = random.Next(18, 21);
                return ran;
            }
            else if (tam == 1)
            {
                int ran = random.Next(20, 26);
                return ran;
            }
            else if (tam == 2)
            {
                int ran = random.Next(25, 30);
                return ran;
            }
            else
            {
                int ran = random.Next(30, 36);
                return ran;
            }

        }
        return 0;
    }
    //este es para que salga una descripcion sobre el tamano del laberinto
    public static void DescTamDelLab(int c)
    {
        Console.WriteLine(" ");
        Console.WriteLine(" ");
        Console.WriteLine(" ");
        Console.ForegroundColor = ConsoleColor.Blue;
        if (c == 0)
        {
            Console.WriteLine("-TAMAÑO: CHICO ");
            Console.WriteLine("-RECOMENDACION: PARA PROBAR ");
        }
        else if (c == 1)
        {
            Console.WriteLine("-TAMAÑO: ESTANDAR ");
            Console.WriteLine("-RECOMENDACION: PARA PROBAR UNA PARTIDA NORMAL ");
        }
        else if (c == 2)
        {
            Console.WriteLine("-TAMAÑO: GRANDE ");
            Console.WriteLine("-RECOMENDACION: PUEDE DEMORAR UN POCO MAS LAS PARTIDAD EN ESTE MAPA ");
        }
        else if (c == 3)
        {
            Console.WriteLine("-TAMAÑO: MUY GRANDE ");
            Console.WriteLine("-RECOMENDACION: PARA UNA PARTIDAD DE MAYOR DURACION ");
        }

        Console.ResetColor();
    }
    //para imprimir el laberinto
    public static void Gameplay(string jug)
    {
        Console.WriteLine("╔═══════════════╦═════════════════╦═════════════════╦═════════════════╦════════════════════╗");
        Console.WriteLine("║   JUGADORES   ║     PUNTOS      ║    CANTIDAD     ║    HABILIDAD    ║   RESTAURACION     ║");
        Console.WriteLine("║               ║                 ║    DE PASOS     ║                 ║ DE LA HABILIDAD    ║");
        Console.WriteLine("╠═══════════════╬═════════════════╬═════════════════╬═════════════════╬════════════════════╣");
        if (turnos)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("║   JUGADOR 1   ║ " + puntos1 + "               ║ " + cantpaso1 + "               ║  " + habilidad1 + "              ║ " + enfriamiento1 + "/3                ║");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine("║   JUGADOR 1   ║ " + puntos1 + "               ║ " + cantpaso1 + "               ║  " + habilidad1 + "              ║ " + enfriamiento1 + "/3                ║");
        }
        Console.WriteLine("╠═══════════════╬═════════════════╬═════════════════╬═════════════════╬════════════════════╣");
        if (turnos == false)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("║   JUGADOR 2   ║ " + puntos2 + "               ║ " + cantpaso2 + "               ║  " + habilidad2 + "              ║ " + enfriamiento2 + "/3                ║");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine("║   JUGADOR 2   ║ " + puntos2 + "               ║ " + cantpaso2 + "               ║  " + habilidad2 + "              ║ " + enfriamiento2 + "/3                ║");
        }
        Console.WriteLine("╚═══════════════╩═════════════════╩═════════════════╩═════════════════╩════════════════════╝");

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (matriz[i, j] == "X")
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                }
                if (matriz[i, j] == "*")
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
                if (matriz[i, j] == jug)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;

                }
                if (matriz[i, j] == "§")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.Write(matriz[i, j]);
                Console.ResetColor();

                Console.Write(" ");
                //Thread.Sleep(250);
            }
            Console.WriteLine();

        }

    }
    //para cuando el personaje use la hablidad te pone lo que hace
    public static void DescDeHab(int habdesc, int t, string jug)
    {
        Console.Clear();
        Gameplay(jug);
        Console.ForegroundColor = ConsoleColor.Blue;
        if (habdesc == 0)
        {

        }
        else if (habdesc == 1)
        {
            Console.WriteLine("LA HABILIDAD ESCOGIDA PERMITE A IRON MAN UTILIZAR SU TRAJE PARA IMPULSARCE Y CAMINAR 3 CASILLAS EXTRAS");
        }
        else if (habdesc == 2)
        {
            Console.WriteLine("LA HABILIDAD ESCOGIDA PERMITE AL CAPITAN AMERICA ATURDIR AL ALVERSARIO CON SU ESCUDO Y SALTAR UN TURNO");
        }
        else if (habdesc == 3)
        {
            Console.WriteLine("LA HABILIDAD ESCOGIDA PERMITE A VENOM USAR UN SIMBIONTE PARA CONTROLAR A TU OPONENTE POR UN TURNO");
        }
        else if (habdesc == 4)
        {
            Console.WriteLine("LA HABILIDAD ESCOGIDA PERMITE A SPIDERMAN COLUMPIARSE SOBRE LAS TRAMPAS ( INMUNE A LAS TRAMPAS)");
        }
        else if (habdesc == 5)
        {
            Console.WriteLine("LA HABILIDAD ESCOGIDA PERMITE A JEAN GRAY USAR SU TELEQUINESIS PARA TOMAR UNA DE LAS GEMAS DE TU OPONENTE ");
        }
        else if (habdesc == 6)
        {
            Console.WriteLine("LA HABILIDAD ESCOGIDA PERMITE A JEAN GRAY USAR SU TELEQUINESIS PARA TOMAR UNA DE LAS GEMAS DE TU OPONENTE ( su oponente no tiene gemas ) ");
        }
        Console.ResetColor();
        FuncTranpas(t);

    }
    //este metodo es para habilitar las casillas del alrrededor
    public static void Paso(int x, int y)
    {

        matriz[x, y] = " ";
        if (x > 0 && x < n && y > 0 && y < m)
        {
            if (x - 2 > 0)
            {
                if (matriz[x - 2, y] != " " && matriz[x - 1, y - 1] != " " && matriz[x - 1, y + 1] != " ")
                {
                    x = x - 1;
                    matriz[x, y] = " ";
                    x = x + 1;
                }
            }
            if (y - 2 > 0)
            {
                if (matriz[x, y - 2] != " " && matriz[x - 1, y - 1] != " " && matriz[x - 1, y + 1] != " ")
                {
                    y = y - 1;
                    matriz[x, y] = " ";
                    y = y + 1;
                }
            }
            if (x + 2 < n)
            {
                if (matriz[x + 2, y] != " " && matriz[x + 1, y - 1] != " " && matriz[x + 1, y + 1] != " ")
                {
                    x = x + 1;
                    matriz[x, y] = " ";
                    x = x - 1;
                }
            }
            if (y + 2 < m)
            {
                if (matriz[x, y + 2] != " " && matriz[x - 1, y + 1] != " " && matriz[x + 1, y + 1] != " ")
                {
                    y = y + 1;
                    matriz[x, y] = " ";
                    y = y - 1;
                }
            }
        }


    }
    //este metodo crea el laberinto
    public static void Camino()
    {
        Random random = new Random();
        Paso(1, 1);
        Paso(1, n - 2);
        Paso(n - 2, 1);
        Paso(m - 2, n - 2);
        //crea islas habitables en toda la matriz
        for (int k = 1; k < n * 100;)
        {
            int ranx = random.Next(1, n - 1);
            int rany = random.Next(1, m - 1);
            //Console.WriteLine(ranx + " " + rany);
            int x = ranx;
            int y = rany;
            if (matriz[x, y] != " " && matriz[x - 1, y] != " " && matriz[x, y - 1] != " " && matriz[x + 1, y] != " " && matriz[x, y + 1] != " ") Paso(ranx, rany);
            else
            {
                k = k + 1;
            }
        }
        //para abrir caminos
        for (int i = 2; i < n - 2; i++)
        {
            int caso = random.Next(0, 2);
            for (int j = 2; j < m - 2; j++)
            {
                if (matriz[i, j] == " ")
                {
                    if (matriz[i - 1, j] != " " && matriz[i, j + 1] != " ")
                    {
                        switch (caso)
                        {
                            case 0:
                                matriz[i - 1, j] = " ";
                                break;
                            case 1:
                                matriz[i, j + 1] = " ";

                                break;
                        }
                    }
                    else if (matriz[i - 1, j] != " " && matriz[i, j - 1] != " ")
                    {
                        matriz[i - 1, j] = " ";
                    }
                    else if (matriz[i + 1, j] != " " && matriz[i, j - 1] != " ")
                    {
                        matriz[i + 1, j] = " ";

                    }
                    else if (matriz[i + 1, j] != " " && matriz[i, j + 1] != " ")
                    {
                        matriz[i, j + 1] = " ";

                    }

                }

            }

        }
        //para que no se cierren en los marcos
        for (int i = 1; i < n - 2; i++)
        {
            if (matriz[i, 1] == "0" && matriz[i - 1, 2] == "0") matriz[i - 1, 2] = " ";
        }
        for (int i = n - 2; i < n - 2; i++)
        {
            if (matriz[i, n - 2] == "0" && matriz[i - 1, n - 3] == "0") matriz[i - 1, n - 3] = " ";
        }
        for (int i = 1; i < n - 2; i++)
        {
            if (matriz[1, i] == "0" && matriz[2, i + 1] == "0") matriz[2, i + 1] = " ";
        }
        for (int i = 1; i < n - 2; i++)
        {
            if (matriz[n - 2, i] == "0" && matriz[n - 3, i + 1] == "0") matriz[n - 3, i + 1] = " ";
        }
        matriz[2, 3] = " ";
        matriz[n - 3, 3] = " ";
        matriz[n - 2, 3] = " ";
        matriz[3, n - 2] = " ";
        matriz[n - 3, n - 2] = " ";
        //para que no quede tan vacio
        for (int i = 2; i < n - 2; i++)
        {
            for (int j = 2; j < m - 2; j++)
            {
                if (matriz[i, j] == " " && matriz[i + 1, j] == " " && matriz[i - 1, j] == " " && matriz[i, j + 1] == " " && matriz[i, j - 1] == " ")
                {
                    if (matriz[i + 1, j + 1] == " " && matriz[i + 1, j - 1] == " " && matriz[i - 1, j + 1] == " " && matriz[i - 1, j - 1] == " ") matriz[i, j] = "0";
                    if (matriz[i + 1, j + 1] == "0" && matriz[i + 1, j - 1] == " " && matriz[i - 1, j + 1] == " " && matriz[i - 1, j - 1] == " ") matriz[i, j] = "0";
                    if (matriz[i + 1, j + 1] == " " && matriz[i + 1, j - 1] == " " && matriz[i - 1, j + 1] == " " && matriz[i - 1, j - 1] == "0") matriz[i, j] = "0";
                }
            }
        }
    }
    //Distribuye las trampas 
    public static void Tranpas()
    {
        Random random = new Random();
        for (int k = 1; k < n * 4;)
        {
            int ranx = random.Next(1, n - 1);
            int rany = random.Next(1, m - 1);
            int x = ranx;
            int y = rany;
            if (matriz[x, y] == " ") matriz[x, y] = "X";
            k = k + 1;
        }

    }
    //para elegir jugadores 
    public static void Jugadores()
    {
        //posicion del primer jugador
        int playerX = 2;
        int playerY = 2;
        //posicion del segundo jugador
        int playerXX = n - 3;
        int playerYY = n - 3;
        //jugadores
        int kk = 0;
        int k = 0;
        int opcion = 0;
        int opcion2 = 0;
        while (k == 0)
        {
            while (kk == 0)
            {

                Console.Clear();
                if (opcion == 0)
                {
                    Console.WriteLine("Elige un jugador:");
                    AnsiConsole.MarkupLine("> [blue]Iron Man[/]");
                    Console.WriteLine("  Capitan America");
                    Console.WriteLine("  Venom");
                    Console.WriteLine("  Spiderman");
                    Console.WriteLine("  Jean Gray");
                }
                if (opcion == 1)
                {
                    Console.WriteLine("Elige un jugador:");
                    Console.WriteLine("  Iron Man");
                    AnsiConsole.MarkupLine("> [blue]Capitan America[/]");
                    Console.WriteLine("  Venom");
                    Console.WriteLine("  Spiderman");
                    Console.WriteLine("  Jean Gray");
                }
                if (opcion == 2)
                {
                    Console.WriteLine("Elige un jugador:");
                    Console.WriteLine("  Iron Man");
                    Console.WriteLine("  Capitan America");
                    AnsiConsole.MarkupLine("> [blue]Venom[/]");
                    Console.WriteLine("  Spiderman");
                    Console.WriteLine("  Jean Gray");
                }
                if (opcion == 3)
                {
                    Console.WriteLine("Elige un jugador:");
                    Console.WriteLine("  Iron Man");
                    Console.WriteLine("  Capitan America");
                    Console.WriteLine("  Venom");
                    AnsiConsole.MarkupLine("> [blue]Spiderman[/]");
                    Console.WriteLine("  Jean Gray");
                }
                if (opcion == 4)
                {
                    Console.WriteLine("Elige un jugador:");
                    Console.WriteLine("  Iron Man");
                    Console.WriteLine("  Capitan America");
                    Console.WriteLine("  Venom");
                    Console.WriteLine("  Spiderman");
                    AnsiConsole.MarkupLine("> [blue]Jean Gray[/]");
                }
                DescJugadores(opcion);
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (opcion != 4) opcion = opcion + 1;
                        break;
                    case ConsoleKey.UpArrow:
                        if (opcion != 0) opcion = opcion - 1;
                        break;
                    case ConsoleKey.Enter:
                        Musc.Sonidos(1);
                        kk = 1;
                        break;
                }
            }

            if (opcion == 0)
            {
                matriz[playerX, playerY] = "I";
                break;
            }
            else if (opcion == 1)
            {
                matriz[playerX, playerY] = "C";
                break;
            }
            else if (opcion == 2)
            {
                matriz[playerX, playerY] = "V";
                break;
            }
            else if (opcion == 3)
            {
                matriz[playerX, playerY] = "S";
                break;
            }

            else if (opcion == 4)
            {
                matriz[playerX, playerY] = "J";
                break;
            }

        }

        kk = 0;
        while (k == 0)
        {
            while (kk == 0)
            {
                Console.Clear();
                if (opcion2 == 0)
                {
                    Console.WriteLine("Elige otro jugador:");
                    AnsiConsole.MarkupLine("> [blue]Iron Man[/]");
                    Console.WriteLine("  Capitan America");
                    Console.WriteLine("  Venom");
                    Console.WriteLine("  Spiderman");
                    Console.WriteLine("  Jean Gray");
                }
                if (opcion2 == 1)
                {
                    Console.WriteLine("Elige otro jugador:");
                    Console.WriteLine("  Iron Man");
                    AnsiConsole.MarkupLine("> [blue]Capitan America[/]");
                    Console.WriteLine("  Venom");
                    Console.WriteLine("  Spiderman");
                    Console.WriteLine("  Jean Gray");
                }
                if (opcion2 == 2)
                {
                    Console.WriteLine("Elige otro jugador:");
                    Console.WriteLine("  Iron Man");
                    Console.WriteLine("  Capitan America");
                    AnsiConsole.MarkupLine("> [blue]Venom[/]");
                    Console.WriteLine("  Spiderman");
                    Console.WriteLine("  Jean Gray");
                }
                if (opcion2 == 3)
                {
                    Console.WriteLine("Elige otro jugador:");
                    Console.WriteLine("  Iron Man");
                    Console.WriteLine("  Capitan America");
                    Console.WriteLine("  Venom");
                    AnsiConsole.MarkupLine("> [blue]Spiderman[/]");
                    Console.WriteLine("  Jean Gray");
                }
                if (opcion2 == 4)
                {
                    Console.WriteLine("Elige otro jugador:");
                    Console.WriteLine("  Iron Man");
                    Console.WriteLine("  Capitan America");
                    Console.WriteLine("  Venom");
                    Console.WriteLine("  Spiderman");
                    AnsiConsole.MarkupLine("> [blue]Jean Gray[/]");
                }
                DescJugadores(opcion2);

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (opcion2 != 4) opcion2 = opcion2 + 1;
                        break;
                    case ConsoleKey.UpArrow:
                        if (opcion2 != 0) opcion2 = opcion2 - 1;
                        break;
                    case ConsoleKey.Enter:
                        Musc.Sonidos(1);
                        if (opcion != opcion2) kk = 1;
                        else
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("No puede coger el mismo personaje, utilice una de las anteriores opciones");
                            Console.ResetColor();
                            Console.ReadKey();
                        }
                        break;
                    case ConsoleKey.Escape:
                        Jugadores();
                        return;
                }
            }
            if (opcion2 == 0 && opcion != opcion2)
            {
                matriz[playerXX, playerYY] = "I";
                break;
            }
            else if (opcion2 == 1 && opcion != opcion2)
            {
                matriz[playerXX, playerYY] = "C";
                break;
            }
            else if (opcion2 == 2 && opcion != opcion2)
            {
                matriz[playerXX, playerYY] = "V";
                break;
            }
            else if (opcion2 == 3 && opcion != opcion2)
            {
                matriz[playerXX, playerYY] = "S";
                break;
            }

            else if (opcion2 == 4 && opcion != opcion2)
            {
                matriz[playerXX, playerYY] = "J";
                break;
            }
        }
        Historia();
    }
    //historia del juego 
    public static void Historia()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        int c = 0; int cc = 0;
        string hist = "LAS GEMAS DEL INFINITO SON SEIS: MENTE, ALMA, ESPACIO, PODER, TIEMPO Y REALIDAD. EN ESTE MULTIVERSO EN EL QUE SE ENCUNTRAN SE HA ALTERADO LA REALIDAD POR LO QUE AHORA EXISTEN MAS DE SEIS GEMAS. SU OBJETIVO ES AGARRAR SEIS DE ESTAS GEMAS PARA PODER VOLVER A TU REALIDAD. SUERTE";
        for (int t = 0; t < hist.Length; t++)
        {

            Thread.Sleep(5);
            if (t >= Console.WindowWidth - 12 && hist[t] == ' ' && c == 0)
            {
                Console.WriteLine(" ");
                c = 1;
            }
            Console.Write(hist[t]);
            if (Console.KeyAvailable)
            {
                Console.Clear();
                ConsoleKeyInfo key = Console.ReadKey(true);
                for (int tt = 0; tt < hist.Length; tt++)
                {
                    if (tt >= Console.WindowWidth - 12 && hist[tt] == ' ' && cc == 0)
                    {
                        Console.WriteLine(" ");
                        cc = 1;
                    }
                    Console.Write(hist[tt]);
                }
                break;
                t = 100000;
            }
        }
        Console.WriteLine(" ");
        Console.WriteLine(" ");
        Console.ResetColor();
        Console.WriteLine("( presione una tecla para comenzar )");
        Console.ReadKey();
        Musc.Sonidos(1);
        Tutorial();
    }
    //tutorial
    public static void Tutorial()
    {
        int k = 0;
        while (k == 0)
        {
            Console.Clear();
            Console.WriteLine("QUIERES UN PEQUEÑO TUTORIAL SOBRE EL JUEGO?");
            Console.WriteLine(" ");
            Console.WriteLine("SI (pulse A)                                NO (pulse S)");
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.A:
                    Musc.Sonidos(1);
                    Console.Clear();
                    AnsiConsole.MarkupLine("[blue]                                TUTORIAL:[/]");
                    AnsiConsole.MarkupLine("[blue]-OBJETIVO:[/] ESTE ES UN JUEGO DONDE DOS JUGADORES ESTAN EN UN LABERINTO, GANA EL QUE PRIMERO CONSIGA REUNIR LAS SEIS GEMAS.");
                    Console.WriteLine("");
                    AnsiConsole.MarkupLine("[blue]-TABLA SUPERIOR:[/] EN ESTA SE MARCA DE AZUL EL JUGADOR AL CUAL LE CORRESPONDA EL TURNO AL IGUAL QUE SU CARACTER EN EL MAPA. EN ESTA TABLA SALEN LOS PUNTOS(GEMAS), HABILIDADES QUE PODEMOS USAR, LA CANTIDAD DE TURNOS QUE SE DEBE ESPERAR PARA RECARGAR LA HABILIDAD Y LA CANTIDAD DE PASOS POR DAR DEL JUGADOR");
                    Console.WriteLine("");
                    Console.WriteLine("╔═══════════════╦═════════════════╦═════════════════╦═════════════════╦════════════════════╗");
                    Console.WriteLine("║   JUGADORES   ║     PUNTOS      ║    CANTIDAD     ║    HABILIDAD    ║   RESTAURACION     ║");
                    Console.WriteLine("║               ║                 ║    DE PASOS     ║                 ║ DE LA HABILIDAD    ║");
                    Console.WriteLine("╠═══════════════╬═════════════════╬═════════════════╬═════════════════╬════════════════════╣");
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine("║   JUGADOR 1   ║         0       ║      0          ║        0        ║      1/3           ║");
                    Console.ResetColor();
                    Console.WriteLine("╚═══════════════╩═════════════════╩═════════════════╩═════════════════╩════════════════════╝");
                    Console.WriteLine("");
                    AnsiConsole.MarkupLine("[blue]-USO DE HABILIDAD:[/] ESTA SE PUEDE USAR PULSANDO X Y SOLO SE PUEDE USAR EN LA PRIMERA ACCION DEL TURNO ");
                    Console.WriteLine("");
                    AnsiConsole.MarkupLine("[blue]-PERSONAJES:[/] EL PERSONAJE EN EL MAPA ESTARA REPRESENTADO POR EL CARACTER CON EL QUE COMIENZA SU NOMBRE Y EN COLOR AZUL AL QUE LE CORRESPONDA EL TURNO. EJEMPLO: SPIDERMAN- [blue]S[/] ");
                    Console.WriteLine("");
                    AnsiConsole.MarkupLine("[blue]-LEYENDA:[/] ");
                    AnsiConsole.MarkupLine("[red] X [/] - TRAMPAS  ");
                    AnsiConsole.MarkupLine("[yellow] § [/] - CASILLA DE BENEFICIOS  ");
                    AnsiConsole.MarkupLine(" 0 - PAREDES  ");
                    AnsiConsole.MarkupLine("[green] * [/] - GEMAS  ");
                    Console.WriteLine("");
                    Console.WriteLine("( presione cualquier tecla para continuar )");
                    Console.ReadKey();
                    k = 1;
                    Musc.Sonidos(1);
                    break;
                case ConsoleKey.S:
                    Musc.Sonidos(1);
                    k = 1;
                    break;

            }
        }
    }
    //este metodo es para mostrar lo que hace cada jugador
    public static void DescJugadores(int c)
    {
        Console.WriteLine(" ");
        Console.WriteLine(" ");
        Console.WriteLine(" ");
        Console.ForegroundColor = ConsoleColor.Blue;
        if (c == 0)
        {
            Console.WriteLine("IRON MAN ");
            Console.WriteLine("-VELOCIDAD: 3 PASOS POR TURNO");
            Console.WriteLine("-HABILIDAD: UTILIZAR SU TRAJE PARA IMPULSARCE Y CAMINAR 3 CASILLAS EXTRAS");
        }
        else if (c == 1)
        {
            Console.WriteLine("CAPITAN AMERICA");
            Console.WriteLine("-VELOCIDAD: 3 PASOS POR TURNO");
            Console.WriteLine("-HABILIDAD: ATURDIR AL ALVERSARIO CON SU ESCUDO Y SALTAR UN TURNO");
        }
        else if (c == 2)
        {
            Console.WriteLine("VENOM");
            Console.WriteLine("-VELOCIDAD: 4 PASOS POR TURNO");
            Console.WriteLine("-HABILIDAD: USAR UN SIMBIONTE PARA CONTROLAR A SU OPONENTE POR UN TURNO");
        }
        else if (c == 3)
        {
            Console.WriteLine("SPIDERMAN");
            Console.WriteLine("-VELOCIDAD: 4 PASOS POR TURNO");
            Console.WriteLine("-HABILIDAD: COLUMPIARSE SOBRE LAS TRAMPAS ( INMUNE A LAS TRAMPAS)");
        }
        else if (c == 4)
        {
            Console.WriteLine("JEAN GRAY");
            Console.WriteLine("-VELOCIDAD: 3 PASOS POR TURNO");
            Console.WriteLine("-HABILIDAD: USA SU TELEQUINESIS PARA TOMAR UNA DE LAS GEMAS DE SU OPONENTE");
        }

        Console.ResetColor();

    }
    //esta clase es para dar mov a los jugadores por turnos 
    public static void MovJug()
    {
        //posicion del primer jugador
        int playerX = 2;
        int playerY = 2;
        //posicion del segundo jugador
        int playerXX = n - 3;
        int playerYY = n - 3;
        //jugadores
        string jug1 = matriz[playerX, playerY];
        string jug2 = matriz[playerXX, playerYY];
        //para las trampas
        Random random = new Random();
        int tip = random.Next(0, 3);
        bool tramp = true;
        //para las condiciones 
        bool control1 = false;
        bool control2 = false;
        int desc = 0;
        int hab = 0;
        int t = 0;
        //para que cuando salte el turno no cambie el bool
        int saltarturno = 0;
        //para condicionar que el enfriamiento no incremente en el primer turno
        int enf = 0;
        int enf2 = 0;
        //para la tabla lps pasos
        if (jug1 == "I" || jug1 == "C" || jug1 == "J") cantpaso1 = 3;
        else if (jug1 == "V" || jug1 == "S") cantpaso1 = 4;
        if (jug2 == "I" || jug2 == "C" || jug2 == "J") cantpaso2 = 3;
        else if (jug2 == "V" || jug2 == "S") cantpaso2 = 4;

        while (true)
        {
            desc = 0;
            t = 0;
            if (turnos)
            {
                if (jug1 == "I" || jug1 == "C" || jug1 == "J")
                {
                    for (int c = 0; c < 3;)
                    {
                        t = 0;
                        DescDeHab(desc, t, jug1);
                        Win();
                        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                        matriz[playerX, playerY] = " ";
                        tip = random.Next(0, 3);
                        switch (keyInfo.Key)
                        {
                            case ConsoleKey.UpArrow:
                                if (matriz[playerX - 1, playerY] == jug2) break;
                                if (matriz[playerX - 1, playerY] != "0")
                                {
                                    hab = hab + 1;
                                    playerX = playerX - 1;
                                    c = c + 1;
                                    cantpaso1 = cantpaso1 - 1;
                                }
                                if (matriz[playerX, playerY] == "*") { { puntos1 = puntos1 + 1; Musc.Sonidos(2); } }
                                if (matriz[playerX, playerY] == "§") { matriz[playerX, playerY] = jug1; c = CasillaBen(c, jug1); }
                                if (matriz[playerX, playerY] == "X")
                                {
                                    switch (tip)
                                    {
                                        //para enviar a la casilla de salida
                                        case 0:
                                            {
                                                matriz[playerX, playerY] = " ";
                                                playerX = 2;
                                                playerY = 2;
                                                t = 1;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t, jug1);
                                                Console.ReadKey();
                                            }
                                            break;
                                        //te quita un punto
                                        case 1:
                                            {
                                                if (puntos1 != 0)
                                                {
                                                    puntos1 = puntos1 - 1;
                                                    t = 2;
                                                }
                                                else t = 3;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t, jug1);
                                                Console.ReadKey();
                                            }
                                            break;
                                        //no puedes moverte mas
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t, jug1);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.DownArrow:
                                if (matriz[playerX + 1, playerY] == jug2) break;
                                if (matriz[playerX + 1, playerY] != "0")
                                {
                                    hab = hab + 1;
                                    c = c + 1;
                                    playerX = playerX + 1;
                                    cantpaso1 = cantpaso1 - 1;
                                }
                                if (matriz[playerX, playerY] == "*") { puntos1 = puntos1 + 1; Musc.Sonidos(2); }
                                if (matriz[playerX, playerY] == "§") { matriz[playerX, playerY] = jug1; c = CasillaBen(c, jug1); }
                                if (matriz[playerX, playerY] == "X")
                                {
                                    switch (tip)
                                    {
                                        case 0:
                                            {
                                                matriz[playerX, playerY] = " ";
                                                playerX = 2;
                                                playerY = 2;
                                                t = 1;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t, jug1);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 1:
                                            {
                                                if (puntos1 != 0)
                                                {
                                                    puntos1 = puntos1 - 1;
                                                    t = 2;
                                                }
                                                else t = 3;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t, jug1);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t, jug1);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.LeftArrow:
                                if (matriz[playerX, playerY - 1] == jug2) break;
                                if (matriz[playerX, playerY - 1] != "0")
                                {
                                    hab = hab + 1;
                                    playerY = playerY - 1;
                                    cantpaso1 = cantpaso1 - 1;
                                    c = c + 1;
                                }
                                if (matriz[playerX, playerY] == "*") { puntos1 = puntos1 + 1; Musc.Sonidos(2); }
                                if (matriz[playerX, playerY] == "§") { matriz[playerX, playerY] = jug1; c = CasillaBen(c, jug1); }
                                if (matriz[playerX, playerY] == "X")
                                {
                                    switch (tip)
                                    {
                                        case 0:
                                            {
                                                matriz[playerX, playerY] = " ";
                                                playerX = 2;
                                                playerY = 2;
                                                t = 1;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t, jug1);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 1:
                                            {
                                                if (puntos1 != 0)
                                                {
                                                    puntos1 = puntos1 - 1;
                                                    t = 2;
                                                }
                                                else t = 3;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t, jug1);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t, jug1);
                                                Win();
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.RightArrow:
                                if (matriz[playerX, playerY + 1] == jug2) break;
                                if (matriz[playerX, playerY + 1] != "0")
                                {
                                    hab = hab + 1;
                                    c = c + 1;
                                    playerY = playerY + 1;
                                    cantpaso1 = cantpaso1 - 1;
                                }
                                if (matriz[playerX, playerY] == "*") { puntos1 = puntos1 + 1; Musc.Sonidos(2); }
                                if (matriz[playerX, playerY] == "§") { matriz[playerX, playerY] = jug1; c = CasillaBen(c, jug1); }
                                if (matriz[playerX, playerY] == "X")
                                {
                                    switch (tip)
                                    {
                                        case 0:
                                            {
                                                matriz[playerX, playerY] = " ";
                                                playerX = 2;
                                                playerY = 2;
                                                t = 1;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t, jug1);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 1:
                                            {
                                                if (puntos1 != 0)
                                                {
                                                    puntos1 = puntos1 - 1;
                                                    t = 2;
                                                }
                                                else t = 3;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t, jug1);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t, jug1);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.Escape:
                                Exit(); break;
                            case ConsoleKey.X:
                                if (hab == 0 && habilidad1 > 0 && jug1 == "I")
                                {
                                    Musc.Sonidos(3);
                                    cantpaso1 = cantpaso1 + 3;
                                    c = c - 3;
                                    habilidad1 = habilidad1 - 1;
                                    desc = 1;
                                    hab = hab + 1;
                                }
                                if (hab == 0 && habilidad1 > 0 && jug1 == "C")
                                {
                                    Musc.Sonidos(3);
                                    saltarturno = 1;
                                    habilidad1 = habilidad1 - 1;
                                    desc = 2;
                                    hab = hab + 1;
                                }
                                if (hab == 0 && habilidad1 > 0 && jug1 == "J")
                                {
                                    Musc.Sonidos(3);
                                    if (puntos2 != 0)
                                    {
                                        puntos1 = puntos1 + 1;
                                        puntos2 = puntos2 - 1;
                                        desc = 5;
                                        hab = hab + 1;
                                        habilidad1 = habilidad1 - 1;
                                    }
                                    else
                                    {
                                        desc = 6;
                                    }

                                }
                                break;
                        }
                        matriz[playerX, playerY] = jug1;

                    }
                    if (habilidad1 == 0)
                    {
                        if (enf == 1 && jug1 != "C") enfriamiento1 = enfriamiento1 + 1;
                        if (jug1 != "C") enf = 1;
                        if (enf == 2) enfriamiento1 = enfriamiento1 + 1;
                        if (jug1 == "C" && enf < 2) enf = enf + 1;
                        if (enfriamiento1 == 3) { habilidad1 = 1; enf = 0; }

                    }
                }
                else if (jug1 == "V" || jug1 == "S")
                {
                    for (int c = 0; c < 4;)
                    {
                        t = 0;
                        DescDeHab(desc, t, jug1);
                        Win();
                        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                        tip = random.Next(0, 3);
                        matriz[playerX, playerY] = " ";
                        switch (keyInfo.Key)
                        {
                            case ConsoleKey.UpArrow:
                                if (matriz[playerX - 1, playerY] == jug2) break;
                                if (matriz[playerX - 1, playerY] != "0")
                                {
                                    hab = hab + 1;
                                    playerX = playerX - 1;
                                    c = c + 1;
                                    cantpaso1 = cantpaso1 - 1;
                                }
                                if (matriz[playerX, playerY] == "*") { puntos1 = puntos1 + 1; Musc.Sonidos(2); }
                                if (matriz[playerX, playerY] == "§") { matriz[playerX, playerY] = jug1; c = CasillaBen(c, jug1); }
                                if (matriz[playerX, playerY] == "X" && tramp)
                                {
                                    switch (tip)
                                    {
                                        case 0:
                                            {
                                                matriz[playerX, playerY] = " ";
                                                playerX = 2;
                                                playerY = 2;
                                                t = 1;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t, jug1);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 1:
                                            {
                                                if (puntos1 != 0)
                                                {
                                                    puntos1 = puntos1 - 1;
                                                    t = 2;
                                                }
                                                else t = 3;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t, jug1);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t, jug1);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.DownArrow:
                                if (matriz[playerX + 1, playerY] == jug2) break;
                                if (matriz[playerX + 1, playerY] != "0")
                                {
                                    hab = hab + 1;
                                    c = c + 1;
                                    playerX = playerX + 1;
                                    cantpaso1 = cantpaso1 - 1;
                                }
                                if (matriz[playerX, playerY] == "*") { puntos1 = puntos1 + 1; Musc.Sonidos(2); }
                                if (matriz[playerX, playerY] == "§") { matriz[playerX, playerY] = jug1; c = CasillaBen(c, jug1); }
                                if (matriz[playerX, playerY] == "X" && tramp)
                                {
                                    switch (tip)
                                    {
                                        case 0:
                                            {
                                                matriz[playerX, playerY] = " ";
                                                playerX = 2;
                                                playerY = 2;
                                                t = 1;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t, jug1);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 1:
                                            {
                                                if (puntos1 != 0)
                                                {
                                                    puntos1 = puntos1 - 1;
                                                    t = 2;
                                                }
                                                else t = 3;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t, jug1);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t, jug1);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.LeftArrow:
                                if (matriz[playerX, playerY - 1] == jug2) break;
                                if (matriz[playerX, playerY - 1] != "0")
                                {
                                    hab = hab + 1;
                                    playerY = playerY - 1;
                                    c = c + 1;
                                    cantpaso1 = cantpaso1 - 1;
                                }
                                if (matriz[playerX, playerY] == "*") { puntos1 = puntos1 + 1; Musc.Sonidos(2); }
                                if (matriz[playerX, playerY] == "§") { matriz[playerX, playerY] = jug1; c = CasillaBen(c, jug1); }
                                if (matriz[playerX, playerY] == "X" && tramp)
                                {
                                    switch (tip)
                                    {
                                        case 0:
                                            {
                                                matriz[playerX, playerY] = " ";
                                                playerX = 2;
                                                playerY = 2;
                                                t = 1;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t, jug1);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 1:
                                            {
                                                if (puntos1 != 0)
                                                {
                                                    puntos1 = puntos1 - 1;
                                                    t = 2;
                                                }
                                                else t = 3;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t, jug1);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t, jug1);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.RightArrow:
                                if (matriz[playerX, playerY + 1] == jug2) break;
                                if (matriz[playerX, playerY + 1] != "0")
                                {
                                    hab = hab + 1;
                                    c = c + 1;
                                    playerY = playerY + 1;
                                    cantpaso1 = cantpaso1 - 1;
                                }
                                if (matriz[playerX, playerY] == "*") { puntos1 = puntos1 + 1; Musc.Sonidos(2); }
                                if (matriz[playerX, playerY] == "§") { matriz[playerX, playerY] = jug1; c = CasillaBen(c, jug1); }
                                if (matriz[playerX, playerY] == "X" && tramp)
                                {
                                    switch (tip)
                                    {
                                        case 0:
                                            {
                                                matriz[playerX, playerY] = " ";
                                                playerX = 2;
                                                playerY = 2;
                                                t = 1;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t, jug1);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 1:
                                            {
                                                if (puntos1 != 0)
                                                {
                                                    puntos1 = puntos1 - 1;
                                                    t = 2;
                                                }
                                                else t = 3;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t, jug1);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t, jug1);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }

                                break;
                            case ConsoleKey.Escape:
                                Exit(); break;
                            case ConsoleKey.X:
                                if (hab == 0 && habilidad1 > 0 && jug1 == "V")
                                {
                                    Musc.Sonidos(3);
                                    control1 = !control1;
                                    c = 5;
                                    habilidad1 = habilidad1 - 1;
                                    desc = 3;
                                    hab = hab + 1;
                                }
                                if (hab == 0 && habilidad1 > 0 && jug1 == "S")
                                {
                                    Musc.Sonidos(3);
                                    tramp = false;
                                    habilidad1 = habilidad1 - 1;
                                    hab = hab + 1;
                                    desc = 4;
                                }
                                break;
                        }
                        matriz[playerX, playerY] = jug1;

                    }
                    if (habilidad1 == 0)
                    {
                        if (enf == 1) enfriamiento1 = enfriamiento1 + 1;
                        enf = 1;
                        if (enfriamiento1 == 3) { habilidad1 = 1; enf = 0; }

                    }
                }
            }
            else
            {
                if (jug2 == "I" || jug2 == "C" || jug2 == "J")
                {
                    for (int c = 0; c < 3;)
                    {
                        t = 0;
                        DescDeHab(desc, t, jug2);
                        Win();
                        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                        tip = random.Next(0, 3);
                        matriz[playerXX, playerYY] = " ";
                        switch (keyInfo.Key)
                        {
                            case ConsoleKey.UpArrow:
                                if (matriz[playerXX - 1, playerYY] == jug1) break;
                                if (matriz[playerXX - 1, playerYY] != "0")
                                {
                                    hab = hab + 1;
                                    c = c + 1;
                                    playerXX = playerXX - 1;
                                    cantpaso2 = cantpaso2 - 1;
                                }
                                if (matriz[playerXX, playerYY] == "*") { puntos2 = puntos2 + 1; Musc.Sonidos(2); }
                                if (matriz[playerXX, playerYY] == "§") { matriz[playerXX, playerYY] = jug2; c = CasillaBen(c, jug2); }
                                if (matriz[playerXX, playerYY] == "X")
                                {
                                    switch (tip)
                                    {
                                        case 0:
                                            {
                                                matriz[playerXX, playerYY] = " ";
                                                playerXX = n - 3;
                                                playerYY = n - 3;
                                                t = 1;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t, jug2);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 1:
                                            {
                                                if (puntos2 != 0)
                                                {
                                                    puntos2 = puntos2 - 1;
                                                    t = 2;
                                                }
                                                else t = 3;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t, jug2);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t, jug2);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.DownArrow:
                                if (matriz[playerXX + 1, playerYY] == jug1) break;
                                if (matriz[playerXX + 1, playerYY] != "0")
                                {
                                    hab = hab + 1;
                                    c = c + 1;
                                    playerXX = playerXX + 1;
                                    cantpaso2 = cantpaso2 - 1;
                                }
                                if (matriz[playerXX, playerYY] == "*") { puntos2 = puntos2 + 1; Musc.Sonidos(2); }
                                if (matriz[playerXX, playerYY] == "§") { matriz[playerXX, playerYY] = jug2; c = CasillaBen(c, jug2); }
                                if (matriz[playerXX, playerYY] == "X")
                                {
                                    switch (tip)
                                    {
                                        case 0:
                                            {
                                                matriz[playerXX, playerYY] = " ";
                                                playerXX = n - 3;
                                                playerYY = n - 3;
                                                t = 1;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t, jug2);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 1:
                                            {
                                                if (puntos2 != 0)
                                                {
                                                    puntos2 = puntos2 - 1;
                                                    t = 2;
                                                }
                                                else t = 3;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t, jug2);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t, jug2);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.LeftArrow:
                                if (matriz[playerXX, playerYY - 1] == jug1) break;
                                if (matriz[playerXX, playerYY - 1] != "0")
                                {
                                    hab = hab + 1;
                                    c = c + 1;
                                    playerYY = playerYY - 1;
                                    cantpaso2 = cantpaso2 - 1;
                                }
                                if (matriz[playerXX, playerYY] == "*") { puntos2 = puntos2 + 1; Musc.Sonidos(2); }
                                if (matriz[playerXX, playerYY] == "§") { matriz[playerXX, playerYY] = jug2; c = CasillaBen(c, jug2); }
                                if (matriz[playerXX, playerYY] == "X")
                                {
                                    switch (tip)
                                    {
                                        case 0:
                                            {
                                                matriz[playerXX, playerYY] = " ";
                                                playerXX = n - 3;
                                                playerYY = n - 3;
                                                t = 1;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t, jug2);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 1:
                                            {
                                                if (puntos2 != 0)
                                                {
                                                    puntos2 = puntos2 - 1;
                                                    t = 2;
                                                }
                                                else t = 3;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t, jug2);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t, jug2);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.RightArrow:
                                if (matriz[playerXX, playerYY + 1] == jug1) break;
                                if (matriz[playerXX, playerYY + 1] != "0")
                                {
                                    hab = hab + 1;
                                    c = c + 1;
                                    playerYY = playerYY + 1;
                                    cantpaso2 = cantpaso2 - 1;
                                }
                                if (matriz[playerXX, playerYY] == "*") { puntos2 = puntos2 + 1; Musc.Sonidos(2); }
                                if (matriz[playerXX, playerYY] == "§") { matriz[playerXX, playerYY] = jug2; c = CasillaBen(c, jug2); }
                                if (matriz[playerXX, playerYY] == "X")
                                {
                                    switch (tip)
                                    {
                                        case 0:
                                            {
                                                matriz[playerXX, playerYY] = " ";
                                                playerXX = n - 3;
                                                playerYY = n - 3;
                                                t = 1;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t, jug2);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 1:
                                            {
                                                if (puntos2 != 0)
                                                {
                                                    puntos2 = puntos2 - 1;
                                                    t = 2;
                                                }
                                                else t = 3;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t, jug2);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t, jug2);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.Escape:
                                Exit(); break;
                            case ConsoleKey.X:
                                if (hab == 0 && habilidad2 > 0 && jug2 == "I")
                                {
                                    Musc.Sonidos(3);
                                    cantpaso2 = cantpaso2 + 3;
                                    c = c - 3;
                                    habilidad2 = habilidad2 - 1;
                                    desc = 1;
                                    hab = hab + 1;
                                }
                                if (hab == 0 && habilidad2 > 0 && jug2 == "C")
                                {
                                    Musc.Sonidos(3);
                                    saltarturno = 1;
                                    habilidad2 = habilidad2 - 1;
                                    desc = 2;
                                    hab = hab + 1;
                                }
                                if (hab == 0 && habilidad2 > 0 && jug2 == "J")
                                {
                                    Musc.Sonidos(3);
                                    if (puntos1 != 0)
                                    {
                                        puntos2 = puntos2 + 1;
                                        puntos1 = puntos1 - 1;
                                        desc = 5;
                                        habilidad2 = habilidad2 - 1;
                                    }
                                    else
                                    {
                                        desc = 6;
                                    }
                                    hab = hab + 1;
                                }
                                break;

                        }
                        matriz[playerXX, playerYY] = jug2;

                    }
                    if (habilidad2 == 0)
                    {
                        if (enf2 == 1 && jug2 != "C") enfriamiento2 = enfriamiento2 + 1;
                        if (jug2 != "C") enf2 = 1;
                        if (enf2 == 2) enfriamiento2 = enfriamiento2 + 1;
                        if (jug2 == "C" && enf2 < 2) enf2 = enf2 + 1;
                        if (enfriamiento2 == 3) { habilidad2 = 1; enf2 = 0; }
                    }
                }
                else if (jug2 == "V" || jug2 == "S")
                {
                    for (int c = 0; c < 4;)
                    {
                        t = 0;
                        DescDeHab(desc, t, jug2);
                        Win();
                        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                        tip = random.Next(0, 3);
                        matriz[playerXX, playerYY] = " ";
                        switch (keyInfo.Key)
                        {
                            case ConsoleKey.UpArrow:
                                if (matriz[playerXX - 1, playerYY] == jug1) break;
                                if (matriz[playerXX - 1, playerYY] != "0")
                                {
                                    hab = hab + 1;
                                    cantpaso2 = cantpaso2 - 1;
                                    c = c + 1;
                                    playerXX = playerXX - 1;
                                }
                                if (matriz[playerXX, playerYY] == "*") { puntos2 = puntos2 + 1; Musc.Sonidos(2); }
                                if (matriz[playerXX, playerYY] == "§") { matriz[playerXX, playerYY] = jug2; c = CasillaBen(c, jug2); }
                                if (matriz[playerXX, playerYY] == "X" && tramp)
                                {
                                    switch (tip)
                                    {
                                        case 0:
                                            {
                                                matriz[playerXX, playerYY] = " ";
                                                playerXX = n - 3;
                                                playerYY = n - 3;
                                                t = 1;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t, jug2);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 1:
                                            {
                                                if (puntos2 != 0)
                                                {
                                                    puntos2 = puntos2 - 1;
                                                    t = 2;
                                                }
                                                else t = 3;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t, jug2);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t, jug2);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.DownArrow:
                                if (matriz[playerXX + 1, playerYY] == jug1) break;
                                if (matriz[playerXX + 1, playerYY] != "0")
                                {
                                    hab = hab + 1;
                                    cantpaso2 = cantpaso2 - 1;
                                    c = c + 1;
                                    playerXX = playerXX + 1;
                                }
                                if (matriz[playerXX, playerYY] == "*") { puntos2 = puntos2 + 1; Musc.Sonidos(2); }
                                if (matriz[playerXX, playerYY] == "§") { matriz[playerXX, playerYY] = jug2; c = CasillaBen(c, jug2); }
                                if (matriz[playerXX, playerYY] == "X" && tramp)
                                {
                                    switch (tip)
                                    {
                                        case 0:
                                            {
                                                matriz[playerXX, playerYY] = " ";
                                                playerXX = n - 3;
                                                playerYY = n - 3;
                                                t = 1;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t, jug2);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 1:
                                            {
                                                if (puntos2 != 0)
                                                {
                                                    puntos2 = puntos2 - 1;
                                                    t = 2;
                                                }
                                                else t = 3;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t, jug2);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t, jug2);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.LeftArrow:
                                if (matriz[playerXX, playerYY - 1] == jug1) break;
                                if (matriz[playerXX, playerYY - 1] != "0")
                                {
                                    hab = hab + 1;
                                    cantpaso2 = cantpaso2 - 1;
                                    c = c + 1;
                                    playerYY = playerYY - 1;
                                }
                                if (matriz[playerXX, playerYY] == "*") { puntos2 = puntos2 + 1; Musc.Sonidos(2); }
                                if (matriz[playerXX, playerYY] == "§") { matriz[playerXX, playerYY] = jug2; c = CasillaBen(c, jug2); }
                                if (matriz[playerXX, playerYY] == "X" && tramp)
                                {
                                    switch (tip)
                                    {
                                        case 0:
                                            {
                                                matriz[playerXX, playerYY] = " ";
                                                playerXX = n - 3;
                                                playerYY = n - 3;
                                                t = 1;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t, jug2);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 1:
                                            {
                                                if (puntos2 != 0)
                                                {
                                                    puntos2 = puntos2 - 1;
                                                    t = 2;
                                                }
                                                else t = 3;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t, jug2);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t, jug2);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.RightArrow:
                                if (matriz[playerXX, playerYY + 1] == jug1) break;
                                if (matriz[playerXX, playerYY + 1] != "0")
                                {
                                    hab = hab + 1;
                                    cantpaso2 = cantpaso2 - 1;
                                    c = c + 1;
                                    playerYY = playerYY + 1;

                                }
                                if (matriz[playerXX, playerYY] == "*") { puntos2 = puntos2 + 1; Musc.Sonidos(2); }
                                if (matriz[playerXX, playerYY] == "§") { matriz[playerXX, playerYY] = jug2; c = CasillaBen(c, jug2); }
                                if (matriz[playerXX, playerYY] == "X" && tramp)
                                {
                                    switch (tip)
                                    {
                                        case 0:
                                            {
                                                matriz[playerXX, playerYY] = " ";
                                                playerXX = n - 3;
                                                playerYY = n - 3;
                                                t = 1;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t, jug2);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 1:
                                            {
                                                if (puntos2 != 0)
                                                {
                                                    puntos2 = puntos2 - 1;
                                                    t = 2;
                                                }
                                                else t = 3;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t, jug2);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t, jug2);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.Escape:
                                Exit(); break;
                            case ConsoleKey.X:
                                if (hab == 0 && habilidad2 > 0 && jug2 == "V")
                                {
                                    Musc.Sonidos(3);
                                    control2 = !control2;
                                    c = 5;
                                    habilidad2 = habilidad2 - 1;
                                    desc = 3;
                                    hab = hab + 1;
                                }
                                if (hab == 0 && habilidad2 > 0 && jug2 == "S")
                                {
                                    Musc.Sonidos(3);
                                    tramp = false;
                                    habilidad2 = habilidad2 - 1;
                                    hab = hab + 1;
                                    desc = 4;
                                }
                                break;
                        }
                        matriz[playerXX, playerYY] = jug2;
                    }
                    if (habilidad2 == 0)
                    {
                        if (enf2 == 1) enfriamiento2 = enfriamiento2 + 1;
                        enf2 = 1;
                        if (enfriamiento2 == 3) { habilidad2 = 1; enf2 = 0; }
                    }
                }
            }
            t = 0;
            hab = 0;
            tramp = true;
            Musc.Sonidos(1);
            if (saltarturno == 0) turnos = !turnos;
            saltarturno = 0;
            if (enfriamiento1 == 3) { enfriamiento1 = 0; }
            if (enfriamiento2 == 3) { enfriamiento2 = 0; }
            if (control1)
            {
                turnos = !turnos;
                if (jug2 == "I" || jug2 == "C" || jug2 == "J")
                {
                    for (int c = 0; c < 3;)
                    {
                        t = 0;
                        DescDeHab(desc, t, jug2);
                        Win();
                        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                        tip = random.Next(0, 3);
                        matriz[playerXX, playerYY] = " ";
                        switch (keyInfo.Key)
                        {
                            case ConsoleKey.UpArrow:
                                if (matriz[playerXX - 1, playerYY] == jug1) break;
                                if (matriz[playerXX - 1, playerYY] != "0")
                                {
                                    c = c + 1;
                                    playerXX = playerXX - 1;
                                    cantpaso2 = cantpaso2 - 1;
                                }
                                if (matriz[playerXX, playerYY] == "*") { puntos2 = puntos2 + 1; Musc.Sonidos(2); }
                                if (matriz[playerXX, playerYY] == "§") { matriz[playerXX, playerYY] = jug2; c = CasillaBen(c, jug2); }
                                if (matriz[playerXX, playerYY] == "X")
                                {
                                    switch (tip)
                                    {
                                        case 0:
                                            {
                                                matriz[playerXX, playerYY] = " ";
                                                playerXX = n - 3;
                                                playerYY = n - 3;
                                                t = 1;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t, jug2);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 1:
                                            {
                                                if (puntos2 != 0)
                                                {
                                                    puntos2 = puntos2 - 1;
                                                    t = 2;
                                                }
                                                else t = 3;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t, jug2);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t, jug2);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.DownArrow:
                                if (matriz[playerXX + 1, playerYY] == jug1) break;
                                if (matriz[playerXX + 1, playerYY] != "0")
                                {
                                    c = c + 1;
                                    playerXX = playerXX + 1;
                                    cantpaso2 = cantpaso2 - 1;
                                }
                                if (matriz[playerXX, playerYY] == "*") { puntos2 = puntos2 + 1; Musc.Sonidos(2); }
                                if (matriz[playerXX, playerYY] == "§") { matriz[playerXX, playerYY] = jug2; c = CasillaBen(c, jug2); }
                                if (matriz[playerXX, playerYY] == "X")
                                {
                                    switch (tip)
                                    {
                                        case 0:
                                            {
                                                matriz[playerXX, playerYY] = " ";
                                                playerXX = n - 3;
                                                playerYY = n - 3;
                                                t = 1;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t, jug2);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 1:
                                            {
                                                if (puntos2 != 0)
                                                {
                                                    puntos2 = puntos2 - 1;
                                                    t = 2;
                                                }
                                                else t = 3;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t, jug2);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t, jug2);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.LeftArrow:
                                if (matriz[playerXX, playerYY - 1] == jug1) break;
                                if (matriz[playerXX, playerYY - 1] != "0")
                                {
                                    c = c + 1;
                                    playerYY = playerYY - 1;
                                    cantpaso2 = cantpaso2 - 1;
                                }
                                if (matriz[playerXX, playerYY] == "*") { puntos2 = puntos2 + 1; Musc.Sonidos(2); }
                                if (matriz[playerXX, playerYY] == "§") { matriz[playerXX, playerYY] = jug2; c = CasillaBen(c, jug2); }
                                if (matriz[playerXX, playerYY] == "X")
                                {
                                    switch (tip)
                                    {
                                        case 0:
                                            {
                                                matriz[playerXX, playerYY] = " ";
                                                playerXX = n - 3;
                                                playerYY = n - 3;
                                                t = 1;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t, jug2);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 1:
                                            {
                                                if (puntos2 != 0)
                                                {
                                                    puntos2 = puntos2 - 1;
                                                    t = 2;
                                                }
                                                else t = 3;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t, jug2);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t, jug2);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.RightArrow:
                                if (matriz[playerXX, playerYY + 1] == jug1) break;
                                if (matriz[playerXX, playerYY + 1] != "0")
                                {
                                    c = c + 1;
                                    playerYY = playerYY + 1;
                                    cantpaso2 = cantpaso2 - 1;
                                }
                                if (matriz[playerXX, playerYY] == "*") { puntos2 = puntos2 + 1; Musc.Sonidos(2); }
                                if (matriz[playerXX, playerYY] == "§") { matriz[playerXX, playerYY] = jug2; c = CasillaBen(c, jug2); }
                                if (matriz[playerXX, playerYY] == "X")
                                {
                                    switch (tip)
                                    {
                                        case 0:
                                            {
                                                matriz[playerXX, playerYY] = " ";
                                                playerXX = n - 3;
                                                playerYY = n - 3;
                                                t = 1;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t, jug2);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 1:
                                            {
                                                if (puntos2 != 0)
                                                {
                                                    puntos2 = puntos2 - 1;
                                                    t = 2;
                                                }
                                                else t = 3;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t, jug2);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t, jug2);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.Escape:
                                Exit(); break;
                        }
                        matriz[playerXX, playerYY] = jug2;
                    }
                }
                else if (jug2 == "V" || jug2 == "S")
                {
                    for (int c = 0; c < 4;)
                    {
                        t = 0;
                        DescDeHab(desc, t, jug2);
                        Win();
                        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                        tip = random.Next(0, 3);
                        matriz[playerXX, playerYY] = " ";
                        switch (keyInfo.Key)
                        {
                            case ConsoleKey.UpArrow:
                                if (matriz[playerXX - 1, playerYY] == jug1) break;
                                if (matriz[playerXX - 1, playerYY] != "0")
                                {
                                    cantpaso2 = cantpaso2 - 1;
                                    c = c + 1;
                                    playerXX = playerXX - 1;
                                }
                                if (matriz[playerXX, playerYY] == "*") { puntos2 = puntos2 + 1; Musc.Sonidos(2); }
                                if (matriz[playerXX, playerYY] == "§") { matriz[playerXX, playerYY] = jug2; c = CasillaBen(c, jug2); }
                                if (matriz[playerXX, playerYY] == "X" && tramp)
                                {
                                    switch (tip)
                                    {
                                        case 0:
                                            {
                                                matriz[playerXX, playerYY] = " ";
                                                playerXX = n - 3;
                                                playerYY = n - 3;
                                                t = 1;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t, jug2);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 1:
                                            {
                                                if (puntos2 != 0)
                                                {
                                                    puntos2 = puntos2 - 1;
                                                    t = 2;
                                                }
                                                else t = 3;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t, jug2);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t, jug2);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.DownArrow:
                                if (matriz[playerXX + 1, playerYY] == jug1) break;
                                if (matriz[playerXX + 1, playerYY] != "0")
                                {
                                    cantpaso2 = cantpaso2 - 1;
                                    c = c + 1;
                                    playerXX = playerXX + 1;
                                }
                                if (matriz[playerXX, playerYY] == "*") { puntos2 = puntos2 + 1; Musc.Sonidos(2); }
                                if (matriz[playerXX, playerYY] == "§") { matriz[playerXX, playerYY] = jug2; c = CasillaBen(c, jug2); }
                                if (matriz[playerXX, playerYY] == "X" && tramp)
                                {
                                    switch (tip)
                                    {
                                        case 0:
                                            {
                                                matriz[playerXX, playerYY] = " ";
                                                playerXX = n - 3;
                                                playerYY = n - 3;
                                                t = 1;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t, jug2);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 1:
                                            {
                                                if (puntos2 != 0)
                                                {
                                                    puntos2 = puntos2 - 1;
                                                    t = 2;
                                                }
                                                else t = 3;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t, jug2);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t, jug2);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.LeftArrow:
                                if (matriz[playerXX, playerYY - 1] == jug1) break;
                                if (matriz[playerXX, playerYY - 1] != "0")
                                {
                                    cantpaso2 = cantpaso2 - 1;
                                    c = c + 1;
                                    playerYY = playerYY - 1;
                                }
                                if (matriz[playerXX, playerYY] == "*") { puntos2 = puntos2 + 1; Musc.Sonidos(2); }
                                if (matriz[playerXX, playerYY] == "§") { matriz[playerXX, playerYY] = jug2; c = CasillaBen(c, jug2); }
                                if (matriz[playerXX, playerYY] == "X" && tramp)
                                {
                                    switch (tip)
                                    {
                                        case 0:
                                            {
                                                matriz[playerXX, playerYY] = " ";
                                                playerXX = n - 3;
                                                playerYY = n - 3;
                                                t = 1;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t, jug2);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 1:
                                            {
                                                if (puntos2 != 0)
                                                {
                                                    puntos2 = puntos2 - 1;
                                                    t = 2;
                                                }
                                                else t = 3;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t, jug2);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t, jug2);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.RightArrow:
                                if (matriz[playerXX, playerYY + 1] == jug1) break;
                                if (matriz[playerXX, playerYY + 1] != "0")
                                {
                                    cantpaso2 = cantpaso2 - 1;
                                    c = c + 1;
                                    playerYY = playerYY + 1;
                                }
                                if (matriz[playerXX, playerYY] == "*") { puntos2 = puntos2 + 1; Musc.Sonidos(2); }
                                if (matriz[playerX, playerY] == "§") c = CasillaBen(c, jug2);
                                if (matriz[playerXX, playerYY] == "X" && tramp)
                                {
                                    switch (tip)
                                    {
                                        case 0:
                                            {
                                                matriz[playerXX, playerYY] = " ";
                                                playerXX = n - 3;
                                                playerYY = n - 3;
                                                t = 1;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t, jug2);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 1:
                                            {
                                                if (puntos2 != 0)
                                                {
                                                    puntos2 = puntos2 - 1;
                                                    t = 2;
                                                }
                                                else t = 3;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t, jug2);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t, jug2);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.Escape:
                                Exit(); break;
                        }
                        matriz[playerXX, playerYY] = jug2;

                    }
                }
                control1 = !control1;
                enf = 0;
                hab = 1;
            }
            if (control2)
            {
                turnos = !turnos;
                if (jug1 == "I" || jug1 == "C" || jug1 == "J")
                {
                    for (int c = 0; c < 3;)
                    {
                        t = 0;
                        DescDeHab(desc, t, jug1);
                        Win();
                        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                        matriz[playerX, playerY] = " ";
                        tip = random.Next(0, 3);
                        switch (keyInfo.Key)
                        {
                            case ConsoleKey.UpArrow:
                                if (matriz[playerX - 1, playerY] == jug2) break;
                                if (matriz[playerX - 1, playerY] != "0")
                                {
                                    playerX = playerX - 1;
                                    c = c + 1;
                                    cantpaso1 = cantpaso1 - 1;
                                }
                                if (matriz[playerX, playerY] == "*") { puntos1 = puntos1 + 1; Musc.Sonidos(2); }
                                if (matriz[playerX, playerY] == "§") { matriz[playerX, playerY] = jug1; c = CasillaBen(c, jug1); }
                                if (matriz[playerX, playerY] == "X")
                                {
                                    switch (tip)
                                    {
                                        //para enviar a la casilla de salida
                                        case 0:
                                            {
                                                matriz[playerX, playerY] = " ";
                                                playerX = 2;
                                                playerY = 2;
                                                t = 1;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t, jug1);
                                                Console.ReadKey();
                                            }
                                            break;
                                        //te quita un punto
                                        case 1:
                                            {
                                                if (puntos1 != 0)
                                                {
                                                    puntos1 = puntos1 - 1;
                                                    t = 2;
                                                }
                                                else t = 3;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t, jug1);
                                                Console.ReadKey();
                                            }
                                            break;
                                        //no puedes moverte mas
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t, jug1);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.DownArrow:
                                if (matriz[playerX + 1, playerY] == jug2) break;
                                if (matriz[playerX + 1, playerY] != "0")
                                {
                                    c = c + 1;
                                    playerX = playerX + 1;
                                    cantpaso1 = cantpaso1 - 1;
                                }
                                if (matriz[playerX, playerY] == "*") { puntos1 = puntos1 + 1; Musc.Sonidos(2); }
                                if (matriz[playerX, playerY] == "§") { matriz[playerX, playerY] = jug1; c = CasillaBen(c, jug1); }
                                if (matriz[playerX, playerY] == "X")
                                {
                                    switch (tip)
                                    {
                                        case 0:
                                            {
                                                matriz[playerX, playerY] = " ";
                                                playerX = 2;
                                                playerY = 2;
                                                t = 1;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t, jug1);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 1:
                                            {
                                                if (puntos1 != 0)
                                                {
                                                    puntos1 = puntos1 - 1;
                                                    t = 2;
                                                }
                                                else t = 3;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t, jug1);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t, jug1);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.LeftArrow:
                                if (matriz[playerX, playerY - 1] == jug2) break;
                                if (matriz[playerX, playerY - 1] != "0")
                                {
                                    playerY = playerY - 1;
                                    cantpaso1 = cantpaso1 - 1;
                                    c = c + 1;
                                }

                                if (matriz[playerX, playerY] == "*") { puntos1 = puntos1 + 1; Musc.Sonidos(2); }
                                if (matriz[playerX, playerY] == "§") { matriz[playerX, playerY] = jug1; c = CasillaBen(c, jug1); }
                                if (matriz[playerX, playerY] == "X")
                                {
                                    switch (tip)
                                    {
                                        case 0:
                                            {
                                                matriz[playerX, playerY] = " ";
                                                playerX = 2;
                                                playerY = 2;
                                                t = 1;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t, jug1);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 1:
                                            {
                                                if (puntos1 != 0)
                                                {
                                                    puntos1 = puntos1 - 1;
                                                    t = 2;
                                                }
                                                else t = 3;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t, jug1);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t, jug1);
                                                Win();
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.RightArrow:
                                if (matriz[playerX, playerY + 1] == jug2) break;
                                if (matriz[playerX, playerY + 1] != "0")
                                {
                                    c = c + 1;
                                    playerY = playerY + 1;
                                    cantpaso1 = cantpaso1 - 1;
                                }
                                if (matriz[playerX, playerY] == "*") { puntos1 = puntos1 + 1; Musc.Sonidos(2); }
                                if (matriz[playerX, playerY] == "§") { matriz[playerX, playerY] = jug1; c = CasillaBen(c, jug1); }
                                if (matriz[playerX, playerY] == "X")
                                {
                                    switch (tip)
                                    {
                                        case 0:
                                            {
                                                matriz[playerX, playerY] = " ";
                                                playerX = 2;
                                                playerY = 2;
                                                t = 1;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t, jug1);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 1:
                                            {
                                                if (puntos1 != 0)
                                                {
                                                    puntos1 = puntos1 - 1;
                                                    t = 2;
                                                }
                                                else t = 3;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t, jug1);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t, jug1);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.Escape:
                                Exit(); break;
                        }
                        matriz[playerX, playerY] = jug1;
                    }

                }
                else if (jug1 == "V" || jug1 == "S")
                {
                    for (int c = 0; c < 4;)
                    {
                        t = 0;
                        DescDeHab(desc, t, jug1);
                        Win();
                        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                        tip = random.Next(0, 3);
                        matriz[playerX, playerY] = " ";
                        switch (keyInfo.Key)
                        {
                            case ConsoleKey.UpArrow:
                                if (matriz[playerX - 1, playerY] == jug2) break;
                                if (matriz[playerX - 1, playerY] != "0")
                                {
                                    playerX = playerX - 1;
                                    c = c + 1;
                                    cantpaso1 = cantpaso1 - 1;
                                }
                                if (matriz[playerX, playerY] == "*") { puntos1 = puntos1 + 1; Musc.Sonidos(2); }
                                if (matriz[playerX, playerY] == "§") { matriz[playerX, playerY] = jug1; c = CasillaBen(c, jug1); }
                                if (matriz[playerX, playerY] == "X")
                                {
                                    switch (tip)
                                    {
                                        case 0:
                                            {
                                                matriz[playerX, playerY] = " ";
                                                playerX = 2;
                                                playerY = 2;
                                                t = 1;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t, jug1);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 1:
                                            {
                                                if (puntos1 != 0)
                                                {
                                                    puntos1 = puntos1 - 1;
                                                    t = 2;
                                                }
                                                else t = 3;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t, jug1);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t, jug1);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.DownArrow:
                                if (matriz[playerX + 1, playerY] == jug2) break;
                                if (matriz[playerX + 1, playerY] != "0")
                                {
                                    c = c + 1;
                                    playerX = playerX + 1;
                                    cantpaso1 = cantpaso1 - 1;
                                }
                                if (matriz[playerX, playerY] == "*") { puntos1 = puntos1 + 1; Musc.Sonidos(2); }
                                if (matriz[playerX, playerY] == "§") { matriz[playerX, playerY] = jug1; c = CasillaBen(c, jug1); }
                                if (matriz[playerX, playerY] == "X")
                                {
                                    switch (tip)
                                    {
                                        case 0:
                                            {
                                                matriz[playerX, playerY] = " ";
                                                playerX = 2;
                                                playerY = 2;
                                                t = 1;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t, jug1);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 1:
                                            {
                                                if (puntos1 != 0)
                                                {
                                                    puntos1 = puntos1 - 1;
                                                    t = 2;
                                                }
                                                else t = 3;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t, jug1);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t, jug1);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.LeftArrow:
                                if (matriz[playerX, playerY - 1] == jug2) break;
                                if (matriz[playerX, playerY - 1] != "0")
                                {
                                    playerY = playerY - 1;
                                    c = c + 1;
                                    cantpaso1 = cantpaso1 - 1;
                                }
                                if (matriz[playerX, playerY] == "*") { puntos1 = puntos1 + 1; Musc.Sonidos(2); }
                                if (matriz[playerX, playerY] == "§") { matriz[playerX, playerY] = jug1; c = CasillaBen(c, jug1); }
                                if (matriz[playerX, playerY] == "X")
                                {
                                    switch (tip)
                                    {
                                        case 0:
                                            {
                                                matriz[playerX, playerY] = " ";
                                                playerX = 2;
                                                playerY = 2;
                                                t = 1;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t, jug1);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 1:
                                            {
                                                if (puntos1 != 0)
                                                {
                                                    puntos1 = puntos1 - 1;
                                                    t = 2;
                                                }
                                                else t = 3;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t, jug1);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t, jug1);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.RightArrow:
                                if (matriz[playerX, playerY + 1] == jug2) break;
                                if (matriz[playerX, playerY + 1] != "0")
                                {
                                    c = c + 1;
                                    playerY = playerY + 1;
                                    cantpaso1 = cantpaso1 - 1;
                                }
                                if (matriz[playerX, playerY] == "*") { puntos1 = puntos1 + 1; Musc.Sonidos(2); }
                                if (matriz[playerX, playerY] == "§") { matriz[playerX, playerY] = jug1; c = CasillaBen(c, jug1); }
                                if (matriz[playerX, playerY] == "X")
                                {
                                    switch (tip)
                                    {
                                        case 0:
                                            {
                                                matriz[playerX, playerY] = " ";
                                                playerX = 2;
                                                playerY = 2;
                                                t = 1;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t, jug1);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 1:
                                            {
                                                if (puntos1 != 0)
                                                {
                                                    puntos1 = puntos1 - 1;
                                                    t = 2;
                                                }
                                                else t = 3;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t, jug1);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t, jug1);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.Escape:
                                Exit(); break;
                        }
                        matriz[playerX, playerY] = jug1;
                    }
                }
                control2 = !control2;
                enf2 = 0;
                hab = 1;
            }
            if (jug1 == "I" || jug1 == "C" || jug1 == "J") cantpaso1 = 3;
            else if (jug1 == "V" || jug1 == "S") cantpaso1 = 4;
            if (jug2 == "I" || jug2 == "C" || jug2 == "J") cantpaso2 = 3;
            else if (jug2 == "V" || jug2 == "S") cantpaso2 = 4;
        }
    }
    //este metodo es para q cuando caigas en casilla de beneficio se active el mismo
    public static int CasillaBen(int c, string jug)
    {
        Musc.Sonidos(5);
        Random random = new Random();
        int tip = random.Next(1, 5);
        if (turnos)
        {
            cantpaso1 = cantpaso1 + tip;
        }
        else { cantpaso2 = cantpaso2 + tip; }
        DescDeHab(0, 0, jug);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.SetCursorPosition((Console.WindowWidth / 2), 12);
        Console.WriteLine(" EQUIPANDO:");
        Console.SetCursorPosition((Console.WindowWidth / 2), 13);
        Console.WriteLine("   █░░░░░:");
        Thread.Sleep(250);
        DescDeHab(0, 0, jug);
        Console.SetCursorPosition((Console.WindowWidth / 2), 12);
        Console.WriteLine(" EQUIPANDO:");
        Console.SetCursorPosition((Console.WindowWidth / 2), 13);
        Console.WriteLine("   ███░░░:");
        Thread.Sleep(250);
        DescDeHab(0, 0, jug);
        Console.SetCursorPosition((Console.WindowWidth / 2), 12);
        Console.WriteLine(" EQUIPANDO:");
        Console.SetCursorPosition((Console.WindowWidth / 2), 13);
        Console.WriteLine("   ████░░:");
        Thread.Sleep(250);
        DescDeHab(0, 0, jug);
        Console.SetCursorPosition((Console.WindowWidth / 2), 12);
        Console.WriteLine(" EQUIPANDO:");
        Console.SetCursorPosition((Console.WindowWidth / 2), 13);
        Console.WriteLine("   ██████:");
        Thread.Sleep(250);
        Console.Clear();
        Thread.Sleep(250);
        DescDeHab(0, 0, jug);
        Console.SetCursorPosition((Console.WindowWidth / 2), 12);
        Console.WriteLine(" EQUIPAMIENTO LISTO:");
        Console.SetCursorPosition((Console.WindowWidth / 2), 13);
        Console.WriteLine("-SE A QUIPADO " + tip + " PROPURSORES DE TECNOLOGIA STARK ( presione alguna tecla )");
        Console.ResetColor();
        Console.ReadKey();
        return c - tip;
    }
    //para saber que hacen las diferentes trampas 
    public static void FuncTranpas(int t)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        if (t == 0)
        {
        }
        if (t == 1)
        {
            Musc.Sonidos(4);
            Console.WriteLine("ESTA TRAMPA TE HA ENVIADO A LA CASILLA DE SALIDA ( presione cualquier tecla para continuar )");
        }
        if (t == 2)
        {
            Musc.Sonidos(4);
            Console.WriteLine("ESTA TRAMPA TE QUITA PUNTOS ( presione cualquier tecla para continuar )");
        }
        if (t == 3)
        {
            Musc.Sonidos(4);
            Console.WriteLine("ESTA TRAMPA TE QUITA PUNTOS PERO USTED NO TIENE AUN( presione cualquier tecla para continuar )");
        }
        if (t == 4)
        {
            Musc.Sonidos(4);
            Console.WriteLine("ESTA TRAMPA YA NO DEJA QUE TE MUEVAS MAS ( presione cualquier tecla para continuar )");
        }
        Console.ResetColor();
    }
    //esta clase distribuye los puntos aleatoriamente 
    public static void Points()
    {
        Random random = new Random();
        for (int k = 0; k < n + 3;)
        {
            int ranx = random.Next(1, n - 1);
            int rany = random.Next(1, m - 1);
            int x = ranx;
            int y = rany;
            if (matriz[x, y] == " ")
            {
                matriz[x, y] = "*";
                k = k + 1;
            }
        }

    }
    //para casillas de beneficio
    public static void Benef()
    {
        Random random = new Random();
        for (int k = 0; k < n;)
        {
            int ranx = random.Next(1, n - 1);
            int rany = random.Next(1, m - 1);
            int x = ranx;
            int y = rany;
            if (matriz[x, y] == " ")
            {

                matriz[x, y] = "§";
                k = k + 1;
            }
        }

    }
    //esta clase es para terminar el juego cuando recolecten x cantidad de puntos
    public static void Win()
    {
        if (puntos1 == 6)
        {
            Musc.Sonidos(3);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" FELIZIDADES EL JUGADOR UNO CONSEGUIDO LAS SEIS GEMAS ;)");
            Console.ReadKey();
            Console.Clear();
            Environment.Exit(0);

        }
        if (puntos2 == 6)
        {
            Musc.Sonidos(3);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" FELIZIDADES EL JUGADOR DOS CONSEGUIDO LAS SEIS GEMAS ;)");
            Console.ReadKey();
            Console.Clear();
            Environment.Exit(0);

        }
    }
    //cartel al salir 
    public static void Exit()
    {
        Musc.Sonidos(3);
        Console.Clear();
        Console.WriteLine(" USTED HA SALIDO EL JUEGO ");
        Console.ReadKey();
        Console.Clear();
        Environment.Exit(0);
    }
}

















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
public class Laberinto
{
    static int n = 1000;
    static int m = 1000;
    static string[,] matriz = new string[n, m];
    static int puntos1 = 0;
    static int puntos2 = 0;
    static int habilidad1 = 1;
    static int habilidad2 = 1;
    static bool turnos = true;
    static int enfriamiento1 = 0;
    static int enfriamiento2 = 0;
    static int cantpaso1 = 0;
    static int cantpaso2 = 0;


    static void Main()
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                matriz[i, j] = "0";
            }
        }
        Menu();


    }
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
                    AnsiConsole.MarkupLine("> [green]Jugar[/]");
                    Console.WriteLine("  Salir");
                }
                if (op == 2)
                {
                    Console.Clear();
                    Console.WriteLine("  Jugar");
                    AnsiConsole.MarkupLine("> [green]Salir[/]");
                }
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.DownArrow:
                        op = 2;
                        break;
                    case ConsoleKey.UpArrow:
                        op = 1;
                        break;
                    case ConsoleKey.Enter:
                        kk = 1;
                        break;
                }
            }

            if (op == 1)
            {
                Console.Clear();
                Console.WriteLine("Elija las dimensiones (N x N) del mapa en el que desea jugar");
                n = int.Parse(Console.ReadLine()!);
                m = n;

                Camino();
                Tranpas();
                Points();
                Jugadores();
                MovJug();
                Gameplay();
                break;
            }
            else if (op == 2)
            {
                Console.Clear();
                Environment.Exit(0);
                break;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Elija una de las opciones");
                Console.ReadKey();
            }
        }
    }
    //para imprimir el laberinto
    public static void Gameplay()
    {
        Console.WriteLine("╔═══════════════╦═════════════════╦═════════════════╦═════════════════╦════════════════════╗");
        Console.WriteLine("║   JUGADORES   ║     PUNTOS      ║    CANTIDAD     ║    HABILIDAD    ║   RESTAURACION     ║");
        Console.WriteLine("║               ║                 ║    DE PASOS     ║                 ║ DE LA HABILIDAD    ║");
        Console.WriteLine("╠═══════════════╬═════════════════╬═════════════════╬═════════════════╬════════════════════╣");
        if (turnos)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("║   JUGADOR 1   ║ " + puntos1 + "               ║ " + cantpaso1 + "               ║  " + habilidad1 + "              ║ " + enfriamiento1 + "                  ║");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine("║   JUGADOR 1   ║ " + puntos1 + "               ║ " + cantpaso1 + "               ║  " + habilidad1 + "              ║ " + enfriamiento1 + "                  ║");
        }
        Console.WriteLine("╠═══════════════╬═════════════════╬═════════════════╬═════════════════╬════════════════════╣");
        if (turnos == false)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("║   JUGADOR 2   ║ " + puntos2 + "               ║ " + cantpaso2 + "               ║  " + habilidad2 + "              ║ " + enfriamiento2 + "                  ║");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine("║   JUGADOR 2   ║ " + puntos2 + "               ║ " + cantpaso2 + "               ║  " + habilidad2 + "              ║ " + enfriamiento2 + "                  ║");
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
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                if (matriz[i, j] == "")
                {

                }
                Console.Write(matriz[i, j]);
                Console.ResetColor();

                Console.Write(" ");
                //Thread.Sleep(250);
            }
            Console.WriteLine();

        }

    }
    public static void DescDeHab(int habdesc, int t)
    {
        Console.Clear();
        Gameplay();
        if (habdesc == 0)
        {

        }
        else if (habdesc == 1)
        {
            Console.WriteLine("LA HABILIDAD ESCOGINA PERMITE A Iron Man CAMINAR 3 CASILLAS EXTRAS");
        }
        else if (habdesc == 2)
        {
            Console.WriteLine("LA HABILIDAD ESCOGINA SALTA EL TURNO DEL OTRO JUGADOR");
        }
        else if (habdesc == 3)
        {
            Console.WriteLine("LA HABILIDAD ESCOGINA PERMITE CONTROLAR A TU OPONENTE POR UN TURNO");
        }
        else if (habdesc == 4)
        {
            Console.WriteLine("LA HABILIDAD ESCOGINA PERMITE A Spiderman SER INMUNE A LAS TRAMPAS");
        }
        else if (habdesc == 5)
        {
            Console.WriteLine("LA HABILIDAD ESCOGINA PERMITE TOMAR UNO DE LOS PUNTOS DE TU OPONENTE ");
        }
        else if (habdesc == 6)
        {
            Console.WriteLine("LA HABILIDAD ESCOGINA PERMITE TOMAR UNO DE LOS PUNTOS DE TU OPONENTE (SU OPONENTE NO TENIA PUNTOS) ");
        }
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

        int caso = random.Next(0, 2);
        for (int i = 2; i < n - 2; i++)
        {
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
        matriz[2, 3] = " ";
        matriz[n - 3, 3] = " ";
        matriz[n - 2, 3] = " ";
        matriz[3, n - 2] = " ";
        matriz[n - 3, n - 2] = " ";
    }
    //distribulle las trampas 
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
                if (opcion == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Elige un jugador:");
                    AnsiConsole.MarkupLine("> [green]Iron Man[/]");
                    Console.WriteLine("  Capitan America");
                    Console.WriteLine("  Venom");
                    Console.WriteLine("  Spiderman");
                    Console.WriteLine("  Jean Gray");
                }
                if (opcion == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Elige un jugador:");
                    Console.WriteLine("  Iron Man");
                    AnsiConsole.MarkupLine("> [green]Capitan America[/]");
                    Console.WriteLine("  Venom");
                    Console.WriteLine("  Spiderman");
                    Console.WriteLine("  Jean Gray");
                }
                if (opcion == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Elige un jugador:");
                    Console.WriteLine("  Iron Man");
                    Console.WriteLine("  Capitan America");
                    AnsiConsole.MarkupLine("> [green]Venom[/]");
                    Console.WriteLine("  Spiderman");
                    Console.WriteLine("  Jean Gray");
                }
                if (opcion == 3)
                {
                    Console.Clear();
                    Console.WriteLine("Elige un jugador:");
                    Console.WriteLine("  Iron Man");
                    Console.WriteLine("  Capitan America");
                    Console.WriteLine("  Venom");
                    AnsiConsole.MarkupLine("> [green]Spiderman[/]");
                    Console.WriteLine("  Jean Gray");
                }
                if (opcion == 4)
                {
                    Console.Clear();
                    Console.WriteLine("Elige un jugador:");
                    Console.WriteLine("  Iron Man");
                    Console.WriteLine("  Capitan America");
                    Console.WriteLine("  Venom");
                    Console.WriteLine("  Spiderman");
                    AnsiConsole.MarkupLine("> [green]Bet[/]");
                }
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
            else
            {
                Console.Clear();
                Console.WriteLine("Utilice una de las anteriores opciones");
                Console.ReadKey();
            }

        }

        kk = 0;
        while (k == 0)
        {
            while (kk == 0)
            {
                if (opcion2 == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Elige otro jugador:");
                    AnsiConsole.MarkupLine("> [green]Iron Man[/]");
                    Console.WriteLine("  Capitan America");
                    Console.WriteLine("  Venom");
                    Console.WriteLine("  Spiderman");
                    Console.WriteLine("  Jean Gray");
                }
                if (opcion2 == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Elige otro jugador:");
                    Console.WriteLine("  Iron Man");
                    AnsiConsole.MarkupLine("> [green]Capitan America[/]");
                    Console.WriteLine("  Venom");
                    Console.WriteLine("  Spiderman");
                    Console.WriteLine("  Jean Gray");
                }
                if (opcion2 == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Elige otro jugador:");
                    Console.WriteLine("  Iron Man");
                    Console.WriteLine("  Capitan America");
                    AnsiConsole.MarkupLine("> [green]Venom[/]");
                    Console.WriteLine("  Spiderman");
                    Console.WriteLine("  Jean Gray");
                }
                if (opcion2 == 3)
                {
                    Console.Clear();
                    Console.WriteLine("Elige otro jugador:");
                    Console.WriteLine("  Iron Man");
                    Console.WriteLine("  Capitan America");
                    Console.WriteLine("  Venom");
                    AnsiConsole.MarkupLine("> [green]Spiderman[/]");
                    Console.WriteLine("  Jean Gray");
                }
                if (opcion2 == 4)
                {
                    Console.Clear();
                    Console.WriteLine("Elige otro jugador:");
                    Console.WriteLine("  Iron Man");
                    Console.WriteLine("  Capitan America");
                    Console.WriteLine("  Venom");
                    Console.WriteLine("  Spiderman");
                    AnsiConsole.MarkupLine("> [green]Jean Gray[/]");
                }
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
                        kk = 1;
                        break;
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
            else
            {
                Console.Clear();
                Console.WriteLine("Utilice una de las anteriores opciones");
                Console.ReadKey();
            }

        }
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
                        DescDeHab(desc, t);
                        Win();
                        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                        matriz[playerX, playerY] = " ";
                        tip = random.Next(0, 3);
                        switch (keyInfo.Key)
                        {
                            case ConsoleKey.UpArrow:
                                if (matriz[playerX - 1, playerY] != "0")
                                {
                                    playerX = playerX - 1;
                                    c = c + 1;
                                    cantpaso1 = cantpaso1 - 1;
                                }

                                if (matriz[playerX, playerY] == "*") puntos1 = puntos1 + 1;
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
                                                DescDeHab(desc, t);
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
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                        //no puedes moverte mas
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.DownArrow:
                                if (matriz[playerX + 1, playerY] != "0")
                                {
                                    c = c + 1;
                                    playerX = playerX + 1;
                                    cantpaso1 = cantpaso1 - 1;
                                }
                                if (matriz[playerX, playerY] == "*") puntos1 = puntos1 + 1;
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
                                                DescDeHab(desc, t);
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
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.LeftArrow:
                                if (matriz[playerX, playerY - 1] != "0")
                                {
                                    playerY = playerY - 1;
                                    cantpaso1 = cantpaso1 - 1;
                                    c = c + 1;
                                }

                                if (matriz[playerX, playerY] == "*") puntos1 = puntos1 + 1;
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
                                                DescDeHab(desc, t);
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
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t);
                                                Win();
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.RightArrow:
                                if (matriz[playerX, playerY + 1] != "0")
                                {
                                    c = c + 1;
                                    playerY = playerY + 1;
                                    cantpaso1 = cantpaso1 - 1;
                                }
                                if (matriz[playerX, playerY] == "*") puntos1 = puntos1 + 1;
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
                                                DescDeHab(desc, t);
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
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }

                                break;
                            case ConsoleKey.X:
                                if (hab == 0 && habilidad1 > 0 && jug1 == "I")
                                {
                                    cantpaso1 = cantpaso1 + 3;
                                    c = c - 3;
                                    habilidad1 = habilidad1 - 1;
                                    desc = 1;
                                    hab = hab + 1;

                                }
                                if (hab == 0 && habilidad1 > 0 && jug1 == "C")
                                {
                                    saltarturno = 1;
                                    habilidad1 = habilidad1 - 1;
                                    desc = 2;
                                    hab = hab + 1;
                                }
                                if (hab == 0 && habilidad1 > 0 && jug1 == "J")
                                {
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
                        hab = hab + 1;
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
                        DescDeHab(desc, t);
                        Win();
                        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                        tip = random.Next(0, 3);
                        matriz[playerX, playerY] = " ";
                        switch (keyInfo.Key)
                        {
                            case ConsoleKey.UpArrow:
                                if (matriz[playerX - 1, playerY] != "0")
                                {
                                    playerX = playerX - 1;
                                    c = c + 1;
                                    cantpaso1 = cantpaso1 - 1;
                                }
                                if (matriz[playerX, playerY] == "*") puntos1 = puntos1 + 1;
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
                                                DescDeHab(desc, t);
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
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.DownArrow:
                                if (matriz[playerX + 1, playerY] != "0")
                                {
                                    c = c + 1;
                                    playerX = playerX + 1;
                                    cantpaso1 = cantpaso1 - 1;
                                }
                                if (matriz[playerX, playerY] == "*") puntos1 = puntos1 + 1;
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
                                                DescDeHab(desc, t);
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
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.LeftArrow:
                                if (matriz[playerX, playerY - 1] != "0")
                                {
                                    playerY = playerY - 1;
                                    c = c + 1;
                                    cantpaso1 = cantpaso1 - 1;
                                }
                                if (matriz[playerX, playerY] == "*") puntos1 = puntos1 + 1;
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
                                                DescDeHab(desc, t);
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
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.RightArrow:
                                if (matriz[playerX, playerY + 1] != "0")
                                {
                                    c = c + 1;
                                    playerY = playerY + 1;
                                    cantpaso1 = cantpaso1 - 1;
                                }
                                if (matriz[playerX, playerY] == "*") puntos1 = puntos1 + 1;
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
                                                DescDeHab(desc, t);
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
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }

                                break;
                            case ConsoleKey.X:
                                if (hab == 0 && habilidad1 > 0 && jug1 == "V")
                                {
                                    control1 = !control1;
                                    c = 5;
                                    habilidad1 = habilidad1 - 1;
                                    desc = 3;
                                    hab = hab + 1;
                                }
                                if (hab == 0 && habilidad1 > 0 && jug1 == "S")
                                {
                                    tramp = false;
                                    hab = hab + 1;
                                    desc = 4;
                                }
                                break;
                        }
                        hab = hab + 1;
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
                        DescDeHab(desc, t);
                        Win();
                        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                        tip = random.Next(0, 3);
                        matriz[playerXX, playerYY] = " ";
                        switch (keyInfo.Key)
                        {
                            case ConsoleKey.UpArrow:
                                if (matriz[playerXX - 1, playerYY] != "0")
                                {
                                    c = c + 1;
                                    playerXX = playerXX - 1;
                                    cantpaso2 = cantpaso2 - 1;
                                }
                                if (matriz[playerXX, playerYY] == "*") puntos2 = puntos2 + 1;
                                if (matriz[playerXX, playerYY] == "X")
                                {
                                    switch (tip)
                                    {
                                        case 0:
                                            {
                                                matriz[playerXX, playerYY] = " ";
                                                playerXX = n - 2;
                                                playerYY = n - 2;
                                                t = 1;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t);
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
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.DownArrow:
                                if (matriz[playerXX + 1, playerYY] != "0")
                                {
                                    c = c + 1;
                                    playerXX = playerXX + 1;
                                    cantpaso2 = cantpaso2 - 1;
                                }
                                if (matriz[playerXX, playerYY] == "*") puntos2 = puntos2 + 1;
                                if (matriz[playerXX, playerYY] == "X")
                                {
                                    switch (tip)
                                    {
                                        case 0:
                                            {
                                                matriz[playerXX, playerYY] = " ";
                                                playerXX = n - 2;
                                                playerYY = n - 2;
                                                t = 1;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t);
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
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.LeftArrow:
                                if (matriz[playerXX, playerYY - 1] != "0")
                                {
                                    c = c + 1;
                                    playerYY = playerYY - 1;
                                    cantpaso2 = cantpaso2 - 1;
                                }
                                if (matriz[playerXX, playerYY] == "*") puntos2 = puntos2 + 1;
                                if (matriz[playerXX, playerYY] == "X")
                                {
                                    switch (tip)
                                    {
                                        case 0:
                                            {
                                                matriz[playerXX, playerYY] = " ";
                                                playerXX = n - 2;
                                                playerYY = n - 2;
                                                t = 1;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t);
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
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.RightArrow:
                                if (matriz[playerXX, playerYY + 1] != "0")
                                {
                                    c = c + 1;
                                    playerYY = playerYY + 1;
                                    cantpaso2 = cantpaso2 - 1;
                                }
                                if (matriz[playerXX, playerYY] == "*") puntos2 = puntos2 + 1;
                                if (matriz[playerXX, playerYY] == "X")
                                {
                                    switch (tip)
                                    {
                                        case 0:
                                            {
                                                matriz[playerXX, playerYY] = " ";
                                                playerXX = n - 2;
                                                playerYY = n - 2;
                                                t = 1;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t);
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
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.X:
                                if (hab == 0 && habilidad2 > 0 && jug2 == "I")
                                {
                                    cantpaso2 = cantpaso2 + 3;
                                    c = c - 3;
                                    habilidad2 = habilidad2 - 1;
                                    desc = 1;
                                    hab = hab + 1;
                                }
                                if (hab == 0 && habilidad2 > 0 && jug2 == "C")
                                {
                                    saltarturno = 1;
                                    habilidad2 = habilidad2 - 1;
                                    desc = 2;
                                    hab = hab + 1;
                                }
                                if (hab == 0 && habilidad2 > 0 && jug2 == "J")
                                {
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
                        hab = hab + 1;
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
                        DescDeHab(desc, t);
                        Win();
                        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                        tip = random.Next(0, 3);
                        matriz[playerXX, playerYY] = " ";
                        switch (keyInfo.Key)
                        {
                            case ConsoleKey.UpArrow:
                                if (matriz[playerXX - 1, playerYY] != "0")
                                {
                                    cantpaso2 = cantpaso2 - 1;
                                    c = c + 1;
                                    playerXX = playerXX - 1;
                                }
                                if (matriz[playerXX, playerYY] == "*") puntos2 = puntos2 + 1;
                                if (matriz[playerXX, playerYY] == "X" && tramp)
                                {
                                    switch (tip)
                                    {
                                        case 0:
                                            {
                                                matriz[playerXX, playerYY] = " ";
                                                playerXX = n - 2;
                                                playerYY = n - 2;
                                                t = 1;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t);
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
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.DownArrow:
                                if (matriz[playerXX + 1, playerYY] != "0")
                                {
                                    cantpaso2 = cantpaso2 - 1;
                                    c = c + 1;
                                    playerXX = playerXX + 1;
                                }
                                if (matriz[playerXX, playerYY] == "*") puntos2 = puntos2 + 1;
                                if (matriz[playerXX, playerYY] == "X" && tramp)
                                {
                                    switch (tip)
                                    {
                                        case 0:
                                            {
                                                matriz[playerXX, playerYY] = " ";
                                                playerXX = n - 2;
                                                playerYY = n - 2;
                                                t = 1;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t);
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
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.LeftArrow:
                                if (matriz[playerXX, playerYY - 1] != "0")
                                {
                                    cantpaso2 = cantpaso2 - 1;
                                    c = c + 1;
                                    playerYY = playerYY - 1;
                                }
                                if (matriz[playerXX, playerYY] == "*") puntos2 = puntos2 + 1;
                                if (matriz[playerXX, playerYY] == "X" && tramp)
                                {
                                    switch (tip)
                                    {
                                        case 0:
                                            {
                                                matriz[playerXX, playerYY] = " ";
                                                playerXX = n - 2;
                                                playerYY = n - 2;
                                                t = 1;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t);
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
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.RightArrow:
                                if (matriz[playerXX, playerYY + 1] != "0")
                                {
                                    cantpaso2 = cantpaso2 - 1;
                                    c = c + 1;
                                    playerYY = playerYY + 1;
                                }
                                if (matriz[playerXX, playerYY] == "*") puntos2 = puntos2 + 1;
                                if (matriz[playerXX, playerYY] == "X" && tramp)
                                {
                                    switch (tip)
                                    {
                                        case 0:
                                            {
                                                matriz[playerXX, playerYY] = " ";
                                                playerXX = n - 2;
                                                playerYY = n - 2;
                                                t = 1;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t);
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
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.X:
                                if (hab == 0 && habilidad2 > 0 && jug2 == "V")
                                {
                                    control2 = !control2;
                                    c = 5;
                                    habilidad2 = habilidad2 - 1;
                                    desc = 3;
                                    hab = hab + 1;
                                }
                                if (hab == 0 && habilidad1 > 0 && jug2 == "S")
                                {
                                    tramp = false;
                                    hab = hab + 1;
                                    desc = 4;
                                }
                                break;
                        }
                        hab = hab + 1;
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
                        DescDeHab(desc, t);
                        Win();
                        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                        tip = random.Next(0, 3);
                        matriz[playerXX, playerYY] = " ";
                        switch (keyInfo.Key)
                        {
                            case ConsoleKey.UpArrow:
                                if (matriz[playerXX - 1, playerYY] != "0")
                                {
                                    c = c + 1;
                                    playerXX = playerXX - 1;
                                    cantpaso2 = cantpaso2 - 1;
                                }
                                if (matriz[playerXX, playerYY] == "*") puntos2 = puntos2 + 1;
                                if (matriz[playerXX, playerYY] == "X")
                                {
                                    switch (tip)
                                    {
                                        case 0:
                                            {
                                                matriz[playerXX, playerYY] = " ";
                                                playerXX = n - 2;
                                                playerYY = n - 2;
                                                t = 1;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t);
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
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.DownArrow:
                                if (matriz[playerXX + 1, playerYY] != "0")
                                {
                                    c = c + 1;
                                    playerXX = playerXX + 1;
                                    cantpaso2 = cantpaso2 - 1;
                                }
                                if (matriz[playerXX, playerYY] == "*") puntos2 = puntos2 + 1;
                                if (matriz[playerXX, playerYY] == "X")
                                {
                                    switch (tip)
                                    {
                                        case 0:
                                            {
                                                matriz[playerXX, playerYY] = " ";
                                                playerXX = n - 2;
                                                playerYY = n - 2;
                                                t = 1;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t);
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
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.LeftArrow:
                                if (matriz[playerXX, playerYY - 1] != "0")
                                {
                                    c = c + 1;
                                    playerYY = playerYY - 1;
                                    cantpaso2 = cantpaso2 - 1;
                                }
                                if (matriz[playerXX, playerYY] == "*") puntos2 = puntos2 + 1;
                                if (matriz[playerXX, playerYY] == "X")
                                {
                                    switch (tip)
                                    {
                                        case 0:
                                            {
                                                matriz[playerXX, playerYY] = " ";
                                                playerXX = n - 2;
                                                playerYY = n - 2;
                                                t = 1;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t);
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
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.RightArrow:
                                if (matriz[playerXX, playerYY + 1] != "0")
                                {
                                    c = c + 1;
                                    playerYY = playerYY + 1;
                                    cantpaso2 = cantpaso2 - 1;
                                }
                                if (matriz[playerXX, playerYY] == "*") puntos2 = puntos2 + 1;
                                if (matriz[playerXX, playerYY] == "X")
                                {
                                    switch (tip)
                                    {
                                        case 0:
                                            {
                                                matriz[playerXX, playerYY] = " ";
                                                playerXX = n - 2;
                                                playerYY = n - 2;
                                                t = 1;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t);
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
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                        }
                        matriz[playerXX, playerYY] = jug2;
                    }
                }
                else if (jug2 == "V" || jug2 == "S")
                {
                    for (int c = 0; c < 4;)
                    {
                        t = 0;
                        DescDeHab(desc, t);
                        Win();
                        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                        tip = random.Next(0, 3);
                        matriz[playerXX, playerYY] = " ";
                        switch (keyInfo.Key)
                        {
                            case ConsoleKey.UpArrow:
                                if (matriz[playerXX - 1, playerYY] != "0")
                                {
                                    cantpaso2 = cantpaso2 - 1;
                                    c = c + 1;
                                    playerXX = playerXX - 1;
                                }
                                if (matriz[playerXX, playerYY] == "*") puntos2 = puntos2 + 1;
                                if (matriz[playerXX, playerYY] == "X" && tramp)
                                {
                                    switch (tip)
                                    {
                                        case 0:
                                            {
                                                matriz[playerXX, playerYY] = " ";
                                                playerXX = n - 2;
                                                playerYY = n - 2;
                                                t = 1;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t);
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
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.DownArrow:
                                if (matriz[playerXX + 1, playerYY] != "0")
                                {
                                    cantpaso2 = cantpaso2 - 1;
                                    c = c + 1;
                                    playerXX = playerXX + 1;
                                }
                                if (matriz[playerXX, playerYY] == "*") puntos2 = puntos2 + 1;
                                if (matriz[playerXX, playerYY] == "X" && tramp)
                                {
                                    switch (tip)
                                    {
                                        case 0:
                                            {
                                                matriz[playerXX, playerYY] = " ";
                                                playerXX = n - 2;
                                                playerYY = n - 2;
                                                t = 1;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t);
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
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.LeftArrow:
                                if (matriz[playerXX, playerYY - 1] != "0")
                                {
                                    cantpaso2 = cantpaso2 - 1;
                                    c = c + 1;
                                    playerYY = playerYY - 1;
                                }
                                if (matriz[playerXX, playerYY] == "*") puntos2 = puntos2 + 1;
                                if (matriz[playerXX, playerYY] == "X" && tramp)
                                {
                                    switch (tip)
                                    {
                                        case 0:
                                            {
                                                matriz[playerXX, playerYY] = " ";
                                                playerXX = n - 2;
                                                playerYY = n - 2;
                                                t = 1;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t);
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
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.RightArrow:
                                if (matriz[playerXX, playerYY + 1] != "0")
                                {
                                    cantpaso2 = cantpaso2 - 1;
                                    c = c + 1;
                                    playerYY = playerYY + 1;
                                }
                                if (matriz[playerXX, playerYY] == "*") puntos2 = puntos2 + 1;
                                if (matriz[playerXX, playerYY] == "X" && tramp)
                                {
                                    switch (tip)
                                    {
                                        case 0:
                                            {
                                                matriz[playerXX, playerYY] = " ";
                                                playerXX = n - 2;
                                                playerYY = n - 2;
                                                t = 1;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t);
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
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerXX, playerYY] = jug2;
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                        }
                        matriz[playerXX, playerYY] = jug2;

                    }
                }
                control1 = !control1;
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
                        DescDeHab(desc, t);
                        Win();
                        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                        matriz[playerX, playerY] = " ";
                        tip = random.Next(0, 3);
                        switch (keyInfo.Key)
                        {
                            case ConsoleKey.UpArrow:
                                if (matriz[playerX - 1, playerY] != "0")
                                {
                                    playerX = playerX - 1;
                                    c = c + 1;
                                    cantpaso1 = cantpaso1 - 1;
                                }

                                if (matriz[playerX, playerY] == "*") puntos1 = puntos1 + 1;
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
                                                DescDeHab(desc, t);
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
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                        //no puedes moverte mas
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.DownArrow:
                                if (matriz[playerX + 1, playerY] != "0")
                                {
                                    c = c + 1;
                                    playerX = playerX + 1;
                                    cantpaso1 = cantpaso1 - 1;
                                }
                                if (matriz[playerX, playerY] == "*") puntos1 = puntos1 + 1;
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
                                                DescDeHab(desc, t);
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
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.LeftArrow:
                                if (matriz[playerX, playerY - 1] != "0")
                                {
                                    playerY = playerY - 1;
                                    cantpaso1 = cantpaso1 - 1;
                                    c = c + 1;
                                }

                                if (matriz[playerX, playerY] == "*") puntos1 = puntos1 + 1;
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
                                                DescDeHab(desc, t);
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
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t);
                                                Win();
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.RightArrow:
                                if (matriz[playerX, playerY + 1] != "0")
                                {
                                    c = c + 1;
                                    playerY = playerY + 1;
                                    cantpaso1 = cantpaso1 - 1;
                                }
                                if (matriz[playerX, playerY] == "*") puntos1 = puntos1 + 1;
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
                                                DescDeHab(desc, t);
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
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }

                                break;
                        }
                        matriz[playerX, playerY] = jug1;
                    }

                }
                else if (jug1 == "V" || jug1 == "S")
                {
                    for (int c = 0; c < 4;)
                    {
                        t = 0;
                        DescDeHab(desc, t);
                        Win();
                        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                        tip = random.Next(0, 3);
                        matriz[playerX, playerY] = " ";
                        switch (keyInfo.Key)
                        {
                            case ConsoleKey.UpArrow:
                                if (matriz[playerX - 1, playerY] != "0")
                                {
                                    playerX = playerX - 1;
                                    c = c + 1;
                                    cantpaso1 = cantpaso1 - 1;
                                }
                                if (matriz[playerX, playerY] == "*") puntos1 = puntos1 + 1;
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
                                                DescDeHab(desc, t);
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
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.DownArrow:
                                if (matriz[playerX + 1, playerY] != "0")
                                {
                                    c = c + 1;
                                    playerX = playerX + 1;
                                    cantpaso1 = cantpaso1 - 1;
                                }
                                if (matriz[playerX, playerY] == "*") puntos1 = puntos1 + 1;
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
                                                DescDeHab(desc, t);
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
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.LeftArrow:
                                if (matriz[playerX, playerY - 1] != "0")
                                {
                                    playerY = playerY - 1;
                                    c = c + 1;
                                    cantpaso1 = cantpaso1 - 1;
                                }
                                if (matriz[playerX, playerY] == "*") puntos1 = puntos1 + 1;
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
                                                DescDeHab(desc, t);
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
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.RightArrow:
                                if (matriz[playerX, playerY + 1] != "0")
                                {
                                    c = c + 1;
                                    playerY = playerY + 1;
                                    cantpaso1 = cantpaso1 - 1;
                                }
                                if (matriz[playerX, playerY] == "*") puntos1 = puntos1 + 1;
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
                                                DescDeHab(desc, t);
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
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 2:
                                            {
                                                c = 10;
                                                t = 4;
                                                matriz[playerX, playerY] = jug1;
                                                DescDeHab(desc, t);
                                                Console.ReadKey();
                                            }
                                            break;
                                    }
                                }

                                break;
                        }
                        matriz[playerX, playerY] = jug1;
                    }
                }
                control2 = !control2;
                hab = 1;
            }
            if (jug1 == "I" || jug1 == "C" || jug1 == "J") cantpaso1 = 3;
            else if (jug1 == "V" || jug1 == "S") cantpaso1 = 4;
            if (jug2 == "I" || jug2 == "C" || jug2 == "J") cantpaso2 = 3;
            else if (jug2 == "V" || jug2 == "S") cantpaso2 = 4;
        }
    }
    //para las diferentes trampas 
    public static void FuncTranpas(int t)
    {
        if (t == 0)
        {
        }
        if (t == 1)
        {
            Console.WriteLine("ESTA TRAMPA TE HA ENVIADO A LA CASILLA DE SALIDA(PRESIONE CUALQUIER TECLA PARA CONTINUAR)");
        }
        if (t == 2)
        {
            Console.WriteLine("ESTA TRAMPA TE QUITA PUNTOS(PRESIONE CUALQUIER TECLA PARA CONTINUAR)");
        }
        if (t == 3)
        {
            Console.WriteLine("ESTA TRAMPA TE QUITA PUNTOS PERO USTED NO TIENE AUN(PRESIONE CUALQUIER TECLA PARA CONTINUAR)");
        }
        if (t == 4)
        {
            Console.WriteLine("ESTA TRAMPA YA NO DEJA QUE TE MUEVAS MAS (PRESIONE CUALQUIER TECLA PARA CONTINUAR)");
        }
    }
    //esta clase distribuye los puntos aleatoriamente 
    public static void Points()
    {
        Random random = new Random();
        for (int k = 0; k < 15;)
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
    //esta clase es para terminar el juego cuando recolecten x cantidad de puntos
    public static void Win()
    {
        if (puntos1 == 5)
        {
            Console.Clear();
            Console.WriteLine(" Felicidades, a ganado el jugador 1");
            Console.ReadKey();
            Console.Clear();
            Environment.Exit(0);

        }
        if (puntos2 == 5)
        {
            Console.Clear();
            Console.WriteLine(" Felicidades, a ganado el jugador 2");
            Console.ReadKey();
            Console.Clear();
            Environment.Exit(0);

        }
    }

}

















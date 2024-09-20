using System;

class ProgramaReservaciones
{
    const int TOTAL_ASIENTOS = 10;
    const int FUMAR = 1;
    const int NO_FUMAR = 2;

    static void MostrarMenu()
    {
        Console.WriteLine("Please type 1 for \"smoking\"");
        Console.WriteLine("Please type 2 for \"nonsmoking\"");
    }

    static void ImprimirPaseAbordaje(int asiento, int tipo)
    {
        if (tipo == FUMAR)
        {
            Console.WriteLine($"Your boarding pass: Seat {asiento} (Smoking section)");
        }
        else
        {
            Console.WriteLine($"Your boarding pass: Seat {asiento} (Non-smoking section)");
        }
    }

    static void Main()
    {
        int[] asientos = new int[TOTAL_ASIENTOS]; // 0: libre, 1: ocupado
        int opcion;

        while (true)
        {
            MostrarMenu();
            while (!int.TryParse(Console.ReadLine(), out opcion)) 
            { 
                Console.WriteLine("Digite un numero valido!");
            }

            int asientoAsignado = -1;

            switch (opcion)
            {
                case FUMAR:
                    for (int i = 0; i < 5; i++)
                    {
                        if (asientos[i] == 0) // Buscando asiento libre en fumar
                        {
                            asientos[i] = 1; // Asignar asiento
                            asientoAsignado = i + 1; // Asiento 1 al 5
                            ImprimirPaseAbordaje(asientoAsignado, FUMAR);
                            break;
                        }
                    }
                    if (asientoAsignado == -1)
                    {
                        Console.Write("Smoking section full. Would you like to sit in non-smoking section? (y/n): ");
                        char respuesta = Console.ReadKey().KeyChar;
                        Console.WriteLine();
                        if (respuesta == 'y')
                        {
                            for (int i = 5; i < TOTAL_ASIENTOS; i++)
                            {
                                if (asientos[i] == 0)
                                {
                                    asientos[i] = 1;
                                    asientoAsignado = i + 1; // Asiento 6 al 10
                                    ImprimirPaseAbordaje(asientoAsignado, NO_FUMAR);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Next flight leaves in 3 hours.");
                        }
                    }
                    break;

                case NO_FUMAR:
                    for (int i = 5; i < TOTAL_ASIENTOS; i++)
                    {
                        if (asientos[i] == 0) // Buscando asiento libre en no fumar
                        {
                            asientos[i] = 1; // Asignar asiento
                            asientoAsignado = i + 1; // Asiento 6 al 10
                            ImprimirPaseAbordaje(asientoAsignado, NO_FUMAR);
                            break;
                        }
                    }
                    if (asientoAsignado == -1)
                    {
                        Console.Write("Non-smoking section full. Would you like to sit in smoking section? (y/n): ");
                        char respuesta = Console.ReadKey().KeyChar;
                        Console.WriteLine();
                        if (respuesta == 'y')
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                if (asientos[i] == 0)
                                {
                                    asientos[i] = 1;
                                    asientoAsignado = i + 1; // Asiento 1 al 5
                                    ImprimirPaseAbordaje(asientoAsignado, FUMAR);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Next flight leaves in 3 hours.");
                        }
                    }
                    break;

                default:
                    Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                    break;
            }
        }
    }
}

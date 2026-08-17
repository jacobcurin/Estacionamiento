using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Net.NetworkInformation;

namespace Estacionamiento
{
    internal class Program
    {
        public static int Pregunta()
        {
            while (true)
            {
                Console.WriteLine("¿Cuántas horas ha estado en el estacionamiento?");
                string? respuestaHora = Console.ReadLine();

                Console.WriteLine("¿Y cuántos minutos adicionales?");
                string? respuestaMinuto = Console.ReadLine();

                //Comprobamos que ambas entradas sean números
                if (!int.TryParse(respuestaHora, out int hora) ||
                    !int.TryParse(respuestaMinuto, out int minuto))
                {
                    Console.WriteLine("Favor de indicar NÚMEROS.");
                    continue;
                }

                //Aqui impedimos el paso a números negativos
                if (hora < 0 || minuto < 0)
                {
                    Console.WriteLine("No se permiten números negativos.");
                    continue;
                }

                //Aqué compruebo el rango de minutos adicionales
                if (minuto > 59)
                {
                    Console.WriteLine("El rango de minutos va de 0 a 59.");
                    continue;
                }

                //Para este punto los datos ya son válidos
                int totalMinutos = (hora * 60) + minuto;

                if (totalMinutos <= 60)
                {
                    return 5000;
                }
                else if (totalMinutos <= 120)
                {
                    return 15000;
                }
                else
                {
                    return 40000;
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine(Pregunta());
        }
    }
}

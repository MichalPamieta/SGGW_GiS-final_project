using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Temat18
{
    class Program
    {
        public static void Uruchom()
        {
            string dane = "";
            int n = 0;
            //wierzchołki
            do
            {
                Console.Write("\nPodaj liczbę wierzchołków w grafie (liczbę większą od 0)\n n = ");
                //wersja dłuższa - dokładniejsza
                dane = Console.ReadLine();
                try
                {
                    n = Convert.ToInt32(dane);
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Nie podano żadnej wartości! Wprowadzono pusty ciąg.");
                    continue;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Podano wartość w niepoprawnym formacie! Dozwolone wartości to liczby całkowite większe od 0.");
                    continue;
                }
                catch(OverflowException)
                {
                    Console.WriteLine("Podana liczba wykracza poza dozwolony zakres, czyli: " + Int32.MaxValue + "!");
                    continue;
                }
                if (n > 0) break;
                else Console.WriteLine("Liczba węzełów nie może być wartością ujemną!");
                /*
                wersja krótsza - ogólniejsza
                dane = Console.ReadLine();
                int n = int.TryParse(dane, out n) ? n : 0;
                if (n > 0) break;
                else Console.WriteLine("Podano niepoprawną wartość!");
                */
            } while (true);
            //początek
            int p = 0;
            do
            {
                Console.Write("\nPodaj węzeł początkowy\n p = ");
                //wersja dłuższa - dokładniejsza
                dane = Console.ReadLine();
                try
                {
                    p = Convert.ToInt32(dane);
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Nie podano żadnej wartości! Wprowadzono pusty ciąg.");
                    continue;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Podano wartość w niepoprawnym formacie! Dozwolone wartości to liczby całkowite większe od 0.");
                    continue;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Podana liczba wykracza poza dozwolony zakres, czyli: " + Int32.MaxValue + "!");
                    continue;
                }
                if (p >= 0)
                {
                    if (p < n) break;
                    else Console.WriteLine("Numer węzła nie może wykraczać poza liczbę podanych węzłów (n = " + n + ")! Uwaga: Węzły są numerowane od 0.");
                }
                else
                {
                    Console.WriteLine("Węzeł nie może być wartością ujemną!");
                }
                /*
                wersja krótsza - ogólniejsza
                dane = Console.ReadLine();
                int p = int.TryParse(dane, out p) ? p : 0;
                if (p > 0 && p < n) break;
                else Console.WriteLine("Podano niepoprawną wartość!");
                */
            } while (true);
            //koniec
            int k = 0;
            do
            {
                Console.Write("\nPodaj węzeł końcowy\n k = ");
                //wersja dłuższa - dokładniejsza
                dane = Console.ReadLine();
                try
                {
                    k = Convert.ToInt32(dane);
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Nie podano żadnej wartości! Wprowadzono pusty ciąg.\n");
                    continue;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Podano wartość w niepoprawnym formacie! Dozwolone wartości to liczby całkowite większe od 0.\n");
                    continue;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Podana liczba wykracza poza dozwolony zakres, czyli: " + Int32.MaxValue + "!\n");
                    continue;
                }
                if (k >= 0)
                {
                    if (k < n) break;
                    else Console.WriteLine("Numer węzła nie może wykraczać poza liczbę podanych węzłów (n = " + n + ")! Uwaga: Węzły są numerowane od 0.\n");
                }
                else
                {
                    Console.WriteLine("Węzeł nie może być wartością ujemną!\n");
                }
                /*
                wersja krótsza - ogólniejsza
                dane = Console.ReadLine();
                int k = int.TryParse(dane, out k) ? k : 0;
                if (k > 0 && k < n) break;
                else Console.WriteLine("Podano niepoprawną wartość!");
                */
            } while (true);
            //macierz sąsiedztwa
            int[,] macierz = new int[n, n];
                Console.WriteLine("\nWprowadź macierz sąsiedztwa dla grafu (wartości między kolumnami oddzielaj znakiem SPACJI - poprawny format: \"x y z\"):\n");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Podaj wiersz " + i);
                string[] data = Console.ReadLine().Split(' ');
                if (data.Length > n)
                {
                    Console.WriteLine("Podano za dużo wartości! Wprowadzono " + data.Length + " wartości w kolumnach, gdy graf ma " + n + " węzłów!\nSpróbuj wpisać wiersz ponownie (" + n + " kolumn)");
                    i--;
                }
                else if (data.Length < n)
                {
                    Console.WriteLine("Podano za mało wartości! Wprowadzono " + data.Length + " wartości w kolumnach, gdy graf ma " + n + " węzłów!\nSpróbuj wpisać wiersz ponownie (" + n + " kolumn)");
                    i--;
                }
                else
                {
                    for (int j = 0; j < n; j++)
                    {
                        try
                        {
                            macierz[i, j] = Convert.ToInt32(data[j]);
                        }
                        catch (ArgumentNullException)
                        {
                            Console.WriteLine("Nie podano żadnej wartości! Wprowadzono pusty ciąg.\nSpróbuj wpisać wiersz ponownie (poprawny format to: \"x y z\")!");
                            i--;
                            break;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Podano wartość w niepoprawnym formacie! Dozwolone wartości to liczby całkowite większe od 0.\nSpróbuj wpisać wiersz ponownie (poprawny format to: \"x y z\")!");
                            i--;
                            break;
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine("Podana liczba wykracza poza dozwolony zakres, czyli: " + Int32.MaxValue + "!\nSpróbuj wpisać wiersz ponownie (poprawny format to: \"x y z\")!");
                            i--;
                            break;
                        }
                    }
                }
            }
            //potwierdzenie danych (opcjonalne)
            Console.WriteLine("\n\n\nWprowadzono następujące wartości:\nLiczba węzłów w grafie: {0}\nWęzeł początkowy: {1}\nWęzeł końcowy: {2}\nWprowadzona macierz sąsiedztwa:\n", n, p, k);
            for (int i = 0; i < macierz.GetLength(0); i++)
            {
                for (int j = 0; j < macierz.GetLength(1); j++)
                {
                    Console.Write(macierz[i,j] + " ");
                }
                Console.WriteLine();
            }
            int drogi = -1;
            do
            {
                Console.WriteLine("\nJeżeli wyświetlone wartości zgadzają się - wpisz \"OBLICZ\"");
                Console.WriteLine("Jeżeli chcesz wprowadzić WSZYSTKIE dane od początku  - wpisz \"RESTART\"");
                string test = Console.ReadLine();
                test = test.Trim().ToUpper();
                switch (test)
                {
                    case ("OBLICZ"):
                        drogi = RozlaczneDrogi(macierz, n, p, k);
                        Console.Write("\nWYNIK\nW podanym grafie program znalazł następującą liczbę rozłącznych dróg od węzła początkowego {0} do węzła końcowego {1}: ", p, k);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(drogi);
                        Console.ResetColor();
                        break;
                    case ("RESTART"):
                        Uruchom();
                        break;
                    default:
                        Console.WriteLine("Wprowadzono niepoprawną wartość!\n");
                        break;
                }

            } while (drogi == -1);
        }
        private static bool BFS(int[,] macierz, ref int[] rodzice, int n, int start, int koniec)
        {
            bool[] odwiedzone = new bool[n];
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            odwiedzone[start] = true;

            while (queue.Count > 0)
            {
                int u = queue.Dequeue();
                for (int i = 0; i < n; i++)
                {
                    if (!odwiedzone[i] && macierz[u, i] > 0)
                    {
                        queue.Enqueue(i);
                        odwiedzone[i] = true;
                        rodzice[i] = u;
                    }
                }
            }
            return odwiedzone[koniec];
        }
        private static int RozlaczneDrogi(int[,] macierz, int n, int start, int koniec)
        {
            int[] rodzice = new int[n];
            int drog = 0;
            while (BFS(macierz, ref rodzice, n, start, koniec))
            {
                drog++;

                int koniec_tmp = koniec;
                do
                {
                    macierz[rodzice[koniec_tmp], koniec_tmp] -= 1;
                    koniec_tmp = rodzice[koniec_tmp];
                } while (koniec_tmp != start);
            }
            return drog;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("\n       PROJEKT NA PRZEDMIOT: GRAFY I SIECI \n\n   WYBRANY TEMAT: \n       18. Zaprojektować i zaimplementować algorytm poszukiwana maksymalnej liczby dróg \n" +
            "       krawędziowo rozłącznych między dwoma dowolnymi wierzchołkami grafu spójnego. \n\n       AUTOR:\n        Michał Pamięta\n        196099");
            Console.WriteLine("\n\n\n");
            Uruchom();
            bool czyRestart = true;
            do
            {
                Console.WriteLine("\n\n\nCzy chcesz uruchomić program ponownie?\n\"TAK\" - restartuje program\n\"NIE\" - zamyka program");
                string test = Console.ReadLine();
                test = test.Trim().ToUpper();
                switch (test)
                {
                    case ("TAK"):
                        Uruchom();
                        break;
                    case ("NIE"):
                        czyRestart = false;
                        Console.WriteLine("Okno zamknie się za 3 sekundy");
                        Thread.Sleep(3000);
                        break;
                    default:
                        Console.WriteLine("Wprowadzono niepoprawną wartość!\n");
                        break;
                }
            } while (czyRestart);
        }
    }
}

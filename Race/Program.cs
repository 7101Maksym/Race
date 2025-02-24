using System.Diagnostics;

namespace Race
{
	internal class Program
	{
		static bool stop = false;

		static void SetColorByNumber(int background_number, int foreground_number)
		{
			switch (background_number)
			{
				case 0:
					Console.BackgroundColor = ConsoleColor.Black;
					break;
				case 1:
					Console.BackgroundColor = ConsoleColor.DarkBlue;
					break;
				case 2:
					Console.BackgroundColor = ConsoleColor.DarkGreen;
					break;
				case 3:
					Console.BackgroundColor = ConsoleColor.DarkCyan;
					break;
				case 4:
					Console.BackgroundColor = ConsoleColor.DarkRed;
					break;
				case 5:
					Console.BackgroundColor = ConsoleColor.DarkMagenta;
					break;
				case 6:
					Console.BackgroundColor = ConsoleColor.DarkYellow;
					break;
				case 7:
					Console.BackgroundColor = ConsoleColor.Gray;
					break;
				case 8:
					Console.BackgroundColor = ConsoleColor.DarkGray;
					break;
				case 9:
					Console.BackgroundColor = ConsoleColor.Blue;
					break;
				case 10:
					Console.BackgroundColor = ConsoleColor.Green;
					break;
				case 11:
					Console.BackgroundColor = ConsoleColor.Cyan;
					break;
				case 12:
					Console.BackgroundColor = ConsoleColor.Red;
					break;
				case 13:
					Console.BackgroundColor = ConsoleColor.Magenta;
					break;
				case 14:
					Console.BackgroundColor = ConsoleColor.Yellow;
					break;
				case 15:
					Console.BackgroundColor = ConsoleColor.White;
					break;
				default:
					Console.BackgroundColor = ConsoleColor.Black;
					break;
			}

			switch (foreground_number)
			{
				case 0:
					Console.ForegroundColor = ConsoleColor.Black;
					break;
				case 1:
					Console.ForegroundColor = ConsoleColor.DarkBlue;
					break;
				case 2:
					Console.ForegroundColor = ConsoleColor.DarkGreen;
					break;
				case 3:
					Console.ForegroundColor = ConsoleColor.DarkCyan;
					break;
				case 4:
					Console.ForegroundColor = ConsoleColor.DarkRed;
					break;
				case 5:
					Console.ForegroundColor = ConsoleColor.DarkMagenta;
					break;
				case 6:
					Console.ForegroundColor = ConsoleColor.DarkYellow;
					break;
				case 7:
					Console.ForegroundColor = ConsoleColor.Gray;
					break;
				case 8:
					Console.ForegroundColor = ConsoleColor.DarkGray;
					break;
				case 9:
					Console.ForegroundColor = ConsoleColor.Blue;
					break;
				case 10:
					Console.ForegroundColor = ConsoleColor.Green;
					break;
				case 11:
					Console.ForegroundColor = ConsoleColor.Cyan;
					break;
				case 12:
					Console.ForegroundColor = ConsoleColor.Red;
					break;
				case 13:
					Console.ForegroundColor = ConsoleColor.Magenta;
					break;
				case 14:
					Console.ForegroundColor = ConsoleColor.Yellow;
					break;
				case 15:
					Console.ForegroundColor = ConsoleColor.White;
					break;
				default:
					Console.ForegroundColor = ConsoleColor.Black;
					break;
			}
		}

		static (int, int) GetFieldLengthAndSnailCount()
		{
			(int, int) parametrs;

			Console.Write("Введите длину дорожек: ");

			while (!int.TryParse(Console.ReadLine(), out parametrs.Item1) || parametrs.Item1 < 4 || parametrs.Item1 > 100)
			{
				Console.WriteLine("Невенрный ввод!");
			}

			Console.Clear();

			Console.Write("Введите количество улиток: ");

			while (!int.TryParse(Console.ReadLine(), out parametrs.Item2) || parametrs.Item2 < 2 || parametrs.Item2 > 15)
			{
				Console.WriteLine("Невенрный ввод!");
			}

			return parametrs;
		}

		static void PrintSnailsInformation(int[] steps)
		{
			for (int i = 0; i < steps.Length; i++)
			{
				SetColorByNumber(0, i + 1);
				Console.Write("@");
                SetColorByNumber(0, 15);

				Console.WriteLine($" прошла {steps[i]} шагов.");
            }
		}

		static void PrintField(int length, int[] positions, int count_snails)
		{
			bool wall_or_road = true;

			int n = 0;

			do
			{
				SetColorByNumber(0, 15);

				Console.Write("|");

				if (wall_or_road)
				{
					for (int i = 0; i <= length; i++)
					{
                        Console.Write("-");
                    }
                }
				else
				{
                    for (int i = 0; i <= length; i++)
                    {
						if (i == positions[n] && positions[n] != 50)
						{
							SetColorByNumber(0, n + 1);
							Console.Write("@");
                            SetColorByNumber(0, 15);
                        }
						else
						{
							Console.Write(" ");
						}
                    }

					n++;
                }
				
				Console.WriteLine("|");

				wall_or_road = !wall_or_road;
			}while (n != count_snails);

            Console.Write("|");

            for (int i = 0; i <= length; i++)
            {
                Console.Write("-");
            }

            Console.WriteLine("|");
        }

		static void Process((int, int) param)
		{
			int[] winners;

			Snails_parametrs s = new Snails_parametrs(param.Item2, param.Item1);

			do
			{
				PrintField(param.Item1, s.GetSnailsPositions(), s.count_snails);

				winners = s.GetWinners();
				
				PrintSnailsInformation(s.GetSnailsPositions());
				
				if (winners.Length != 0)
				{
					break;
				}

				Console.ReadKey();

				Console.Clear();

				s.MoveSnails();
			}while(true);

			Console.Write("\n\nВыиграли: ");

			for (int i = 0; i < winners.Length; i++)
			{
				SetColorByNumber(0, winners[i]);
				Console.Write("@");
                SetColorByNumber(0, 15);
				Console.Write(" ");
            }

			Console.WriteLine("\n");
		}

		static void Main(string[] args)
		{
			(int, int) param;

			param = GetFieldLengthAndSnailCount();

			Process(param);
		}
	}
}

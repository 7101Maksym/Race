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

		static void PrintSnailInformation(ref List<Snail> snails)
		{
			Console.WriteLine();

            for (int i = 0; i < snails.Count; i++)
			{
				SetColorByNumber(0, i + 1);
				Console.Write("@ ");
                SetColorByNumber(0, 15);
				Console.WriteLine($"прошла {snails[i].pos} шагов");
            }
		}

		static void PrintFied(char[,] field)
		{
			int id = 1;

			for (int i = 0; i < field.GetLength(0); i++)
			{
				for (int j = 0;  j < field.GetLength(1); j++)
				{
					if (field[i, j] == '@')
					{
						SetColorByNumber(0, id);

						id++;

						Console.Write(field[i, j]);
					}
					else
					{
						SetColorByNumber(0, 15);

						Console.Write(field[i, j]);
					}
                }

				Console.WriteLine();
			}
		}

		static char[,] InitField(int rows, int cols)
		{
			char[,] field = new char[rows + rows + 1, cols + 2];

			for (int i = 0; i < field.GetLength(0); i++)
			{
				for (int j = 0; j < field.GetLength(1); j++)
				{
					if (j == 0 || j == field.GetLength(1) - 1)
					{
						field[i, j] = '|';
					}
					else if (j == 1 && i % 2 != 0)
					{
                        field[i, j] = '@';
                    }
                    else if ((j == 2 || j == field.GetLength(1) - 2) && i % 2 != 0)
                    {
                        field[i, j] = '#';
                    }
                    else if (i % 2 == 0)
					{
						field[i, j] = '-';
					}
					else
					{
						field[i, j] = ' ';
					}
				}
			}

			return field;
		}

		static void InitSnails(ref List<Snail> snails, int count)
		{
			for (int i = 0; i < count; i++)
			{
				Snail item = new Snail((Random.Shared.Next() % 6) + 1);

				snails.Add(item);
            }
		}

		static void process(ref List<Snail> snails, ref char[,] field, int length)
		{
			ConsoleKeyInfo a;

			bool is_win = false, is_win2 = false;

			do
			{
				Console.WriteLine("Нажмите Enter, чтобы продолжить, или другую клавишу, чтобы завершить игру");

                a = Console.ReadKey();

				if (a.Key == ConsoleKey.Enter)
				{
					for (int i = 1, j = 0; j < snails.Count; i += 2, j++)
					{
						if ((snails[j].pos + 1 + snails[j]._speed) >= length)
						{
							is_win = true;
							is_win2 = true;
						}
						else
						{
							is_win = false;
						}

						if (!is_win)
						{
							field[i, snails[j].pos + 1] = snails[j]._sumbol;

							snails[j]._sumbol = field[i, snails[j].pos + 1 + snails[j]._speed];

							snails[j].pos = snails[j]._speed;

							field[i, snails[j].pos + 1] = '@';
						}
						else
						{
							field[i, snails[j].pos + 1] = snails[j]._sumbol;

                            snails[j]._position = length;

                            field[i, field.GetLength(1) - 2] = '@';

							snails[j]._id = j + 1;
						}
					}
				}
				else
				{
					Console.Clear();
					Console.WriteLine("Игра остановлена");

					stop = true;

					return;
				}

				Console.Clear();

				PrintFied(field);
				PrintSnailInformation(ref snails);
			} while (!is_win2 && a.Key == ConsoleKey.Enter);
        }

		static void PrintWinner(List<Snail> snails)
		{
			Console.Clear();

			Console.Write("Победители:");

			for (int i = 0; i < snails.Count; i++)
			{
				if (snails[i]._id != -1)
				{
					SetColorByNumber(0, snails[i]._id);
					Console.Write($" @");
                    SetColorByNumber(0, 15);
                }
			}

			Console.WriteLine();
		}

		

		static void Main(string[] args)
		{
			char[,] field;

			(int, int) param;

			param = GetFieldLengthAndSnailCount();

			List<Snail> Snails = new List<Snail>(param.Item2);

			field = InitField(param.Item2, param.Item1);

			InitSnails(ref Snails, param.Item2);

			PrintFied(field);

			process(ref Snails, ref field, param.Item1);

			if (!stop)
			{
				Console.WriteLine("Нажмите любую клавишу");

				Console.ReadKey();

				PrintWinner(Snails);
			}
		}
	}
}

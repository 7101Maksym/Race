using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Race
{
	internal class Snails_parametrs
	{
		private static List<Snail> _s = new List<Snail>();

		private static int _field_length;

		public Snails_parametrs(int count_snails, int field_length)
		{
			_field_length = field_length;

			for (int i = 0; i < count_snails; i++)
			{
				Snail s = new Snail((Random.Shared.Next() % 6) + 1, i + 1);

				_s.Add(s);
			}
		}

		public int count_snails
		{
			get
			{
				return _s.Count;
			}
			set
			{
			}
		}

        public int[] GetSnailsPositions()
		{
			int[] positions = new int[_s.Count];

			for (int i = 0; i < _s.Count; i++)
			{
				positions[i] = _s[i].pos;
			}

			return positions;
		}

		public int[] GetWinners()
		{
			int n = 0;

			List<int> winners = new List<int>();

			for (int i = 0; i < _s.Count; i++)
			{
				if (_s[i].pos >= _field_length)
				{
					_s[i].pos = _field_length;

                    n++;

					winners.Add(_s[i].id);
				}
			}

			return winners.ToArray();
		}

		public void MoveSnails()
		{
			for (int i = 0; i < _s.Count; i++)
			{
				_s[i].DoStep();
			}
		}
	}
}

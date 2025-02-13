using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Race
{
	public class Snail
	{
		public int _id = -1;

		public char _sumbol = ' ';

		public int _speed;
		public int _position = 0;

		public int pos
		{
			get
			{
				return _position;
			}
			set
			{
				_position += value;
			}
		}

		public Snail(int speed)
		{
			this._speed = speed;
		}
	}
}

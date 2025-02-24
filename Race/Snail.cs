using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Race
{
	public class Snail
	{
		private int _id;

		private int speed;
		private int position = 0;

		public int pos
		{
			get
			{
				return position;
			}
			set
			{
				position = value;
			}
		}

		public int id
		{
			get
			{
				return _id;
			}
			init
			{
				_id = value;
			}
		}

		public int get_speed
		{
			get
			{
				return speed;
			}
		}

		public Snail(int speed, int id)
		{
			this.speed = speed;
			_id = id;
		}

		public void DoStep()
		{
			position += speed;
		}
	}
}

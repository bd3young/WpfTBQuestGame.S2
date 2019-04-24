using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTBQuestGame.S2.Models
{
	public class GameItem
	{
		#region FEILDS
		private int _id;
		private string _name;
		private string _description;
		private int _exp;
		private string _useMessage;

		#endregion

		#region PROPERTIES

		public int Id
		{
			get { return _id; }
			set { _id = value; }
		}

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		public string Description
		{
			get { return _description; }
			set { _description = value; }
		}

		public int Exp
		{
			get { return _exp; }
			set { _exp = value; }
		}

		public string UseMessage
		{
			get { return _useMessage; }
			set { _useMessage = value; }
		}

		#endregion

		#region METHODS

		public virtual string InformationString()
		{
			return $"{Name}: {Description}";
		}

		public string Information
		{
			get
			{
				return InformationString();
			}
		}

		#endregion

		#region CONSTRUCTORS

		public GameItem(int id, string name, string description, int exp, string useMessage = "")
		{
			Id = id;
			Name = name;
			Description = description;
			Exp = exp;
			UseMessage = useMessage;
		}

		#endregion
	}
}

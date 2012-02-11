using System;
using System.Collections.Generic;


namespace DDD.ATM.UI
{
	public class Container
	{
		private Dictionary<Type, object> c_singletonStore = new Dictionary<Type, object>();
		private Dictionary<Type, Tuple<bool,Creator>> c_typeToCreator = new Dictionary<Type, Tuple<bool, Creator>>();


		public delegate object Creator(
			Container subject);


		public void Register<T>(
			Creator creator)
		{
			// Singleton by default
			this.Register<T>(false, creator);
		}


		public void Register<T>(
			bool isTransient, 
			Creator creator)
		{
			this.c_typeToCreator.Add(typeof (T),
				new Tuple<bool, Creator>(isTransient, creator));
		}


		public T Create<T>()
		{
			var _objectInfo = this.c_typeToCreator[typeof (T)];

			if(_objectInfo.Item1)
			{
				if(this.c_singletonStore.ContainsKey(typeof (T)))
				{
					return (T) this.c_singletonStore[typeof (T)];
				}

				var _newObjectSingleton = (T) this.c_typeToCreator[typeof(T)].Item2(this);

				this.c_singletonStore.Add(typeof (T), _newObjectSingleton);

				return _newObjectSingleton;
			}

			return (T)this.c_typeToCreator[typeof(T)].Item2(this);
		}
	}
}

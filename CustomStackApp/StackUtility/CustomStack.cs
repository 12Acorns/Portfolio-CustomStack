namespace CustomStackApp.StackUtility
{
	public class CustomStack
	{
		public CustomStack(int _maxStackSize, StackOptions _stackOptions)
		{
			internalStackAccess = Array.Empty<int>();
			switch (_stackOptions)
			{
				case StackOptions.FixedStack:
					maxStackSize = _maxStackSize;
					stackOption = StackOptions.FixedStack;
					break;
			}
		}
		public CustomStack(int _stackSize)
		{
			stackOption = StackOptions.DynamicStack;
			internalStackAccess = Array.Empty<int>();
			Push(_stackSize);
		}
		public CustomStack()
		{
			stackOption = StackOptions.DynamicStack;
			internalStackAccess = Array.Empty<int>();
		}

		private readonly StackOptions stackOption = StackOptions.DynamicStack;
		private readonly int maxStackSize = 0;

		private int topStackValue => internalStackAccess[^1];
		private int[] internalStackAccess = Array.Empty<int>();

		public void Push(int _value)
		{
			switch (stackOption)
			{
				case StackOptions.FixedStack:
					if (internalStackAccess.Length + 1 > maxStackSize)
					{
						throw new IndexOutOfRangeException("Cannot add more than the maximum stack value");
					}

					int[] _newStack = new int[internalStackAccess.Length + 1];
					internalStackAccess.CopyTo(_newStack, 0);

					_newStack[^1] = _value;
					internalStackAccess = _newStack;
					break;
				case StackOptions.DynamicStack:
					_newStack = new int[internalStackAccess.Length + 1];
					for (int i = 0; i < internalStackAccess.Length; i++)
					{
						internalStackAccess.CopyTo(_newStack, i);
					}
					_newStack[^1] = _value;
					internalStackAccess = _newStack;
					break;
			}
		}
		public bool Empty()
		{
			try
			{
				internalStackAccess = Array.Empty<int>();
				return false;
			}
			catch
			{
				return true;
			}
		}
		public int Pop()
		{
			if (CheckStackAccessable()) throw new NullReferenceException("Cannot pull from empty stack.");
			int _topValue = topStackValue;

			if (Empty()) throw new Exception("Unkown ertror has occoured");

			return _topValue;
		}
		public int Pull()
		{
			return CheckStackAccessable() ?
				throw new NullReferenceException("Cannot pull from empty stack.")
				: topStackValue;
		}
		public bool IsEmpty()
		{
			return !CheckStackAccessable();
		}
		public int Size()
		{
			return internalStackAccess.Length;
		}
		public IEnumerable<int> PrintStack()
		{
			if (CheckStackAccessable()) yield break;

			for (int i = 0; i < internalStackAccess.Length; i++)
			{
				yield return internalStackAccess[i];
			}
		}
		private bool CheckStackAccessable()
		{
			return internalStackAccess.Length < 1;
		}

	}
}

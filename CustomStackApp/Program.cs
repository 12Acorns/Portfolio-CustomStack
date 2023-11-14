using CustomStackApp.StackUtility;

namespace CustomStackApp
{
	internal class Program
	{
		static void Main(string[] args)
		{
			CustomStack _stack = new();
			_stack.Push(1);
			_stack.Push(2);
			Console.WriteLine(_stack.Pull());
			IterateStack(_stack);
			Console.WriteLine(_stack.Pop());
			_stack.Push(1);
			_stack.Push(2);
			IterateStack(_stack);
			Console.WriteLine(_stack.IsEmpty());
			Console.WriteLine(_stack.Empty());
			Console.WriteLine(_stack.IsEmpty());
			_stack = new(10, StackOptions.FixedStack);
			_stack.Push(1);
			_stack.Push(2);
			_stack.Push(3);
			_stack.Push(4);
			_stack.Push(5);
			_stack.Push(5);
			_stack.Push(5);
			_stack.Push(5);
			_stack.Push(5);
			_stack.Push(5);
			Console.WriteLine(_stack.Size());
			IterateStack(_stack);
			Console.ReadLine();
		}
		private static void IterateStack(CustomStack _stack)
		{
			Console.WriteLine("\n");
			foreach(var _value in _stack.PrintStack())
			{
				Console.Write($"{_value},\n");
			}
			Console.WriteLine();
		}
	}
}
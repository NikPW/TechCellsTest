using System;

namespace TechCellsTest {
	class Program {
		static void Main(string[] args) {

			string input;
			ulong number;
			
			while (true) {

				input = Console.ReadLine();
				if (input.ToLower() == "quit") {
					return;
				}
				else {
					bool parsed = ulong.TryParse(input, out number);
					if (!parsed) {
						Console.WriteLine("Invalid number");
					}
				}

				if (number != null) {
					if (!IsPrimeNumber(number)) {
						Console.WriteLine("It is not a prime number!");
					}
					else if (IsMersennePrimeNumber(number)) {
						Console.WriteLine("It is Mersenne prime number!");
					}
					else if (IsPrimeNumber(number)) {
						Console.WriteLine("It is a regular prime number!");
					}
				}
			}
		}

		private static bool IsPrimeNumber(ulong number) {
			bool result = true;
			for (ulong i = 2; i < number; ++i) {
				if (number % i == 0) {
					result = false;
					break;
				}
			}
			return result;
		}
		private static bool IsMersennePrimeNumber(ulong number) {
			bool result = true;
			bool flag = false;
			if (IsPrimeNumber(number)) {
				for (int i = 1; i <= 50; ++i) {
					if ((ulong)MathF.Pow(2, i) - 1 == number || (ulong)MathF.Pow(2, i) + 1 == number) {
						flag = true;
						break;
					}
				}
				if (!flag) {
					result = false;
				}
			}
			else {
				result = false;
			}

			return result;
		}
	}
}
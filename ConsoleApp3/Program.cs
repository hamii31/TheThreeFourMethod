namespace ConsoleApp3
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// given a collection of 3 or more distinct elements
			int[] numbers = new int[]
			{
				1,2,3,4,5,6
			};

			int n = numbers.Length;

			// that is shuffled in a random manner
			Random rng = new Random();
			while (n > 1)
			{
				int k = rng.Next(n--);
				int temp = numbers[n];
				numbers[n] = numbers[k];
				numbers[k] = temp;
			}

			n = 0;

			Queue<int> queueA = new Queue<int>(); // takes three elements, enqueues them to queueB for safekeeping
			Queue<int> queueB = new Queue<int>(); // feeds queueA with the elements it stores 

			foreach (var item in numbers)
			{
				queueB.Enqueue(item); // initial feeding of queueB with the original shuffled elements
			}

			// if the randomized collection is then looped through three elements at a time, as many times as the total length of the collection,
			// the mock collection will always be the same on the next loop
			while (n < numbers.Length)
			{

				int repeater = 0;
				for (int i = 0; i < numbers.Length; i++)
				{
					if (repeater == 3) // on every fourth rotation the for loop is broken, queueA is fed with only three elements every loop
					{
						break;
					}
					queueA.Enqueue(queueB.Dequeue());
					repeater++;
				}
				foreach (var item in queueA)
				{
					queueB.Enqueue(item); // queueA enqueues its three elements to queueB which will feed them back to queueA 
				}
				n++;
			}

			// the first elements are the same
			Console.WriteLine(numbers[0]);
			Console.WriteLine(queueA.Peek());

			List<int> displayNumbersInQueue = new List<int>();

			foreach (var item in queueA)
			{
				displayNumbersInQueue.Add(item);
			}

			for (int i = 0; i < numbers.Length; i++)
			{
				Console.Write(numbers[i]);
				Console.WriteLine(displayNumbersInQueue[i]);
			}
		}
	}
}
using System.Linq;

int kitsCount;
string[] input;
int n;
int m;
List<int> sits;
//int[] sits;

int option;
int p;

int i;

kitsCount = int.Parse((Console.ReadLine() ?? "_"));

for (int _ = 0; _ < kitsCount; _++)
{
    Console.ReadLine();

    input = (Console.ReadLine() ?? "_").Split(' ');
    n = int.Parse(input[0]);
    m = int.Parse(input[1]);
    //sits = new int[2 * m];
    sits = new List<int>(2 * m);

    for (int __ = 0; __ < m; __++)
    {
        input = (Console.ReadLine() ?? "_").Split(' ');
        option = int.Parse(input[0]);
        p = 0;
        if (input.Length > 1)
            p = int.Parse(input[1]);

        if (option == 1)
        {
            if (sits.Contains(p) == false)
            {
                sits.Add(p);
                Console.WriteLine("SUCCESS");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
        }
        else if (option == 2)
        {
            if (sits.Contains(p) == true)
            {
                sits.Remove(p);
                Console.WriteLine("SUCCESS");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
        }
        else if (option == 3)
        {
            /*
            for (i = 0; i < 2 * n; i += 2)
            {
                if (sits[i] == false && sits[i + 1] == false)
                    break;
            }
            if (i < 2 * n)
            {
                sits[i] = true;
                sits[i + 1] = true;
                Console.WriteLine($"SUCCESS {i+1}-{i+2}");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            */
            i = 0;  // last occupied sit. one-based (not zero-based). Initially it's zero
            //foreach (int sit in sits)
            foreach (int sit in sits.OrderBy(s => s))
            {
                //if (sit - i > 2 && (i + 1) % 2 == 1)
                if (sit - i > 2)
                {
                    if ((i + 1) % 2 == 1)
                        break;
                    else if (sit - i > 3)
                    {
                        i += 1;
                        break;
                    }
                }
                i = sit;
            }
            if (2 * n - i >= 2)
            {
                if (i % 2 == 1)
                    i++;
                sits.Add(i + 1);
                sits.Add(i + 2);
                Console.WriteLine($"SUCCESS {i+1}-{i+2}");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
        }
    }

    Console.WriteLine();
}
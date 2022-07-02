
int kitsCount;
string[] input;
int n;
int m;
bool[] sits;

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
    sits = new bool[2 * n];

    for (int __ = 0; __ < m; __++)
    {
        input = (Console.ReadLine() ?? "_").Split(' ');
        option = int.Parse(input[0]);
        p = 0;
        if (input.Length > 1)
            p = int.Parse(input[1]);

        if (option == 1)
        {
            if (sits[p - 1] == false)
            {
                sits[p - 1] = true;
                Console.WriteLine("SUCCESS");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
        }
        else if (option == 2)
        {
            if (sits[p - 1] == true)
            {
                sits[p - 1] = false;
                Console.WriteLine("SUCCESS");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
        }
        else if (option == 3)
        {
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
        }
    }

    Console.WriteLine();
}
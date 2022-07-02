using System.Linq;

int kitsCount;
string[] input;
int n;
int m;
bool[] sits;

int option;
int p;

int i;

kitsCount = int.Parse((Console.ReadLine() ?? "_"));
sits = new bool[600_000];

for (int _ = 0; _ < kitsCount; _++)
{
    Console.ReadLine();

    input = (Console.ReadLine() ?? "_").Split(' ');
    n = int.Parse(input[0]);
    m = int.Parse(input[1]);
    Array.Clear(sits);

    for (int __ = 0; __ < m; __++)
    {
                /*
                var tmp = Console.Out;
                Console.SetOut(Console.Error);
                Console.Write(".");
                Console.SetOut(tmp);
                */
        input = (Console.ReadLine() ?? "_").Split(' ');
        option = int.Parse(input[0]);
        p = 0;
        if (input.Length > 1)
        {
            p = int.Parse(input[1]);
            p -= 1;  // to be zero-based
        }

        if (option == 1)
        {
            TakeSit();
        }
        else if (option == 2)
        {
            ExposeSit();
        }
        else if (option == 3)
        {
            TakeKupe();
        }
    }

    Console.WriteLine();



    void TakeSit()
    {
        if (sits[p] == false)
        {
            sits[p] = true;
            Console.WriteLine("SUCCESS");
        }
        else
        {
            Console.WriteLine("FAIL");
        }
    }
    void ExposeSit()
    {
        if (sits[p] == true)
        {
            sits[p] = false;
            Console.WriteLine("SUCCESS");
        }
        else
        {
            Console.WriteLine("FAIL");
        }
    }
    void TakeKupe()
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
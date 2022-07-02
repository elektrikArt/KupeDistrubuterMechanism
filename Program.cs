using System.IO;
using System.Linq;

string[] _stdin = Console.In.ReadToEnd().Split('\n');
int _i = -1;

int kitsCount;
string[] input;
int n;
int m;
bool[] sits;
int nextFreeKupe = 0;  // zero-based

int option;
int p;

int i;

//kitsCount = int.Parse((Console.ReadLine() ?? "_"));
kitsCount = int.Parse(ReadLine());
sits = new bool[200_000];
i = 0;

for (int _ = 0; _ < kitsCount; _++)
{
    //Console.ReadLine();
    ReadLine();

    //input = (Console.ReadLine() ?? "_").Split(' ');
    input = (ReadLine()).Split(' ');
    n = int.Parse(input[0]);
    m = int.Parse(input[1]);
    Array.Clear(sits);
    nextFreeKupe = 0;

    for (int __ = 0; __ < m; __++)
    {
                /*
                var tmp = Console.Out;
                Console.SetOut(Console.Error);
                Console.Write(".");
                Console.SetOut(tmp);
                */
        //input = (Console.ReadLine() ?? "_").Split(' ');
        input = (ReadLine()).Split(' ');
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

            if ((nextFreeKupe == p || nextFreeKupe + 1 == p) && nextFreeKupe != -1)
                FindFreeKupe(p);
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

            //FindFreeKupe(p);
            if ((nextFreeKupe == -1 || p < nextFreeKupe) && IsFreeKupe(p))
            {
                if (p % 2 == 0)
                    nextFreeKupe = p;
                else
                    nextFreeKupe = p - 1;
            }
        }
        else
        {
            Console.WriteLine("FAIL");
        }
    }
    void TakeKupe()
    {
        if (nextFreeKupe != -1)
        {
            sits[nextFreeKupe] = true;
            sits[nextFreeKupe + 1] = true;
            Console.WriteLine($"SUCCESS {nextFreeKupe+1}-{nextFreeKupe+2}");
            FindFreeKupe(nextFreeKupe);
        }
        else
        {
            Console.WriteLine("FAIL");
        }
    }
    void FindFreeKupe(int p)
    {
        for (i = p - p % 2; i < 2 * n; i += 2)
        {
            if (sits[i] == false && sits[i + 1] == false)
                break;
        }
        if (i < 2 * n)
        {
            nextFreeKupe = i;
        }
        else
            nextFreeKupe = -1;
    }
    bool IsFreeKupe(int p)
    {
        if (p < 0 || p >= sits.Length)
            return false;
        if (p % 2 == 0)
            return sits[p] == false && sits[p + 1] == false;
        else
            return sits[p - 1] == false && sits[p] == false;
    }
}

string ReadLine()
{
    _i++;
    return _stdin[_i];
}
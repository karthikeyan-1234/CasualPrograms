// See https://aka.ms/new-console-template for more information

await MakeBreakFast();
await MakeBreakFast2();

async Task MakeBreakFast()
{
    Egg egg = new Egg();
    Chicken chicken = new Chicken();

    Console.WriteLine("Beginning the process..");


    Task fryEggTask = egg.FryEggs(10);
    Task fryChickenTask = chicken.FryChicken(10);

    List<Task> tasks = new List<Task>() { fryEggTask, fryChickenTask };

    var startTime = DateTime.Now;

    while (tasks.Count > 0)
    {
        var completedTask = await Task.WhenAny(tasks);

        if (completedTask == fryEggTask)
            Console.WriteLine("Eggs are Fried");

        if (completedTask == fryChickenTask)
            Console.WriteLine("Chicken are Fried");

        tasks.Remove(completedTask);
    }

    var endTime = DateTime.Now;

    Console.WriteLine("Time taken for all tasks : {0}", endTime - startTime);

    Console.ReadKey();
}

async Task MakeBreakFast2()
{
    Egg egg = new Egg();
    Chicken chicken = new Chicken();

    Console.WriteLine("Beginning the process...");

    var startTime = DateTime.Now;

    Console.WriteLine("Frying eggs..");
    await egg.FryEggs(10);
    Console.WriteLine("Eggs are fried..!!");

    Console.WriteLine("Frying chicken pieces..");
    await chicken.FryChicken(10);
    Console.WriteLine("Chicken pieces are fried..!!");

    var endTime = DateTime.Now;

    Console.WriteLine("Time taken for all tasks : {0}", endTime - startTime);

    Console.ReadKey();
}


class Egg
{
    public async Task FryEggs(int noOfEggs)
    {
        Console.WriteLine("Eggs are frying...");

        for(int i = 0; i < noOfEggs; i++)
        {
            await Task.Delay(100);
            Console.WriteLine("Egg {0} is done", i + 1);
        }

    }
}

class Chicken
{
    public async Task FryChicken(int noOfPieces)
    {
        Console.WriteLine("Chicken pieces are frying...");

        for(int i =0; i< noOfPieces; i++)
        {
            await Task.Delay(100);
            Console.WriteLine("Chicken piece {0} is done", i + 1);
        }

    }
}

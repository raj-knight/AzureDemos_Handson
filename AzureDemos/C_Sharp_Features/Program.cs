
using C_Sharp_Features;

Console.WriteLine("C# Demos");

//  Generics_Demo();

Parallel_Demo_1();


void Parallel_Demo_1()
{
    Parallel_Demo parallel_Demo = new Parallel_Demo();
    
    Console.WriteLine( parallel_Demo.For_Loop() );
    Console.WriteLine( parallel_Demo.For_Loop_Parallel() );
    Console.WriteLine(parallel_Demo.For_Loop_Parallel_Optimized());
}


static void Generics_Demo()
{
    var outputString = GenericsMethod_Demo.Reverse<string>(new string[] { "A", "B", "C", "D", "E" });
    var outputInt = GenericsMethod_Demo.Reverse<int>(new int[] { 1, 2, 3, 4, 5 });


    Console.WriteLine(string.Join(", ", outputString));
    Console.WriteLine(string.Join(", ", outputInt));


    outputInt = GenericsClass_Demo<int>.Reverse(new int[] { 1, 2, 3, 4, 5 });
    outputString = GenericsClass_Demo<string>.Reverse(new string[] { "A", "B", "C", "D", "E" });

    Console.WriteLine(string.Join(", ", outputString));
    Console.WriteLine(string.Join(", ", outputInt));

    KeyValue<string, string> keys = new KeyValue<string, string>();
    keys.Key = "babu";
    keys.Value = "Good";

    KeyValue<int, string> key = new KeyValue<int, string>();
    key.Key = 1;
    key.Value = "Good";

}
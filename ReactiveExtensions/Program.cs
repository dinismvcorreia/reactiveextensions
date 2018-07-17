namespace ReactiveExtensions
{
    using System;
    using System.Reactive.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var p = new Producer();

            p.TitlePublished.FirstAsync()
                .Subscribe(ta => Console.WriteLine("FIRST: " + ta.Title));

            p.TitlePublished.Where(ta => ta.Title.StartsWith("0"))
                .Subscribe(ta => Console.WriteLine("SPECIAL: " + ta.Title));

            p.TitlePublished
                .Subscribe(ta => Console.WriteLine(ta.Title));

            Console.ReadKey();

            p.Dispose();
        }
    }
}
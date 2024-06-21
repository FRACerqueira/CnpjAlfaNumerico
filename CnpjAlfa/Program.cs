using System.Diagnostics;

namespace CnpjAlfa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sw = new Stopwatch();
            var before2 = GC.CollectionCount(2);
            var before1 = GC.CollectionCount(1);
            var before0 = GC.CollectionCount(0);

            sw.Start();
            for (int i = 0; i < 1_000_000; i++)
            {
                var aux0 = new Cnpj("abcdefgihijk56").ToString();
                var aux1 = new Cnpj("ab.cde.fgi/hijk-56").ToString();
                var aux2 = new Cnpj("AB.CDE.FGI/HIJK-56").ToString();
            }
            sw.Stop();

            Console.WriteLine($"Tempo total 3.000.000 de validações: {sw.ElapsedMilliseconds}ms");
            Console.WriteLine($"GC Gen #2  : {GC.CollectionCount(2) - before2}");
            Console.WriteLine($"GC Gen #1  : {GC.CollectionCount(1) - before1}");
            Console.WriteLine($"GC Gen #0  : {GC.CollectionCount(0) - before0}");
            Console.WriteLine("");

            Cnpj oldcnpj = "94646426000160";
            Cnpj newcnpj = "ABCDEFGIHIJK56";
            var fmtcnpj = new Cnpj("AB.CDE.FGI/HIJK-56");
            var fmtcnpjerr = new Cnpj("ab.cde.fgi/hijk-56");

            Console.WriteLine("Isvalid = {0}, oldcnpj.ToString() = {1} ", oldcnpj.IsValid, oldcnpj.ToString());
            Console.WriteLine("Isvalid = {0}, newcnpj.ToString() = {1} ", newcnpj.IsValid, newcnpj.ToString());
            Console.WriteLine("Isvalid = {0}, fmtcnpj.ToString() = {1} ", fmtcnpj.IsValid, fmtcnpj.ToString());
            Console.WriteLine("Isvalid = {0}, fmtcnpjerr.ToString() = {1} ", fmtcnpjerr.IsValid, fmtcnpjerr.ToString());

        }
    }
}

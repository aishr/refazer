using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using IronPython.Compiler.Ast;
using Microsoft.ProgramSynthesis;
using Microsoft.ProgramSynthesis.AST;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Refazer.Core;
using Tutor;

namespace Refazer.Experiments
{
    class Program
    {
        static void Main(string[] args)
        {
            var before = "a or (a or b)";
            var after = "a or b";
            var examples = new List<Tuple<string, string>>() {Tuple.Create(before, after)};
            var refazer = new Refazer4Python();
            var transformation = refazer.LearnTransformations(examples.ToList()).First();

            foreach (var mistake in examples)
            {
                var output = refazer.Apply(transformation, mistake.Item1);
                Console.Out.WriteLine("");
                var isFixed = false;
                foreach (var newCode in output)
                {
                    var unparser = new Unparser();
                    isFixed = mistake.Item2.Equals(newCode);
                    if (isFixed)
                        break;
                }
                Console.WriteLine("Before: " + mistake.Item1);
                Console.WriteLine("Expected After: " + mistake.Item2);
                Console.WriteLine("Actual After: " + output.FirstOrDefault());
                Console.WriteLine(isFixed);
            }
        }
    }
}
